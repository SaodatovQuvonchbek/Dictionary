using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Language
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            UzbekControl uz = new UzbekControl();
            addUserControl(uz);
         //   this.Padding = new Padding(borderSize);

        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel4.Controls.Clear();
            panel4.Controls.Add(userControl);
            userControl.BringToFront();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm form = new LoginForm();
            form.ShowDialog();
            form = null;
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            muallifControl1 muallifControl1 = new muallifControl1();
            addUserControl(muallifControl1);
        }



        private void button2_Click(object sender, EventArgs e)
        {
            RussianControl1 russian = new RussianControl1();
            addUserControl(russian);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            UzbekControl uz = new UzbekControl();
            addUserControl(uz);

        }




        private void button5_Click(object sender, EventArgs e)
        {

            EnglishControl1 english = new EnglishControl1();
            addUserControl(english);

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            pictureBoxmax.Visible = false;
            pictureBoxmin.Visible = true;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxmin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            pictureBoxmax.Visible = true;
            pictureBoxmin.Visible = false;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                pictureBoxmax.Visible = true;
                pictureBoxmin.Visible = false;
            }

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.Visible = true;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            tableLayoutPanel2.Visible = false;
            label6.Text = "Lug'at";
            label7.Text = "AXBOROT-KOMMUNIKATSIYA TEXNOLOGIYALARI VA ALOQA HARBIY INSTITUTI";
            button3.Text = "O'zbek tili";
            button9.Text = "Ingliz tli";
            button2.Text = "Rus tili";
            button7.Text = "Kirish";
            button4.Text = "Sozlamalar";
            button1.Text = "Muallif";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.Visible = false;
            label6.Text = "Dictionary";
            label7.Text = "MILITARY INSTITUTE OF INFORMATION-COMMUNICATION TECHNOLOGIES AND COMMUNICATIONS";
            button3.Text = "Uzbek";
            button9.Text = "English";
            button2.Text = "Russian";
            button7.Text = "Admin";
            button4.Text = "Settings";
            button1.Text = "Author";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tableLayoutPanel2.Visible = false;
            label6.Text = "Словарь";
            label7.Text = "ВОЕННЫЙ ИНСТИТУТ ИНФОРМАЦИОННО-КОММУНИКАЦИОННЫХ ТЕХНОЛОГИЙ И СВЯЗИ";
            button3.Text = "Узбекский ";
            button9.Text = "Английский ";
            button3.Text = "Русский ";
            button7.Text = "Войти";
            button4.Text = "Настройки";
            button1.Text = "Автор";
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            // button3.BackColor = Color.Blue;

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void Form3_Resize(object sender, EventArgs e)
        {
            Adjustfrom();
        }
        private void Adjustfrom()
        { switch(this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(0, 8, 8, 0);
                      break;

           

            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    } }

