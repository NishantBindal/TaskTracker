using DotNetAuth.OAuth1a;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTracker.Auth.Models
{
    public class ValidateClientResult
    {
        public bool Status{ get; set; }
        public string RedirectionUrl { get; set;  }
    }
}