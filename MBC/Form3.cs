using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MBC
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            //pictureBox1.Load(@"C:\\Users\\s2019\\Desktop\\workspace\\MBC\\USB.png");
            pictureBox1.Load(@"C:\\MBC\\USB.png");
            //pictureBox2.Load(@"C:\\Users\\s2019\\Desktop\\workspace\\MBC\\internet.png");
            pictureBox2.Load(@"C:\\MBC\\internet.png");
            //pictureBox3.Load(@"C:\\Users\\s2019\\Desktop\\workspace\\MBC\\time.png");
            pictureBox3.Load(@"C:\\MBC\\time.png");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form4 showForm4 = new Form4();
            showForm4.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Visible = false;             // 추가
            Form1 showForm1 = new Form1();
            showForm1.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form7 showForm7 = new Form7();
            showForm7.ShowDialog();
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 showForm2 = new Form2();
            showForm2.ShowDialog();
        }
    }
}
