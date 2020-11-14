using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace MBC
{
    public partial class Form7 : Form
    {
        WindowsMediaPlayer Player = new WindowsMediaPlayer();
        Boolean setting = false;
        String file_path = null;
        int hour;
        int min;
        int sec;
        int time = 0;
        int schedule = 0;
        String settingTime = "";
        String s;

        int status = 0;
        protected override void WndProc(ref Message m)
        {
            // StringBuilder sb = new StringBuilder();
            if (m.Msg == UsbAlarm.WM_DEVICECHANGE)
            {
                Debug.WriteLine("Form1: " + DateTime.Now + ": " + m.Msg + ", " + m.WParam.ToInt64() + ", " + m.LParam.ToInt64());
                //sb.AppendFormat("Form1: " + DateTime.Now + ": " + m.Msg + ", " + m.WParam.ToInt64() + ", " + m.LParam.ToInt64());
                if (m.WParam.ToInt64() == 32768)
                {
                    status = 1;
                }
                else if (m.WParam.ToInt64() == 32772)
                {
                    status = 0;
                }
            }

            base.WndProc(ref m);
        }
        public Form7()
        {
            InitializeComponent();
            Player.URL = "bell.wav"; 
        }
        
        private void Timer_tick_Tick(object sender, EventArgs e)
        {
            lbl_realtime.Text = "현재 시각 : " + DateTime.Now.ToLongTimeString();
            if(setting == true)
            {
                time -= 1;
                if(time <= 0)
                {
                    setting = false;
                    button1.Visible = true;
                    time = 0;
                    MessageBox.Show("알람이 울립니다.");
                }
            }
            s = DateTime.Now.ToString("HHmmss");
            
            int day = WhatDay;
            if (status==1) { 
                switch (s)
                {
                    case "094920":
                        Thread.Sleep(10000);
                        Player.controls.play();
                        MessageBox.Show("1교시가 끝났습니다. USB 분리");
                        schedule = 1;
                        break;
                    case "103920":
                        Thread.Sleep(10000);
                        Player.controls.play();
                        MessageBox.Show("2교시가 끝났습니다. USB 분리");
                        schedule = 1;
                        break;
                    case "112920":
                        Thread.Sleep(10000);
                        Player.controls.play();
                        MessageBox.Show("3교시가 끝났습니다. USB 분리");
                        schedule = 1;
                        break;
                    case "121920":
                        Thread.Sleep(10000);
                        Player.controls.play();
                        MessageBox.Show("4교시가 끝났습니다. USB 분리");
                        schedule = 1;
                        break;
                    case "140920":
                        Thread.Sleep(10000);
                        Player.controls.play();
                        MessageBox.Show("5교시가 끝났습니다. USB 분리");
                        schedule = 1;
                        break;
                    case "145920":
                        Thread.Sleep(10000);
                        Player.controls.play();
                        MessageBox.Show("6교시가 끝났습니다. USB 분리");
                        schedule = 1;
                        break;
                    case "154920":
                        Thread.Sleep(10000);
                        Player.controls.play();
                        MessageBox.Show("7교시가 끝났습니다. USB 분리");
                        schedule = 1;
                        break;
                    case "185350":
                        Thread.Sleep(10000);
                        Player.controls.play();
                        MessageBox.Show("7교시가 끝났습니다. USB 분리");
                        schedule = 1;
                        break;
                }
            }
        }

        private void ReportStatus(string message) => throw new NotImplementedException();


        private void button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine(s);
            
            hour = (int)numericUpDown1.Value;

            Debug.WriteLine(hour);
            min = (int)numericUpDown2.Value;
            Debug.WriteLine(min);
            sec = (int)numericUpDown3.Value; 
            Debug.WriteLine(sec);
           // settingTime = Convert.ToString(hour) + Convert.ToString(min) + Convert.ToString(sec);
            Debug.WriteLine(settingTime);

            for (; hour >= 1; hour--)
           {
                time += 3600;
           }
          for(; min >= 1; min--)
          {
                time += 60;
          }
          for(; sec >= 1; sec--)
          {
                time += 1;
          }
            button1.Visible = false;
            setting = true;
        }
        private int WhatDay
        {
            get
            {
                DayOfWeek day = DateTime.Now.DayOfWeek;

                int iReturn = 0;

                if (day == DayOfWeek.Saturday || day == DayOfWeek.Sunday)
                    iReturn = -1;
                else
                    iReturn = 1;
                return iReturn;
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            Player.controls.stop();
        }
    }
}
