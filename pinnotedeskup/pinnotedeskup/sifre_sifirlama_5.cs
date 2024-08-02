using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static pinnotedeskup.Program;

namespace pinnotedeskup
{
    public partial class sifre_sifirlama_5 : Form
    {
        public sifre_sifirlama_5()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void sifre_sifirlama_5_Load(object sender, EventArgs e)
        {

        }

        private void psw_button_Click(object sender, EventArgs e)
        {
            
            if(new_psw1.Text == new_psw2.Text)
            {
                //password içeriğinin uygunluğunu kontrol et


                //db de password olarak psw1 ata
                SqlConnection baglanti = new SqlConnection("Data Source = SEDEN\\SQLEXPRESS; Initial Catalog = PinNoteDB; Integrated Security = True; Encrypt=False;");
                baglanti.Open();
                SqlCommand VeriGuncelle = new SqlCommand("update  PASSWORD_TABLE PASSWORD=@password,LAST_UPDATE=@lastupdate where ID=@id", baglanti);
                VeriGuncelle.Parameters.AddWithValue("@id", user_data.Id);
                VeriGuncelle.Parameters.AddWithValue("@password", new_psw1.Text);
                VeriGuncelle.Parameters.AddWithValue("@lastupdate", DateTime.Now);
                baglanti.Close();
                MessageBox.Show("password güncellendi");
            }
            else 
            {
                MessageBox.Show("Passwordlar eslesmiyor");
                new_psw1.Text = "";
                new_psw2.Text = "";
                new_psw1.Focus();

            }
            giris giris = new giris();
            giris.Show();
            this.Hide();
        }
    }
}
