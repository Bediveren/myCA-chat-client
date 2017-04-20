using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    public class CommandHandler
    {
        private const string CommandDisconnect = "/disconnect";
        private const string CommandSetName = "/set name";
        private const string CommandClientList = "/set client list";

        FormChatWindow chatWindow { get; set; }
        protected ServerHandler serverConnection;
        public CommandHandler(ServerHandler serverConnection, FormChatWindow chatWindow)
        {
            this.serverConnection = serverConnection;
            this.chatWindow = chatWindow;
            chatWindow.EventClientConnect += OnEventClientConnect;
            chatWindow.EventClientDisconnect += OnEventClientDisconnect;
            chatWindow.EventClientSendMessage += OnEvenClientSendMessage;

            serverConnection.EventClientRecieveMessage += OnEventClientRecieveMessage;
           

        }

        public virtual void SendMessageToServer(string message)
        {
            try
            {
                serverConnection.binaryWriter.Write(message);
                serverConnection.binaryWriter.Flush();
            }
            catch(Exception ex)
            { }
        }

        public virtual void OnEvenClientSendMessage(object source, ServerMessageEventArgs args)
        {
            SendMessageToServer(args.Message);
        }

        public virtual void OnEventClientConnect(object source, ServerMessageEventArgs args)
        {
            //send to a list of clients***
            SendMessageToServer(CommandSetName + chatWindow.clientName);
        }

        public virtual void OnEventClientDisconnect(object source, ServerMessageEventArgs args)
        {
            SendMessageToServer(CommandDisconnect);
            serverConnection.CloseConnection();
            chatWindow.Close();
            chatWindow.parentForm.Show();
        }

        public virtual void OnEventClientRecieveMessage(object source, ServerMessageEventArgs args)
        {
            if (args.Message.StartsWith(CommandClientList))
            {
                chatWindow.Invoke(new Action<string>(chatWindow.FillClientList), args.Message.Substring(CommandClientList.Length).Trim());    
            }
            else
            {
                chatWindow.Invoke(new Action<string>(chatWindow.ConcatinateChatTextBox), args.Message);
            }
            serverConnection.OnEventClientShowMessage(args);
        }
    }
}
