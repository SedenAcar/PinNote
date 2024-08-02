using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Messaging;

namespace pinnotedeskup
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kayit_ekran_2 formm2 = new kayit_ekran_2();
            formm2.Show();
            this.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            hesaba_giris_ekranı_3 formm3 = new hesaba_giris_ekranı_3();
            formm3.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
