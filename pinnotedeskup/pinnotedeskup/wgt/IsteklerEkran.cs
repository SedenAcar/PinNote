using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using static pinnotedeskup.Program;

namespace pinnotedeskup.wgt
{
    public partial class IsteklerEkran : Form
    {
        private DateTime lastCheck = DateTime.Now;
        SqlConnection baglanti = new SqlConnection("Data Source = SEDEN\\SQLEXPRESS; Initial Catalog = PinNoteDB; Integrated Security = True; Encrypt=False;");

        public IsteklerEkran()
        {
            InitializeComponent();
            LoadRequests();
        }

        private void LoadRequests()
        {
            string tableName = "REQUESTS_" + user_data.Id;
            List<int> requestIds = new List<int>();
            baglanti.Open();
            // İstek ID'lerini çekme
            using (SqlCommand requestList = new SqlCommand($"SELECT RequesterID FROM {tableName}", baglanti))
            {
                using (SqlDataReader reader = requestList.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        requestIds.Add(reader.GetInt32(0));
                    }
                }
            }

            // Kişi bilgilerini çekme
            foreach (int reqID in requestIds)
            {
                using (SqlCommand friendsInfo = new SqlCommand("SELECT NAME, SURNAME FROM USER_DATA WHERE ID = @ID", baglanti))
                {
                    friendsInfo.Parameters.AddWithValue("@ID", reqID);
                    using (SqlDataReader reader = friendsInfo.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString(0);
                            string surname = reader.GetString(1);
                            istek.Rows.Add(reqID, name, surname, "Accept", "Decline");
                        }
                    }
                }
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void istek_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && istek.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                int friendId = Convert.ToInt32(istek.Rows[e.RowIndex].Cells[0].Value);

                if (istek.Columns[e.ColumnIndex].Name == "accept")
                {
                    AcceptRequest(friendId);
                }
                else if (istek.Columns[e.ColumnIndex].Name == "decline")
                {
                    RemoveRequest(friendId);
                }
            }
        }

        private void AcceptRequest(int friendId)
        {
            string tableName = "FRIENDS_" + user_data.Id;
            baglanti.Open();
            using (SqlCommand command = new SqlCommand($"INSERT INTO {tableName} (FriendID, AddedDate) VALUES (@friendId, @date)", baglanti))
            {
                command.Parameters.AddWithValue("@friendId", friendId);
                command.Parameters.AddWithValue("@date", DateTime.Now);
                command.ExecuteNonQuery();
            }
            RemoveRequest(friendId);
            baglanti.Close();
        }

        private void RemoveRequest(int friendId)
        {
            string tableName = "REQUESTS_" + user_data.Id;
            baglanti.Open();
            using (SqlCommand command = new SqlCommand($"DELETE FROM {tableName} WHERE RequesterID = @friendId", baglanti))
            {
                command.Parameters.AddWithValue("@friendId", friendId);
                command.ExecuteNonQuery();
            }
            // DataGridView'dan satırı kaldırma
            foreach (DataGridViewRow row in istek.Rows)
            {
                if (Convert.ToInt32(row.Cells[0].Value) == friendId)
                {
                    istek.Rows.Remove(row);
                    break;
                }
            }
            baglanti.Close ();
        }
    }
}
