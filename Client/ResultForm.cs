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
        //private string img = "";

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

        //public string IMG
        //{
        //    set { img = value; }
        //}

        private void ResultForm_Load(object sender, EventArgs e)
        {
            //TopMost = false;
            string[] s = vitri.Split(',');
            //MessageBox.Show(ten);
            //tendiadiem.Cursor = Cursors.Arrow;


            tendiadiem.Text = ten;
            
            masodiadiem.Text = Maso;
            vido.Text = s[0];
            kinhdo.Text = s[1];
            motadiadiem.Text = mota;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ZoomPictureForm f = new ZoomPictureForm();
            f.hinhanh = pictureBox1.Image;
            f.Show();
        }
    }
}