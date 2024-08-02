using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static pinnotedeskup.Program;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Microsoft.Graph.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Globalization;


namespace pinnotedeskup
{
    public partial class reminder_olusturma_10 : Form
    {
        int onemdrc=1;
        string mailaddress = string.Empty;
        int? reminderID = null;
        List<int> paylasilanlar = new List<int>();
        List<int> addedfriendsids = new List <int>();
        bool duzenleme;
        bool mail;
        List<int> friends = new List<int>();
        string mail_body;
        List<bool>mailyolla = new List<bool>();
        List<bool> duzenizin = new List<bool>();
        int index;



        SqlConnection baglanti = new SqlConnection("Data Source = SEDEN\\SQLEXPRESS; Initial Catalog = PinNoteDB; Integrated Security = True; Encrypt=False;");
        
        public reminder_olusturma_10(int? reminderId)
        {
            baglanti.Open();
            InitializeComponent();
            //reminderid null değilse çalışacak
            if (reminderId != null)
            {
                reminderID = reminderId.Value;
                //not bilgilerini ekrana yazdir
                string sql = $"SELECT REMINDER_NAME, REMINDER_BODY, REMINDER_IMPLVL FROM REMINDERS WHERE REMINDER_ID=@id ";
                using (SqlCommand sqlCommand = new SqlCommand(sql, baglanti))
                {
                    sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = reminderID.Value;
                    SqlDataReader sqlDataReader_reminder_read = sqlCommand.ExecuteReader();
                    while (sqlDataReader_reminder_read.Read())
                    {
                        reminder_title_box.Text = sqlDataReader_reminder_read.GetString(0);
                        reminder_box.Text = sqlDataReader_reminder_read.GetString(1);
                        int imp = sqlDataReader_reminder_read.GetInt32(2);

                        if (imp == 1) { comboBox1.SelectedIndex = 0; }
                        else if (imp == 2) { comboBox1.SelectedIndex = 1; }
                        else if (imp == 3) { comboBox1.SelectedIndex = 2; }
                        else if (imp == 4) { comboBox1.SelectedIndex = 3; }
                        else if (imp == 5) { comboBox1.SelectedIndex = 4; }
                    }
                    sqlDataReader_reminder_read.Close();
                }
            }
            else
            {
                reminder_box.Text = "";
                reminder_title_box.Text = "";
                reminderId = null;
                date.Value = DateTime.Now;
                saat.SelectedIndex = 9;
                comboBox1.SelectedIndex = 1;
            }

             //arkadaslar listesini yazdır
            
            string tablename = "FRIENDS_" + user_data.Id;

            using (SqlCommand arkadaslariyazdir = new SqlCommand($"SELECT FriendID FROM {tablename}", baglanti))
            {
                SqlDataReader reader = arkadaslariyazdir.ExecuteReader();
                while (reader.Read())
                {
                    friends.Add(reader.GetInt32(0));  // FriendID değerlerini listeye ekle
                }
                reader.Close();
            }

            foreach (int id in friends)
            {
                using (SqlCommand listboxyazdir = new SqlCommand("SELECT NAME, SURNAME, MAIL FROM USER_DATA WHERE ID=@id", baglanti))
                {
                    listboxyazdir.Parameters.AddWithValue("@id", id);
                    SqlDataReader arkadasisim = listboxyazdir.ExecuteReader();
                    while (arkadasisim.Read())
                    {
                        string isim = arkadasisim.GetString(0);
                        string soyisim = arkadasisim.GetString(1);
                        mailaddress = arkadasisim.GetString(2);
                        addfriend.Rows.Add(id, isim, soyisim,false,false,"Add"); // DataGridView'e veri ekler
                    }
                    arkadasisim.Close();
                }
            }
            baglanti.Close();
        }

