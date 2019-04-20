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
    //This is really just a storage class with get/set methods.
    public class SqlRow
    {
        public SqlRow() { }

        public SqlRow(string ap_name, long ap_year, long ap_month, long ap_day, string ap_time, string descr)
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

    //This is a similar idea to what is above, except that this is for the projects
    //rather than the appointments.
    public class ProjectRow
    {
        public ProjectRow() { }

        public ProjectRow(string name, long styear, long stmonth, long stday, long eyear, long emonth, long eday, System.Drawing.Color myColor, string descr)
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
    public class SqlClass
    {

        //This is the only place we change the db file location
        //as it is important to be consistent across all of our methods.
        //Store it in AppData because why not.
        private static readonly string dbFileName = "C:\\Users\\" + Environment.UserName + "\\AppData\\Calendar_db.sqlite";
        private static readonly string testDBFileName = "C:\\Users\\" + Environment.UserName + "\\AppData\\test_db.sqlite";


        //Method meant to initialize the database.
        //Should be noted that it doesn't check to make sure the contents of the database are
        //what we expect, so if for instance the projects table is deleted but the database
        //still exists, this won't fix it and everything will be broken.
        private static void initializeDB(string dbFile)
        {
 
            SQLiteConnection calDbConnection;
            string sqlStr = "";
            SQLiteCommand sqlCmd;

            //Create the DB file
            //or if it already exists we're done here
            if (System.IO.File.Exists(dbFile))
            {
                return; 
            }
            SQLiteConnection.CreateFile(dbFile);

            //Connect to the database we just created
            calDbConnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");

            //Open our database
            calDbConnection.Open();

            //Create the appointments table
            sqlStr = "CREATE TABLE appointments (ap_name VARCHAR(250), ap_year integer, ap_month integer, ap_day integer, ap_time varchar(5), desc VARCHAR(250));";
            sqlCmd = new SQLiteCommand(sqlStr, calDbConnection);
            sqlCmd.ExecuteNonQuery();

            //Create the projects table
            sqlStr = "CREATE TABLE projects (name VARCHAR(250), startYr integer, startMo integer, startDay integer, endYr integer, endMo integer, endDay integer, colorA integer, colorR integer, colorG integer, colorB integer, desc VARCHAR(250));";
            sqlCmd = new SQLiteCommand(sqlStr, calDbConnection);
            sqlCmd.ExecuteNonQuery();

            //Finally, we close the database/connection
            calDbConnection.Close();
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
            //Do a simple check here using System.IO
            //and delete the database if we find it.
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

        //This method takes the results from getAppointments and turns the SqlRow objects
        //into Event objects for the calendar to use.
        private static List<Event> getEvents(string dbFile, DateTime d)
        {
            List<Event> events = new List<Event>();
            List<SqlRow> returnList = getAppointments(dbFile, d.Year, d.Month, d.Day);
            string tmpString = "";

            foreach(SqlRow row in returnList)
            {
                tmpString = (row.apt_day.ToString() + "-" + row.apt_month.ToString() + "-" + row.apt_year.ToString() + " " + row.apt_time.ToString());
                DateTime dtmp = DateTime.ParseExact(tmpString, "d-M-yyyy HH:mm", CultureInfo.InvariantCulture);
                Event e = new Event(row.apt_name, dtmp, row.desc);
                events.Add(e);
            }

            return events;
        }

        //Same idea as above, except for projects instead of appointments.
        //Turns them into Project objects for the calendar to use.
        private static List<Project> getProjects(string dbFile, DateTime d)
        {
            List<Project> projects = new List<Project>();
            List<ProjectRow> returnList = getProjs(dbFile, d.Year, d.Month, d.Day);
            string tmpString = "";
            string tmpString2 = "";
            foreach (ProjectRow row in returnList)
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
            return getProjects(dbFileName, d);
        }

        public static List<Event> GetTestEvents(DateTime d)
        {
            return getEvents(testDBFileName, d);
        }

        private static bool addEvent(string dbFile, Event e)
        {
            int retval = 0;
            retval = insertAppointment(dbFile, e.Name, e.When.Year, e.When.Month, e.When.Day, e.When.ToString("hh:mm"), e.Description);
            return retval == 1;
        }

        private static bool addProject(string dbFile, Project p)
        {
            int retval = 0;
            retval = insertProject(dbFile, p.Name, p.Start.Year, p.Start.Month, p.Start.Day, p.End.Year, p.End.Month, p.End.Day, p.Color.A, p.Color.R, p.Color.G, p.Color.B, p.Description); //p.When.Year, e.When.Month, e.When.Day, e.When.ToString("hh:mm"), e.Description);
            return retval == 1;
        }

        private static bool deleteAppointment(string dbFile, Event e)
        {
            int retval = 0;
            retval = delAppointment(dbFile, e.Name, e.When.Year, e.When.Month, e.When.Day, e.When.ToString("hh:mm"), e.Description);
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

        private static List<SqlRow> getAppointments(string dbFile, int ap_year, int ap_month, int ap_day)
        {
            //This simply gets all appointments for a given day

            //Connect to the database.
            //This doesn't bother checking to see if the DB exists at this point
            //as it operates under the assumption that initialize_db() is always
            //run at the start of the program.
            SQLiteConnection calDbConnection;
            calDbConnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
            calDbConnection.Open();

            //Queries the appointments for the given date
            string sqlStr = "SELECT ap_name, ap_year, ap_month, ap_day, ap_time, desc FROM appointments WHERE ap_year = " + ap_year + " AND ap_month = " + ap_month + " AND ap_day = " + ap_day + ";";
            SQLiteCommand sqlCmd;
            sqlCmd = new SQLiteCommand(sqlStr, calDbConnection);
            SQLiteDataReader sqlReader = sqlCmd.ExecuteReader();

            //List of SqlRow objects to store our results.
            var returnList = new List<SqlRow>();
            while (sqlReader.Read())
            {
                //Console.WriteLine(Convert.ToInt64(sqlReader["seqno"]));
                SqlRow tmp_row = new SqlRow((string)sqlReader["ap_name"], (long)sqlReader["ap_year"], (long)sqlReader["ap_month"], (long)sqlReader["ap_day"], (string)sqlReader["ap_time"], (string)sqlReader["desc"]);
                returnList.Add(tmp_row);
            }

            //Finally, close our connection and return the results.
            calDbConnection.Close();
            return returnList;

        }

        private static List<ProjectRow> getProjs(string dbFile, int myYear, int myMonth, int myDay)
        {
            SQLiteConnection calDbConnection;
            calDbConnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
            calDbConnection.Open();
            DateTime mydt = new DateTime(myYear, myMonth, myDay, 0, 0, 0);
            string sqlStr = "SELECT name, startYr, startMo, startDay, endYr, endMo, endDay, colorA, colorR, colorG, colorB, desc from projects;"; //where ('" + myYear + "|| '-' ||" + myMonth + "|| '-' ||" + myDay + "') BETWEEN ('startYr || '-' || startMo || '-' || startDay') AND ('endYr || '-' || endMo || '-' || endDay');"; //(;//2011 || '-' || 1 || '-' || 1

            SQLiteCommand sqlCmd;
            sqlCmd = new SQLiteCommand(sqlStr, calDbConnection);
            SQLiteDataReader sqlReader = sqlCmd.ExecuteReader();

            var returnList = new List<ProjectRow>();
            while (sqlReader.Read())
            {
                //We only want to add it here if it meets our criteria. Too difficult to check this using SQLite because
                //It is date DUMB so we do it here.

                System.Drawing.Color c = System.Drawing.Color.FromArgb((int)(long)sqlReader["colorA"], (int)(long)sqlReader["colorR"], (int)(long)sqlReader["colorG"], (int)(long)sqlReader["colorB"]);
                ProjectRow tmp_row = new ProjectRow((string)sqlReader["name"], (long)sqlReader["startYr"], (long)sqlReader["startMo"], (long)sqlReader["startDay"], (long)sqlReader["endYr"], (long)sqlReader["endMo"], (long)sqlReader["endDay"], c, (string)sqlReader["desc"]);
                DateTime stdt = new DateTime((int)tmp_row.startYear, (int)tmp_row.startMonth, (int)tmp_row.startDay, 0, 0, 0);
                DateTime endt = new DateTime((int)tmp_row.endYear, (int)tmp_row.endMonth, (int)tmp_row.endDay, 0, 0, 0);
                if (mydt >= stdt && mydt <= endt)
                {
                    returnList.Add(tmp_row);
                }
                
            }

            //Finally, close our connection and return the results.
            calDbConnection.Close();
            return returnList;

        }

        private static int insertAppointment(string dbFile, string ap_name, int ap_year, int ap_month, int ap_day, string ap_time, string apt_desc)
        {
            //This function simply creates an appointment based on the parameters.

            //Connect to the database.
            SQLiteConnection calDbConnection;
            calDbConnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
            calDbConnection.Open();

            //Row num will be an integer recording the number of rows affected.
            int numRows = 0;

            //Insert the row here.
            string sqlStr = "INSERT INTO appointments values ('" + ap_name + "', " + ap_year + ", " + ap_month + ", " + ap_day + ", '" + ap_time + "', '" + apt_desc + "');";
            SQLiteCommand sqlCmd;
            sqlCmd = new SQLiteCommand(sqlStr, calDbConnection);
            numRows = sqlCmd.ExecuteNonQuery();

            //Finally, close our connection and return a 1 if success.
            calDbConnection.Close();
            return numRows;
        }

        private static int delAppointment(string dbFile, string ap_name, int ap_year, int ap_month, int ap_day, string ap_time, string apt_desc)
        {
            //This function removes an appointment based on the parameters.

            //Connect to the database.
            SQLiteConnection calDbConnection;
            calDbConnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
            calDbConnection.Open();

            //Row num will be an integer recording the number of rows affected.
            int numRows = 0;

            //Delete the row here.
            string sqlStr = "DELETE FROM appointments WHERE ap_name = '" + ap_name + "' AND ap_year = " + ap_year + " AND ap_month = " + ap_month + " AND ap_day = " + ap_day + " and ap_time = '" + ap_time + "' and desc = '" + apt_desc + "';";
            SQLiteCommand sqlCmd;
            sqlCmd = new SQLiteCommand(sqlStr, calDbConnection);
            numRows = sqlCmd.ExecuteNonQuery();

            //Finally, close our connection and return a 1 if success.
            calDbConnection.Close();
            return numRows;

        }

        public static int insertProject(string dbFile, string name, int startYear, int startMonth, int startDay, int endYear, int endMonth, int endDay, int colorA, int colorR, int colorG, int colorB, string desc)
        {

            //Connect to the database.
            SQLiteConnection calDbConnection;
            calDbConnection = new SQLiteConnection("Data Source=" + dbFile + ";Version=3;");
            calDbConnection.Open();

            //Row num will be an integer recording the number of rows affected.
            int numRows = 0;

            //Insert the row here.
            string sqlStr = "INSERT INTO projects values ('" + name + "', " + startYear + ", " + startMonth + ", " + startDay + ", " + endYear + ", " + endMonth + ", " + endDay + ", " + colorA + ", " + colorR + ", " + colorG + ", " + colorB + ", '" + desc + "');";
            SQLiteCommand sqlCmd;
            sqlCmd = new SQLiteCommand(sqlStr, calDbConnection);
            numRows = sqlCmd.ExecuteNonQuery();

            //Finally, close our connection and return a 1 if success.
            calDbConnection.Close();
            return numRows;

        }
    }
}