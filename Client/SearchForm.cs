using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

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
                //MessageBox.Show(itemObj["name"].ToString());

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
            if (optionProvince.Text == "") return;
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
                //MessageBox.Show(itemObj["name"].ToString());

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

        private void dataTable_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv.SelectedItems.Count > 0)
            {
                ListViewItem item = lv.SelectedItems[0];
                string codeL = "";
                if (item.Text != "")
                    codeL = item.Text;

                client.requestPlacesList_Detail(codeL);
                client.ReceiveResponse();

                ResultForm f = new ResultForm();
                f.cli = client;
                f.Ten = client.location["name"].ToString();
                f.MaSo = client.location["code"].ToString();
                f.ViTri = client.location["coord"].ToString();
                f.MoTa = client.location["description"].ToString();
                //f.TopLevel = true;
                //Thread.Sleep(1000);

                //AddOwnedForm(this);
                //f.TopMost = true;
                f.Show();
                //Thread.Sleep(1000);
                //f.TopMost = false;
                //RemoveOwnedForm(f);


                //string codeI = codeL + "01";
                //MessageBox.Show(codeI);

                //client.requestPlacesList_Image(codeI);
                //client.ReceiveResponse();

                //f.IMG = client.image;

            }
        }
    }
}
