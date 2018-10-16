using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.DAL.Enitty
{
    public partial class AuthType
    {
        public int AuthTypeId { get; set; }
        public string Description { get; set; }
        public ICollection<UserSession> UserSessions { get; set; }
    }
}
