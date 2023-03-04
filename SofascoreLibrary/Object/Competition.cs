using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofascoreLibrary.Object
{
    public class Competition
    {
        public string name { get; set; }

        public Competition(string name)
        {
            this.name = name;
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
            return name;
        }
        public string Display() => "Competition: " + name;
    }
}
