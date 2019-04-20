# Student Calendar

This application is a calendar targeting a student audience. <br>
Its goal is to provide project and assignment entities that can be entered into the calendar, as well as automatic importing of a user's class schedule. <br> 
Another of its goals was to provide a tag system, that allowed for easy filtering of what is shown on the calendar.

## Building the Application
This WinForms application was developed in Visual C#. It uses the .NET Framework 4.6.1. It is recommended to use Visual Studio 2017 when opening this project. The Calendar.sln file will be recognized and opened by Visual Studio. 

## Database
The calendar allows the user to store appointments/events, as well as projects. This is realized using an implementation of SQLite for use with C#.
The database is extremely simple and currently has an appointments table and a project table, and there is no relationship between the two.

## Layout of the Application Files
MonthlyView is the main form, as well as the controller of everything. It instantiates 42 (6 weeks worth) DayFrame objects which are placed in the grid representing days in the month. <br>
DayFrame inherits from the Panel object and contains the gui relating to a single day, as well as all information for that date. SetMonth in MonthlyView is responsible for updating the DayFrames as months change. <br>
DayFrame may be expanded by clicking on it to show DayViewForm, which is a verbose view of a single day, allowing editing of the events for that day. <br>
AddEventForm and AddProjectForm may be opened by clicking on their respective buttons in the MonthlyView. <br>
