using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Challenge_Repository
{
    public class Badges
    {
        public int BadgeID { get; set; }
        public string DoorA1 { get; set; }
        public string DoorA2 { get; set; }
        public Badges() { }
        public Badges(int badgeID, string doorA1, string doorA2)
        {
            BadgeID = badgeID;
            DoorA1 = doorA1;
            DoorA2 = doorA2;
        }
    }


}
