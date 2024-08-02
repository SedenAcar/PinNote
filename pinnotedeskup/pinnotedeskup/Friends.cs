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
using Microsoft.Graph.Models;
using Microsoft.VisualBasic;
using pinnotedeskup.wgt;
using static System.Net.Mime.MediaTypeNames;
using static pinnotedeskup.Program;

namespace pinnotedeskup
{
    public partial class Friends : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source = SEDEN\\SQLEXPRESS; Initial Catalog = PinNoteDB; Integrated Security = True; Encrypt=False;");
        
        public Friends()
        {
            InitializeComponent();
            

            baglanti.Open();

            //arkdas id çekme
            string table_name = "FRIENDS_" + user_data.Id;
            List<int> friendsids = new List<int>();
            using (SqlCommand friendslist = new SqlCommand($"SELECT FriendID FROM {table_name}",baglanti))
            {
                try
                {
                    using(SqlDataReader friends_list =friendslist.ExecuteReader())
                    {
                        
                        while (friends_list.Read())
                        {
                            int friendID = friends_list.GetInt32(0);
                            friendsids.Add(friendID);
                        }
                        friends_list.Close();
                    }
                }
                catch (Exception ex)
                { 
                    MessageBox.Show("Error: " + ex.Message); 
                }                

            }

            //arkadas bilgilerini çekme
            foreach (int friendID in friendsids) 
            {
                using (SqlCommand friendsinfo = new SqlCommand("SELECT NAME, SURNAME, PHOTO FROM USER_DATA WHERE ID=@ID", baglanti))
                {
                    try
                    {
                        friendsinfo.Parameters.AddWithValue("@ID", friendID);
                        using (SqlDataReader sqlDataReader_friendsinfo = friendsinfo.ExecuteReader())
                        {
                            while (sqlDataReader_friendsinfo.Read())
                            {
                                string name = (sqlDataReader_friendsinfo.GetString(0));
                                string surname = (sqlDataReader_friendsinfo.GetString(1));
                                if (!sqlDataReader_friendsinfo.IsDBNull(2)) 
                                {
                                    byte[] imageData = (byte[])sqlDataReader_friendsinfo["PHOTO"];
                                    using (MemoryStream ms = new MemoryStream(imageData))
                                    {
                                        System.Drawing.Image profilephoto = System.Drawing.Image.FromStream(ms);
                                        dataGridView1.Rows.Add(profilephoto, name + " " + surname, friendID);
                                    }
                                }
                                else
                                {
                                    dataGridView1.Rows.Add(null, name + " " + surname, friendID);
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
            }           
        }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                int idColumnIndex = 2;
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[idColumnIndex].Value);
                friendprofile friendprofile = new friendprofile(id);
                friendprofile.Show();
                this.Hide();
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            //add friends
            string add_id = Interaction.InputBox("Add friends id:", "Add Friend!");
            if (!string.IsNullOrEmpty(add_id))
            {
                // ID'nin USER_DATA tablosunda mevcut mu
                string idvarmi = "SELECT COUNT(1) FROM USER_DATA WHERE ID = @add_id";
                using (SqlCommand checkid = new SqlCommand(idvarmi, baglanti))
                {
                    checkid.Parameters.AddWithValue("@add_id", int.Parse(add_id));

                    // Kullanıcı ID'sinin var olup olmadığını kontrol edin
                    int userExists = (int)checkid.ExecuteScalar();

                    if (userExists > 0)
                    {
                        string tablename = "FRIENDS_" + user_data.Id;
                        string eklimi = $"SELECT COUNT(1) FROM {tablename} WHERE FriendID = @add_id";
                        using (SqlCommand checkfriend = new SqlCommand(eklimi, baglanti))
                        {
                            checkfriend.Parameters.AddWithValue("@add_id", int.Parse(add_id));
                            int ekli = (int)checkfriend.ExecuteScalar();
                            if(ekli <= 0)
                            {
                                // Kullanıcı ID'si mevcutsa arkadaşlık isteğini ekleyin
                                string table_name = "REQUESTS_" + add_id;
                                string insertid = "INSERT INTO " + table_name + " (RequesterID, RequestDate) VALUES (@myid, @date)";

                                using (SqlCommand addfriend = new SqlCommand(insertid, baglanti))
                                {
                                    // Parametreler oluşturulur ve değerleri atanır
                                    addfriend.Parameters.AddWithValue("@myid", user_data.Id);
                                    addfriend.Parameters.AddWithValue("@date", DateTime.Now);

                                    try
                                    {
                                        addfriend.ExecuteNonQuery();
                                        MessageBox.Show("Request sent!");
                                    }
                                    catch (SqlException ex)
                                    {
                                        MessageBox.Show("An error occurred while sending the request: " + ex.Message);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("This person is already on your list.");
                            }
                        }     
                    }
                    else
                    {
                        // Kullanıcı ID'si mevcut değilse hata mesajı göster
                        MessageBox.Show("The specified user ID does not exist.");
                    }
                }
            }  
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            homepage homepage = new homepage();
            homepage.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IsteklerEkran isteklerEkran = new IsteklerEkran();
            isteklerEkran.Show();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            notes notes = new notes(); notes.Show(); this.Hide();
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
    }
}
