using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace MBC
{
    public partial class Form1 : Form
    {
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
                    label1.Text = "인터넷 연결이 되어 있습니다.";
                }
                else
                {
                    label1.Text = "인터넷 연결이 끊어 졌습니다.";
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
    }
}
