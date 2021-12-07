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

namespace Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void Automatic_CheckedChanged(object sender, EventArgs e)
        {
            if (Automatic.Checked == false)
            {
                IPAdd.Text = string.Empty;
                Port.Text = string.Empty;
                IPAdd.ReadOnly = false;
                Port.ReadOnly = false;
                IPAdd.ForeColor = Color.Black;
                Port.ForeColor = Color.Black;
            }
            else
            {
                IPAdd.Text = "127.0.0.1";
                Port.Text = "8080";
                IPAdd.ReadOnly = true;
                Port.ReadOnly = true;
            }
        }

        private void IPAdd_Enter(object sender, EventArgs e)
        {
            if (IPAdd.Text != "Input IPAdd...") return;
            IPAdd.Text = "";
            IPAdd.ForeColor = Color.Black;
        }

        private void IPAdd_Leave(object sender, EventArgs e)
        {
            if (IPAdd.Text != "") return;
            IPAdd.Text = "Input IPAdd...";
            IPAdd.ForeColor = Color.Gray;
        }

        private void Port_Enter(object sender, EventArgs e)
        {
            if (Port.Text != "Input Port...") return;
            Port.Text = "";
            Port.ForeColor = Color.Black;
        }

        private void Port_Leave(object sender, EventArgs e)
        {
            if (Port.Text != "") return;
            Port.Text = "Input Port...";
            Port.ForeColor = Color.Gray;
        }

        private bool IsIPaddr()
        {
            Match collection = Regex.Match(IPAdd.Text, @"\b((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)(\.|$)){4}\b");
            if (collection.Value.Length <= 0) return false;
            return true;
        }

        private bool IsPort()
        {
            Match collection = Regex.Match(Port.Text, @"^([0-9]{1,4}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-5])$");
            if (collection.Value.Length <= 0) return false;
            return true;
        }

        private bool checkInputIsEmpty()
        {
            if (string.IsNullOrEmpty(IPAdd.Text) || string.IsNullOrWhiteSpace(IPAdd.Text)) return false;
            if (string.IsNullOrEmpty(Port.Text) || string.IsNullOrWhiteSpace(Port.Text)) return false;
            return true;
        }

        private UDP_client client = null;
        private void Connect_Click(object sender, EventArgs e)
        {
            if (checkInputIsEmpty() == false)
            {
                MessageBox.Show("IP address or Port can not be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (IsIPaddr() == false)
            {
                MessageBox.Show("IP address is invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (IsPort() == false)
            {
                MessageBox.Show("Port is invalid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (client == null)
                {
                    client = new UDP_client(IPAdd.Text, Int32.Parse(Port.Text));
                    if (client.run())
                    {
                        connect.Enabled = false;
                        disconnect.Enabled = true;
                        IPAdd.Enabled = false;
                        Port.Enabled = false;
                        Hide();
                        SearchForm searchForm = new SearchForm();
                        searchForm.cli = client;
                        searchForm.connectForm = this;
                        searchForm.Show();
                    }
                    else
                    {
                        client = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            client.disconnect();
            
            MessageBox.Show("Disconnected to server successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            client = null;
            connect.Enabled = true;
            disconnect.Enabled = false;
            IPAdd.ReadOnly = false;
            Port.ReadOnly = false;
            Automatic.Enabled = true;
            Automatic.Checked = false;
            IPAdd.Text = "Input IPAdd...";
            IPAdd.ForeColor = Color.Gray;
            Port.Text = "Input Port...";
            Port.ForeColor = Color.Gray;
            IPAdd.Enabled = true;
            Port.Enabled = true;
        }

    }
}
