using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MBC
{
    public partial class Form9 : System.Windows.Forms.Form
    {

        public Form9()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(textBox1.Text);
            if(string.IsNullOrWhiteSpace(textBox2.Text))
            {
                foreach(var file in dirInfo.GetFiles())
                {
                    file.Delete();
                }
            }
            else
            {
                foreach(var file in dirInfo.GetFiles(textBox2.Text))
                {
                    file.Delete();
                }
            }
            if(checkBox1.Checked)
            {
                try
                {
                    dirInfo.Delete();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

   
    }
}
