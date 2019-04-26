using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge_Repository
{
    public enum ClaimType
    {
        Car =1,
        Home,
        Theft
    }

    public class Claims
    {
        public int ClaimID { get; set; }
        public ClaimType CType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValidClaim { get; set; }

        public Claims() { }

        public Claims(int claimId, ClaimType cType, string description, double claimAmount, DateTime dateOfIncident, DateTime dateOfClaim, bool isValidClaim)
        {
            ClaimID = claimId;
            CType = cType;
            Description = description;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            IsValidClaim = isValidClaim;
        }
    }


}




