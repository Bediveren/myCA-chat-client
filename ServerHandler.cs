using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ChatClient
{
    public class ServerMessageEventArgs : EventArgs
    {
        public string Message { get; set; }
    }

    //temp acces to window
    public class ServerHandler
    {
        
        public event EventHandler<ServerMessageEventArgs> EventClientRecieveMessage;
        public event EventHandler<ServerMessageEventArgs> EventClientShowMessage;
        public TcpClient server;
        public NetworkStream netStream;
        public BinaryReader binaryReader;
        public BinaryWriter binaryWriter;
        public CommandHandler commandHandler;
        public bool serverOnline = false;
        public FormChatWindow chatWindow;



        public ServerHandler(TcpClient server, FormChatWindow chatWindow)                                                                                         // Establishing connection, listening
        {
            
            if (server != null)
            {
                try
                {
                    SetupListening(server, chatWindow);
                }
                catch (Exception ex)
                { }
            }
        }

        public void Listen()                                                                                   // Listening for clinet input
        {

            if (server != null)
            {
                serverOnline = true;
                #region Listening
                while (serverOnline)
                {
                    try
                    {
                        
                        String messageRecieved = binaryReader.ReadString();
                        OnEventClientRecieveMessage(new ServerMessageEventArgs() { Message = messageRecieved });
                        

                    }
                    catch (IOException ex)
                    {
                        // No input recieved
                    }
                    // Reducing workload
                    Thread.Sleep(10);

                }
                #endregion


            }

        }

        private void SetupListening(TcpClient server, FormChatWindow chatWindow)
        {

            this.server = server;
            try
            {
                netStream = server.GetStream();
                binaryReader = new BinaryReader(netStream, Encoding.UTF8);
                binaryWriter = new BinaryWriter(netStream, Encoding.UTF8);
            }
            catch (IOException ex)
            {
                ex.Data.Add("Description", "Error initializing Binary IO");
                throw ex;
            }
            catch (Exception ex)
            {
                ex.Data.Add("Description", "Unknown error setting up listening for server");
                throw ex;
            }
           // eventSystem = new EventSystem();
            this.chatWindow = chatWindow;
            commandHandler = new CommandHandler(this, this.chatWindow);
        }
        public virtual void CloseConnection()
        {
            //throw away from list
            serverOnline = false;
            binaryWriter.Close();
            binaryReader.Close();
            netStream.Close();
            server.Close();
        }

        public virtual void OnEventClientShowMessage(ServerMessageEventArgs args)
        {
            if (EventClientShowMessage != null)
            {
                EventClientShowMessage(this, args);
            }
        }
       
        public virtual void OnEventClientRecieveMessage(ServerMessageEventArgs args)
        {
            if (EventClientRecieveMessage != null)
            {
                EventClientRecieveMessage(this, args);
            }
        }



    }
}
