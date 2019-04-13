using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;
using System.Globalization;


namespace Calendar
{
    //This is simply a class to hold the results of a query to get an appointment
    //At this point is simply a storage class with get/set methods.
    public class sql_row
    {
        public sql_row() { }

        public sql_row(string ap_name, long ap_year, long ap_month, long ap_day, string ap_time, string descr)
        {
            apt_name = ap_name;
            apt_year = ap_year;
            apt_month = ap_month;
            apt_day = ap_day;
            apt_time = ap_time;
            desc = descr;
        }

        // Properties.
        public string apt_name { get; set; }
        public long apt_year { get; set; }
        public long apt_month { get; set; }
        public long apt_day { get; set; }
        public string apt_time { get; set; }
        public string desc { get; set; }

    }

    public class proj_row
    {
        public proj_row() { }

        public proj_row(string name, long styear, long stmonth, long stday, long eyear, long emonth, long eday, string myColor, string descr)
        {
            projName = name;
            startYear = styear;
            startMonth = stmonth;
            startDay = stday;
            endYear = eyear;
            endMonth = emonth;
            endDay = eday;
            color = myColor;
            desc = descr;
        }

        // Properties.
        public string projName { get; set; }
        public long startYear { get; set; }
        public long startMonth { get; set; }
        public long startDay { get; set; }
        public long endYear { get; set; }
        public long endMonth { get; set; }
        public long endDay { get; set; }
        public string color { get; set; }
        public string desc { get; set; }

    }

    //This is the meat of the DB manager.
    public class sql_class
    {
        private static readonly string dbFileName = "C:\\Users\\" + Environment.UserName + "\\AppData\\Calendar_db.sqlite";
        private static readonly string testDBFileName = "C:\\Users\\" + Environment.UserName + "\\AppData\\test_db.sqlite";

        private static void initializeDB(string dbFile)
        {
 
            SQLiteConnection cal_dbconnection;
            string sql_str = "";
            SQLiteCommand sql_cmd;

            //Create the DB file
            //or if it already exists we're done here
            if (System.IO.File.Exists(dbFile))
            {
                return; 
            }
            SQLiteConnection.CreateFile(dbFile);

            //Connect to the database we just created
            cal_dbconnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");

            //Open our database
            cal_dbconnection.Open();

            //Create the appointments table
            sql_str = "CREATE TABLE appointments (ap_name VARCHAR(250), ap_year integer, ap_month integer, ap_day integer, ap_time varchar(5), desc VARCHAR(250));";
            sql_cmd = new SQLiteCommand(sql_str, cal_dbconnection);
            sql_cmd.ExecuteNonQuery();

            //Create the projects table
            sql_str = "CREATE TABLE projects (name VARCHAR(250), startYr integer, startMo integer, startDay integer, endYr integer, endMo integer, endDay integer, desc VARCHAR(250), color VARCHAR(250));";
            sql_cmd = new SQLiteCommand(sql_str, cal_dbconnection);
            sql_cmd.ExecuteNonQuery();

            //Finally, we close the database/connection
            cal_dbconnection.Close();
        }

        public static void InitializeDB()
        {
            initializeDB(dbFileName);
        }

        public static void InitializeTestDB()
        {
            initializeDB(testDBFileName);
        }

        private static void destroyDB(string dbFile)
        {
            if (System.IO.File.Exists(dbFile))
            {
                System.IO.File.Delete(dbFile);
            }
        }

        public static void DestroyDB()
        {
            destroyDB(dbFileName);
        }

        public static void DestroyTestDB()
        {
            destroyDB(testDBFileName);
        }

        private static List<Event> getEvents(string dbFile, DateTime d)
        {
            List<Event> events = new List<Event>();
            List<sql_row> ret_list = get_appointments(dbFile, d.Year, d.Month, d.Day);
            string tmpString = "";

            foreach(sql_row row in ret_list)
            {
                Console.WriteLine(row.apt_day);
                Console.WriteLine(row.apt_month);
                Console.WriteLine(row.apt_year);
                Console.WriteLine(row.apt_time);

                tmpString = (row.apt_day.ToString() + "-" + row.apt_month.ToString() + "-" + row.apt_year.ToString() + " " + row.apt_time.ToString());
                Console.WriteLine(tmpString);

                DateTime dtmp = DateTime.ParseExact(tmpString, "d-M-yyyy HH:mm", CultureInfo.InvariantCulture);
                Event e = new Event(row.apt_name, dtmp, row.desc);
                events.Add(e);
            }

            return events;
        }

