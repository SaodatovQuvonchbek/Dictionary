using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Language
{
    public partial class UzbekControl : UserControl
    {
        public UzbekControl()
        {
            InitializeComponent();
            populate();
        }
        private const string conStr = "Data Source=army.db;Version=3;";
        DataTable dt = new DataTable();


        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
          
        }

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        { //File.Copy(openFileDialog1.FileName, ".\\Resources\\"+Path.GetFileName(openFileDialog1.FileName));

          
           
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

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                dt.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", "Uzbek", textBox6.Text);
            }
            catch
            {
            }

          
        }

        private void textBox6_Enter_1(object sender, EventArgs e)
        {

            if (textBox6.Text == "Qidiruv")
            {
                textBox6.Text = "";
                textBox6.ForeColor = Color.Black;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBox3.Text = row.Cells[3].Value.ToString();
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

        private void UzbekControl_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
