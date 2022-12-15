using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Language
{
    public partial class Form1 : Form
    {
        //string cs = @"URI=file:Data\army.db";

        private const string conStr = "Data Source = army.db; Version=3;";
        DataTable dt = new DataTable();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public Form1()
        {
            InitializeComponent();
            populate();
             string execPath = Assembly.GetEntryAssembly().Location;
            Debug.WriteLine(execPath);
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3();
            form.ShowDialog();
            form = null;
            this.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // rasmni ochadigan dastur
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //rasmni  ochadigan dastur
            openFileDialog1.Filter = "Select image (*.Jpg; *.png; *Gif) |*.Jpg; *.png; *Gif";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                Debug.WriteLine(Path.GetFileName(openFileDialog1.FileName));
            }
        }
        //datagriga chiqarish
        private void populate()
        {

            using (SQLiteConnection con = new SQLiteConnection(conStr))
            using (SQLiteCommand com = new SQLiteCommand("select * from UserTab", con))
            using (SQLiteDataAdapter da = new SQLiteDataAdapter(com))
            {

                con.Open();
                com.ExecuteNonQuery();
                dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }

        }
        //insert
        private void button1_Click(object sender, EventArgs e)
        {
           File.Copy(openFileDialog1.FileName, ".\\Resources\\"+Path.GetFileName(openFileDialog1.FileName));

            using (SQLiteConnection con = new SQLiteConnection(conStr))
            using (SQLiteCommand com = new SQLiteCommand("insert into UserTab( Uzbek, English, Russian, Information, image) values( @Uzbek, @English, @Russian, @Information, @image)", con))
            {
                con.Open();
                //cmd.Parameters.AddWithValue("Id", textBox1.Text);
                com.Parameters.AddWithValue("Uzbek", textBox2.Text);
                com.Parameters.AddWithValue("English", textBox3.Text);
                com.Parameters.AddWithValue("Russian", textBox4.Text);
                com.Parameters.AddWithValue("Information", textBox5.Text);
                com.Parameters.AddWithValue("image", Path.GetFileName(openFileDialog1.FileName)); // Faqat rasm nomini saqlab qoladi
                com.ExecuteNonQuery();
               
                MessageBox.Show("Ma'lumot qo'shildi");
                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                pictureBox1.Image = Image.FromFile(".\\Resources\\rasm1.jpg");
            }

            populate();

        }

        //Update ishlamadi
        private void button2_Click(object sender, EventArgs e)
        {

            using (SQLiteConnection con = new SQLiteConnection(conStr))
                try
                {
                    if ( textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || openFileDialog1.FileName == "")
                    {
                        MessageBox.Show("O'zgartirmioqchi bo'lgan ma'lumotingizni tanlang");
                    }

                    else
                    {
                        File.Copy(openFileDialog1.FileName, ".\\Resources\\" + Path.GetFileName(openFileDialog1.FileName));
                      
                        

                        con.Open();
                     

                        string query = "update  UserTab set  Uzbek='" + textBox2.Text + "',English='" + textBox3.Text + "',Russian='" + textBox4.Text + "',Information=' " + textBox5.Text + "'where image=' " + Path.GetFileName(openFileDialog1.FileName) + "";

                        SQLiteCommand cmd = new SQLiteCommand(query, con);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ma'lumot o'zgardi");
                        con.Close();

                        populate();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        pictureBox1.Image = Image.FromFile(".\\Resources\\rasm1.jpg");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }



        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "English", textBox6.Text);
        }

        //RESET:
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            pictureBox1.Image = Image.FromFile(".\\Resources\\rasm1.jpg");
        }

        //datagritdan texboxlargaa chiqarish
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                try
                {
                    pictureBox1.Image = Image.FromFile(".\\Resources\\"+ row.Cells[5].Value.ToString());
                }
                catch
                {
                    pictureBox1.Image = Image.FromFile(".\\Resources\\no-image-available.png"); //Agar rasm mavjud bolmasa rasm yoqligini bildiruvchi rasm chiqaradi
                }
            }
        }


        //delete
        private void button3_Click(object sender, EventArgs e)
        {
            using (SQLiteConnection con = new SQLiteConnection(conStr))
                try
                {
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("O'chirmoqchi bo'lgan ma'lumotingizni tanlang");
                    }

                    else
                    {
                        con.Open();
                        string query = "delete from  UserTab where Id=" + textBox1.Text + "";

                        SQLiteCommand cmd = new SQLiteCommand(query, con);
                        //    cmd.Parameters.AddWithValue("@image",pictureBox1.Image);    
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Ma'lumot o'zgardi");
                        con.Close();
                        populate();
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        pictureBox1.Image = Image.FromFile(".\\Resources\\rasm1.jpg");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Test");
            if(this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // this.Close();
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "Search") 
            {
                textBox6.Text = "";
                textBox6.ForeColor = Color.Black;
            }
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            this.WindowState=FormWindowState.Minimized;
        }
    }
}

