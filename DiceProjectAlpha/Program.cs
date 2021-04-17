using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceProjectAlpha
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LogicController Controller = new LogicController();
            Form2 f2 = new Form2(Controller);
            f2.Show();
            Application.Run(new Form1(Controller));
            
        }
    }
}
