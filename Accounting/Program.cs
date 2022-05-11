using System;
using System.Windows.Forms;

namespace Accounting
{
    static class Program
    {
        public static mainFm MainFm;
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool flag = false;
            System.Threading.Mutex Mutex = new System.Threading.Mutex(false, "TVM_Accounting", out flag);
            if (!flag)
            {
                MessageBox.Show("Программа уже запущена!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MainFm = new mainFm();
            Application.Run(MainFm);

            Mutex.Close();
        }
    }
}
