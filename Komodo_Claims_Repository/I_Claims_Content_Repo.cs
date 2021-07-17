using System.Collections.Generic;

namespace Komodo_Claims_Repository
{
    public interface I_Claims_Content_Repo
    {
        List<Claims_Content> GetAllClaimsContent();
        Claims_Content GetClaimByQueueNumber(int claimID); // Use a switch case with an if / else if
        void AddANewClaim(Claims_Content content);
    }
}

// "1. See all the claims.\n" +
// "2. Take care of the next claim.\n" +
// "3. Enter a new claim\n" +
