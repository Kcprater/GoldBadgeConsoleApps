using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Repository
{
    public class ClaimsRepo
    {
        private List<Claims> _claimsList = new List<Claims>();

        //Enter A New Claim
        public bool AddNewClaim(Claims claim)
        {
            int startingCount = _claimsList.Count;
            _claimsList.Add(claim);
            bool wasAdded = (_claimsList.Count > startingCount) ? true : false;
            return wasAdded;
        }
        //See All Claims
        public List<Claims> ViewClaims()
        {
            return _claimsList;
        }

        //Get Claim by ClaimID
        public Claims GetClaimByID(int claimID)
        {
            foreach (Claims id in _claimsList)
            {
                if (id.ClaimID == claimID)
                {
                    return id;
                }
            }
            return null;
        }
        //Delete Claim
        public bool DeleteClaim(int claimID)
        {
            var existingClaim = GetClaimByID(claimID);
            return _claimsList.Remove(existingClaim);
        }

        //Update Claim
        public bool UpdateClaim(int ClaimID, Claims updateExisitngClaim)
        {
            Claims originalClaim = GetClaimByID(ClaimID);
            if (originalClaim != null)
            {
                originalClaim.ClaimAmount = updateExisitngClaim.ClaimAmount;
                originalClaim.ClaimType = updateExisitngClaim.ClaimType;
                originalClaim.Description = updateExisitngClaim.Description;
                originalClaim.ClaimType = updateExisitngClaim.ClaimType;
                originalClaim.DateOfIncident = updateExisitngClaim.DateOfIncident;
                originalClaim.DateOfClaim = updateExisitngClaim.DateOfClaim;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}