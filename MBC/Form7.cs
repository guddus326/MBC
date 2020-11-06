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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MBC
{
    public partial class Form7 : Form
    {

        Boolean setting = false;
        String file_path = null;
        int hour;
        int min;
        int sec;
        int time = 0;

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
        public Form7()
        {
            InitializeComponent();
        }
        
        private void Timer_tick_Tick(object sender, EventArgs e)
        {
            lbl_realtime.Text = "현재 시각 : " + DateTime.Now.ToLongTimeString();
            if(setting == true)
            {
                time -= 1;
                lbl_status.Text = "알람까지 " + time + "초 남았습니다.";
                if(time <= 0)
                {
                    setting = false;
                    radioButton1.Enabled = true;
                    radioButton2.Enabled = true;
                    button1.Visible = true;
                    time = 0;
                    MessageBox.Show("알람이 울립니다.");
                }
            }
        }

        private void Btn_music_load_Click(object sender, EventArgs e)
        {
            String file_path = null;
            ofd_music.InitialDirectory = "C:\\"; //기본 경로 설정
            if(ofd_music.ShowDialog() == DialogResult.OK)   //다이얼로그에서 OK를 눌렀을 때
            {
                file_path = ofd_music.FileName;
                text_soundname.Text = file_path.Split('\\')[file_path.Split('\\').Length - 1];
                //경로를 지우고 파일 이름과 확장자명만 보여줄 때
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer sp = new SoundPlayer(file_path);
                sp.Play();
            }
            catch (Exception ex)
            {
                ReportStatus(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer sp = new SoundPlayer(file_path);
                sp.Stop();
            }
            catch(Exception ex)
            {
                ReportStatus(ex.Message);
            }
        }

        private void ReportStatus(string message)
        {
            throw new NotImplementedException();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                numericUpDown3.Visible = false;
                label3.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                numericUpDown3.Visible = true;
                label3.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)    //알람 버튼이 선택
            {
                hour = (int)numericUpDown1.Value;
                min = (int)numericUpDown2.Value;
                for(; hour >= 1; hour--)
                {
                    time += 3600;
                }
                for(; min >= 1; min--)
                {
                    time += 60;
                }
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                button1.Visible = false;
                setting = true;
            }

            if(radioButton2.Checked == true)    //타이머 버튼 선택
            {
                hour = (int)numericUpDown1.Value;
                min = (int)numericUpDown2.Value;
                sec = (int)numericUpDown3.Value;
                for(; hour >= 1; hour--)
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
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                button1.Visible = false;
                setting = true;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = status;
        }
    }
}
