namespace pinnotedeskup
{
    partial class reminder_olusturma_10
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(reminder_olusturma_10));
            this.reminder_create = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.saat = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.addfriend = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editcheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mail_bildirim = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.add = new System.Windows.Forms.DataGridViewButtonColumn();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.added_friend = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.edit2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mail2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.del = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.reminder_box = new System.Windows.Forms.TextBox();
            this.reminder_title_box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addfriend)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.added_friend)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // reminder_create
            // 
            this.reminder_create.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(82)))), ((int)(((byte)(255)))));
            this.reminder_create.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.reminder_create.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.reminder_create.ForeColor = System.Drawing.Color.White;
            this.reminder_create.Location = new System.Drawing.Point(1227, 53);
            this.reminder_create.Name = "reminder_create";
            this.reminder_create.Size = new System.Drawing.Size(172, 51);
            this.reminder_create.TabIndex = 21;
            this.reminder_create.Text = "SAVE";
            this.reminder_create.UseVisualStyleBackColor = false;
            this.reminder_create.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panel2.Controls.Add(this.saat);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.flowLayoutPanel2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.date);
            this.panel2.Controls.Add(this.reminder_box);
            this.panel2.Controls.Add(this.reminder_title_box);
            this.panel2.Location = new System.Drawing.Point(198, 216);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1201, 468);
            this.panel2.TabIndex = 20;
            // 
            // saat
            // 
            this.saat.FormatString = "f";
            this.saat.FormattingEnabled = true;
            this.saat.Items.AddRange(new object[] {
            "00:00",
            "00:30",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.saat.Location = new System.Drawing.Point(414, 240);
            this.saat.Name = "saat";
            this.saat.Size = new System.Drawing.Size(93, 21);
            this.saat.TabIndex = 24;
            this.saat.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBox1.Location = new System.Drawing.Point(1048, 243);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(612, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 19);
            this.label5.TabIndex = 22;
            this.label5.Text = "Added Friends:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.addfriend);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(35, 323);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(559, 121);
            this.flowLayoutPanel1.TabIndex = 20;
            // 
            // addfriend
            // 
            this.addfriend.AllowUserToAddRows = false;
            this.addfriend.AllowUserToDeleteRows = false;
            this.addfriend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addfriend.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.surname,
            this.editcheck,
            this.mail_bildirim,
            this.add});
            this.addfriend.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.addfriend.Location = new System.Drawing.Point(3, 3);
            this.addfriend.Name = "addfriend";
            this.addfriend.Size = new System.Drawing.Size(553, 118);
            this.addfriend.TabIndex = 0;
            this.addfriend.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.addfriend_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // name
            // 
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 150;
            // 
            // surname
            // 
            this.surname.HeaderText = "Surname";
            this.surname.Name = "surname";
            this.surname.ReadOnly = true;
            this.surname.Width = 150;
            // 
            // editcheck
            // 
            this.editcheck.HeaderText = "Edit";
            this.editcheck.Name = "editcheck";
            this.editcheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.editcheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.editcheck.Width = 70;
            // 
            // mail_bildirim
            // 
            this.mail_bildirim.HeaderText = "Send Mail";
            this.mail_bildirim.Name = "mail_bildirim";
            this.mail_bildirim.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.mail_bildirim.Width = 70;
            // 
            // add
            // 
            this.add.HeaderText = "Add";
            this.add.Name = "add";
            this.add.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.add.Width = 70;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.added_friend);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(613, 323);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(559, 121);
            this.flowLayoutPanel2.TabIndex = 21;
            // 
            // added_friend
            // 
            this.added_friend.AllowUserToAddRows = false;
            this.added_friend.AllowUserToDeleteRows = false;
            this.added_friend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.added_friend.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.edit2,
            this.mail2,
            this.del});
            this.added_friend.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.added_friend.Location = new System.Drawing.Point(3, 3);
            this.added_friend.Name = "added_friend";
            this.added_friend.Size = new System.Drawing.Size(553, 118);
            this.added_friend.TabIndex = 0;
            this.added_friend.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.added_friend_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Surname";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // edit2
            // 
            this.edit2.HeaderText = "Edit";
            this.edit2.Name = "edit2";
            this.edit2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.edit2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.edit2.Width = 70;
            // 
            // mail2
            // 
            this.mail2.HeaderText = "Send Mail";
            this.mail2.Name = "mail2";
            this.mail2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.mail2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.mail2.Width = 70;
            // 
            // del
            // 
            this.del.HeaderText = "Delete";
            this.del.Name = "del";
            this.del.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.del.Width = 70;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(44, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 19);
            this.label4.TabIndex = 16;
            this.label4.Text = "Add Friend:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(44, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "Hatırlatma tarihi :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Candara Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(928, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Önem derecesi :";
            // 
            // date
            // 
            this.date.CalendarFont = new System.Drawing.Font("Candara Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.CalendarForeColor = System.Drawing.Color.White;
            this.date.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.date.CustomFormat = "dd/MM/yyyy HH:mm";
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(191, 241);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(190, 20);
            this.date.TabIndex = 8;
            this.date.Value = new System.DateTime(2024, 5, 15, 0, 0, 0, 0);
            this.date.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // reminder_box
            // 
            this.reminder_box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.reminder_box.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.reminder_box.ForeColor = System.Drawing.Color.White;
            this.reminder_box.Location = new System.Drawing.Point(44, 153);
            this.reminder_box.Name = "reminder_box";
            this.reminder_box.Size = new System.Drawing.Size(1114, 29);
            this.reminder_box.TabIndex = 7;
            this.reminder_box.Text = "Hatırlatıcı notu yazın.";
            this.reminder_box.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // reminder_title_box
            // 
            this.reminder_title_box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.reminder_title_box.Font = new System.Drawing.Font("Georgia", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.reminder_title_box.ForeColor = System.Drawing.Color.White;
            this.reminder_title_box.Location = new System.Drawing.Point(44, 62);
            this.reminder_title_box.Name = "reminder_title_box";
            this.reminder_title_box.Size = new System.Drawing.Size(1114, 50);
            this.reminder_title_box.TabIndex = 1;
            this.reminder_title_box.Text = "Hatırlatıcı başlığını yazınız.";
            this.reminder_title_box.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(190, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 45);
            this.label1.TabIndex = 19;
            this.label1.Text = "PinNote";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(139, 800);
            this.panel1.TabIndex = 22;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(42, 711);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(48, 51);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox7.TabIndex = 7;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(42, 539);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(48, 55);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 6;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(42, 321);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(48, 45);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(42, 427);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(42, 228);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // reminder_olusturma_10
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(1500, 800);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.reminder_create);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "reminder_olusturma_10";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PinNote";
            this.Load += new System.EventHandler(this.reminder_olusturma_10_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.addfriend)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.added_friend)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button reminder_create;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox reminder_title_box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.TextBox reminder_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView addfriend;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.DataGridView added_friend;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox saat;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn surname;
        private System.Windows.Forms.DataGridViewCheckBoxColumn editcheck;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mail_bildirim;
        private System.Windows.Forms.DataGridViewButtonColumn add;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn edit2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn mail2;
        private System.Windows.Forms.DataGridViewButtonColumn del;
    }
}