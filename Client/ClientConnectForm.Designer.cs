
namespace Client
{
    partial class Client
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IPAdd = new System.Windows.Forms.TextBox();
            this.Port = new System.Windows.Forms.TextBox();
            this.Automatic = new System.Windows.Forms.CheckBox();
            this.connect = new System.Windows.Forms.Button();
            this.disconnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(139, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port";
            // 
            // IPAdd
            // 
            this.IPAdd.ForeColor = System.Drawing.Color.Gray;
            this.IPAdd.Location = new System.Drawing.Point(260, 78);
            this.IPAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IPAdd.Name = "IPAdd";
            this.IPAdd.Size = new System.Drawing.Size(217, 22);
            this.IPAdd.TabIndex = 2;
            this.IPAdd.TabStop = false;
            this.IPAdd.Text = "Input IPAdd...";
            this.IPAdd.Enter += new System.EventHandler(this.IPAdd_Enter);
            this.IPAdd.Leave += new System.EventHandler(this.IPAdd_Leave);
            // 
            // Port
            // 
            this.Port.ForeColor = System.Drawing.Color.Gray;
            this.Port.Location = new System.Drawing.Point(260, 117);
            this.Port.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(169, 22);
            this.Port.TabIndex = 3;
            this.Port.TabStop = false;
            this.Port.Text = "Input Port...";
            this.Port.Enter += new System.EventHandler(this.Port_Enter);
            this.Port.Leave += new System.EventHandler(this.Port_Leave);
            // 
            // Automatic
            // 
            this.Automatic.AutoSize = true;
            this.Automatic.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Automatic.Location = new System.Drawing.Point(260, 156);
            this.Automatic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Automatic.Name = "Automatic";
            this.Automatic.Size = new System.Drawing.Size(108, 23);
            this.Automatic.TabIndex = 4;
            this.Automatic.TabStop = false;
            this.Automatic.Text = "Automatic";
            this.Automatic.UseVisualStyleBackColor = true;
            this.Automatic.CheckedChanged += new System.EventHandler(this.Automatic_CheckedChanged);
            // 
            // connect
            // 
            this.connect.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connect.Location = new System.Drawing.Point(143, 212);
            this.connect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(129, 30);
            this.connect.TabIndex = 5;
            this.connect.TabStop = false;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // disconnect
            // 
            this.disconnect.Enabled = false;
            this.disconnect.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.disconnect.Location = new System.Drawing.Point(348, 212);
            this.disconnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(129, 30);
            this.disconnect.TabIndex = 6;
            this.disconnect.TabStop = false;
            this.disconnect.Text = "Disconnect";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.disconnect_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 334);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.connect);
            this.Controls.Add(this.Automatic);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.IPAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Client";
            this.Text = "UPD_Client";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IPAdd;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.CheckBox Automatic;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button disconnect;
    }
}

