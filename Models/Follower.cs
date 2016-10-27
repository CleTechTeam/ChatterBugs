using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ChatterBugs.Models.ApplicationUser;

namespace ChatterBugs.Models
{
    public class Follower
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int FollowerID { get; set; }
        public EFollowerType FollowerType { get; set; }

        public ApplicationUser User { get; set; }
        public ApplicationUser FollowedBy { get; set; }
    }
}