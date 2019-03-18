﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;


namespace Calendar
{
    //This is simply a class to hold the results of a query to get an appointment
    //At this point is simply a storage class with get/set methods.
    public class sql_row
    {
        public sql_row() { }

        public sql_row(long ap_year, long ap_month, long ap_day, string ap_time, string descr)
        {
            apt_year = ap_year;
            apt_month = ap_month;
            apt_day = ap_day;
            apt_time = ap_time;
            desc = descr;
        }

        // Properties.
        public long apt_year { get; set; }
        public long apt_month { get; set; }
        public long apt_day { get; set; }
        public string apt_time { get; set; }
        public string desc { get; set; }

    }

    //This is the meat of the DB manager.
    public class sql_class
    {
        public static void initialize_db()
        {
            //Only bother with database creation if one doesn't exist.
            //This also allows us to call this function each time we
            //start the program.

            //Should consider putting this in an absolute location
            //so if the user moves the calendar program it can still
            //find the DB.
            if (!File.Exists("Calendar_db.sqlite"))
            {
                //VARS
                SQLiteConnection cal_dbconnection;
                string sql_str = "";
                SQLiteCommand sql_cmd;

                //Create the DB file
                SQLiteConnection.CreateFile("Calendar_db.sqlite");

                //Connect to the database we just created
                cal_dbconnection = new SQLiteConnection("Data Source=Calendar_db.sqlite;Version=3;");

                //Open our database
                cal_dbconnection.Open();

                //Create the appointments table
                sql_str = "CREATE TABLE appointments (ap_year integer, ap_month integer, ap_day integer, ap_time varchar(5), desc VARCHAR(250), primary key (ap_year, ap_month, ap_day, ap_time, desc));";
                sql_cmd = new SQLiteCommand(sql_str, cal_dbconnection);
                sql_cmd.ExecuteNonQuery();

                //Finally, we close the database/connection
                cal_dbconnection.Close();
            }
        }

        public static List<Event> GetEvents(DateTime d)
        {
            List<Event> events = new List<Event>();
            // todo
            return events;
        }

        public static List<sql_row> get_appointments(int ap_year, int ap_month, int ap_day)
        {
            //This simply gets all appointments for a given day

            //Connect to the database.
            //This doesn't bother checking to see if the DB exists at this point
            //as it operates under the assumption that initialize_db() is always
            //run at the start of the program.
            SQLiteConnection cal_dbconnection;
            cal_dbconnection = new SQLiteConnection("Data Source=Calendar_db.sqlite;Version=3;");
            cal_dbconnection.Open();

            //Queries the appointments for the given date
            string sql_str = "SELECT ap_year, ap_month, ap_day, ap_time, desc FROM appointments WHERE ap_year = " + ap_year + " AND ap_month = " + ap_month + " AND ap_day = " + ap_day + ";";
            SQLiteCommand sql_cmd;
            sql_cmd = new SQLiteCommand(sql_str, cal_dbconnection);
            SQLiteDataReader sql_rdr = sql_cmd.ExecuteReader();

            //List of sql_row objects to store our results.
            var ret_list = new List<sql_row>();
            while (sql_rdr.Read())
            {
                //Console.WriteLine(Convert.ToInt64(sql_rdr["seqno"]));
                sql_row tmp_row = new sql_row((long)sql_rdr["ap_year"], (long)sql_rdr["ap_month"], (long)sql_rdr["ap_day"], (string)sql_rdr["ap_time"], (string)sql_rdr["desc"]);
                ret_list.Add(tmp_row);
            }

            //Finally, close our connection and return the results.
            cal_dbconnection.Close();
            return ret_list;

        }

        public static int insert_appointment(int ap_year, int ap_month, int ap_day, string ap_time, string apt_desc)
        {
            //This function simply creates an appointment based on the parameters.

            //Connect to the database.
            SQLiteConnection cal_dbconnection;
            cal_dbconnection = new SQLiteConnection("Data Source=Calendar_db.sqlite;Version=3;");
            cal_dbconnection.Open();

            //Row num will be an integer recording the number of rows affected.
            int row_num = 0;

            //Insert the row here.
            string sql_str = "INSERT INTO appointments values (" + ap_year + ", " + ap_month + ", " + ap_day + ", '" + ap_time + "', '" + apt_desc + "');";
            //Console.WriteLine(sql_str); //TESTING REMOVE LATER
            SQLiteCommand sql_cmd;
            sql_cmd = new SQLiteCommand(sql_str, cal_dbconnection);
            row_num = sql_cmd.ExecuteNonQuery();

            //Finally, close our connection and return a 1 if success.
            cal_dbconnection.Close();
            return row_num;

        }
    }
}