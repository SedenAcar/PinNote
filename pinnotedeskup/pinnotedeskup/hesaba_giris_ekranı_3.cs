using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static pinnotedeskup.Program;

namespace pinnotedeskup
{
    public partial class hesaba_giris_ekranı_3 : Form
    {
           
        /*kullanicidan bilgileri alma*/
        string password="";
        string mail="";
        /*SQL Control*/
        string user_ID;
        string user_psw;
        /*eslesme durumunu kontrol etme*/
        bool isim;
        bool sifre;
        /*hata mesajı icerigi*/
        string warning_message;
        /*SQL baglantisi*/
        bool psw;

        SqlConnection baglanti = new SqlConnection("Data Source = SEDEN\\SQLEXPRESS; Initial Catalog = PinNoteDB; Integrated Security = True; Encrypt=False;");
        /*DB SADECE  OKUMA MODUNDA AÇ!!!!!!!!!!*/
        public hesaba_giris_ekranı_3()
        {
            InitializeComponent();
            mailbox.Focus();
        } 
        private void Form3_Load(object sender, EventArgs e)
        {
    
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            mailbox.Focus();
            mail= mailbox.Text;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            password= textBox4.Text;
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            baglanti.Open();
            if (mail.Length > 0 && password.Length > 0)
            {
                /*mail control*/
                
                SqlCommand mail_ctrl = new SqlCommand("SELECT ID FROM USER_DATA WHERE MAIL = @Mail", baglanti);
                mail_ctrl.Parameters.AddWithValue("@Mail", mail);
                SqlDataReader sqlDataReader_mail = mail_ctrl.ExecuteReader();

                if (sqlDataReader_mail.Read())
                {
                    user_data.Id = Convert.ToInt32(sqlDataReader_mail["ID"]);
                }
                else
                {
                    //hata msj goster
                    MessageBox.Show("wrong mail!");
                    mailbox.Focus();
                    return;
                }
                sqlDataReader_mail.Close();

                /*password control*/

                SqlCommand psw_ctrl = new SqlCommand("SELECT PASSWORD FROM USER_PASSWORD WHERE ID = @UserID", baglanti);
                psw_ctrl.Parameters.AddWithValue("@UserID", user_data.Id);
                SqlDataReader sqlDataReader_psw = psw_ctrl.ExecuteReader();

                if (sqlDataReader_psw.Read())
                {
                    user_psw = sqlDataReader_psw["PASSWORD"].ToString();//eğer değer varsa atama yapacak
                    
                }
                sqlDataReader_psw.Close();

                /*giris durumu*/
                if (user_psw == password)
                {
                    try
                    {
                        // SQL komutu
                        string sql = "SELECT NAME, SURNAME, PHONE, MAIL, BIRTH_DATE, PHOTO FROM USER_DATA WHERE ID = @id";

                        using (SqlCommand vericekme = new SqlCommand(sql, baglanti))
                        {
                            // Parametre ekleme
                            vericekme.Parameters.AddWithValue("@id", user_data.Id);


                            using (SqlDataReader reader = vericekme.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    user_data.Name = reader["NAME"].ToString();
                                    user_data.Surname = reader["SURNAME"].ToString();
                                    user_data.PhoneNumber = reader["PHONE"].ToString();
                                    user_data.Email = reader["MAIL"].ToString();
                                    user_data.BirthDate = (DateTime)reader["BIRTH_DATE"];

                                    // Fotoğraf okuma, varsa
                                    if (reader["PHOTO"] != DBNull.Value)
                                    {
                                        byte[] photoArray = (byte[])reader["PHOTO"];
                                        // Fotoğrafı işlemek için gerekli kodlar burada olabilir
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No data found.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }

                    /*homepage yonlendir*/
                    homepage homepage = new homepage();
                    homepage.Show();
                    this.Hide();
                }
                else
                {
                    //uyari mesaji goster ve yonlendir
                    MessageBox.Show("Wrong password!");
                    textBox4.Text = "";
                    textBox4.Focus();
                }
            
            }
            else
            {
                MessageBox.Show("mail or password can not be empty");
            }
            baglanti.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dogrulama_kodu_4 dogrulama = new dogrulama_kodu_4();
            dogrulama.Show();
            this.Hide();
        }
    }
    
}
