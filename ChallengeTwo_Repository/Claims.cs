using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeTwo_Repository
{
    public enum ClaimType
    {
        Car,
        Home,
        Theft,
    }
    public class Claims
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        //if difference of DateOfIncident and DateOfClaim is <= 30 days is valid else invalid
        public bool IsValid
        {
            get
            {
                if ((DateOfClaim - DateOfIncident).TotalDays <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public Claims() { }
        public Claims(int claimID, ClaimType claimType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}