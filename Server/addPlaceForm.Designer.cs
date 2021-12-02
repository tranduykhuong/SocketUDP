
namespace Server
{
    partial class AddPlaceForm
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
            this.submitBtn = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.Label();
            this.coord = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.Label();
            this.boxName = new System.Windows.Forms.TextBox();
            this.boxVi = new System.Windows.Forms.TextBox();
            this.boxKinh = new System.Windows.Forms.TextBox();
            this.boxDiscrip = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tinh = new System.Windows.Forms.Label();
            this.huyen = new System.Windows.Forms.Label();
            this.listImg = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addImg = new System.Windows.Forms.Button();
            this.boxProvince = new System.Windows.Forms.ComboBox();
            this.boxDistrict = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(316, 423);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 23);
            this.submitBtn.TabIndex = 0;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(78, 40);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(35, 13);
            this.name.TabIndex = 1;
            this.name.Text = "Name";
            // 
            // coord
            // 
            this.coord.AutoSize = true;
            this.coord.Location = new System.Drawing.Point(78, 74);
            this.coord.Name = "coord";
            this.coord.Size = new System.Drawing.Size(35, 13);
            this.coord.TabIndex = 2;
            this.coord.Text = "Coord";
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Location = new System.Drawing.Point(78, 185);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(60, 13);
            this.description.TabIndex = 3;
            this.description.Text = "Description";
            // 
            // boxName
            // 
            this.boxName.Location = new System.Drawing.Point(206, 40);
            this.boxName.Name = "boxName";
            this.boxName.Size = new System.Drawing.Size(433, 20);
            this.boxName.TabIndex = 4;
            // 
            // boxVi
            // 
            this.boxVi.Location = new System.Drawing.Point(254, 74);
            this.boxVi.Name = "boxVi";
            this.boxVi.Size = new System.Drawing.Size(84, 20);
            this.boxVi.TabIndex = 5;
            // 
            // boxKinh
            // 
            this.boxKinh.Location = new System.Drawing.Point(414, 74);
            this.boxKinh.Name = "boxKinh";
            this.boxKinh.Size = new System.Drawing.Size(82, 20);
            this.boxKinh.TabIndex = 6;
            // 
            // boxDiscrip
            // 
            this.boxDiscrip.Location = new System.Drawing.Point(206, 185);
            this.boxDiscrip.Name = "boxDiscrip";
            this.boxDiscrip.Size = new System.Drawing.Size(433, 96);
            this.boxDiscrip.TabIndex = 7;
            this.boxDiscrip.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Vĩ độ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(364, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Kinh độ";
            // 
            // tinh
            // 
            this.tinh.AutoSize = true;
            this.tinh.Location = new System.Drawing.Point(78, 111);
            this.tinh.Name = "tinh";
            this.tinh.Size = new System.Drawing.Size(71, 13);
            this.tinh.TabIndex = 10;
            this.tinh.Text = "Province/City";
            // 
            // huyen
            // 
            this.huyen.AutoSize = true;
            this.huyen.Location = new System.Drawing.Point(78, 147);
            this.huyen.Name = "huyen";
            this.huyen.Size = new System.Drawing.Size(39, 13);
            this.huyen.TabIndex = 11;
            this.huyen.Text = "District";
            // 
            // listImg
            // 
            this.listImg.FormattingEnabled = true;
            this.listImg.Location = new System.Drawing.Point(206, 303);
            this.listImg.Name = "listImg";
            this.listImg.Size = new System.Drawing.Size(335, 95);
            this.listImg.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Image";
            // 
            // addImg
            // 
            this.addImg.Location = new System.Drawing.Point(560, 303);
            this.addImg.Name = "addImg";
            this.addImg.Size = new System.Drawing.Size(75, 23);
            this.addImg.TabIndex = 16;
            this.addImg.Text = "Add image";
            this.addImg.UseVisualStyleBackColor = true;
            this.addImg.Click += new System.EventHandler(this.addImg_Click);
            // 
            // boxProvince
            // 
            this.boxProvince.FormattingEnabled = true;
            this.boxProvince.Location = new System.Drawing.Point(206, 108);
            this.boxProvince.Name = "boxProvince";
            this.boxProvince.Size = new System.Drawing.Size(185, 21);
            this.boxProvince.TabIndex = 17;
            this.boxProvince.TextChanged += new System.EventHandler(this.boxProvince_TextChanged);
            // 
            // boxDistrict
            // 
            this.boxDistrict.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.boxDistrict.FormattingEnabled = true;
            this.boxDistrict.Location = new System.Drawing.Point(206, 144);
            this.boxDistrict.Name = "boxDistrict";
            this.boxDistrict.Size = new System.Drawing.Size(185, 21);
            this.boxDistrict.TabIndex = 18;
            // 
            // AddPlaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 480);
            this.Controls.Add(this.boxDistrict);
            this.Controls.Add(this.boxProvince);
            this.Controls.Add(this.addImg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listImg);
            this.Controls.Add(this.huyen);
            this.Controls.Add(this.tinh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boxDiscrip);
            this.Controls.Add(this.boxKinh);
            this.Controls.Add(this.boxVi);
            this.Controls.Add(this.boxName);
            this.Controls.Add(this.description);
            this.Controls.Add(this.coord);
            this.Controls.Add(this.name);
            this.Controls.Add(this.submitBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AddPlaceForm";
            this.Text = "ADD PLACE";
            this.Load += new System.EventHandler(this.AddPlaceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label coord;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.TextBox boxName;
        private System.Windows.Forms.TextBox boxVi;
        private System.Windows.Forms.TextBox boxKinh;
        private System.Windows.Forms.RichTextBox boxDiscrip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label tinh;
        private System.Windows.Forms.Label huyen;
        private System.Windows.Forms.ListBox listImg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addImg;
        private System.Windows.Forms.ComboBox boxProvince;
        private System.Windows.Forms.ComboBox boxDistrict;
    }
}

