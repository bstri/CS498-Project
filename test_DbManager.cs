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
            //Test inserting appointment fct
            row_int = sql_class.insert_appointment("1993-12-25", "Jacks birth");
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
            sql_class.insert_appointment("1993-12-25", "Cool dude");
            sql_class.insert_appointment("1993-12-25", "test");
            sql_class.insert_appointment("1993-12-25", "test2");
            List<sql_row> ret_list = sql_class.get_appointments("1993-12-25");
            foreach(sql_row row in ret_list)
            {
                Console.WriteLine(row.apt_date + ' ' + row.desc);
            }
            Console.ReadKey();
        }
    }
}
