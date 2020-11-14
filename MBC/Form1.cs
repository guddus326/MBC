using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace MBC
{
    public partial class Form1 : Form
    {
        private Timer Timer1 = null;
        private int time = 0;
        Boolean setting = false;
        int hour;
        int min;
        int sec;
        
        int timercount = 0;

        [DllImport("wininet.dll", SetLastError = true)] 
        private extern static bool InternetGetConnectedState(out int lpdwFlags, int dwReserved);
        [Flags] 
        enum ConnectionStates 
        { 
            Modem = 0x1, 
            LAN = 0x2, 
            Proxy = 0x4, 
            RasInstalled = 0x10, 
            Offline = 0x20, 
            Configured = 0x40, 
        }
        System.Threading.Thread thMain; 
        bool bCheck = false;
        
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false; 
            thMain = new System.Threading.Thread(new System.Threading.ThreadStart(Thread_Tick)); 
            //백그라운드 스레드로 지정... 
            thMain.IsBackground = true; 
            button1.Text = "Internet Connect Check Start"; 
            bCheck = true; 
            //스레드 시작... 
            thMain.Start();
        }
        protected override void OnClosed(EventArgs e)
        {
            if (thMain != null)
            { 
                //스레드가 돌고 있으면... 
                if (bCheck ) 
                { 
                    //강제종료... 
                    thMain.Abort (); 
                } 
                //스레드가 일시 정지 상태이면... 
                else 
                { 
                    //대기중인 스레드 종료... 
                    thMain.Interrupt(); 
                } 
                thMain = null; 
            } 
            GC.Collect(); 
            base.OnClosed(e); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!bCheck)
            {
                bCheck = true; 
                //일시정지된 스레드 다시 시작 
                thMain.Resume(); 
                button1.Text = "Internet Connect Check Start"; 
            } 
            else 
            { 
                bCheck = false; 
                //스레드 일시정지 
                thMain.Suspend(); 
                button1.Text = "Internet Connect Check Stop"; 
            } 
        } 
        /// <summary> 
        /// 인터넷 연결 상태 
        /// </summary> 
        /// <returns></returns> 
        public static bool Get_InternetConnectedState() 
        { 
            int flage = 0; 
            return InternetGetConnectedState(out flage, 0);
        }
        private void Thread_Tick()
        {
            while (true)
            {
                if (Get_InternetConnectedState())
                {
                    label1.Text = "인터넷이 연결되었습니다.";
                }
                else
                {
                    label1.Text = "인터넷이 차단되었습니다.";
                }
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            internet i = new internet();
            i.ConnectInternet();
            label1.Text = i.result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            internet i = new internet();
            i.DisconnectInternet();
            label1.Text = i.result;
        }

<<<<<<< HEAD
        private void button4_Click(object sender, EventArgs e)
        {
            Timer1 = new Timer();
            Timer1.Tick += timer1_Tick;
            Timer1.Interval = (int)numericUpDown3.Value*250 ;       
            Timer1.Start();
            button3.Visible = false;

            label2.Text = DateTime.Now.ToLongTimeString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            Debug.WriteLine(time);

            label2.Text = DateTime.Now.ToLongTimeString();


            if (time > 3)
            {
                time = 0;
                Timer1.Enabled = false;
                button3.Visible = true;
                
            }
        }

       
=======
        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Visible = false;             // 추가
            Form3 showForm3 = new Form3();
            showForm3.ShowDialog();
        }
>>>>>>> c37f2bbe0204b6f0f0c741492b164f0704798066
    }
}
