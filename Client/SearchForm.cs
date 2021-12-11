using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System;

namespace Client
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }
        private void diadiem_Enter(object sender, System.EventArgs e)
        {
            if (diadiem.Text != "Nhập địa điểm du lịch") return;
            diadiem.Text = "";
            diadiem.ForeColor = Color.Black;
        }
        private void diadiem_Leave(object sender, System.EventArgs e)
        {
            if (diadiem.Text != "") return;
            diadiem.Text = "Nhập địa điểm du lịch";
            diadiem.ForeColor = Color.Gray;
        }

        private UDP_client client = null;
        private Form connect = null;
        public UDP_client cli
        {
            set { client = value; }
        }
        public Form connectForm
        {
            set { connect = value; }
        }

        private void SearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            connect.Show();
        }

        private void SearchForm_Load(object sender, System.EventArgs e)
        {
            client.requestOption_Provinces();
            client.ReceiveResponse();

            foreach (var province in client.provinces)
            {
                optionProvince.Items.Add(province.Key);
            }
            filterBtn_Click(sender, e);
        }

        private void picturesearchBox_Click(object sender, System.EventArgs e)
        {
            string tourist_area = diadiem.Text;

            client.requestPlacesList_Search(tourist_area);
            client.ReceiveResponse();

            dataTable.Items.Clear();

            string[] Item = new string[5];
            ListViewItem LItems;
            foreach (var item in client.places)
            {
                JObject itemObj = JObject.Parse(item.ToString());

                Item[0] = itemObj["code"].ToString();
                Item[1] = itemObj["name"].ToString();
                Item[2] = itemObj["coord"].ToString();
                Item[3] = itemObj["description"].ToString();

                // add new row
                LItems = new ListViewItem(Item);
                LItems.ForeColor = System.Drawing.Color.DarkBlue;
                dataTable.Items.Add(LItems);
            }
        }

        private void optionProvince_TextChanged(object sender, System.EventArgs e)
        {
            optionDistrict.Items.Clear();
            optionDistrict.Text = "";
            if (optionProvince.Text == "" || !client.provinces.ContainsKey(optionProvince.Text)) return;
            string codeT = client.provinces[optionProvince.Text];
            client.requestOption_Districts(codeT);
            client.ReceiveResponse();

            foreach (var district in client.districts)
            {
                optionDistrict.Items.Add(district.Key);
            }
        }

        private void filterBtn_Click(object sender, System.EventArgs e)
        {
            string codeP = "0";
            
            if (optionProvince.Text != "")
                codeP = client.provinces[optionProvince.Text];

            string codeD = "0";
            if (optionDistrict.Text != "")
                codeD = client.districts[optionDistrict.Text];

            client.requestPlacesList_Filter(codeP, codeD);
            client.ReceiveResponse();

            dataTable.Items.Clear();

            string[] Item = new string[5];
            ListViewItem LItems;
            foreach (var item in client.places)
            {
                JObject itemObj = JObject.Parse(item.ToString());

                Item[0] = itemObj["code"].ToString();
                Item[1] = itemObj["name"].ToString();
                Item[2] = itemObj["coord"].ToString();
                Item[3] = itemObj["description"].ToString();

                // add new row
                LItems = new ListViewItem(Item);
                LItems.ForeColor = System.Drawing.Color.DarkBlue;
                dataTable.Items.Add(LItems);
            }
        }

        private void dataTable_MouseClick(object sender, MouseEventArgs e)
        {
            string selected = "";
            for (var i = 0; i < dataTable.Items.Count; i++)
            {
                if (dataTable.Items[i].Selected == true)
                {
                    selected = i.ToString();
                    string codeL = "";
                    if (dataTable.Items[i].Text != "")
                        codeL = dataTable.Items[i].Text;

                    client.requestPlacesList_Detail(codeL);
                    client.ReceiveResponse();

                    ResultForm f = new ResultForm();
                    f.cli = client;
                    f.Ten = client.location["name"].ToString();
                    f.MaSo = client.location["code"].ToString();
                    f.ViTri = client.location["coord"].ToString();
                    f.MoTa = client.location["description"].ToString();

                    int nImg = Int32.Parse(client.location["img"].ToString());
                    f.imgs = new string[nImg];

                    for (int k = 1; k <= nImg; k++)
                    {
                        client.requestPlacesList_Image(client.location["code"].ToString() + "0" + k.ToString());
                        client.ReceiveResponse();

                        f.imgs[k - 1] = client.image;
                    }
                    f.Show();
                    dataTable.Items[i].ForeColor = Color.DarkSlateBlue;
                    
                    this.Top = 0;
                }
            }
        }

        private void pictureresetBox_Click(object sender, EventArgs e)
        {
            optionDistrict.Text = "";
            optionProvince.Text = "";
            diadiem.Text = "Nhập địa điểm du lịch";
            diadiem.ForeColor = Color.Gray;
            diadiem_Leave(sender, e);
            dataTable.Items.Clear();
            filterBtn_Click(sender, e);
        }

        private void pictureresetBox_MouseHover(object sender, System.EventArgs e)
        {
            pictureresetBox.BackColor = Color.Cyan;
        }

        private void pictureresetBox_MouseLeave(object sender, System.EventArgs e)
        {
            pictureresetBox.BackColor = Color.LightCyan;
        }

        private void picturesearchBox_MouseHover(object sender, System.EventArgs e)
        {
            picturesearchBox.BackColor = Color.Cyan;
        }

        private void picturesearchBox_MouseLeave(object sender, System.EventArgs e)
        {
            picturesearchBox.BackColor = Color.LightCyan;
        }

        private void optionProvince_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void optionDistrict_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
