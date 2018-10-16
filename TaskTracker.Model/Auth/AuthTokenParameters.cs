using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Enums.Enumerators;
using TaskTracker.Enums.Extensions;

namespace TaskTracker.Model.Auth
{
    public class AuthTokenParameters
    {
        public AuthType Type { get; set; }
        public string UserName
        {
            get
            {
                if (!Type.Equals(AuthType.Basic.GetEnumDescription()))
                    return null;
                return UserName;
            }
            set
            {
                if (Type.Equals(AuthType.Basic.GetEnumDescription()))
                     UserName = value;
            }
        }
        public string Password
        {
            get
            {
                if (!Type.Equals(AuthType.Basic.GetEnumDescription()))
                    return null;
                return Password;
            }
            set
            {
                if (Type.Equals(AuthType.Basic.GetEnumDescription()))
                     Password = value;
            }
        }
        public string BaseUrl { get; set; }
        public Uri RequestUrl { get; set; }
        public int AuthClientConfigId { get; set; }
        public string CallbackUrl { get; set; }
    }
}
