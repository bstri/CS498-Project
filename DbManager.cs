using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

    public class sql_row
    {
        public sql_row() { }

        public sql_row(string apt_dt, string descr)
        {
            apt_date = apt_dt;
            desc = descr;
        }

        // Properties.
        public string apt_date { get; set; }
        public string desc { get; set; }

        //public override string ToString() => FirstName + "  " + ID;
    }


public class sql_class
{
    public static void initialize_db()
    {
        // TODO this function should do nothing if the database has already been created
        //Remember to error handle lol

        //var decs
        SQLiteConnection cal_dbconnection; //connection object
        string sql_str = "";
        SQLiteCommand sql_cmd;

        //Create databse
        SQLiteConnection.CreateFile("Calendar_db.sqlite");
        //Connect to database
        cal_dbconnection = new SQLiteConnection("Data Source=Calendar_db.sqlite;Version=3;");
        //Open database
        cal_dbconnection.Open();
        //Create appointments table
        sql_str = "CREATE TABLE appointments (apdt VARCHAR(10), desc VARCHAR(250), primary key (apdt, desc));";
        sql_cmd = new SQLiteCommand(sql_str, cal_dbconnection);
        //This is the execute that returns an integer representing rows affected
        sql_cmd.ExecuteNonQuery();
        //Close database/connection
        cal_dbconnection.Close();

    }

    public static List<sql_row> get_appointments(string apt_date)
    {

        SQLiteConnection cal_dbconnection; //connection object
        string sql_str = "SELECT apdt, desc FROM appointments WHERE apdt = '" + apt_date + "';";
        SQLiteCommand sql_cmd;


        cal_dbconnection = new SQLiteConnection("Data Source=Calendar_db.sqlite;Version=3;");
        //Open database
        cal_dbconnection.Open();
        //insert new appointment
        sql_cmd = new SQLiteCommand(sql_str, cal_dbconnection);
        //This is the execute that returns an integer representing rows affected
        SQLiteDataReader sql_rdr = sql_cmd.ExecuteReader();
        //Close database/connection
        var ret_list = new List<sql_row>();
        while (sql_rdr.Read())
        {
            //Console.WriteLine(Convert.ToInt64(sql_rdr["seqno"]));
            sql_row tmp_row = new sql_row(sql_rdr["apdt"].ToString(), (string)sql_rdr["desc"]);
            ret_list.Add(tmp_row);
        }
        cal_dbconnection.Close();
        return ret_list;

    }

    public static int insert_appointment(string apt_date, string apt_desc)
    {
        //Here we want to make sure the database actually exists and such
        //But that is for later.

        SQLiteConnection cal_dbconnection; //connection object
        int row_num = 0;
        string sql_str = "INSERT INTO appointments (apdt, desc) values ('" + apt_date + "', '" + apt_desc + "');";
        Console.WriteLine(sql_str);
        SQLiteCommand sql_cmd;

        cal_dbconnection = new SQLiteConnection("Data Source=Calendar_db.sqlite;Version=3;");
        //Open database
        cal_dbconnection.Open();
        //insert new appointment
        sql_cmd = new SQLiteCommand(sql_str, cal_dbconnection);
        //This is the execute that returns an integer representing rows affected
        row_num = sql_cmd.ExecuteNonQuery();
        //Close database/connection
        cal_dbconnection.Close();
        return row_num;

    }
}

