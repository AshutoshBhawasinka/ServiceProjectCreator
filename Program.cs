using System;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace ServiceProjectCreator {
    class Program {

        static void Main(string[] args)
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Program p = new Program();

        }

    }
}
