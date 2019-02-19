
public static class Globals
    {
            public static int currentMonth = 0;
            public static string first = "";
            public static int currMonLen = 0;
            public static 
            int[] numDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            String[] monthsArr = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
    }
public static class DateInfo.cs
{
//ini of code for date
DateTime now = DateTime.Now;
string month = DateTime.Now.ToString("MM");
var FirstDay = new DateTime(now.Year, now.Month, 1);

//Gets how long a month is
var LastDay = FirstDay.AddMonths(1).AddDays(-1);

string firstDate = FirstDay.ToString("dddd");
int lastDateNum = Int32.Parse(LastDay.ToString("dd"));
//On Load sets the first date of the current month

Globals.currentMonth = Int32.Parse(month);
Globals.currentMonth--;
Globals.currentMonth = Int32.Parse(month);
Globals.currentMonth--;
Globals.first = firstDate;
Globals.currMonLen = LastDay;
//Changes label to be on month, can change or delete later            
MonthLabel.Text = monthsArr[Globals.currentMonth];
}