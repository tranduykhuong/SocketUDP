using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Client
{
    public partial class ZoomPictureForm : Form
    {
        public ZoomPictureForm()
        {
            InitializeComponent();
        }
        private Image img;
        public Image hinhanh
        {
            set { img = value; }
        }

        private void ZoomPictureForm_Load(object sender, EventArgs e)
        {
            pictureBox7.Image = img;
        }

        private void zoomin_Click(object sender, EventArgs e)
        {
            Convert.ToInt32(pictureBox7.Width += 20);
            Convert.ToInt32(pictureBox7.Height += 20);
        }

        private void zoomout_Click(object sender, EventArgs e)
        {
            Convert.ToInt32(pictureBox7.Width -= 20);
            Convert.ToInt32(pictureBox7.Height -= 20);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //for (int k = 1; k <= listSize; k++)
            //{
            //    string codeImg = k < 10 ? (codeT + "0" + k.ToString()) : codeT + k.ToString();
            //    imgStr += "\"Database/img/" + codeImg + ".png\",";
            //    // save png
            //    using (var imageFile = new FileStream(@"Database/img/" + codeImg + @".png", FileMode.Create))
            //    {
            //        imageFile.Write(listImage[k - 1], 0, listImage[k - 1].Length);
            //        imageFile.Flush();
            //    }
            //}
        }
    }
}
