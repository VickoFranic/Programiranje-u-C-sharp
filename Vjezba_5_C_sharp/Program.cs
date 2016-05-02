using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Vjezba_5
{

    public class Program : Form
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new PersonsListForm());
        }
    }
}
