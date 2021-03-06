﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MBC
{
    public partial class Form4 : Form
    {
        

        public Form4()
        {
            InitializeComponent();
            //pictureBox1.Load(@"C:\\Users\\s2019\\Desktop\\workspace\\MBC\\USB.png");
            pictureBox1.Load(@"C:\\MBC\\USB.png");
        }
        string status = "";
        protected override void WndProc(ref Message m)
        {
            // StringBuilder sb = new StringBuilder();
            if (m.Msg == UsbAlarm.WM_DEVICECHANGE)
            {
                Debug.WriteLine("Form1: " + DateTime.Now + ": " + m.Msg + ", " + m.WParam.ToInt64() + ", " + m.LParam.ToInt64());
                //sb.AppendFormat("Form1: " + DateTime.Now + ": " + m.Msg + ", " + m.WParam.ToInt64() + ", " + m.LParam.ToInt64());
                if (m.WParam.ToInt64() == 32768)
                {
                    status = "연결";
                }
                else if (m.WParam.ToInt64() == 32772)
                {
                    status = "해제";
                }
            }

            base.WndProc(ref m);
        }

       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = status;
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form3 showForm3 = new Form3();
            showForm3.ShowDialog();
        }
    }
}
