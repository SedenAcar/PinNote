namespace pinnotedeskup
{
    partial class sifre_sifirlama_5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sifre_sifirlama_5));
            this.label4 = new System.Windows.Forms.Label();
            this.psw_button = new System.Windows.Forms.Button();
            this.new_psw2 = new System.Windows.Forms.TextBox();
            this.new_psw1 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(554, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "New Password";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // psw_button
            // 
            this.psw_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(82)))), ((int)(((byte)(255)))));
            this.psw_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.psw_button.ForeColor = System.Drawing.Color.White;
            this.psw_button.Location = new System.Drawing.Point(652, 490);
            this.psw_button.Name = "psw_button";
            this.psw_button.Size = new System.Drawing.Size(172, 33);
            this.psw_button.TabIndex = 28;
            this.psw_button.Text = "kayit";
            this.psw_button.UseVisualStyleBackColor = false;
            this.psw_button.Click += new System.EventHandler(this.psw_button_Click);
            // 
            // new_psw2
            // 
            this.new_psw2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(209)))), ((int)(((byte)(255)))));
            this.new_psw2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.new_psw2.Location = new System.Drawing.Point(557, 407);
            this.new_psw2.Name = "new_psw2";
            this.new_psw2.Size = new System.Drawing.Size(362, 20);
            this.new_psw2.TabIndex = 27;
            // 
            // new_psw1
            // 
            this.new_psw1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(209)))), ((int)(((byte)(255)))));
            this.new_psw1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.new_psw1.Location = new System.Drawing.Point(557, 359);
            this.new_psw1.Name = "new_psw1";
            this.new_psw1.Size = new System.Drawing.Size(362, 20);
            this.new_psw1.TabIndex = 26;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(668, 90);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(135, 153);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(554, 391);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "New Password Again";
            // 
            // sifre_sifirlama_5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1454, 811);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.psw_button);
            this.Controls.Add(this.new_psw2);
            this.Controls.Add(this.new_psw1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "sifre_sifirlama_5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.sifre_sifirlama_5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button psw_button;
        private System.Windows.Forms.TextBox new_psw2;
        private System.Windows.Forms.TextBox new_psw1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
    }
}