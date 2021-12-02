
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
            this.zoomin = new System.Windows.Forms.PictureBox();
            this.zoomout = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.download = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.zoomin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.download)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // zoomin
            // 
            this.zoomin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.zoomin.Image = global::Client.Properties.Resources.zoom;
            this.zoomin.Location = new System.Drawing.Point(309, 527);
            this.zoomin.Name = "zoomin";
            this.zoomin.Size = new System.Drawing.Size(41, 37);
            this.zoomin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.zoomin.TabIndex = 0;
            this.zoomin.TabStop = false;
            this.zoomin.Click += new System.EventHandler(this.zoomin_Click);
            // 
            // zoomout
            // 
            this.zoomout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.zoomout.Image = global::Client.Properties.Resources.zoom_out;
            this.zoomout.Location = new System.Drawing.Point(488, 527);
            this.zoomout.Name = "zoomout";
            this.zoomout.Size = new System.Drawing.Size(41, 37);
            this.zoomout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.zoomout.TabIndex = 1;
            this.zoomout.TabStop = false;
            this.zoomout.Click += new System.EventHandler(this.zoomout_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Location = new System.Drawing.Point(0, 3);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(547, 367);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 7;
            this.pictureBox7.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Location = new System.Drawing.Point(223, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 370);
            this.panel1.TabIndex = 8;
            // 
            // download
            // 
            this.download.Cursor = System.Windows.Forms.Cursors.Hand;
            this.download.Image = global::Client.Properties.Resources.dowload;
            this.download.Location = new System.Drawing.Point(668, 527);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(41, 37);
            this.download.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.download.TabIndex = 9;
            this.download.TabStop = false;
            this.download.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(12, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(995, 467);
            this.panel2.TabIndex = 10;
            // 
            // ZoomPictureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 603);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.download);
            this.Controls.Add(this.zoomout);
            this.Controls.Add(this.zoomin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ZoomPictureForm";
            this.Text = "Picture";
            this.Load += new System.EventHandler(this.ZoomPictureForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.zoomin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.download)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox zoomin;
        private System.Windows.Forms.PictureBox zoomout;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox download;
        private System.Windows.Forms.Panel panel2;
    }
}