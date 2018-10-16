using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.DAL.Enitty
{
    public class UserSession
    {
        [ForeignKey("AuthClientConfig")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserSessionId { get; set; }
        public string AccessToken { get; set; }
        public string AccessSecret { get; set; }
        public virtual AuthClientConfig AuthClientConfig { get; set; }
        [ForeignKey("AuthType")]
        public int AuthTypeId { get; set; }
        public virtual AuthType AuthType { get; set; }
    }
}
