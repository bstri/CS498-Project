# Student Calendar

This application is a calendar targeting a student audience. <br>
Its goal is to provide project and assignment entities that can be entered into the calendar, as well as automatic importing of a user's class schedule. <br> 
Another of its goals was to provide a tag system, that allowed for easy filtering of what is shown on the calendar.

## Building the Application

This WinForms application was developed in Visual C#. It uses the .NET Framework 4.6.1

## Database
The calendar allows the user to store appointments, as well as projects. This is realized using an implementation of SQLite for use with C#.
The database is extremely simple and currently has an appointments table and a project table, and there is no relationship between the two.