        //add friend table
        private void addfriend_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(addfriend.Rows[e.RowIndex].Cells[0].Value);
            int index = 0;
            for (int i = 0; i<addedfriendsids.Count; i++)
            {
                if (addedfriendsids[i] == id)
                {
                    index = i; break;
                }
            }
            if (e.RowIndex >= 0 && (e.ColumnIndex == addfriend.Columns["edit"].Index))
            {
               duzenleme = Convert.ToBoolean(addfriend.Rows[e.RowIndex].Cells["edit"].Value);
                duzenizin[index] = duzenleme;
                
            }
            if (e.ColumnIndex == addfriend.Columns["mail"].Index)
            {
               mail = Convert.ToBoolean(addfriend.Rows[e.RowIndex].Cells["mail"].Value);
                mailyolla[index] = duzenleme;
            }
        }
        private void addfriend_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && (e.ColumnIndex == addfriend.Columns["editcheck"].Index || e.ColumnIndex == addfriend.Columns["mail_bildirim"].Index))
            {
                addfriend.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            // Tıklanan hücrenin buton olup olmadığını ve "add" isimli buton olup olmadığını kontrol et
            if (e.RowIndex >= 0 && e.ColumnIndex == addfriend.Columns["add"].Index)
            {
                try
                {
                    int arkdsId = Convert.ToInt32(addfriend.Rows[e.RowIndex].Cells[0].Value);
                    // Listede bu ID yoksa ekleme işlemini yap
                    if (!addedfriendsids.Contains(arkdsId))
                    {
                        string arkdsname = Convert.ToString(addfriend.Rows[e.RowIndex].Cells[1].Value);
                        string arkdssur = Convert.ToString(addfriend.Rows[e.RowIndex].Cells[2].Value);
                        bool edt = Convert.ToBoolean(addfriend.Rows[e.RowIndex].Cells[3].Value);
                        bool m = Convert.ToBoolean(addfriend.Rows[e.RowIndex].Cells[4].Value);

                        // Arkadaş bilgilerini yeni tabloya ekle
                        added_friend.Rows.Add(arkdsId, arkdsname, arkdssur, edt, m, "Add");

                        // ID'yi listeye ekle
                        addedfriendsids.Add(arkdsId) ;
                        duzenizin.Add(edt);
                        mailyolla.Add(m);
                        MessageBox.Show("Arkadaş eklendi: " + arkdsname + " " + arkdssur);
                    }
                    else
                    {
                        MessageBox.Show("Bu arkadaş zaten listeye eklenmiş.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }
       
        //added friend table
        private void added_friend_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(addfriend.Rows[e.RowIndex].Cells[0].Value);
            for (int i = 0; i < addedfriendsids.Count; i++)
            {
                if (addedfriendsids[i] == id)
                {
                    index = i; break;
                }
            }
            // Tıklanan hücrenin buton olup olmadığını ve "del" isimli buton olup olmadığını kontrol et
            if (e.RowIndex >= 0 && e.ColumnIndex == added_friend.Columns["del"].Index)
            {

                try
                {
                    addedfriendsids.Remove(addedfriendsids[index]);
                    mailyolla.Remove(mailyolla[index]);
                    duzenizin.Remove(duzenizin[index]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }
        private void added_friend_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int id = Convert.ToInt32(added_friend.Rows[e.RowIndex].Cells[0].Value);
            for (int i = 0; i < addedfriendsids.Count; i++)
            {
                if (addedfriendsids[i] == id)
                {
                    index = i; break;
                }
            }
            if (e.RowIndex >= 0 && (e.ColumnIndex == added_friend.Columns["edit"].Index))
            {
                duzenleme = Convert.ToBoolean(added_friend.Rows[e.RowIndex].Cells["edit"].Value);
                duzenizin[index] = duzenleme;

            }
            if (e.ColumnIndex == added_friend.Columns["mail"].Index)
            {
                mail = Convert.ToBoolean(added_friend.Rows[e.RowIndex].Cells["mail"].Value);
                mailyolla[index] = duzenleme;
            }
        }
        
        //bos
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //hatırlatıcı açıklama, null olabilir
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //hatırlatılacak tarih, null olamaz
        }
        private void reminder_olusturma_10_Load(object sender, EventArgs e)
        {

        }
       
        //yan menu
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            homepage homepage = new homepage();
            homepage.Show();
            this.Hide();
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            notes notes = new notes();
            notes.Show();
            this.Hide();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            reminder_liste reminderlist = new reminder_liste();
            reminderlist.Show(); 
            this.Hide();
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Friends friends = new Friends();
            friends.Show();
            this.Hide();
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            profile profile = new profile();
            profile.Show();
            this.Hide();
        }

        //kaydet ve mail yolla
        private void SendEmail(string paylasan, string paylasılanmailadresi, string mailbody)
        {
            baglanti.Open();
            string subjectEmail = paylasan + " share a reminder with you.";
            string bodyEmail = mailbody;

            using (SmtpClient smtp = new SmtpClient("smtp.outlook.com")) // SMTP sunucusu
            {
                smtp.Port = 587; // SMTP port numarası
                smtp.Credentials = new NetworkCredential("pinnote_app@hotmail.com", "XqWchh6s!Y"); // E-posta hesabı bilgileri
                smtp.EnableSsl = true; // SSL/TLS

                // E-posta oluştur
                MailMessage mailMessage = new MailMessage("pinnote_app@hotmail.com", paylasılanmailadresi)
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
            baglanti.Close();
        }
        private void button1_Click_2(object sender, EventArgs e)
        {
            baglanti.Open();
            int onemdrc = Convert.ToInt32(comboBox1.SelectedValue);


            if (reminderID != null)
            {
                //değişiklikleri kaydet
                if (!string.IsNullOrWhiteSpace(reminder_title_box.Text) && !string.IsNullOrWhiteSpace(reminder_box.Text))
                {
                    string updateSql = @"UPDATE REMINDERS SET REMINDER_NAME = @remname, REMINDER_BODY = @remBody, REMINDER_DATE=@remdate, REMINDER_IMPLVL = @ImpLevel WHERE REMINDER_ID = @remId;";
                    using (SqlCommand command = new SqlCommand(updateSql, baglanti))
                    {
                        // parametreleri ayarla
                        command.Parameters.AddWithValue("@remId", reminderID);
                        command.Parameters.AddWithValue("@remname", reminder_title_box.Text);
                        command.Parameters.AddWithValue("@remBody", reminder_box.Text);
                        command.Parameters.AddWithValue("@ImpLevel", onemdrc);
                        command.Parameters.AddWithValue("@remdate", date.Value);
                        command.ExecuteNonQuery();
                    }
                }
                baglanti.Close();
                MessageBox.Show("Reminder saved successfully.");
            }
            else
            {
                
                DateTime hatirlatma = date.Value;
                if (!string.IsNullOrWhiteSpace(reminder_title_box.Text) && !string.IsNullOrWhiteSpace(reminder_box.Text))
                {
                    // Notları REMINDERS tablosuna ekle
                    string insertnote = "INSERT INTO REMINDERS (REMINDER_NAME, REMINDER_BODY, REMINDER_DATE, REMINDER_IMPLVL, REMINDER_CREATER) VALUES (@Notetitle, @Notebody, @Reminderdate, @Imp_level, @Createrid)";
                    using (SqlCommand command = new SqlCommand(insertnote, baglanti))
                    {
                        command.Parameters.AddWithValue("@Notetitle", reminder_title_box.Text);
                        command.Parameters.AddWithValue("@Notebody", reminder_box.Text);
                        command.Parameters.AddWithValue("@Reminderdate", hatirlatma);
                        command.Parameters.AddWithValue("@Imp_level", onemdrc);
                        command.Parameters.AddWithValue("@Createrid", user_data.Id);

                        command.ExecuteNonQuery();
                    }

                    // En son eklenen Reminder'ın ID'sini al
                    string getReminderIdQuery = "SELECT IDENT_CURRENT('REMINDERS')";  // Varsayılan olarak son eklenen ID'yi döner
                    int reminderID;
                    using (SqlCommand sqlsorgu = new SqlCommand(getReminderIdQuery, baglanti))
                    {
                        reminderID = Convert.ToInt32(sqlsorgu.ExecuteScalar()); // ID değerini döndür
                    }

                    // REMINDER_ID'yi kullanıcının REMINDER tablosuna ekle
                    string note_table_name = "REMINDER_" + user_data.Id;
                    string insert_note_id = $"INSERT INTO {note_table_name} (REMINDER_ID, REMINDER_EDIT) VALUES (@Noteid, @Edit)";
                    using (SqlCommand command1 = new SqlCommand(insert_note_id, baglanti))
                    {
                        command1.Parameters.AddWithValue("@Noteid", reminderID);
                        command1.Parameters.AddWithValue("@Edit", 1);
                        command1.ExecuteNonQuery();
                    }
                    MessageBox.Show("Reminder saved successfully.");

                    //paylasilan arkadaslara reminder ekleme
                    try
                    {
                        int a = 0;
                        foreach (int id in addedfriendsids)
                        {
                            string note_table_name1 = $"REMINDER_{id}";
                            string insert_rem_id = $"INSERT INTO {note_table_name1} (REMINDER_ID, REMINDER_EDIT) VALUES (@remid, @Edit)";

                            using (SqlCommand command1 = new SqlCommand(insert_rem_id, baglanti))
                            {
                                command1.Parameters.AddWithValue("@remid", reminderID);
                                command1.Parameters.AddWithValue("@Edit", duzenizin[a]);
                                command1.ExecuteNonQuery();
                            }
                            if (mailyolla[a])
                            {
                                string paylasan = user_data.Name + " " + user_data.Surname;
                                mail_body = paylasan + " shared a reminder with you.\n" + reminder_title_box.Text + "\n" + reminder_box.Text + "\n" + date.Value;
                                SendEmail(paylasan, mailaddress, mail_body);
                            }
                            a++;
                        }
                        homepage homepage = new homepage();
                        homepage.Show();
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("An error occurred: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Title or body can not be empty");
                }
            }
            homepage homepage1 = new homepage();
            homepage1.Show();
            this.Hide();
        }
    }
}
