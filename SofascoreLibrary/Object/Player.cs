using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofascoreLibrary.Object
{
    [Serializable]
    public class Player
    {
        public string kitNumber { get; set; }
        public string fullName { get; set; }
        public string position { get; set; }
        public string nationality { get; set; }
        public string playerLink { get; set; }

        public Player()
        {
        }

        public Player(string kitNumber, string fullName, string position, string nationality)
        {
            this.kitNumber = kitNumber;
            this.fullName = fullName;
            this.position = position;
            this.nationality = nationality;
        }

        public Player(string kitNumber, string fullName, string position, string nationality, string playerLink) : this(kitNumber, fullName, position, nationality)
        {
            this.playerLink = playerLink;
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
            return kitNumber + "," + fullName + "," + position + "," + nationality + "," + playerLink;
        }
        public string Display() => String.Format("#{0}", kitNumber) + String.Format("\tName: {0,-30}", fullName) + String.Format("\tPosition: {0}", position) +
            String.Format("\tNationality: {0}", nationality) + String.Format("\tLink: {0}", playerLink);
    }
}
