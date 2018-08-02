using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class Badge
    {
        public Badge(string badgeID, List<string> doors)
        {
            BadgeID = badgeID;
            Doors = doors;
        }

        public string BadgeID { get; set; }
        public List<string> Doors { get; set; }
    }
}
