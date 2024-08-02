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
    public partial class reminder_liste : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source = SEDEN\\SQLEXPRESS; Initial Catalog = PinNoteDB; Integrated Security = True; Encrypt=False;");
        public reminder_liste()
        {
            InitializeComponent();
            
            string reminderName = "REMINDER_" + user_data.Id;
            List<int> reminderIds = new List<int>();
            List<bool> reminderEdits = new List<bool>();

            baglanti.Open();
            // ID ve edit bilgilerini çekme
            using (SqlCommand command = new SqlCommand($"SELECT REMINDER_ID, REMINDER_EDIT FROM {reminderName}", baglanti))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reminderIds.Add(reader.GetInt32(0));
                        reminderEdits.Add(reader.GetBoolean(1));
                    }
                }
            }

            // Detayları çekme
            for (int i = 0; i < reminderIds.Count; i++)
            {
                using (SqlCommand detailCommand = new SqlCommand("SELECT REMINDER_NAME, REMINDER_BODY, REMINDER_IMPLVL, REMINDER_DATE, REMINDER_CREATER FROM REMINDERS WHERE REMINDER_ID = @id", baglanti))
                {
                    detailCommand.Parameters.AddWithValue("@id", reminderIds[i]);
                    using (SqlDataReader detailReader = detailCommand.ExecuteReader())
                    {
                        while (detailReader.Read())
                        {
                            string title = detailReader.GetString(0);
                            string body = detailReader.GetString(1);
                            int implvl = detailReader.GetInt32(2);
                            DateTime reminderDate = detailReader.GetDateTime(3);
                            int createrId = detailReader.GetInt32(4);
                            dataGridView.Rows.Add(reminderIds[i], title, body, reminderDate, implvl, createrId, reminderEdits[i], "Del");
                        }
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            reminder_olusturma_10 newreminder_ = new reminder_olusturma_10(null);
            newreminder_.Show();
            this.Hide();
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

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                // Sütun isimlerine göre işlem türünü kontrol et
                if (dataGridView.Columns[e.ColumnIndex].Name == "edit")
                {
                    // Düzenleme işlemi
                    int reminderId = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value);
                    reminder_olusturma_10 reminder_Olusturma_10 = new reminder_olusturma_10(reminderId);
                    reminder_Olusturma_10.Show();
                    this.Hide();
                }
                else if (dataGridView.Columns[e.ColumnIndex].Name == "delete")
                {
                    // Silme işlemi
                    int reminderId = Convert.ToInt32(dataGridView.Rows[e.RowIndex].Cells[0].Value);
                    string remdeletename = "REMINDER_" + user_data.Id;
                    try
                    {
                        using (SqlCommand delreminder = new SqlCommand($"DELETE FROM {remdeletename} WHERE REMINDER_ID=@remid", baglanti))
                        {
                            
                            delreminder.Parameters.AddWithValue("@remid", reminderId);
                            delreminder.ExecuteNonQuery();
                            MessageBox.Show("Reminder deleted successfully.");
                        }
                        this.Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting reminder: " + ex.Message);
                    }
                }
            }
        }

    }
}
