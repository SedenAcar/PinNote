using pinnotedeskup.wgt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static pinnotedeskup.Program;

namespace pinnotedeskup
{
    public partial class homepage : Form
    {

        SqlConnection baglanti = new SqlConnection("Data Source = SEDEN\\SQLEXPRESS; Initial Catalog = PinNoteDB; Integrated Security = True; Encrypt=False;");


        public homepage()
        {
            InitializeComponent();
            //MessageBox.Show(user_data.Name + user_data.Email);
            //note
            baglanti.Open();
            string table_name = "NOTES_" + user_data.Id;
            List<int> note_id_list = new List<int>();
            List<bool> note_edit_list = new List<bool>();
            //database veri çekme(note)
            notetablewriter();
            //database veri çekme (reminder)
            remindertablewriter();
            //db name çekme
            using (SqlCommand name_ctrl = new SqlCommand("SELECT NAME FROM USER_DATA WHERE ID = @id", baglanti))
            {
                name_ctrl.Parameters.AddWithValue("@id", user_data.Id);
                using (SqlDataReader sqlDataReader_nameread = name_ctrl.ExecuteReader())
                {
                    while (sqlDataReader_nameread.Read())
                    {
                        string alinan_veri = Convert.ToString(sqlDataReader_nameread["NAME"]);
                        label2.Text = "Merhaba " + alinan_veri + "!";
                    }
                }
            }

            //takvim verisi
            List<int> reminderIds = new List<int>();
            string reminderTable = $"REMINDER_{user_data.Id}";
            using (SqlCommand cmd = new SqlCommand($"SELECT REMINDER_ID FROM {reminderTable}", baglanti))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    
                    while (reader.Read())
                    {
                        reminderIds.Add(reader.GetInt32(0));
                    }
                }
            }
            foreach (int reminderId in reminderIds)
            {
                using (SqlCommand innerCmd = new SqlCommand("SELECT REMINDER_DATE FROM REMINDERS WHERE REMINDER_ID = @id", baglanti))
                {
                    innerCmd.Parameters.AddWithValue("@id", reminderId);
                    using (SqlDataReader innerReader = innerCmd.ExecuteReader())
                    {
                        while (innerReader.Read())
                        {
                            DateTime reminderDate = innerReader.GetDateTime(0);

                            monthCalendar1.AddBoldedDate(reminderDate);
                        }
                    }
                }
            }
            monthCalendar1.UpdateBoldedDates();
            //masaustu bildirim
            foreach (int reminderId in reminderIds)
            {
                using (SqlCommand innerCmd = new SqlCommand("SELECT REMINDER_DATE,REMINDER_NAME, REMINDER_BODY FROM REMINDERS WHERE REMINDER_ID = @id", baglanti))
                {
                    innerCmd.Parameters.AddWithValue("@id", reminderId);
                    using (SqlDataReader innerReader = innerCmd.ExecuteReader())
                    {
                        while (innerReader.Read())
                        {
                            DateTime reminderDate = innerReader.GetDateTime(0);
                            string reminderName = innerReader.GetString(1);
                            string reminderbody = innerReader.GetString(2);
                            // Şu anki zaman ile hatırlatıcı tarihi arasındaki fark
                            TimeSpan difference = reminderDate - DateTime.Now;
                            // Eğer fark 0'a eşitse bildirim göster
                            if (difference == TimeSpan.Zero)
                            {
                                // Hatırlatıcı zamanı geldiğinde bildirim göster
                                DialogResult result = MessageBox.Show(reminderName, reminderbody, MessageBoxButtons.OKCancel);
                                if (result == DialogResult.OK)
                                {
                                    // "OK" butonuna tıklanırsa yapılacak işlemler
                                    // Örneğin, başka bir formu açabilirsiniz
                                    reminder_olusturma_10 rem = new reminder_olusturma_10(reminderId);
                                    rem.Show();
                                    this.Hide();
                                }
                                else if (result == DialogResult.Cancel)
                                {
                                    
                                }
                            }
                        }
                    }
                }
            }

            
        }

        private void Form6_Load(object sender, EventArgs e)
        {
           
        }
        //yan menu
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //home
            homepage homepage = new homepage();
            homepage.Show();
            this.Hide();    
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //notlar
            notes notes = new notes();
            notes.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //hatırlatıcı
            reminder_liste reminder_Liste = new reminder_liste();
            reminder_Liste.Show();
            this.Hide();

        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //arkadaslar
            Friends friends = new Friends();
            friends.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //profil
            profile profile = new profile();
            profile.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //home
            homepage homepage1 = new homepage();
            homepage1.Show();
            this.Hide();
        }

        //
        private void button1_Click_1(object sender, EventArgs e)
        {
            //bildirimler
        }

        private void remindergrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (remindergrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                try
                {
                    int reminderIdColumnIndex = remindergrid.Columns["ReminderID"].Index;
                    if (!int.TryParse(remindergrid.Rows[e.RowIndex].Cells[reminderIdColumnIndex].Value.ToString(), out int reminderId))
                    {
                        MessageBox.Show("Reminder ID could not be parsed.");
                        return;
                    }

                    if (remindergrid.Columns[e.ColumnIndex].Name == "rem_edit")
                    {
                        EditReminder(reminderId);
                        
                    }
                    else if (remindergrid.Columns[e.ColumnIndex].Name == "delete_rem")
                    {
                        DeleteReminder(reminderId);
                        remindertablewriter();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void EditReminder(int reminderId)
        {
            reminder_olusturma_10 reminder_Olusturma_10 = new reminder_olusturma_10(reminderId);
            reminder_Olusturma_10.Show();
            this.Hide();
        }

        private void DeleteReminder(int reminderId)
        {
            string tablename = $"REMINDER_{user_data.Id}";
            string sqlsorgustr = $"DELETE FROM {tablename} WHERE REMINDER_ID = @delete";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlsorgustr, baglanti))
                {
                    cmd.Parameters.AddWithValue("@delete", reminderId);
                    cmd.ExecuteNonQuery();
                }
                this.Refresh();
                MessageBox.Show("Reminder deleted successfully.");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete reminder: {ex.Message}");
            }
        }


        private void notegrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (notegrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                try
                {
                    int noteIdColumnIndex = notegrid.Columns["NoteID"].Index;
                    if (!int.TryParse(notegrid.Rows[e.RowIndex].Cells[noteIdColumnIndex].Value.ToString(), out int noteId))
                    {
                        MessageBox.Show("Note ID could not be parsed.");
                        return;
                    }

                    if (notegrid.Columns[e.ColumnIndex].Name == "edit")
                    {
                        EditNote(noteId);
                        this.Refresh();
                    }
                    else if (notegrid.Columns[e.ColumnIndex].Name == "delete")
                    {
                        DeleteNote(noteId);
                        notetablewriter();
                        this.Refresh();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void EditNote(int noteId)
        {
            newnote newNoteForm = new newnote(noteId);
            newNoteForm.Show();
            this.Hide();
        }

        private void DeleteNote(int noteId)
        {
            string tablename = $"NOTES_{user_data.Id}";
            string sqlsorgustr = $"DELETE FROM {tablename} WHERE NOTE_ID = @delete";
            try
            {
                using (SqlCommand cmd = new SqlCommand(sqlsorgustr, baglanti))
                {
                    cmd.Parameters.AddWithValue("@delete", noteId);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Note deleted successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to delete note: {ex.Message}");
            }


        }

        private void notetablewriter ()
        {
            string notetablename = "NOTES_"+user_data.Id;
            List<int> note_id_list = new List<int>();
            List<bool> note_edit_list = new List<bool>();
            

            using (SqlCommand noteid_ctrl = new SqlCommand($"SELECT NOTE_ID, EDIT FROM {notetablename}", baglanti))
            {
                using (SqlDataReader sqlDataReader_noteid = noteid_ctrl.ExecuteReader())
                {
                    while (sqlDataReader_noteid.Read())
                    {
                        note_id_list.Add(sqlDataReader_noteid.GetInt32(0));
                        note_edit_list.Add(sqlDataReader_noteid.GetBoolean(1));
                    }
                    sqlDataReader_noteid.Close();
                }
            }
            //note tablosundan verileri çekme
            foreach (int note_id in note_id_list)
            {
                SqlCommand table_read = new SqlCommand("SELECT NOTE_TITLE, NOTE_BODY, UPDATE_TIME FROM NOTES WHERE NOTEID = @id", baglanti);
                table_read.Parameters.AddWithValue("@id", note_id);
                SqlDataReader sqlDataReader_tableread = table_read.ExecuteReader();
                while (sqlDataReader_tableread.Read())
                {
                    string title = sqlDataReader_tableread.GetString(0);
                    string body = sqlDataReader_tableread.GetString(1);
                    DateTime update = sqlDataReader_tableread.GetDateTime(2);
                    notegrid.Rows.Add(note_id, title, body, update, "Edit", "Del");

                }
                sqlDataReader_tableread.Close();
            }
        }

        private void remindertablewriter ()
        {
            //reminder
            string reminder_name = "REMINDER_" + user_data.Id;
            List<int> reminder_id = new List<int>();
            List<bool> reminder_edit = new List<bool>();

            using (SqlCommand reminderid_ctrl = new SqlCommand($"SELECT REMINDER_ID, REMINDER_EDIT FROM {reminder_name}", baglanti))
            {
                using (SqlDataReader sqlDataReader_reminderid = reminderid_ctrl.ExecuteReader())
                {
                    while (sqlDataReader_reminderid.Read())
                    {
                        reminder_id.Add(sqlDataReader_reminderid.GetInt32(0));
                        reminder_edit.Add(sqlDataReader_reminderid.GetBoolean(1));
                    }
                }
            }
            //reminder tablosundan verileri çekme
            foreach (int i in reminder_id)
            {
                SqlCommand table_read = new SqlCommand("SELECT REMINDER_NAME, REMINDER_BODY, REMINDER_DATE FROM REMINDERS WHERE REMINDER_ID = @id", baglanti);
                table_read.Parameters.AddWithValue("@id", i);
                using (SqlDataReader reader = table_read.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string title = reader.GetString(0);
                        string body = reader.GetString(1);
                        DateTime hatirlatma = reader.GetDateTime(2);
                        remindergrid.Rows.Add(i, title, body, hatirlatma, "Edit", "Del");
                    }
                }

            }
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newnote newnote = new newnote(null);
            newnote.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reminder_olusturma_10 reminder_Olusturma_10 = new reminder_olusturma_10(null);
            reminder_Olusturma_10 .Show();
            this .Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            IsteklerEkran isteklerEkran = new IsteklerEkran();
            isteklerEkran.Show();
        }

    }
}
