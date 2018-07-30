using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class BadgeRepository
    {
        private Dictionary<string, List<string>> _badges = new Dictionary<string, List<string>>();
        private List<string> _doors = new List<string>();

        public void CreateBadge(string badgeID, List<string> doors)
        {
            _badges.Add(badgeID, doors);
        }

        public Dictionary<string, List<string>> GetBadges()
        {
            return _badges;
        }
    }
}
