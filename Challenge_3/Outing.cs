using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class Outing
    {
        private decimal CostOfEvent;

        public Outing(){}

        public Outing(string type, int numOfAttendees, DateTime date, decimal costPerPerson, decimal costOfEvent)
        {
            Type = type;
            NumOfAttendees = numOfAttendees;
            Date = date;
            CostPerPerson = costPerPerson;
            CostOfEvent = costOfEvent;
        }

        public string Type { get; set; }
        public int NumOfAttendees { get; set; }
        public DateTime Date { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal CostofEvent
        {
            get
            {
                return CostOfEvent;
            }
            set
            {
                CostOfEvent = CostPerPerson * NumOfAttendees;
            }
        }

    }
}
