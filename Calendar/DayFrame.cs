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
    class DayFrame : Panel
    {
        private Label dayLabel;

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
            Label l = new Label()
            {
                Text = e.Name,
                AutoEllipsis = true,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleLeft,
            };
            Controls.Add(l);
            eventLabels.Add(e, l);
        }

        public void RemoveEvent(Event e)
        {

        }

        public void EditEvent(Event e)
        {

        }

        private void expandDay()
        {
            Debug.WriteLine("Day clicked");
        }
    }
}
