using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class Badge
    {
        public Badge(Dictionary<string, List<string>> badges)
        {
            Badges = badges;
        }

        public Dictionary<string, List<string>> Badges { get; set; }
    }
}
