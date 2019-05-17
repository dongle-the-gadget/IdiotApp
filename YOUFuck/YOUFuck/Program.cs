using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YOUFuck
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(args.Length > 0 &&
                args[0] == "/fuck")
            {
                FormsApplication.Run(new frmRegFuck());
            }
            else
            {
                FormsApplication.Run(new Form1(Debugger.IsAttached));
            }
        }
    }
}
