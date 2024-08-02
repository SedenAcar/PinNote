using Microsoft.Graph.Models;
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
    public partial class notes : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source = SEDEN\\SQLEXPRESS; Initial Catalog = PinNoteDB; Integrated Security = True; Encrypt=False;");
        public notes()
        {
            InitializeComponent();
            
            string table_name = "NOTES_" + user_data.Id;
            List<int> note_id = new List<int>();
            List<bool> edit = new List<bool>();
            //database veri çekme(reminderid)
            baglanti.Open();
            SqlCommand id_ctrl = new SqlCommand($"SELECT Note_ID, EDIT FROM {table_name}", baglanti);
            SqlDataReader sqlDataReader_noteid = id_ctrl.ExecuteReader();
            while (sqlDataReader_noteid.Read())
            {
                note_id.Add(sqlDataReader_noteid.GetInt32(0));
                edit.Add(sqlDataReader_noteid.GetBoolean(1));
            }
            sqlDataReader_noteid.Close();

            //note tablosundan verileri çekme
            foreach (int id in note_id)
            {
                string query = "SELECT NOTE_TITLE, NOTE_BODY, UPDATE_TIME, IMP_LEVEL, CREATER_ID FROM NOTES WHERE NOTEID = @NoteId";
                SqlCommand table_read = new SqlCommand(query, baglanti);
                table_read.Parameters.AddWithValue("@NoteId", id);

                SqlDataReader sqlDataReader_tableread = table_read.ExecuteReader();

                string title = "", body = "", creater = "";
                DateTime update = DateTime.Now;
                int imp = 0, createrid = 0;

                if (sqlDataReader_tableread.Read())
                {
                    title = sqlDataReader_tableread.GetString(0);
                    body = sqlDataReader_tableread.GetString(1);
                    update = sqlDataReader_tableread.GetDateTime(2);
                    imp = sqlDataReader_tableread.GetInt32(3);
                    createrid = sqlDataReader_tableread.GetInt32(4);
                }
                sqlDataReader_tableread.Close();

                if (createrid != 0)
                {
                    SqlCommand creater_find = new SqlCommand("SELECT NAME, SURNAME FROM USER_DATA WHERE ID=@CreatorId", baglanti);
                    creater_find.Parameters.AddWithValue("@CreatorId", createrid);

                    SqlDataReader read = creater_find.ExecuteReader();
                    if (read.Read())
                    {
                        string creatername = read.GetString(0);
                        string creatersurname = read.GetString(1);
                        creater = creatername + " " + creatersurname;
                    }
                    read.Close();
                }

                dataGridView.Rows.Add(id, title, body, update, imp, creater,"Edit","Del");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //oluşturma sayfasına yönlendir
            newnote newnote = new newnote(null);
            newnote.Show();
            this.Close();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            homepage homepage2 = new homepage();
            homepage2.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            reminder_liste reminder_Liste = new reminder_liste();
            reminder_Liste.Show();
            this.Hide();
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            Friends friends = new Friends();
            friends.Show();
            this.Hide();
        }

        private void pictureBox7_Click_1(object sender, EventArgs e)
        {
            profile profile2 = new profile();
            profile2.Show();
            this.Hide();
        }

        private void dataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int noteIdColumnIndex = 0;
                int noteId = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[noteIdColumnIndex].Value);
                if (dataGridView.Columns[e.ColumnIndex].Name == "edit")
                {
                    // Düzenleme butonu işlemi
                    newnote newNoteForm = new newnote(noteId);
                    newNoteForm.Show();
                    this.Hide();
                }
                else if (dataGridView.Columns[e.ColumnIndex].Name == "delete")
                {
                    // Silme butonu işlemi
                    string deltablename = "NOTES_" + user_data.Id;
                    try
                    {
                        using (SqlCommand delnote = new SqlCommand($"DELETE FROM {deltablename} WHERE NOTE_ID=@notid", baglanti))
                        {
                            delnote.Parameters.AddWithValue("@notid", noteId);
                            delnote.ExecuteNonQuery();
                            MessageBox.Show("Note deleted successfully.");
                        }
                        this.Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting note: " + ex.Message);
                    }
                }
            }
        }

    }
}
