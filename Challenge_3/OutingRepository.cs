using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class OutingRepository
    {
        private List<Outing> _outingList = new List<Outing>();

        public List<Outing> GetOutings()
        {
            return _outingList;
        }

        public void AddOuting(Outing events)
        {
            _outingList.Add(events);
        }

        public decimal CostAllOutings(decimal costOfEvent)
        {
            decimal totalCost = 0;
            foreach(var outing in _outingList)
            {
                if(costOfEvent == outing.CostofEvent)
                {
                    costOfEvent += totalCost;
                }
            }
            return totalCost;
        }

        public decimal CostByType(string type)
        {
            decimal totalCost = 0;
            foreach(var outing in _outingList)
            {
                if(type == outing.Type)
                {
                    outing.CostofEvent += totalCost;
                }
            }
            return totalCost;
        }
    }
}
