﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            sql_class.initialize_db();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MonthlyView mv = new MonthlyView();
            Application.Run(mv);
        }
    }
}
