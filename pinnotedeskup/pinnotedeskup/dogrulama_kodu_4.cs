using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static pinnotedeskup.Program;

namespace pinnotedeskup
{
    public partial class dogrulama_kodu_4 : Form
    {
        string mail;
        string verify_code;
        string verify_check;

        Random random = new Random();

        public dogrulama_kodu_4()
        {
            InitializeComponent();
        }
        private void dogrulama_kodu_4_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            verify_code = verify_maker(6); // 6 karakterlik doğrulama kodu oluştur
            mail =mail_box.Text;
            //email adresi db de mevcut mu kontrol et

            SqlConnection baglanti = new SqlConnection("Data Source = SEDEN\\SQLEXPRESS; Initial Catalog = PinNoteDB; Integrated Security = True; Encrypt=False;");
            baglanti.Open();
            SqlCommand mail_ctrl = new SqlCommand("SELECT ID FROM USER_DATA WHERE MAIL = @Mail", baglanti);
            mail_ctrl.Parameters.AddWithValue("@Mail", mail);
            SqlDataReader sqlDataReader_mail = mail_ctrl.ExecuteReader();

            if (sqlDataReader_mail.Read())
            {
                // Doğrulama kodunu yolla
                SendEmail(verify_code, mail_box.Text);

            }
            else
            {
                //hata msj goster
                MessageBox.Show("wrong mail!");
                
            }
            sqlDataReader_mail.Close();

            

            
        }

        public static string verify_maker(int verify_code_len)
        {
            const string verify_char = "1234567890qwertyuopasdfghjklizxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM@*-+/!?.-_&%$";
            StringBuilder sb = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < verify_code_len; i++)
            {
                int idx = random.Next(verify_char.Length);
                sb.Append(verify_char[idx]);
            }
            return sb.ToString();
        }

        private void SendEmail(string verify_code, string user_mail)
        {
            string subjectEmail = "Verify Code";
            string bodyEmail = "Your verify code for reset password: " + verify_code;

            using (SmtpClient smtp = new SmtpClient("smtp.outlook.com")) // SMTP sunucusu
            {
                smtp.Port = 587; // SMTP port numarası
                smtp.Credentials = new NetworkCredential("pinnote_app@hotmail.com", "XqWchh6s!Y"); // E-posta hesabı bilgileri
                smtp.EnableSsl = true; // SSL/TLS

                // E-posta oluştur
                MailMessage mailMessage = new MailMessage("pinnote_app@hotmail.com", user_mail)
                {
                    Subject = subjectEmail,
                    Body = bodyEmail
                };

                try
                {
                    smtp.Send(mailMessage);
                    MessageBox.Show("Mail sent successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error sending email: " + ex.Message);
                }
            }
        }

        private void verify_code_box_TextChanged(object sender, EventArgs e)
        {
            verify_check = verify_code_box.Text;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (verify_code == verify_check)
            {
                sifre_sifirlama_5 sifre_Sifirlama_5 = new sifre_sifirlama_5();
                sifre_Sifirlama_5.Show();
                this.Hide();
            }
        }

        
    }
}
