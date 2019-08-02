using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGame
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]

        

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form1 = new Form1();
            form1.Wygrana += WeWon;
            Application.Run(form1);
            
        }

        static void WeWon(int time, int trys, Form1 sender)
        {
            sender.Visible = false;
            Form2 form2 = new Form2();
            //form2.Visible = false;
            form2.ShowDialog();
            //sender.Close(); 
        }
    }
}
