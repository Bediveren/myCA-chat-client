using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ChatClient
{
    public partial class FormChatWindow : Form
    {
        public Form parentForm;

        public event EventHandler<ServerMessageEventArgs> EventClientSendMessage;
        public event EventHandler<ServerMessageEventArgs> EventClientConnect;
        public event EventHandler<ServerMessageEventArgs> EventClientDisconnect;
        public ServerHandler serverHandler;
        public string clientName;

        public FormChatWindow(Form parentForm, TcpClient server, string clientName)
        {
            InitializeComponent();

            this.clientName = clientName;
            this.parentForm = parentForm;
            this.serverHandler = new ServerHandler(server, this);
            OnEventClientConnect(new ServerMessageEventArgs());
            chatTextBox.ReadOnly = true;           
        }



        public void StartListening()
        {
            //serverHandler.EventClientShowMessage += OnEventClientShowMessage;
            new Thread(serverHandler.Listen).Start();
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (chatMessageBox.Text != "")
            {
                OnEvenClientSendMessage(new ServerMessageEventArgs() { Message = chatMessageBox.Text });
                chatMessageBox.Text = "";
            }
        }

        public void disconnectBtn_Click(object sender, EventArgs e)
        {
            OnEventClientDisconnect(new ServerMessageEventArgs());
        }

        public string GetChatMessageBox()
        {
            return chatMessageBox.Text;
        }
        public void ConcatinateChatTextBox(string newText = "")
        {
            chatTextBox.Text = chatTextBox.Text + newText + "\n";
        }
        public void FillClientList(string list)
        {
            clientListTextBox.Text = list;
        }

        private void chatMessageBox_TextChanged(object sender, EventArgs e)
        {
           // serverHandler.eventSystem.OnEvenClientSendMessage(new ServerCommandEventArgs() { Message = chatMessageBox.Text });
        }

        private void FormChatWindow_Shown(object sender, EventArgs e)
        {
            StartListening();
        }

        private void OnEventClientShowMessage(object sender, ServerMessageEventArgs args)
        {
            chatTextBox.Text += args.Message;
        }

        public virtual void OnEvenClientSendMessage(ServerMessageEventArgs args)
        {
            if (EventClientSendMessage != null)
            {
                EventClientSendMessage(this, args);
            }
        }
        public virtual void OnEventClientConnect(ServerMessageEventArgs args)
        {
            if (EventClientConnect != null)
            {
                EventClientConnect(this, args);
            }
        }
        public virtual void OnEventClientDisconnect(ServerMessageEventArgs args)
        {
            if (EventClientDisconnect != null)
            {
                EventClientDisconnect(this, args);
            }
        }

        private void chatMessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                sendBtn_Click(this, EventArgs.Empty);
            }
        }

        private void chatTextBox_TextChanged(object sender, EventArgs e)
        {
            chatTextBox.SelectionStart = chatTextBox.Text.Length;
            chatTextBox.ScrollToCaret();    
        }



        private void FormChatWindow_Load(object sender, EventArgs e)
        {

        }

        private void FormChatWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            serverHandler.commandHandler.OnEventClientDisconnect(this, new ServerMessageEventArgs());
            
        }
    }
}
