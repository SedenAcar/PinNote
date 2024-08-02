using Microsoft.Graph.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static pinnotedeskup.Program;

namespace pinnotedeskup
{
    public partial class friendprofile : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source = SEDEN\\SQLEXPRESS; Initial Catalog = PinNoteDB; Integrated Security = True; Encrypt=False;");
        public friendprofile(int friendID)
        {
            InitializeComponent();
            
            baglanti.Open();
            //profil foto
            using (SqlCommand friendsinfo = new SqlCommand("SELECT NAME, SURNAME, MAIL, PHOTO FROM USER_DATA WHERE ID=@ID", baglanti))
            {
                try
                {
                    friendsinfo.Parameters.AddWithValue("@ID", friendID);
                    using (SqlDataReader sqlDataReader_friendsinfo = friendsinfo.ExecuteReader())
                    {
                        while (sqlDataReader_friendsinfo.Read())
                        {
                            textBox1.Text=friendID.ToString();
                            textBox2.Text = (sqlDataReader_friendsinfo.GetString(0));
                            textBox3.Text = (sqlDataReader_friendsinfo.GetString(1));
                            textBox4.Text = sqlDataReader_friendsinfo.GetString(2);
                            if (!sqlDataReader_friendsinfo.IsDBNull(3))
                            {
                                byte[] imageData = (byte[])sqlDataReader_friendsinfo["PHOTO"];
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    pictureBox1.Image = System.Drawing.Image.FromStream(ms);
                                }
                            }
                        }
                        sqlDataReader_friendsinfo.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            baglanti.Close();
            /*********************************************************/
            //ortak notlar
            /*
            string mytable_name = "NOTES_" + user_data.Id;
            string friendtable_name = "NOTES_" + friendID;
            List<int> noteid1 = new List<int>();
            List<int> noteid2 = new List<int>();
            List<int> ortaknotes = new List<int>();

            using (SqlCommand noteid_ctrl = new SqlCommand($"SELECT NOTE_ID FROM {mytable_name}", baglanti))
            {
                using (SqlDataReader sqlDataReader_noteid = noteid_ctrl.ExecuteReader())
                {
                    while (sqlDataReader_noteid.Read())
                    {
                        noteid1.Add(sqlDataReader_noteid.GetInt32(0));
                    }
                    sqlDataReader_noteid.Close();
                }
            }

            using (SqlCommand noteid_ctrl = new SqlCommand($"SELECT NOTE_ID FROM {friendtable_name}", baglanti))
            {
                using (SqlDataReader sqlDataReader_noteid = noteid_ctrl.ExecuteReader())
                {
                    while (sqlDataReader_noteid.Read())
                    {
                        noteid2.Add(sqlDataReader_noteid.GetInt32(0));
                    }
                    sqlDataReader_noteid.Close();
                }
            }

            foreach (int noteid in noteid1)
            {
                if (noteid2.Contains(noteid))
                {
                    ortaknotes.Add(noteid);
                }
            }
            
            //note tablosundan verileri çekme
            foreach (int note_id in ortaknotes)
            {
                SqlCommand table_read = new SqlCommand("SELECT NOTE_TITLE, NOTE_BODY, UPDATE_TIME FROM NOTES WHERE NOTEID = @id", baglanti);
                table_read.Parameters.AddWithValue("@id", note_id);
                SqlDataReader sqlDataReader_tableread = table_read.ExecuteReader();
                while (sqlDataReader_tableread.Read())
                {
                    string title = sqlDataReader_tableread.GetString(0);
                    string body = sqlDataReader_tableread.GetString(1);
                    DateTime update = sqlDataReader_tableread.GetDateTime(2);
                    this.ortaknotes.Rows.Add(note_id, title, body, update);
                    MessageBox.Show(Convert.ToString(note_id));
                }
                sqlDataReader_tableread.Close();
            }

            /*********************************************************/
            //ortak hatırlatıcılar
            /*
            string mytable_namerem = "REMINDER_" + user_data.Id;
            string friendtable_namerem = "REMINDER_" + friendID;
            List<int> remid1 = new List<int>();
            List<int> remid2 = new List<int>();
            List<int> ortakrems = new List<int>();

            using (SqlCommand noteid_ctrlrem = new SqlCommand($"SELECT REMINDER_ID FROM {mytable_namerem}", baglanti))
            {
                using (SqlDataReader sqlDataReader_noteidrem = noteid_ctrlrem.ExecuteReader())
                {
                    while (sqlDataReader_noteidrem.Read())
                    {
                        remid1.Add(sqlDataReader_noteidrem.GetInt32(0));
                    }
                    sqlDataReader_noteidrem.Close();
                }
            }

            using (SqlCommand noteid_ctrlrem = new SqlCommand($"SELECT REMINDER_ID FROM {friendtable_namerem}", baglanti))
            {
                using (SqlDataReader sqlDataReader_noteidrem = noteid_ctrlrem.ExecuteReader())
                {
                    while (sqlDataReader_noteidrem.Read())
                    {
                        remid2.Add(sqlDataReader_noteidrem.GetInt32(0));
                    }
                    sqlDataReader_noteidrem.Close();
                }
            }
            
            foreach (int id in remid1)
            {
                if (remid2.Contains(id)) 
                { 
                    ortakrems.Add(id); 
                }
            }


            //note tablosundan verileri çekme
            foreach (int remid in ortakrems)
            {
                SqlCommand table_readrem = new SqlCommand("SELECT NOTE_TITLE, NOTE_BODY, UPDATE_TIME FROM NOTES WHERE NOTEID = @id", baglanti);
                table_readrem.Parameters.AddWithValue("@id", remid);
                SqlDataReader sqlDataReader_tablereadrem = table_readrem.ExecuteReader();
                while (sqlDataReader_tablereadrem.Read())
                {
                    string title = sqlDataReader_tablereadrem.GetString(0);
                    string body = sqlDataReader_tablereadrem.GetString(1);
                    DateTime update = sqlDataReader_tablereadrem.GetDateTime(2);
                    ortakreminders.Rows.Add(remid, title, body, update);

                }
                sqlDataReader_tablereadrem.Close();
            }
            */
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string tableDeleteName = "FRIENDS_" + user_data.Id;
                string sql = $"DELETE FROM {tableDeleteName} WHERE FriendID = @id";
                baglanti.Open();
                using (SqlCommand delFriend = new SqlCommand(sql, baglanti))
                {
                    // friend_id değişkeninin integer olduğunu varsayarak
                    int id = Convert.ToInt32(friend_id.Text);

                    // Parametreyi AddWithValue kullanarak ekleyin
                    delFriend.Parameters.AddWithValue("@id", id);

                    int rowsAffected = delFriend.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Deleted!");
                    }
                    else
                    {
                        MessageBox.Show("No record found with the specified ID.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }


    }
}
