using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Model
{
    public class UserSession
    {
        public int UserSessionId { get; set; }
        public string AccessToken { get; set; }
        public string AccessSecret { get; set; }
        public virtual AuthClientConfig AuthClientConfig { get; set; }
    }
}
