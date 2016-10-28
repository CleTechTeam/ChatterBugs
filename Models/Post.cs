using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChatterBugs.Models
{
    public class Post
    {
        public int PostID { get; set; }
        [MaxLength(150)]
        public string PostMessage { get; set; }
        [DataType (DataType.DateTime)]
        public string CreatedDate { get; set; }
        
    }
}