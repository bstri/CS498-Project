using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Calendar
{
    class DayFrame : Panel
    {
        private Label dayLabel;

        public DayFrame()
        {
            dayLabel = new Label()
            {
                Location = new Point(0, 0),
                Size = new Size(15, 15)
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

        private string[] appointments;
        private List<Label> apptLabels;
        public void SetAppointments(string[] appts)
        {
            if (appts.SequenceEqual(appointments))
                return;
            foreach(Label appt in apptLabels)
            {
                Controls.Remove(appt);
            }
            appointments = appts;
            foreach(string appt in appts)
            {
                Label lAppt = new Label()
                {
                    Text = appt,

                };
                Controls.Add(lAppt);
                apptLabels.Add(lAppt);
            }
        }

        private void expandDay()
        {

        }
    }
}
