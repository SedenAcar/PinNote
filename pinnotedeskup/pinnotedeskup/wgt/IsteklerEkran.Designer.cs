namespace pinnotedeskup.wgt
{
    partial class IsteklerEkran
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.istek = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accept = new System.Windows.Forms.DataGridViewButtonColumn();
            this.decline = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.istek)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(109, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 45);
            this.label1.TabIndex = 20;
            this.label1.Text = "PinNote";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 21;
            this.label2.Text = "Requests";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.istek);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 94);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(346, 321);
            this.flowLayoutPanel1.TabIndex = 22;
            // 
            // istek
            // 
            this.istek.AllowUserToAddRows = false;
            this.istek.AllowUserToDeleteRows = false;
            this.istek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.istek.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.surname,
            this.accept,
            this.decline});
            this.istek.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.istek.Location = new System.Drawing.Point(3, 3);
            this.istek.Name = "istek";
            this.istek.ReadOnly = true;
            this.istek.Size = new System.Drawing.Size(343, 309);
            this.istek.TabIndex = 0;
            this.istek.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.istek_CellContentClick_1);
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
            // 
            // surname
            // 
            this.surname.HeaderText = "Surname";
            this.surname.Name = "surname";
            this.surname.ReadOnly = true;
            // 
            // accept
            // 
            this.accept.HeaderText = "Accept";
            this.accept.Name = "accept";
            this.accept.ReadOnly = true;
            this.accept.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.accept.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.accept.Width = 50;
            // 
            // decline
            // 
            this.decline.HeaderText = "Decline";
            this.decline.Name = "decline";
            this.decline.ReadOnly = true;
            this.decline.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.decline.Width = 50;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(283, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IsteklerEkran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(74)))), ((int)(((byte)(179)))));
            this.ClientSize = new System.Drawing.Size(373, 438);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "IsteklerEkran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.istek)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView istek;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn surname;
        private System.Windows.Forms.DataGridViewButtonColumn accept;
        private System.Windows.Forms.DataGridViewButtonColumn decline;
    }
}