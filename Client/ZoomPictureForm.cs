using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace Client
{
    public partial class ZoomPictureForm : Form
    {
        public ZoomPictureForm()
        {
            InitializeComponent();
            pictureBox7.MouseWheel += new MouseEventHandler(scrollMouse);
        }

        private string[] imgs;
        private int idx = 0;

        public string[] imgArr
        {
            set { imgs = value; }
        }

        public int index
        {
            set { idx = value; }
        }

        private void ZoomPictureForm_Load(object sender, EventArgs e)
        {
            byte[] NewBytes = Convert.FromBase64String(imgs[idx]);
            MemoryStream ms1 = new MemoryStream(NewBytes);
            Image image = Image.FromStream(ms1);

            pictureBox7.Image = image;
        }

        private void zoomin_Click(object sender, EventArgs e)
        {
            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.Width = Convert.ToInt32(pictureBox7.Width + 30);
            pictureBox7.Height = Convert.ToInt32(pictureBox7.Height + 30);
            zoomout.Enabled = true;

            Point pos = pictureBox7.Location;
            pictureBox7.Location = new Point(pos.X - 15, pos.Y - 15);
        }

        private void zoomout_Click(object sender, EventArgs e)
        {
            if (pictureBox7.Width <= 400)
            {
                zoomout.Enabled = false;
                return;
            }

            pictureBox7.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox7.Width = Convert.ToInt32(pictureBox7.Width - 30);
            pictureBox7.Height = Convert.ToInt32(pictureBox7.Height - 30);

            Point pos = pictureBox7.Location;
            pictureBox7.Location = new Point(pos.X + 15, pos.Y + 15);
        }

        private void scrollMouse(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                pictureBox7.Width += 30;
                pictureBox7.Height += 30;
            }
            else
            {
                if (pictureBox7.Width >= 400)
                {
                    pictureBox7.Width -= 30;
                    pictureBox7.Height -= 30;
                }
            }
        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.png |*.png |*.jpg |*.jpg";

            dlg.InitialDirectory = "@C:\"";      
            dlg.Title = "Save Image";

            dlg.CheckPathExists = true;
            dlg.FilterIndex = 1;
            dlg.RestoreDirectory = true;

            ImageFormat format = ImageFormat.Png;

            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(dlg.FileName);
                if (ext == ".jpg") {
                    format = ImageFormat.Jpeg;
                }
                pictureBox7.Image.Save(dlg.FileName, format);
                MessageBox.Show("Save image successfully!", "Save Image", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void zoomin_MouseHover(object sender, EventArgs e)
        {
            zoomin.BackColor = SystemColors.MenuHighlight;
        }

        private void zoomin_MouseLeave(object sender, EventArgs e)
        {
            zoomin.BackColor = SystemColors.Control;
        }

        private void zoomout_MouseHover(object sender, EventArgs e)
        {
            if (pictureBox7.Width > 400)
                zoomout.BackColor = SystemColors.MenuHighlight;
        }

        private void zoomout_MouseLeave(object sender, EventArgs e)
        {
            zoomout.BackColor = SystemColors.Control;
        }

        private void downloadBtn_MouseHover(object sender, EventArgs e)
        {
            downloadBtn.BackColor = SystemColors.MenuHighlight;
        }

        private void downloadBtn_MouseLeave(object sender, EventArgs e)
        {
            downloadBtn.BackColor = SystemColors.Control;
        }

        private void rightBtn_Click(object sender, EventArgs e)
        {
            idx++;
            if (idx >= imgs.Length) idx = 0;
            byte[] NewBytes = Convert.FromBase64String(imgs[idx]);
            MemoryStream ms1 = new MemoryStream(NewBytes);
            Image image = Image.FromStream(ms1);

            pictureBox7.Image = image;
        }

        private void leftBtn_Click(object sender, EventArgs e)
        {
            idx--;
            if (idx < 0) idx = imgs.Length - 1;
            byte[] NewBytes = Convert.FromBase64String(imgs[idx]);
            MemoryStream ms1 = new MemoryStream(NewBytes);
            Image image = Image.FromStream(ms1);

            pictureBox7.Image = image;
        }

        private void rightBtn_MouseHover(object sender, EventArgs e)
        {
            rightBtn.BackColor = Color.Aquamarine;
        }

        private void rightBtn_MouseLeave(object sender, EventArgs e)
        {
            rightBtn.BackColor = SystemColors.ButtonHighlight;
        }

        private void leftBtn_MouseHover(object sender, EventArgs e)
        {
            leftBtn.BackColor = Color.Aquamarine;
        }

        private void leftBtn_MouseLeave(object sender, EventArgs e)
        {
            leftBtn.BackColor = SystemColors.ButtonHighlight;
        }
    }
}
