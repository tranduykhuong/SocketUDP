using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Server
{
    partial class AddPlaceForm : Form
    {
        private UDP_Server.UDPServer server = null;
        public AddPlaceForm()
        {
            InitializeComponent();

            
        }

        public UDP_Server.UDPServer ser
        {
            set { server = value; }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (boxProvince.Text == "" || boxDistrict.Text == "" || boxName.Text == ""
                || boxVi.Text == "" || boxKinh.Text =="" || boxDiscrip.Text == "" || listImage.Count == 0)
            {
                MessageBox.Show("Please enter all fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (listImage.Count < 3)
            {
                MessageBox.Show("Please add more image!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (server.addPlace(boxProvince.Text, boxDistrict.Text, boxName.Text, boxVi.Text, boxKinh.Text, boxDiscrip.Text, listImage))
                Hide();
        }

        private void addImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files(*.PNG; *.JPG; *JPEG; *.BMP) | *.PNG; *.JPG; *JPEG; *.BMP |" +
                "All files(*.*) | *.*";
            
            dlg.Multiselect = false;
            dlg.FilterIndex = 1;
            dlg.RestoreDirectory = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string fileName;
                fileName = dlg.FileName;
                listImg.Items.Add(fileName);

                byte[] imgArr = System.IO.File.ReadAllBytes(fileName);
                listImage.Add(imgArr);
                //MessageBox.Show(listImage.ToString());
            }
        }

        private void AddPlaceForm_Load(object sender, EventArgs e)
        {
            provinces = new Dictionary<string, string>();
            string json = server.fetch_OptionProvinces();
            provinces = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            foreach (var province in provinces)
            {
                boxProvince.Items.Add(province.Key);
            }
        }

        private void boxProvince_TextChanged(object sender, EventArgs e)
        {
            boxDistrict.Items.Clear();
            Dictionary<string, string> districts = new Dictionary<string, string>();
            string json = server.fetch_OptionDistricts(provinces[boxProvince.Text]);
            districts = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            foreach (var district in districts)
            {
                boxDistrict.Items.Add(district.Key);
            }
        }


        List<byte[]> listImage = new List<byte[]>();
        Dictionary<string, string> provinces;
    }
}
