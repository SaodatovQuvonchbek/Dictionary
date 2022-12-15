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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Language
{
    public partial class RussianControl1 : UserControl
    {
        public RussianControl1()
        {
            InitializeComponent();
            populate();
        }
        private const string conStr = "Data Source=army.db;Version=3;";
        DataTable dt = new DataTable();
       

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Russian", textBox6.Text);

        }
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      

        private void textBox6_Enter_1(object sender, EventArgs e)
        {

            if (textBox6.Text == "Поиск") 
            {
                textBox6.Text = "";
                textBox6.ForeColor = Color.Black;
            }
        }

       

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox3.Text = row.Cells[1].Value.ToString();
                textBox4.Text = row.Cells[2].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                try
                {
                    pictureBox1.Image = Image.FromFile(".\\Resources\\" + row.Cells[5].Value.ToString());
                }
                catch
                {
                    pictureBox1.Image = Image.FromFile(".\\Resources\\no-image-available.png"); //Agar rasm mavjud bolmasa rasm yoqligini bildiruvchi rasm chiqaradi
                }
            }
        }

     

        private void textBox6_Enter(object sender, EventArgs e)
        {
            if (textBox6.Text == "Поиск")
            {
                textBox6.Text = "";
                textBox6.ForeColor = Color.Black;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Russian", textBox6.Text);
        }

        private void textBox6_Enter_2(object sender, EventArgs e)
        {
            if (textBox6.Text == "Поиск")
            {
                textBox6.Text = "";
                textBox6.ForeColor = Color.Black;
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox3.Text = row.Cells[1].Value.ToString();
                textBox4.Text = row.Cells[2].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                try
                {
                    pictureBox1.Image = Image.FromFile(".\\Resources\\" + row.Cells[5].Value.ToString());
                }
                catch
                {
                    pictureBox1.Image = Image.FromFile(".\\Resources\\no-image-available.png"); //Agar rasm mavjud bolmasa rasm yoqligini bildiruvchi rasm chiqaradi
                }
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
