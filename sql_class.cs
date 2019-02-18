using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

public class sql_class
{
    public static void initialize_db()
    {
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
        sql_str = "CREATE TABLE appointments (apdt VARCHAR(10), seqno AUTONUMBER, desc VARCHAR(250), PRIMARY KEY (apdt, seqno));";
        sql_cmd = new SQLiteCommand(sql_str, cal_dbconnection);
        //This is the execute that returns an integer representing rows affected
        sql_cmd.ExecuteNonQuery();
        //Close database/connection
        cal_dbconnection.Close();

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

    public static string select_appointment(string apt_date, int apt_seqno)
    {

        SQLiteConnection cal_dbconnection; //connection object
        string sql_str = "SELECT desc FROM appointments WHERE apdt = '" + apt_date + "';";
        SQLiteCommand sql_cmd;


        cal_dbconnection = new SQLiteConnection("Data Source=Calendar_db.sqlite;Version=3;");
        //Open database
        cal_dbconnection.Open();
        //insert new appointment
        sql_cmd = new SQLiteCommand(sql_str, cal_dbconnection);
        //This is the execute that returns an integer representing rows affected
        SQLiteDataReader sql_rdr = sql_cmd.ExecuteReader();
        //Close database/connection

        sql_rdr.Read();

        string ret_str = (string)sql_rdr["desc"];
        cal_dbconnection.Close();
        return ret_str;
    }
}

