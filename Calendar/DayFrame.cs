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
    public class DayFrame : Panel
    {
        private Label dayLabel;

        private TableLayoutPanel eventList;

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

        private List<Event> events = new List<Event>();
        private Dictionary<Event, Label> eventLabels = new Dictionary<Event, Label>();
        public void AddEvent(Event e)
        {
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

        public void ClearEvents()
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

        private void expandDay()
        {
            Debug.WriteLine("Day clicked");
        }
    }
}
