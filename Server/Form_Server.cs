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
using System.Text.RegularExpressions;
namespace Server
{

    public partial class Form_Server : Form
    {
        const string ip = "Input address";
        const string port = "Input port";

        private UDP_Server.UDPServer server = null;
        public Form_Server()
        {
            InitializeComponent();
        }

        private void IPAddress_TextChanged(object sender, EventArgs e)
        {
            if (ipAddress.Text != ip)
            {
                ipAddress.ForeColor = Color.Black;
            }

        }

        private void IPAddress_Enter(object sender, EventArgs e)
        {
            if (ipAddress.Text != ip)
                return;
            ipAddress.Text = "";
            ipAddress.ForeColor = Color.Black;

        }

        private void IPAddress_Leave(object sender, EventArgs e)
        {
            if (ipAddress.Text == "")
            {
                ipAddress.Text = ip;
                ipAddress.ForeColor = Color.Gray;
            }
        }

        private void Port_TextChanged(object sender, EventArgs e)
        {
            if (Port.Text != port)
                Port.ForeColor = Color.Black;
        }

        private void Port_Enter(object sender, EventArgs e)
        {
            if (Port.Text != port)
                return;
            Port.Text = "";
            Port.ForeColor = Color.Black;
        }

        private void Port_Leave(object sender, EventArgs e)
        {
            if (Port.Text == "")
            {
                Port.Text = port;
                Port.ForeColor = Color.Gray;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                ipAddress.Text = ip;
                ipAddress.ForeColor = Color.Gray;
                Port.ForeColor = Color.Gray;
                Port.Text = port;
                ipAddress.ReadOnly = false;
                Port.ReadOnly = false;
            }
            else
            {
                ipAddress.ForeColor = Color.Black;
                Port.ForeColor = Color.Black;
                ipAddress.Text = "127.0.0.1";
                Port.Text = "8080";
                ipAddress.ReadOnly = true;
                Port.ReadOnly = true;
            }


        }

        private bool CheckIP()
        {
            Match collection = Regex.Match(ipAddress.Text, @"\b((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)(\.|$)){4}\b");
            if (collection.Value.Length <= 0) return false;
            return true;
        }
        private bool CheckPort()
        {
            Match collection = Regex.Match(Port.Text, @"^([0-9]{1,4}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-5])$");
            if (collection.Value.Length <= 0) return false;
            return true;
        }
        private bool checkInputIsEmpty()
        {
            if (string.IsNullOrEmpty(ipAddress.Text) || string.IsNullOrWhiteSpace(ipAddress.Text)) return false; // ip
            if (string.IsNullOrEmpty(Port.Text) || string.IsNullOrWhiteSpace(Port.Text)) return false; // port
            return true;
        }

        private void Run_Click(object sender, EventArgs e)
        {
            if (checkInputIsEmpty() == false)
            {
                MessageBox.Show("IP address or Port can not be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CheckIP() == false)
            {
                MessageBox.Show("IP address is invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (CheckPort() == false)
            {
                MessageBox.Show("Port is invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            server = new UDP_Server.UDPServer(IPAddress.Parse(ipAddress.Text), Int32.Parse(Port.Text.ToString()), 8096,
                clientStatus, consoleServer);
            server.run();
            addPlaceToolStripMenuItem.Enabled = true;
            Run.Enabled = false;
            Stop.Enabled = true;
            Restart.Enabled = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thông tin về giao thức UDP");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void addPlaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPlaceForm addPlace_Form = new AddPlaceForm();
            addPlace_Form.ser = server;
            addPlace_Form.Show();
        }

        private void Form_Server_Load(object sender, EventArgs e)
        {
            clientStatus.ReadOnly = true;
            consoleServer.ReadOnly = true;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                server.Stop();
                Stop.Enabled = false;
                Run.Enabled = true;
                Restart.Enabled=false;
            }
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            if(server != null)
            {
                Stop_Click(sender, e);
                Run_Click(sender, e);
            }
        }
    }
}
