using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class Event
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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Event e2 = (Event)obj;
            return (Name == e2.Name && When == e2.When && Description == e2.Description);
        }

        public override int GetHashCode()
        {
            return When.GetHashCode();
        }
    }
}
