
namespace Client
{
    partial class ZoomPictureForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.leftBtn = new System.Windows.Forms.PictureBox();
            this.rightBtn = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.downloadBtn = new System.Windows.Forms.PictureBox();
            this.zoomout = new System.Windows.Forms.PictureBox();
            this.zoomin = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.leftBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomin)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Location = new System.Drawing.Point(42, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(662, 375);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.leftBtn);
            this.panel2.Controls.Add(this.rightBtn);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(9, 18);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(746, 379);
            this.panel2.TabIndex = 10;
            // 
            // leftBtn
            // 
            this.leftBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.leftBtn.Image = global::Client.Properties.Resources.left;
            this.leftBtn.Location = new System.Drawing.Point(0, 162);
            this.leftBtn.Name = "leftBtn";
            this.leftBtn.Size = new System.Drawing.Size(40, 50);
            this.leftBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.leftBtn.TabIndex = 10;
            this.leftBtn.TabStop = false;
            this.leftBtn.Click += new System.EventHandler(this.leftBtn_Click);
            this.leftBtn.MouseLeave += new System.EventHandler(this.leftBtn_MouseLeave);
            this.leftBtn.MouseHover += new System.EventHandler(this.leftBtn_MouseHover);
            // 
            // rightBtn
            // 
            this.rightBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rightBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rightBtn.Image = global::Client.Properties.Resources.right;
            this.rightBtn.Location = new System.Drawing.Point(706, 162);
            this.rightBtn.Name = "rightBtn";
            this.rightBtn.Size = new System.Drawing.Size(40, 50);
            this.rightBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rightBtn.TabIndex = 9;
            this.rightBtn.TabStop = false;
            this.rightBtn.Click += new System.EventHandler(this.rightBtn_Click);
            this.rightBtn.MouseLeave += new System.EventHandler(this.rightBtn_MouseLeave);
            this.rightBtn.MouseHover += new System.EventHandler(this.rightBtn_MouseHover);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Location = new System.Drawing.Point(129, 39);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(400, 295);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 7;
            this.pictureBox7.TabStop = false;
            // 
            // downloadBtn
            // 
            this.downloadBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.downloadBtn.Image = global::Client.Properties.Resources.dowload;
            this.downloadBtn.Location = new System.Drawing.Point(501, 428);
            this.downloadBtn.Margin = new System.Windows.Forms.Padding(2);
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.Size = new System.Drawing.Size(31, 30);
            this.downloadBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.downloadBtn.TabIndex = 9;
            this.downloadBtn.TabStop = false;
            this.downloadBtn.Click += new System.EventHandler(this.downloadBtn_Click);
            this.downloadBtn.MouseLeave += new System.EventHandler(this.downloadBtn_MouseLeave);
            this.downloadBtn.MouseHover += new System.EventHandler(this.downloadBtn_MouseHover);
            // 
            // zoomout
            // 
            this.zoomout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.zoomout.Image = global::Client.Properties.Resources.zoom_out;
            this.zoomout.Location = new System.Drawing.Point(366, 428);
            this.zoomout.Margin = new System.Windows.Forms.Padding(2);
            this.zoomout.Name = "zoomout";
            this.zoomout.Size = new System.Drawing.Size(31, 30);
            this.zoomout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.zoomout.TabIndex = 1;
            this.zoomout.TabStop = false;
            this.zoomout.Click += new System.EventHandler(this.zoomout_Click);
            this.zoomout.MouseLeave += new System.EventHandler(this.zoomout_MouseLeave);
            this.zoomout.MouseHover += new System.EventHandler(this.zoomout_MouseHover);
            // 
            // zoomin
            // 
            this.zoomin.BackColor = System.Drawing.SystemColors.Control;
            this.zoomin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.zoomin.Image = global::Client.Properties.Resources.zoom;
            this.zoomin.Location = new System.Drawing.Point(232, 428);
            this.zoomin.Margin = new System.Windows.Forms.Padding(2);
            this.zoomin.Name = "zoomin";
            this.zoomin.Size = new System.Drawing.Size(31, 30);
            this.zoomin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.zoomin.TabIndex = 0;
            this.zoomin.TabStop = false;
            this.zoomin.Click += new System.EventHandler(this.zoomin_Click);
            this.zoomin.MouseLeave += new System.EventHandler(this.zoomin_MouseLeave);
            this.zoomin.MouseHover += new System.EventHandler(this.zoomin_MouseHover);
            // 
            // ZoomPictureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 490);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.downloadBtn);
            this.Controls.Add(this.zoomout);
            this.Controls.Add(this.zoomin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "ZoomPictureForm";
            this.Text = "Picture";
            this.Load += new System.EventHandler(this.ZoomPictureForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.leftBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.downloadBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox zoomin;
        private System.Windows.Forms.PictureBox zoomout;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox downloadBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox rightBtn;
        private System.Windows.Forms.PictureBox leftBtn;
    }
}