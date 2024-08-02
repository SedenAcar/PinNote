using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static pinnotedeskup.Program;
using System.IO;

namespace pinnotedeskup
{
    public partial class profile : Form
    {
        /*sql baglanti*/
        SqlConnection baglanti = new SqlConnection("Data Source = SEDEN\\SQLEXPRESS; Initial Catalog = PinNoteDB; Integrated Security = True; Encrypt=False;");

        public profile()
        {
            InitializeComponent();
            user_id_box.Text = Convert.ToString(user_data.Id);
            try
            {
                // SQL komutu
                string sql = "SELECT NAME, SURNAME, PHONE, MAIL, BIRTH_DATE, PHOTO FROM USER_DATA WHERE ID = @id";

                using (SqlCommand vericekme = new SqlCommand(sql, baglanti))
                {
                    // Parametre ekleme
                    vericekme.Parameters.AddWithValue("@id", user_data.Id);

                    // Bağlantıyı aç
                    baglanti.Open();

                    using (SqlDataReader reader = vericekme.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usr_name_box.Text = reader["NAME"].ToString();
                            user_surname_box.Text = reader["SURNAME"].ToString();
                            user_phonenum_box.Text = reader["PHONE"].ToString();
                            user_mail_box.Text = reader["MAIL"].ToString();

                            // Fotoğraf okuma, varsa
                            if (!reader.IsDBNull(reader.GetOrdinal("PHOTO"))) // Burada doğru sütun adı kullanılıyor
                            {
                                byte[] imageData = (byte[])reader["PHOTO"];
                                using (MemoryStream ms = new MemoryStream(imageData))
                                {
                                    System.Drawing.Image profilephoto = System.Drawing.Image.FromStream(ms);
                                    profile_pic_box.Image = profilephoto;
                                }
                            }
                            else
                            {
                                profile_pic_box.Image = null; // veya varsayılan bir resim atayabilirsiniz
                            }
                        }
                        else
                        {
                            MessageBox.Show("No user found with the provided ID.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                baglanti.Close(); // Bağlantıyı her durumda kapat
            }
        }


        private void pictureBox8_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            //User tel no
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //mail ile bildirim yolla/yollama
        }

        private void pp_change_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png"; 
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                profile_pic_box.ImageLocation = openFileDialog.FileName;
                resim_textbox.Text = openFileDialog.FileName;
                SaveImageToDatabase(openFileDialog.FileName);
            }
        }


        private void usr_name_box_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void user_surname_box_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void user_mail_box_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void user_phonenum_box_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void user_id_box_TextChanged(object sender, EventArgs e)
        {
        }

        private byte[] ImageToByteArray(string imagePath)
        {
            using (var imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                var binaryReader = new BinaryReader(imageStream);
                return binaryReader.ReadBytes((int)imageStream.Length);
            }
        }

        private void SaveImageToDatabase(string imagePath)
        {
            byte[] imageBytes = ImageToByteArray(imagePath);
            
            string sql = "UPDATE USER_DATA SET PHOTO = @Photo WHERE ID = @Id";
            using (SqlCommand command = new SqlCommand(sql, baglanti))
            {
                command.Parameters.AddWithValue("@Photo", imageBytes);
                command.Parameters.AddWithValue("@Id", user_data.Id); 

                baglanti.Open();
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Profile photo updated successfully.");
                }
                else
                {
                    MessageBox.Show("No record was updated.");
                }
            }
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
    }

}
