using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MBC
{
    class internet
    {
        public string result;
        public void ConnectInternet()
        {
            SetInternetConnection("renew");
        }

        public void DisconnectInternet()
        {
            SetInternetConnection("release");
        }

        private void SetInternetConnection(string command)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                Arguments = "/C ipconfig /" + command,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(processStartInfo);
            
            if(command== "release")
            {
                result = "인터넷이 연결됨";
            }
            else
            {
                result = "인터넷이 연결되지 않음";
            }
        }
    }
}
