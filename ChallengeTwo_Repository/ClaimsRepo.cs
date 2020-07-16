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
        public bool AddNewClaim(Claims claim)
        {
            int startingCount = _claimsQ.Count;
            _claimsQ.Enqueue(claim); //Add To Back (FIFO)
            bool newClaimWasAdded = (_claimsQ.Count > startingCount) ? true : false;
            return newClaimWasAdded;
        }
        public Claims TakeCareOfNextClaim()
        {
            return _claimsQ.Peek(); //View Front Element
        }
        public bool RemoveClaim(Claims existingClaim)
        {
            int startingCount = _claimsQ.Count;
            _claimsQ.Dequeue(); //Remove Front Element
            bool claimWasDeleted = (_claimsQ.Count < startingCount) ? true : false;
            return claimWasDeleted;
        }
        public Queue<Claims> ViewClaims()
        {
            return _claimsQ;
        }
    }
}