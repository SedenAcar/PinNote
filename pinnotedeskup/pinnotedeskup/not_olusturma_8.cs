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
    public partial class newnote : Form
    {
        int onemdrc = 1;
        int? note_id=null;
        int newnote_id;
        Dictionary<int, bool> paylasim = new Dictionary<int, bool>();

        SqlConnection baglanti = new SqlConnection("Data Source = SEDEN\\SQLEXPRESS; Initial Catalog = PinNoteDB; Integrated Security = True; Encrypt=False;");
        public newnote(int? noteid)
        {
            InitializeComponent();
            
            if (noteid!=null) 
            {
                note_id = noteid.Value;
                //not bilgilerini ekrana yazdir
                string sql = $"SELECT NOTE_TITLE, NOTE_BODY, IMP_LEVEL FROM NOTES WHERE NOTEID=@id ";
                using (SqlCommand sqlCommand = new SqlCommand(sql, baglanti))
                {
                    baglanti.Open();

                    sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = note_id.Value;
                    SqlDataReader sqlDataReader_noteread = sqlCommand.ExecuteReader();
                    while (sqlDataReader_noteread.Read())
                    {
                        note_title_box.Text = sqlDataReader_noteread.GetString(0);
                        note_body.Text = sqlDataReader_noteread.GetString(1);
                        int imp = sqlDataReader_noteread.GetInt32(2);

                        if (imp == 1) { comboBox1.SelectedIndex = 0; }
                        else if (imp == 2) { comboBox1.SelectedIndex = 1; }
                        else if (imp == 3) { comboBox1.SelectedIndex = 2; }
                        else if (imp == 4) { comboBox1.SelectedIndex = 3; }
                        else if (imp == 5) { comboBox1.SelectedIndex = 4; }
                    }
                    baglanti.Close();
                }
            }
            else 
            { 
                note_body.Text = "";
                note_title_box.Text = "";
            }   

        }
        private void button1_Click(object sender, EventArgs e)
        {

            int onemdrc = Convert.ToInt32(comboBox1.SelectedValue);
            if (note_id!=null)
            {
                //değişiklikleri kaydet
                if (!string.IsNullOrWhiteSpace(note_title_box.Text) && !string.IsNullOrWhiteSpace(note_body.Text))
                {
                    string updateSql = "UPDATE NOTES SET NOTE_TITLE = @NoteTitle, NOTE_BODY = @NoteBody, IMP_LEVEL = @ImpLevel, UPDATE_TIME = @UpdateTime WHERE NOTEID = @NoteId;";
                    using (SqlCommand command = new SqlCommand(updateSql, baglanti))
                    {
                        // Parametreleri ayarla
                        command.Parameters.AddWithValue("@NoteId", note_id); // Güncellenecek notun ID'si
                        command.Parameters.AddWithValue("@NoteTitle", note_title_box.Text);
                        command.Parameters.AddWithValue("@NoteBody", note_body.Text);
                        command.Parameters.AddWithValue("@ImpLevel", onemdrc); // Önem derecesi
                        command.Parameters.AddWithValue("@UpdateTime", DateTime.Now); // Güncelleme zamanı
                        baglanti.Open();
                        command.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Degisiklikler kaydedildi."); 

                        homepage homepage = new homepage();
                        homepage.Show();
                        this.Hide();
                    }
                    
                }

            }
            
            else
            {
                if (!string.IsNullOrWhiteSpace(note_title_box.Text) && !string.IsNullOrWhiteSpace(note_body.Text))
                {
                    
                    baglanti.Open();
                    //notu notlar tablosuna ekler
                    int impLevel = Convert.ToInt32(comboBox1.SelectedValue);
                    string insertnote = @"INSERT INTO NOTES (NOTE_TITLE, NOTE_BODY, IMP_LEVEL, UPDATE_TIME, CREATER_ID) VALUES (@Notetitle, @Notebody, @Imp_level, @Updatetime, @Createrid);
                    SELECT SCOPE_IDENTITY();"; // son identitiy değeri alır
                    using (SqlCommand command = new SqlCommand(insertnote, baglanti))
                    {
                        command.Parameters.AddWithValue("@Notetitle", note_title_box.Text);
                        command.Parameters.AddWithValue("@Notebody", note_body.Text);
                        command.Parameters.AddWithValue("@Imp_level", impLevel); 
                        command.Parameters.AddWithValue("@Updatetime", DateTime.Now);
                        command.Parameters.AddWithValue("@Createrid", user_data.Id);  
                        newnote_id = Convert.ToInt32(command.ExecuteScalar());
                    }
                    //notu kullanıcının tablosuna ekler
                    string noteidadd = "NOTES_"+user_data.Id;
                    string insertnoteadd = $"INSERT INTO {noteidadd} (NOTE_ID, EDIT) VALUES (@noteid, @edit)";
                    using (SqlCommand sqlnote = new SqlCommand(insertnoteadd, baglanti))
                    {
                        sqlnote.Parameters.AddWithValue("@noteid", newnote_id);
                        sqlnote.Parameters.AddWithValue("@edit", true);
                        sqlnote.ExecuteNonQuery();
                        MessageBox.Show("Saved!");
                        homepage homepage1 = new homepage();
                        homepage1.Show();
                        this.Hide();
                    }
                    baglanti.Close(); 

                }

                else { MessageBox.Show("Title or body can not be empty"); }
            }

            //tabloya ekleme
            foreach (var kvp in paylasim)
            {
                string tablenamearkds = "NOTES_" + kvp.Key;
                using (SqlCommand arkdsnot = new SqlCommand($"INSERT INTO {tablenamearkds} (NOTE_ID, EDIT) VALUES (@noteid, @edit)", baglanti))
                {
                    arkdsnot.Parameters.AddWithValue("@noteid", kvp.Key); 
                    arkdsnot.Parameters.AddWithValue("@edit", kvp.Value); 

                    baglanti.Open(); 
                    arkdsnot.ExecuteNonQuery();
                    baglanti.Close(); 
                }
            }

        }

        private void newnote_Load(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
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
            reminder_liste reminder_Liste = new reminder_liste();
            reminder_Liste.Show();
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int friendctrl = Convert.ToInt32(textBox1.Text);
            bool editper = checkBox1.Checked;
            List<int> friends = new List<int>();
            baglanti.Open();
            string friendstable = "FRIENDS_" + user_data.Id;
            //arkadaşlar listesini çek
            using (SqlCommand sqlfriend = new SqlCommand($"SELECT FriendID FROM {friendstable}",baglanti))
            {
                friends.Add(Convert.ToInt32(sqlfriend.ExecuteScalar()));
            }
            //yazılan id listede var mı kontrol et
            bool eklimi = friends.Contains(friendctrl);
            string name = string.Empty;
            string surname = string.Empty;
            if (eklimi)
            {
                //isim verisi çekme
                using (SqlCommand namecekme = new SqlCommand("SELECT NAME, SURNAME FROM USER_DATA WHERE ID=@id", baglanti))
                {
                    namecekme.Parameters.AddWithValue ("@id", friendctrl);
                    SqlDataReader sqlDataReader_name = namecekme.ExecuteReader();
                    while (sqlDataReader_name.Read())
                    {
                        name = sqlDataReader_name.GetString(0);
                        surname = sqlDataReader_name.GetString(1);
                    }
                }
                paylasim.Add(friendctrl,editper);
                MessageBox.Show("Not paylaşıldı!");
            }
            else
            {
                MessageBox.Show("Arkadaş listenizde bulunmamaktadır.");
            }
            baglanti.Close();
        }
    }
}

