 using SimpleTCP;
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

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SimpleTcpClient client;
        private void txtConnect_Click(object sender, EventArgs e)
        {
            txtConnect.Enabled = true;
            client.Connect(txtHost2.Text, int.Parse(txtPort2.Text));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            client.DataReceived += Client_DataReceived;
        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            txtDisplay.Invoke((MethodInvoker)delegate ()
            {
                txtDisplay.Text += e.MessageString;
               // e.ReplyLine(string.Format("You said: {0}", e.MessageString));
            });
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            client.WriteLineAndGetReply(txtMess.Text,TimeSpan.FromSeconds(3));
        }
    }
}
