using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace Calendar
{
    // GUI class that stores all the information relating to a single day
    public class DayFrame : Panel
    {
        private Label dayLabel; // label that shows the day number

        // controls for storing gui elements related to events and projects
        public TableLayoutPanel eventList;
        public TableLayoutPanel projectList;

        // date of this dayframe
        public DateTime Date;

        public DayFrame()
        {
            Dock = DockStyle.Fill;

            dayLabel = new Label()
            {
                Location = new Point(0, 0),
                Size = new Size(15, 15),
                AutoSize = true,
            };
            Controls.Add(dayLabel);
            dayLabel.MouseClick += new MouseEventHandler((sender, e) => { OnMouseClick(e); }); // propagate mouse click to dayframe

            eventList = new TableLayoutPanel()
            {
                ColumnCount = 1,
                RowCount = 1,
                Location = new Point(0,15),
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom,
            };
            Controls.Add(eventList);
            eventList.MouseClick += new MouseEventHandler((sender, e) => { OnMouseClick(e); }); // propagate mouse click to dayframe

            projectList = new TableLayoutPanel()
            {
                RowCount = 1,
                ColumnCount = 1,
                Location = new Point(20, 0),
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom,
            };
            Controls.Add(projectList);
            projectList.MouseClick += new MouseEventHandler((sender, e) => { OnMouseClick(e); }); // propagate mouse click to dayframe

            // expand this day when clicked
            this.MouseClick += new MouseEventHandler((sender, e) => { expandDay(); });
        }

        private int _dayNumber;
        public int DayNumber
        {
            get => _dayNumber;
            set
            {
                if (value < 1 || value > 31)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be between 1 and 31.");
                _dayNumber = value;
                dayLabel.Text = value.ToString();
            }
        }

        public List<Event> events = new List<Event>();
        private Dictionary<Event, Label> eventLabels = new Dictionary<Event, Label>();
        // create a label with the event name
        public void AddEvent(Event e)
        {
            events.Add(e);
            
            eventList.RowCount++;

            Label l = new Label()
            {
                Text = e.Name,
                AutoEllipsis = true,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                Font = new Font("Sans Serif", 8),
            };

            eventList.RowStyles.Add(new RowStyle(SizeType.Absolute, 12));
            eventList.Controls.Add(l);
            eventLabels.Add(e, l);
        }

        public List<Project> projects = new List<Project>();
        // create a colored block with the project's color on it
        public void AddProject(Project p)
        {
            projects.Add(p);

            Label l = new Label()
            {
                Size = new Size(10, 10),
                BackColor = p.Color,
            };

            projectList.ColumnCount++;
            projectList.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 12));
            projectList.Controls.Add(l);
        }

        private void clearEvents()
        {
            eventLabels.Clear();
            events.Clear();
            eventList.Controls.Clear();
            for(int r = 1; r < eventList.RowStyles.Count; r++)
            {
                eventList.RowStyles.RemoveAt(r);
            }
            eventList.RowCount = 1;
        }

        private void clearProjects()
        {
            projects.Clear();
            projectList.Controls.Clear();
            for (int c = 1; c < projectList.ColumnStyles.Count; c++)
                projectList.ColumnStyles.RemoveAt(c);
            projectList.ColumnCount = 1;
        }

        // Opens a new DayViewForm for the DayFrame Clicked
        private void expandDay()
        {
            if (events.Count == 0)
                return;
            var f = new DayViewForm(this); 

            f.ShowDialog();
            RefreshDay(Date);
        }

        //Clears events from a view and re-adds them to update the GUI with changes to the database
        public void RefreshDay(DateTime date)
        {
            clearEvents();
            List<Event> events = sql_class.GetEvents(date);
            List<Event> SortedEvents = events.OrderBy(o => o.When).ToList();    //sorts events by Date
            for (int k = 0; k < events.Count; k++)
            {
                AddEvent(SortedEvents[k]);

            }
            clearProjects();
            List<Project> proj = sql_class.GetProjects(date);
            for (int k = 0; k < proj.Count; k++)
            {
                AddProject(proj[k]);

            }
        }
    }
}
