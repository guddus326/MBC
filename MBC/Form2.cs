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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            button1.Text = "START";
            label1.Text = "미백싹싹";

            pictureBox1.Load(@"C:\\Users\\s2019\\Desktop\\workspace\\MBC\\syringe.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBox2.Load(@"C:\\Users\\s2019\\Desktop\\workspace\\MBC\\syringe.png");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;             // 추가
            Form3 showForm3 = new Form3();
            showForm3.ShowDialog();
        }

     
    }
}
