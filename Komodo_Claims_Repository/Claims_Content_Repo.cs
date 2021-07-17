using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims_Repository
{
    public class Claims_Content_Repo : I_Claims_Content_Repo
    {
        //Build out our CRUD methods
        private readonly List<Claims_Content>
            _contentDirectory = new List<Claims_Content>();

        // Create
        public void AddANewClaim (Claims_Content content)
        {
            _contentDirectory.Add(content);
        }

        public Claims_Content GetClaimByQueueNumber(int claimID)
        {
            foreach (Claims_Content item in _contentDirectory)
            {
                if (item.ClaimID == claimID)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Claims_Content> GetAllClaimsContent()
        {
            return _contentDirectory;
        }
    }
}
