using System;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MonthlyView mv = new MonthlyView();
            Application.Run(mv);
            // todo: Set up monthly view with current month, e.g. 
            // mv.SetStartDay(0-6 for sun-sat) ; Backend.GetMonthStartDay(2/2019) --> 0-6
            // mv.SetMonthLength(backend.GetMonthLength(2/2019));
            // mv.SetPreviousMonthLeng(backend.GetMonthLength(1/2019));
        }
    }
}
