using System;
using System.Windows.Forms;

namespace MBC
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new Form1());
=======
            Application.Run(new Form2());
>>>>>>> c37f2bbe0204b6f0f0c741492b164f0704798066
        }
    }
}
