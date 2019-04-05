using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    public class Project
    {
        public readonly string Name;
        public readonly string Description;
        public readonly DateTime Start;
        public readonly DateTime End;
        public readonly ConsoleColor Color;

        public Project(string name, DateTime start, DateTime end, ConsoleColor color, string description = "")
        {
            Name = name;
            Start = start;
            End = end;
            Color = color;
            Description = description;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Project p2 = (Project)obj;
            return (Name == p2.Name && Start == p2.Start && End == p2.End && Color == p2.Color && Description == p2.Description);
        }

        public override int GetHashCode()
        {
            return Start.GetHashCode();
        }
    }
}
