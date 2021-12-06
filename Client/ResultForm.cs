using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace Client
{
    public partial class ResultForm : Form
    {
        public ResultForm()
        {
            InitializeComponent();
        }

        private UDP_client client = null;
        private string ten = "";
        private string Maso = "";
        private string vitri = "";
        private string mota = "";
        public string[] imgs;

        public UDP_client cli
        {
            set { client = value; }
        }
        public string Ten
        {
            set { ten = value; }
        }
        public string MaSo
        {
            set { Maso = value; }
        }

        public string ViTri
        {
            set { vitri = value; }
        }

        public string MoTa
        {
            set { mota = value; }
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            this.Top = 10;
            string[] s = vitri.Split(',');

            tendiadiem.Text = ten;
            
            masodiadiem.Text = Maso;
            vido.Text = s[0];
            kinhdo.Text = s[1];
            motadiadiem.Text = mota;

            // Lấy danh sách image
            listImg.View = View.LargeIcon;

            listImg.Columns.Add("Spacecraft", 150);
            listImg.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(250, 140);

            for (int i = 0; i < imgs.Length; i++) 
            {
                byte[] NewBytes = Convert.FromBase64String(imgs[i]);
                MemoryStream ms1 = new MemoryStream(NewBytes);
                Image image = Image.FromStream(ms1);

                imgList.Images.Add(image);
                listImg.Items.Add("", i);
            }
            listImg.LargeImageList = imgList;
        }

        private void listImg_MouseClick(object sender, MouseEventArgs e)
        {
            for (var i = 0; i < listImg.Items.Count; i++)
            {
                if (listImg.Items[i].Selected == true)
                {
                    ZoomPictureForm f = new ZoomPictureForm();
                    f.imgArr = imgs;
                    f.index = i;
                    f.Show();
                }
            }
            //MessageBox.Show(selected);
        }
    }
}