        public static List<Event> GetEvents(DateTime d)
        {
            return getEvents(dbFileName, d);
        }

        public static List<Event> GetTestEvents(DateTime d)
        {
            return getEvents(testDBFileName, d);
        }

        private static bool addEvent(string dbFile, Event e)
        {
            int retval = 0;
            retval = insert_appointment(dbFile, e.Name, e.When.Year, e.When.Month, e.When.Day, e.When.ToString("hh:mm"), e.Description);
            return retval == 1;
        }

        private static bool deleteAppointment(string dbFile, Event e)
        {
            int retval = 0;
            retval = delete_appointment(dbFile, e.Name, e.When.Year, e.When.Month, e.When.Day, e.When.ToString("hh:mm"), e.Description);
            return retval == 1;
        }

        public static bool DeleteAppointment(Event e)
        {
            return deleteAppointment(dbFileName, e);
        }

        public static bool AddEvent(Event e)
        {
            return addEvent(dbFileName, e);
        }

        public static bool AddTestEvent(Event e)
        {
            return addEvent(testDBFileName, e);
        }

        private static List<sql_row> get_appointments(string dbFile, int ap_year, int ap_month, int ap_day)
        {
            //This simply gets all appointments for a given day

            //Connect to the database.
            //This doesn't bother checking to see if the DB exists at this point
            //as it operates under the assumption that initialize_db() is always
            //run at the start of the program.
            SQLiteConnection cal_dbconnection;
            cal_dbconnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
            cal_dbconnection.Open();

            //Queries the appointments for the given date
            string sql_str = "SELECT ap_name, ap_year, ap_month, ap_day, ap_time, desc FROM appointments WHERE ap_year = " + ap_year + " AND ap_month = " + ap_month + " AND ap_day = " + ap_day + ";";
            SQLiteCommand sql_cmd;
            sql_cmd = new SQLiteCommand(sql_str, cal_dbconnection);
            SQLiteDataReader sql_rdr = sql_cmd.ExecuteReader();

            //List of sql_row objects to store our results.
            var ret_list = new List<sql_row>();
            while (sql_rdr.Read())
            {
                //Console.WriteLine(Convert.ToInt64(sql_rdr["seqno"]));
                sql_row tmp_row = new sql_row((string)sql_rdr["ap_name"], (long)sql_rdr["ap_year"], (long)sql_rdr["ap_month"], (long)sql_rdr["ap_day"], (string)sql_rdr["ap_time"], (string)sql_rdr["desc"]);
                ret_list.Add(tmp_row);
            }

            //Finally, close our connection and return the results.
            cal_dbconnection.Close();
            return ret_list;

        }

        //todo: figure out how we want to handle projects
        private static List<sql_row> get_projects(string dbFile, int myYear, int myMonth, int myDay)
        {
            //This simply gets all appointments for a given day

            //Connect to the database.
            //This doesn't bother checking to see if the DB exists at this point
            //as it operates under the assumption that initialize_db() is always
            //run at the start of the program.
            SQLiteConnection cal_dbconnection;
            cal_dbconnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
            cal_dbconnection.Open();

            //Queries the appointments for the given date
            string sql_str = "SELECT name, startYr, startMo, startDay, endYr, endMo, endDay, desc from projects where '" + myMonth + "/" + myDay + "/" + myYear;
                //"//SELECT ap_name, ap_year, ap_month, ap_day, ap_time, desc FROM appointments WHERE ap_year = " + ap_year + " AND ap_month = " + ap_month + " AND ap_day = " + ap_day + ";";
            // sql_str = "CREATE TABLE projects (name VARCHAR(250), startYr integer, startMo integer, startDay integer, endYr integer, endMo integer, endDay integer, desc VARCHAR(250), color VARCHAR(250));";

            SQLiteCommand sql_cmd;
            sql_cmd = new SQLiteCommand(sql_str, cal_dbconnection);
            SQLiteDataReader sql_rdr = sql_cmd.ExecuteReader();

            //List of sql_row objects to store our results.
            var ret_list = new List<sql_row>();
            while (sql_rdr.Read())
            {
                //Console.WriteLine(Convert.ToInt64(sql_rdr["seqno"]));
                //sql_row tmp_row = new sql_row((string)sql_rdr["ap_name"], (long)sql_rdr["ap_year"], (long)sql_rdr["ap_month"], (long)sql_rdr["ap_day"], (string)sql_rdr["ap_time"], (string)sql_rdr["desc"]);
                //ret_list.Add(tmp_row);
            }

            //Finally, close our connection and return the results.
            cal_dbconnection.Close();
            return ret_list;

        }

