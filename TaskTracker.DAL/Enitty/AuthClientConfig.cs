using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.DAL.Enitty
{
    public class AuthClientConfig
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ConsumerKey { get; set; }
        public string BaseUri { get; set; }
        public string ConsumerSecret { get; set; }
        public string Salt { get; set; }
        public string Digest { get; set; }
    }
}
