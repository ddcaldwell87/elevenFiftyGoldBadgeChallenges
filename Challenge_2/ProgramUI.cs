using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    class ProgramUI
    {
        private ClaimRepo _repo = new ClaimRepo();

        public void Run()
        {
            SeedData();
            RunStartMenu();
        }

        private void SeedData()
        {
            Claim claim1 = new Claim
            {
                ClaimID = 1,
                ClaimType = ClaimType.Car,
                Description = "Wreck",
                ClaimAmount = 400.00m,
                DateOfIncident = DateTime.Now,
                DateOfClaim = DateTime.Now,
            };
            Claim claim2 = new Claim
            {
                ClaimID = 2,
                ClaimType = ClaimType.Home,
                Description = "Garage Fire",
                ClaimAmount = 40000.00m,
                DateOfIncident = DateTime.Now,
                DateOfClaim = DateTime.Now,
            };

            _repo.AddClaim(claim1);
            _repo.AddClaim(claim2);
        }

        private void RunStartMenu()
        {

        }
    }
}
