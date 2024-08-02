using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static pinnotedeskup.Program;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace pinnotedeskup
{
    
    public partial class kayit_ekran_2 : Form
    {
        //DEĞİŞKEN ATAMALARI
        string pas_ctrl = @"^(?=.*[0-9])(?=.*[\W_])(?!.*\s).{8,}$";
        string tel_ctrl = @"^(?:\+?90|0)?[ -]?\d{3}[ -]?\d{3}[ -]?\d{4}$";

        bool name_ctrl = true;
        bool surname_ctrl = true;
        bool email_ctrl = true;
        bool password_ctrl = true;
        bool telnum_ctrl = true;
        bool birth_ctrl = true;
        private DateTime dateTimePicker1_Value;

        SqlConnection baglanti = new SqlConnection("Data Source = SEDEN\\SQLEXPRESS; Initial Catalog = PinNoteDB; Integrated Security = True; Encrypt=False;");
        public kayit_ekran_2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(name_box.Text))
            {
                MessageBox.Show("İsim boş bırakılamaz");
                name_box.Focus();
                return;
            }
            if (!Regex.IsMatch(name_box.Text, @"^[a-zA-Z]+\s*[a-zA-Z]*$"))
            {
                MessageBox.Show("İsim özel karakter veya boşluk içeremez");
                name_box.Text = "";
                name_box.Focus();
                return;
            }

            // Soyisim kontrolü
            if (string.IsNullOrWhiteSpace(surname_box.Text))
            {
                MessageBox.Show("Soyisim boş bırakılamaz");
                surname_box.Focus();
                return;
            }
            if (!Regex.IsMatch(surname_box.Text, @"^[a-zA-Z]+\s*[a-zA-Z]*$"))
            {
                MessageBox.Show("Soyisim özel karakter ve boşluk içeremez");
                surname_box.Text = "";
                surname_box.Focus();
                return;
            }

            // Şifre kontrolü
            if (string.IsNullOrWhiteSpace(pass_box.Text))
            {
                MessageBox.Show("Şifre boş bırakılamaz");
                pass_box.Focus();
                return;
            }
            if (!Regex.IsMatch(pass_box.Text, pas_ctrl))
            {
                MessageBox.Show("Parola uygun değil");
                pass_box.Text = "";
                pass_box.Focus();
                return;
            }

            // E-posta kontrolü
            if (string.IsNullOrWhiteSpace(mail_box.Text))
            {
                MessageBox.Show("E-posta boş bırakılamaz");
                mail_box.Focus();
                return;
            }
            //girilen veriler uygunsa db kontrolü yap
            if (name_ctrl && surname_ctrl && email_ctrl && password_ctrl && telnum_ctrl && birth_ctrl)
            {
                //mail db da mevcut mu
                string sorgu = "SELECT COUNT(*) FROM USER_DATA WHERE E_MAIL = @Email";
                SqlCommand command = new SqlCommand(sorgu, baglanti);
                command.Parameters.AddWithValue("@Email", mail_box.Text);
                try
                {
                    baglanti.Open();
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        email_ctrl = false;
                        MessageBox.Show("mail daha önceden kullanılmış");
                        name_box.Text = ""; mail_box.Focus();
                    }
                    else
                    {
                        email_ctrl = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                //tel no db mevcut mu
                string sorgu2 = "SELECT COUNT(*) FROM USER_DATA WHERE PHONE = @Phone";
                SqlCommand command1 = new SqlCommand(sorgu2, baglanti);
                command1.Parameters.AddWithValue("@Phone", phone_num_box.Text);
                try
                {
                    baglanti.Open();
                    int count = (int)command1.ExecuteScalar();

                    if (count > 0)
                    {
                        telnum_ctrl = false;
                        MessageBox.Show("telefon numarası daha önceden kullanılmış");
                        phone_num_box.Text = "";
                        phone_num_box.Focus();
                    }
                    else
                    {
                        if (Regex.IsMatch(phone_num_box.Text, tel_ctrl)) { telnum_ctrl = true; }//tel no özel karakter içeriyo mu
                        else { MessageBox.Show("Phone number is incorrect or missing"); phone_num_box.Text = ""; phone_num_box.Focus(); }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                //birth kontrol
                if (dateTimePicker1_Value < DateTime.Today) { birth_ctrl = true; }
                else
                {
                    MessageBox.Show("Date of birth cannot be in the future tense", "Invalid birth date");
                }

                //bilgilerin uygun olduğu durumda kayıt oluştur ve ana sayfaya yönlendir
                if (name_ctrl && surname_ctrl && email_ctrl && password_ctrl && telnum_ctrl && birth_ctrl)
                {
                    user_data.Name = name_box.Text;
                    user_data.Surname = surname_box.Text;
                    user_data.Email = mail_box.Text;
                    user_data.Password = pass_box.Text;
                    user_data.PhoneNumber = phone_num_box.Text;
                    user_data.BirthDate = birth.Value;




                    //tabloya kullanıcı bilgilerini ekle
                    string insertdata = "INSERT INTO USER_DATA (NAME, SURNAME, MAIL, PHONE, BIRTH_DATE, REGISTER_DATE) VALUES (@NAME, @SURNAME, @MAIL, @PHONE, @BIRTH, @REGISTER)";
                    using (SqlCommand command2 = new SqlCommand(insertdata, baglanti))
                    {

                        command2.Parameters.AddWithValue("@NAME", user_data.Name);
                        command2.Parameters.AddWithValue("@SURNAME", user_data.Surname);
                        command2.Parameters.AddWithValue("@MAIL", user_data.Email);
                        command2.Parameters.AddWithValue("@PHONE", user_data.PhoneNumber);
                        command2.Parameters.AddWithValue("@BIRTH", user_data.BirthDate);
                        command2.Parameters.AddWithValue("@REGISTER", DateTime.Now);
                        command2.ExecuteNonQuery();
                    }

                    //TABLOYA EKLENDİKTEN SONRA ID BİLGİSİNİ ÇEK
                    string idcekme = "SELECT ID FROM USER_DATA WHERE MAIL = @Email";
                    using (SqlCommand command3 = new SqlCommand(idcekme, baglanti))
                    {
                        command3.Parameters.AddWithValue("@Email", user_data.Email);
                        user_data.Id = Convert.ToInt32(command3.ExecuteScalar());
                    }
                    //MessageBox.Show(Convert.ToString(user_data.Id));
                    //tabloya password ekleme
                    string insertpassword = "INSERT INTO USER_PASSWORD (ID, PASSWORD, LAST_UPDATE) VALUES (@ID, @PASSWORD, @LAST_UPDATE)";
                    using (SqlCommand command3 = new SqlCommand(insertpassword, baglanti))
                    {
                        command3.Parameters.AddWithValue("@ID", user_data.Id);
                        command3.Parameters.AddWithValue("@PASSWORD", user_data.Password);
                        command3.Parameters.AddWithValue("@LAST_UPDATE", DateTime.Now);
                        command3.ExecuteNonQuery();
                    }

                    //yeni kullanıcı için tabloları oluştur

                    // Tabloları oluştur 

                    string note_table = $"NOTES_{user_data.Id}";
                    string create_note_table = $"CREATE TABLE {note_table} ({"NOTE_ID INT PRIMARY KEY, EDIT BIT"})";
                    using (SqlCommand command4 = new SqlCommand(create_note_table, baglanti))
                    {
                        command4.ExecuteNonQuery();
                    }

                    string reminder_table = $"REMINDER_{user_data.Id}";
                    string create_reminder_table = $"CREATE TABLE {reminder_table} ({"REMINDER_ID INT PRIMARY KEY, REMINDER_EDIT BIT"})";
                    using (SqlCommand command5 = new SqlCommand(create_reminder_table, baglanti))
                    {
                        command5.ExecuteNonQuery();
                    }

                    string friends_table = $"FRIENDS_{user_data.Id}";
                    string create_friends_table = $"CREATE TABLE {friends_table} ({"FriendID INT, AddedDate DATETIME"})";
                    using (SqlCommand command6 = new SqlCommand(create_friends_table, baglanti))
                    {
                        command6.ExecuteNonQuery();
                    }

                    string requests_table = $"REQUESTS_{user_data.Id}";
                    string create_requests_table = $"CREATE TABLE {requests_table} ({"RequesterID INT, RequestDate DATETIME"})";
                    using (SqlCommand command7 = new SqlCommand(create_requests_table, baglanti))
                    {
                        command7.ExecuteNonQuery();
                    }
                    //ilk not ve hatırlatıcıyı ekle
                    string firstnote_table = $"NOTES_{user_data.Id}";
                    string firstnoteadd = $"INSERT {firstnote_table} (NOTE_ID, EDIT) VALUES (1000003,0)";
                    using (SqlCommand command8 = new SqlCommand(firstnoteadd, baglanti))
                    {
                        command8.ExecuteNonQuery();
                    }

                    string firstreminder_table = $"REMINDER_{user_data.Id}";
                    string firstreminderadd = $"INSERT {firstreminder_table} (REMINDER_ID, REMINDER_EDIT)VALUES (1000,0)";
                    using (SqlCommand command9 = new SqlCommand(firstreminderadd, baglanti))
                    {
                        command9.ExecuteNonQuery();
                    }

                    string notify_table = $"NOTIFY_{user_data.Id}";
                    string notifytable = $@"CREATE TABLE {notify_table} (BILDIRIM_ID INT IDENTITY(1,1) PRIMARY KEY, PAYLASAN_ID INT NOT NULL, BILDIRIM_DATE DATETIME NOT NULL, PAYLASILAN_ID INT NOT NULL, PAYLASILAN_TUR CHAR(1) NOT NULL)";
                    using (SqlCommand command10 = new SqlCommand(notifytable, baglanti))
                    {
                        command10.ExecuteNonQuery();
                    }

                    baglanti.Close();
                    homepage homepage = new homepage();
                    homepage.Show();
                    this.Hide();
                }
            }
            

            //bilgiler uygun mu kontrol et uygunsa hesabı oluştur ve uygulamaya giriş yap
            //isim soyisim özel karakter ve sayı içeremez
            //sistemde bulunan bir mail yeniden kullanılamaz
            //password en az 8 karakterden oluşmalı ve özel karakter büyük harf küçük hharf ve sayı içermeli
            //telefon numarası daha önce sistemde kayıtlı olmamalı
            //birth date gelecek zaman olamaz
            //telefon numarası ve email adresinin gerçekten var olupolmadığı kontrol edilebiliyorsa kontrol et
            //bütün bilgiler uygunsa unique id tanımla ve verileri database e yolla
            //uygulama ekranına geç

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click_1(object sender, EventArgs e)
        {

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
