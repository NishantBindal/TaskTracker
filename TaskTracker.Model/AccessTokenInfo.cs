using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTracker.Model
{
    public class AccessTokenInfo
    {
        public AccessTokenInfo() { }

        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }
    }
}