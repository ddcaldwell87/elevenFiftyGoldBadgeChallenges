using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class ClaimRepo
    {
        Queue<Claim> _claims = new Queue<Claim>();

        public Queue<Claim> GetClaims()
        {
            return _claims;
        }

        public void NextClaim()
        {
            var nextClaim = _claims.Peek();
        }

        public void AddClaim(Claim claim)
        {
            _claims.Enqueue(claim);
        }
    }
}
