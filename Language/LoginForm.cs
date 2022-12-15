using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Language
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";

        }

        private void button5_Click(object sender, EventArgs e)
        {
          //  button5.BackColor = Color.White;
         //   button5.BackColor=SystemColors.Control;
        //  textBox1.Text=="admin" 
                if(textBox1.Text=="admin" &&textBox2.Text=="1234")
            {
                this.Hide();
                Form1 form = new Form1();
                form.ShowDialog();
                form = null;
                this.Show();
                button5.PerformClick();

            }
            else
            {
                MessageBox.Show("Login yoki parol noto'g'ri");
            }
                    
            
        }
        
   

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3();
            form.ShowDialog();
            form = null;
            this.Show();
        }

        private void panel2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void panel2_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void button5_Enter(object sender, EventArgs e)
        {
        
        }
    }
}
