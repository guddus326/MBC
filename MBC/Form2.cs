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

            pictureBox2.Load(@"C:\\Users\\s2019\\Desktop\\workspace\\MBC\\버튼1.png");
            pictureBox1.Load(@"C:\\Users\\s2019\\Desktop\\workspace\\MBC\\로고.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Visible = false;             // 추가
            Form3 showForm3 = new Form3();
            showForm3.ShowDialog();
        }
    }
}
