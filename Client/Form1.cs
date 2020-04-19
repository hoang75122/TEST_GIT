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

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SimpleTcpServer Server;

        private void Form1_Load(object sender, EventArgs e)
        {
            Server = new SimpleTcpServer();
            Server.Delimiter = 0x13;//enter
            Server.StringEncoder = Encoding.UTF8;
            Server.DataReceived += Server_DataReceived;
        }

        private void Server_DataReceived(object sender, SimpleTCP.Message e)
        {
            txtDisplay.Invoke((MethodInvoker)delegate () 
            {
                
                txtDisplay.Text += e.MessageString;
                if (e.MessageString.Contains("0"))
                    e.ReplyLine("You said: Zero \n");
                else if (e.MessageString.Contains("1"))
                    e.ReplyLine("You said: One \n");
                else if (e.MessageString.Contains("2"))
                    e.ReplyLine("You said: Two \n");
                else if (e.MessageString.Contains("3"))
                    e.ReplyLine("You said: Three \n");
                else if (e.MessageString.Contains("4"))
                    e.ReplyLine("You said: Four \n");
                else if (e.MessageString.Contains("5"))
                    e.ReplyLine("You said: Five \n");
                else if (e.MessageString.Contains("6"))
                    e.ReplyLine("You said: Six \n");
                else if (e.MessageString.Contains("7"))
                    e.ReplyLine("You said: Seven \n");
                else if (e.MessageString.Contains("8"))
                    e.ReplyLine("You said: Eight \n");
                else if (e.MessageString.Contains("9"))
                    e.ReplyLine("You said: Nine \n");
                else if (e.MessageString.Contains("End"))
                    e.ReplyLine("You said: Bye \n");
                else
                    e.ReplyLine("You said : Nhap lai!");
            });
        }

        private void txtStart_Click(object sender, EventArgs e)
        {
            IPAddress ip;
            ip = IPAddress.Parse(txtHost.Text);
            Server.Start(ip, Convert.ToInt32(txtPort.Text));// you đóng cái dòng qq này me thay no k co nen me dong vao
            txtDisplay.Text += "Server starting...";
            
        }

        private void txtStop_Click(object sender, EventArgs e)
        {
            if (Server.IsStarted)
                Server.Stop();
        }
    }
}
