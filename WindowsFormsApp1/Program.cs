using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
           
                Application.EnableVisualStyles();
               // Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Start();
            Autodesk.AutoCAD.ApplicationServices.Application.ShowModelessDialog(new Form1());


            //Autodesk.AutoCAD.ApplicationServices.Application.ShowModalDialog(new Form1());
            //Autodesk.AutoCAD.ApplicationServices.Application.ShowModelessDialog(new Form1());
        }

    }
}
