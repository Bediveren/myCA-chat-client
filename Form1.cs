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
using System.IO;
using System.Threading;

namespace ChatClient
{
    public partial class Form1 : Form
    {
        TcpClient tcpServer;
        public Form1()
        {
            InitializeComponent();
            portBox.Text = "2000";
            serverIPBox.Text = "127.0.0.1";
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void serverIPBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void portBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            if (AreMessageBoxesFilledCorrectly())
            {
                tcpServer = new TcpClient();
                try
                {
                    tcpServer.Connect(serverIPBox.Text, Int32.Parse(portBox.Text));

                    FormChatWindow chatWindow = new FormChatWindow(this, tcpServer, nameBox.Text);

                    this.Hide();
                    chatWindow.ShowDialog();
                    //   chatWindow.StartListening();



                }
                catch (SocketException ex)
                {
                    MessageBox.Show("Failed to connect to server");
                }
                // tcpServer.Close();
            }
            else
            {
                MessageBox.Show("Not all fields are filled properly");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private bool AreMessageBoxesFilledCorrectly()
        {
            if (portBox.Text != "" && serverIPBox.Text != "" && nameBox.Text != "" && nameBox.Text.Length >= 2 && nameBox.Text.Length <= 16)
            { return true; }
            return false;

        }

    }
}
