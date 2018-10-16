using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.UtilitiesDotNetStandard;

namespace TaskTracker.Auth.Models
{
    public class AuthClientConfig
    {
        public int Id { get; set; }
        public string ConsumerKey { get; set; }
        public string BaseUri { get; set; }
        public string ConsumerSecret { get; set; }
        public string Salt { get; set; }
        public string Digest { get; set; }
        public string Password { get; set; }
        public RSACryptoServiceProvider ConsumerSecretKey { get {
                return PemKeyUtils.GetRSAProviderFromString(ConsumerSecret);
            }
            }
        public bool IsPasswordMatched { get
            {
                PasswordWithSaltHasher passwordWithSaltHasher = new PasswordWithSaltHasher();
                var hashWithSaltResult=passwordWithSaltHasher.HashWithSalt(Password, Salt, SHA256.Create());
                string base64Hash = Convert.ToBase64String(Encoding.ASCII.GetBytes(Digest));
                string base64AttemptedHash = Convert.ToBase64String(Encoding.ASCII.GetBytes(hashWithSaltResult.Digest));
                return base64Hash == base64AttemptedHash;
            } }
    }
}
