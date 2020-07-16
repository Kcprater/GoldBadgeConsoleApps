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
            _claimsQ.Enqueue(claim); //Add To Back (FIFO)
        }
        public Claims TakeCareOfNextClaim()
        {
            return _claimsQ.Peek(); //View Front Element
        }
        public void RemoveClaim()
        {
            _claimsQ.Dequeue(); //Remove Front Element
        }
        public Queue<Claims> ViewClaims()
        {
            return _claimsQ;
        }
    }
}