using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models
{
    public abstract class CommonAbtract
    {
        public string CreatedBy { get; set; }   
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set;}
        public string ModifiedBy { get; set; }  
    }
}