        private static int insert_appointment(string dbFile, string ap_name, int ap_year, int ap_month, int ap_day, string ap_time, string apt_desc)
        {
            //This function simply creates an appointment based on the parameters.

            //Connect to the database.
            SQLiteConnection cal_dbconnection;
            cal_dbconnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
            cal_dbconnection.Open();

            //Row num will be an integer recording the number of rows affected.
            int row_num = 0;

            //Insert the row here.
            string sql_str = "INSERT INTO appointments values ('" + ap_name + "', " + ap_year + ", " + ap_month + ", " + ap_day + ", '" + ap_time + "', '" + apt_desc + "');";
            //Console.WriteLine(sql_str); //TESTING REMOVE LATER
            Console.WriteLine(sql_str);
            SQLiteCommand sql_cmd;
            sql_cmd = new SQLiteCommand(sql_str, cal_dbconnection);
            row_num = sql_cmd.ExecuteNonQuery();

            //Finally, close our connection and return a 1 if success.
            cal_dbconnection.Close();
            return row_num;

        }

        private static int delete_appointment(string dbFile, string ap_name, int ap_year, int ap_month, int ap_day, string ap_time, string apt_desc)
        {
            //This function removes an appointment based on the parameters.

            //Connect to the database.
            SQLiteConnection cal_dbconnection;
            cal_dbconnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
            cal_dbconnection.Open();

            //Row num will be an integer recording the number of rows affected.
            int row_num = 0;

            //Delete the row here.
            string sql_str = "DELETE FROM appointments WHERE ap_name = '" + ap_name + "' AND ap_year = " + ap_year + " AND ap_month = " + ap_month + " AND ap_day = " + ap_day + " and ap_time = '" + ap_time + "' and desc = '" + apt_desc + "';";
            Console.WriteLine(sql_str);
            SQLiteCommand sql_cmd;
            sql_cmd = new SQLiteCommand(sql_str, cal_dbconnection);
            row_num = sql_cmd.ExecuteNonQuery();

            //Finally, close our connection and return a 1 if success.
            cal_dbconnection.Close();
            return row_num;

        }

        private static int insert_project(string dbFile, string name, int startYear, int startMonth, int startDay, int endYear, int endMonth, int endDay, string desc)
        {
            //This function simply creates an appointment based on the parameters.

            //Connect to the database.
            SQLiteConnection cal_dbconnection;
            cal_dbconnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
            cal_dbconnection.Open();

            //Row num will be an integer recording the number of rows affected.
            int row_num = 0;

            //Insert the row here.
            string sql_str = "INSERT INTO project values ('" + name + "', " + startYear + ", " + startMonth + ", " + startDay + ", " + endYear + ", " + endMonth + ", " + endDay + ", '" + desc + "');";
            // sql_str = "CREATE TABLE projects (name VARCHAR(250), startYr integer, startMo integer, startDay integer, endYr integer, endMo integer, endDay integer, desc VARCHAR(250), color VARCHAR(250));";
            //Console.WriteLine(sql_str); //TESTING REMOVE LATER
            Console.WriteLine(sql_str);
            SQLiteCommand sql_cmd;
            sql_cmd = new SQLiteCommand(sql_str, cal_dbconnection);
            row_num = sql_cmd.ExecuteNonQuery();

            //Finally, close our connection and return a 1 if success.
            cal_dbconnection.Close();
            return row_num;

        }
    }
} //public Project(string name, DateTime start, DateTime end, ConsoleColor color, string description = "")