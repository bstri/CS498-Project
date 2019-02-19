
public static class Globals
    {
            public static int currentMonth = 0;
            public static string first = "";
            int[] numDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            String[] monthsArr = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
    }
public void DateInfo.cs
{
//ini of code for date
DateTime now = DateTime.Now;
string month = DateTime.Now.ToString("MM");
var FirstDay = new DateTime(now.Year, now.Month, 1);
var LastDay = FirstDay.AddMonths(1).AddDays(-1);
string firstDate = FirstDay.ToString("dddd");
   
//On Load sets the first date of the current month         
Globals.currentMonth = Int32.Parse(month);
Globals.currentMonth--;
Globals.first = firstDate;
//Changes label to be on month, can change or delete later            
MonthLabel.Text = monthsArr[Globals.currentMonth];
}