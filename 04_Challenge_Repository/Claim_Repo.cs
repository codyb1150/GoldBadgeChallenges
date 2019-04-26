using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Challenge_Repository
{
    public class Claim_Repo
    {
        private Queue<Claims> _queueOfContent = new Queue<Claims>();

        public void AddToQueue(Claims content)
        {
            _queueOfContent.Enqueue(content);
        }

        public Queue<Claims> GetQueue()
        {
            return _queueOfContent;
        }

        public Queue<Claims> GetContentByEnum(ClaimType type)
        {
            Queue<Claims> _newQueueClaims = new Queue<Claims>();
            foreach (Claims claim in _queueOfContent)
            {
                if (claim.CType == type)
                {
                    _newQueueClaims.Enqueue(claim);
                }
            }
            return _newQueueClaims;

        }

        public void RemoveClaimFromQueue()
        {
            _queueOfContent.Dequeue();
        }

        public Claims PeekNextInQueue()
        {
            return _queueOfContent.Peek();
        }

        
    }
}
