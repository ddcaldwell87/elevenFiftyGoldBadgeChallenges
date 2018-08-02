using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public enum ClaimType
    {
        Car = 1, Home, Theft
    }

    public class Claim
    {
        

        public Claim()
        {

        }
        public Claim(DateTime dateOfIncident)
        {
            DateOfIncident = dateOfIncident;
        }

        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public TimeSpan TimeBetweenIncidentAndClaim => DateOfClaim - DateOfIncident;
        private bool _isValid;
        public bool IsValid
        {
            get => _isValid;
            set
            {
                if (TimeBetweenIncidentAndClaim.Days < 30)
                    _isValid = true;

                _isValid = value;
            }
        }

    }
}
