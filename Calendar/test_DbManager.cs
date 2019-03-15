using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace sqlite_proj
{
    class Program
    {
        static void Main(string[] args)
        {
            string sql_str = "";
            int row_int = 0;
            //Test initializing db fct
            sql_class.initialize_db();
            if (row_int == 1)
            {
                Console.WriteLine("row_int was 1");
            }
            else
            {
                Console.WriteLine("row_int was not 1. It was: " + row_int.ToString());
            }
            //Testing selecting appointment fct
            //sql_str = sql_class.select_appointment("1993-12-25");
            Console.WriteLine(sql_str);
            //Specify year, month, day, time, descr to insert row
            sql_class.insert_appointment(1993, 14, 25, "12:30", "Cool dude");
            //Specify year, month, date to get appointments
            List<sql_row> ret_list = sql_class.get_appointments(1993, 13, 25);
            foreach (sql_row row in ret_list)
            {
                Console.WriteLine(row.apt_year + ' ' + row.apt_month + ' ' + row.apt_day + ' ' + row.apt_time + ' ' + row.desc);
            }
            Console.ReadKey();
        }
    }
}