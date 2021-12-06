
namespace Client
{
    partial class SearchForm
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataTable = new System.Windows.Forms.ListView();
            this.maso = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ten = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vitri = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mota = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.optionProvince = new System.Windows.Forms.ComboBox();
            this.optionDistrict = new System.Windows.Forms.ComboBox();
            this.diadiem = new System.Windows.Forms.TextBox();
            this.filterBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureresetBox = new System.Windows.Forms.PictureBox();
            this.picturesearchBox = new System.Windows.Forms.PictureBox();
            this.ProgramName = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureresetBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturesearchBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataTable);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 171);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(966, 382);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách tìm kiếm";
            // 
            // dataTable
            // 
            this.dataTable.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.dataTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.maso,
            this.ten,
            this.vitri,
            this.mota});
            this.dataTable.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataTable.FullRowSelect = true;
            this.dataTable.GridLines = true;
            this.dataTable.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            this.dataTable.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.dataTable.Location = new System.Drawing.Point(4, 19);
            this.dataTable.Name = "dataTable";
            this.dataTable.Size = new System.Drawing.Size(959, 358);
            this.dataTable.TabIndex = 0;
            this.dataTable.UseCompatibleStateImageBehavior = false;
            this.dataTable.View = System.Windows.Forms.View.Details;
            this.dataTable.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataTable_MouseClick);
            // 
            // maso
            // 
            this.maso.Text = "Mã số";
            this.maso.Width = 89;
            // 
            // ten
            // 
            this.ten.Text = "Tên địa điểm";
            this.ten.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ten.Width = 274;
            // 
            // vitri
            // 
            this.vitri.Text = "Vị trí địa lý";
            this.vitri.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.vitri.Width = 162;
            // 
            // mota
            // 
            this.mota.Text = "Mô tả";
            this.mota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mota.Width = 428;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 1;
            this.label2.Tag = "";
            this.label2.Text = "Tỉnh/TP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(184, 31);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quận/Huyện";
            // 
            // optionProvince
            // 
            this.optionProvince.FormattingEnabled = true;
            this.optionProvince.Location = new System.Drawing.Point(32, 49);
            this.optionProvince.Margin = new System.Windows.Forms.Padding(2);
            this.optionProvince.Name = "optionProvince";
            this.optionProvince.Size = new System.Drawing.Size(139, 27);
            this.optionProvince.TabIndex = 4;
            this.optionProvince.TextChanged += new System.EventHandler(this.optionProvince_TextChanged);
            this.optionProvince.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.optionProvince_KeyPress);
            // 
            // optionDistrict
            // 
            this.optionDistrict.FormattingEnabled = true;
            this.optionDistrict.Location = new System.Drawing.Point(185, 49);
            this.optionDistrict.Margin = new System.Windows.Forms.Padding(2);
            this.optionDistrict.Name = "optionDistrict";
            this.optionDistrict.Size = new System.Drawing.Size(145, 27);
            this.optionDistrict.TabIndex = 5;
            this.optionDistrict.TabStop = false;
            this.optionDistrict.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.optionDistrict_KeyPress);
            // 
            // diadiem
            // 
            this.diadiem.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diadiem.ForeColor = System.Drawing.Color.Gray;
            this.diadiem.Location = new System.Drawing.Point(505, 49);
            this.diadiem.Margin = new System.Windows.Forms.Padding(2);
            this.diadiem.Name = "diadiem";
            this.diadiem.Size = new System.Drawing.Size(213, 24);
            this.diadiem.TabIndex = 10;
            this.diadiem.TabStop = false;
            this.diadiem.Text = "Nhập địa điểm du lịch";
            this.diadiem.Enter += new System.EventHandler(this.diadiem_Enter);
            this.diadiem.Leave += new System.EventHandler(this.diadiem_Leave);
            // 
            // filterBtn
            // 
            this.filterBtn.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterBtn.Location = new System.Drawing.Point(334, 49);
            this.filterBtn.Margin = new System.Windows.Forms.Padding(2);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(52, 27);
            this.filterBtn.TabIndex = 11;
            this.filterBtn.TabStop = false;
            this.filterBtn.Text = "Lọc";
            this.filterBtn.UseVisualStyleBackColor = true;
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.filterBtn);
            this.groupBox1.Controls.Add(this.diadiem);
            this.groupBox1.Controls.Add(this.pictureresetBox);
            this.groupBox1.Controls.Add(this.picturesearchBox);
            this.groupBox1.Controls.Add(this.optionDistrict);
            this.groupBox1.Controls.Add(this.optionProvince);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 58);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(965, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tool";
            // 
            // pictureresetBox
            // 
            this.pictureresetBox.BackColor = System.Drawing.Color.LightCyan;
            this.pictureresetBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureresetBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureresetBox.Image = global::Client.Properties.Resources.redo;
            this.pictureresetBox.Location = new System.Drawing.Point(866, 49);
            this.pictureresetBox.Margin = new System.Windows.Forms.Padding(2);
            this.pictureresetBox.Name = "pictureresetBox";
            this.pictureresetBox.Size = new System.Drawing.Size(61, 24);
            this.pictureresetBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureresetBox.TabIndex = 9;
            this.pictureresetBox.TabStop = false;
            this.pictureresetBox.Click += new System.EventHandler(this.pictureresetBox_Click);
            this.pictureresetBox.MouseLeave += new System.EventHandler(this.pictureresetBox_MouseLeave);
            this.pictureresetBox.MouseHover += new System.EventHandler(this.pictureresetBox_MouseHover);
            // 
            // picturesearchBox
            // 
            this.picturesearchBox.BackColor = System.Drawing.Color.LightCyan;
            this.picturesearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picturesearchBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picturesearchBox.Image = global::Client.Properties.Resources.loupe;
            this.picturesearchBox.Location = new System.Drawing.Point(722, 49);
            this.picturesearchBox.Margin = new System.Windows.Forms.Padding(2);
            this.picturesearchBox.Name = "picturesearchBox";
            this.picturesearchBox.Size = new System.Drawing.Size(61, 24);
            this.picturesearchBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picturesearchBox.TabIndex = 8;
            this.picturesearchBox.TabStop = false;
            this.picturesearchBox.Click += new System.EventHandler(this.picturesearchBox_Click);
            this.picturesearchBox.MouseLeave += new System.EventHandler(this.picturesearchBox_MouseLeave);
            this.picturesearchBox.MouseHover += new System.EventHandler(this.picturesearchBox_MouseHover);
            // 
            // ProgramName
            // 
            this.ProgramName.AutoSize = true;
            this.ProgramName.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProgramName.ForeColor = System.Drawing.Color.Purple;
            this.ProgramName.Location = new System.Drawing.Point(334, 7);
            this.ProgramName.Name = "ProgramName";
            this.ProgramName.Size = new System.Drawing.Size(338, 35);
            this.ProgramName.TabIndex = 5;
            this.ProgramName.Text = "DU LỊCH BỐN PHƯƠNG";
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(981, 564);
            this.Controls.Add(this.ProgramName);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Du Lịch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchForm_FormClosing);
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureresetBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturesearchBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox optionProvince;
        private System.Windows.Forms.ComboBox optionDistrict;
        private System.Windows.Forms.PictureBox picturesearchBox;
        private System.Windows.Forms.PictureBox pictureresetBox;
        private System.Windows.Forms.TextBox diadiem;
        private System.Windows.Forms.Button filterBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label ProgramName;
        private System.Windows.Forms.ListView dataTable;
        private System.Windows.Forms.ColumnHeader maso;
        private System.Windows.Forms.ColumnHeader ten;
        private System.Windows.Forms.ColumnHeader vitri;
        private System.Windows.Forms.ColumnHeader mota;
    }
}