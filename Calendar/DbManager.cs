using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.SQLite;
using System.Globalization;
using System.Diagnostics;


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

        public proj_row(string name, long styear, long stmonth, long stday, long eyear, long emonth, long eday, System.Drawing.Color myColor, string descr)
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
        public System.Drawing.Color color { get; set; }
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
            sql_str = "CREATE TABLE projects (name VARCHAR(250), startYr integer, startMo integer, startDay integer, endYr integer, endMo integer, endDay integer, desc VARCHAR(250), colorA integer, colorR integer, colorG integer, colorB integer);";
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

        private static List<Project> getProjects(string dbFile, DateTime d)
        {
            List<Project> projects = new List<Project>();
            List<proj_row> ret_list = get_projects(dbFile, d.Year, d.Month, d.Day);
            string tmpString = "";
            string tmpString2 = "";
            foreach (proj_row row in ret_list)
            {
                tmpString = (row.startDay.ToString() + "-" + row.startMonth.ToString() + "-" + row.startYear.ToString());
                DateTime dtmp = DateTime.ParseExact(tmpString, "d-M-yyyy", CultureInfo.InvariantCulture);
                tmpString2 = (row.endDay.ToString() + "-" + row.endMonth.ToString() + "-" + row.endYear.ToString());
                DateTime dtmp2 = DateTime.ParseExact(tmpString, "d-M-yyyy", CultureInfo.InvariantCulture);
                Project p = new Project(row.projName, dtmp, dtmp2, row.color, row.desc);
                projects.Add(p);
            }

            return projects;
        }

        public static List<Event> GetEvents(DateTime d)
        {
            return getEvents(dbFileName, d);
        }

        public static List<Project> GetProjects(DateTime d)
        {
            Console.WriteLine("hello");
            return getProjects(dbFileName, d);
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

        private static bool addProject(string dbFile, Project p)
        {
            int retval = 0;
            //insert_project(string dbFile, string name, int startYear, int startMonth, int startDay, int endYear, int endMonth, int endDay, string desc)
            retval = insert_project(dbFile, p.Name, p.Start.Year, p.Start.Month, p.Start.Day, p.End.Year, p.End.Month, p.End.Day, p.Color.A, p.Color.R, p.Color.G, p.Color.B, p.Description); //p.When.Year, e.When.Month, e.When.Day, e.When.ToString("hh:mm"), e.Description);
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

        public static bool AddProject(Project p)
        {
            return addProject(dbFileName, p);
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
        private static List<proj_row> get_projects(string dbFile, int myYear, int myMonth, int myDay)
        {
            SQLiteConnection cal_dbconnection;
            cal_dbconnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
            cal_dbconnection.Open();
            DateTime mydt = new DateTime(myYear, myMonth, myDay, 0, 0, 0);

            string sql_str = "SELECT name, startYr, startMo, startDay, endYr, endMo, endDay, colorA, colorR, colorG, colorB, desc from projects;"; //where ('" + myYear + "|| '-' ||" + myMonth + "|| '-' ||" + myDay + "') BETWEEN ('startYr || '-' || startMo || '-' || startDay') AND ('endYr || '-' || endMo || '-' || endDay');"; //(;//2011 || '-' || 1 || '-' || 1

            SQLiteCommand sql_cmd;
            sql_cmd = new SQLiteCommand(sql_str, cal_dbconnection);
            SQLiteDataReader sql_rdr = sql_cmd.ExecuteReader();

            var ret_list = new List<proj_row>();
            while (sql_rdr.Read())
            {
                //We only want to add it here if it meets our criteria. Too difficult to check this using SQLite because
                //It is date DUMB so we do it here.

                proj_row tmp_row = new proj_row((string)sql_rdr["name"], (long)sql_rdr["startYr"], (long)sql_rdr["startMo"], (long)sql_rdr["startDay"], (long)sql_rdr["endYr"], (long)sql_rdr["endMo"], (long)sql_rdr["endDay"], System.Drawing.Color.FromArgb((int)sql_rdr["colorA"], (int)sql_rdr["colorR"], (int)sql_rdr["colorG"], (int)sql_rdr["colorB"]), (string)sql_rdr["desc"]);
                DateTime stdt = new DateTime((int)tmp_row.startYear, (int)tmp_row.startMonth, (int)tmp_row.startDay, 0, 0, 0);
                DateTime endt = new DateTime((int)tmp_row.endYear, (int)tmp_row.endMonth, (int)tmp_row.endDay, 0, 0, 0);
                if (mydt >= stdt && mydt <= endt)
                {
                    ret_list.Add(tmp_row);
                }
                
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
            SQLiteCommand sql_cmd;
            sql_cmd = new SQLiteCommand(sql_str, cal_dbconnection);
            row_num = sql_cmd.ExecuteNonQuery();

            //Finally, close our connection and return a 1 if success.
            cal_dbconnection.Close();
            return row_num;

        }

        public static int insert_project(string dbFile, string name, int startYear, int startMonth, int startDay, int endYear, int endMonth, int endDay, int colorA, int colorR, int colorG, int colorB, string desc)
        {

            //Connect to the database.
            SQLiteConnection cal_dbconnection;
            cal_dbconnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
            cal_dbconnection.Open();

            //Row num will be an integer recording the number of rows affected.
            int row_num = 0;

            //Insert the row here.
            string sql_str = "INSERT INTO projects values ('" + name + "', " + startYear + ", " + startMonth + ", " + startDay + ", " + endYear + ", " + endMonth + ", " + endDay + ", " + colorA + ", " + colorR + ", " + colorG + ", " + colorB + ", '" + desc + "');";
            SQLiteCommand sql_cmd;
            sql_cmd = new SQLiteCommand(sql_str, cal_dbconnection);
            row_num = sql_cmd.ExecuteNonQuery();

            //Finally, close our connection and return a 1 if success.
            cal_dbconnection.Close();
            return row_num;

        }
    }
}