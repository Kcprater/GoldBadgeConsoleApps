using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Repository
{
    public class ClaimsRepo
    {
        private Queue<Claims> _claimsQ = new Queue<Claims>();
        public void AddNewClaim(Claims claim)
        {
            _claimsQ.Enqueue(claim);
        }
        public Claims TakeCareOfNextClaim()
        {
            return _claimsQ.Peek();
        }
        public void RemoveClaim()
        {
            _claimsQ.Dequeue();
        }
        public Queue<Claims> ViewClaims()
        {
            return _claimsQ;
        }
    }
}