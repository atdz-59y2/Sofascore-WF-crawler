using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofascoreLibrary.Object
{
    public class Team
    {
        public string name { get; set; }
        public string nationality { get; set; }
        public string stadium { get; set; }

        public Team()
        {
        }

        public Team(string name, string nationality, string stadium)
        {
            this.name = name;
            this.nationality = nationality;
            this.stadium = stadium;
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return name + "," + nationality + "," + stadium;
        }
        public string Display() => "Team name: " + name + "\tNationality: " + nationality + "\tStadium: " + stadium;
    }
}
