using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    class Event
    {
        public readonly string Name;
        public readonly string Description;
        public readonly DateTime When;

        public Event(string name, DateTime d, string description = "")
        {
            Name = name;
            When = d;
            Description = description;
        }
    }
}
