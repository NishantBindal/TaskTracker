using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TinyOAuth1;

namespace TaskTracker.AuthCore.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            string JIRA_BASE_URL = "https://sprintplanner.atlassian.net";
            var config = new TinyOAuthConfig
            {
                RequestTokenUrl = JIRA_BASE_URL + "/plugins/servlet/oauth/request-token",
            AuthorizeTokenUrl = JIRA_BASE_URL + "/plugins/servlet/oauth/authorize",
            AccessTokenUrl = JIRA_BASE_URL + "/plugins/servlet/oauth/access-token",
            ConsumerKey = "CONSUMER_KEY",
                ConsumerSecret = "CONSUMER_SECRET"
            };

            // Use the library
            var tinyOAuth = new TinyOAuth(config);

            // Get the request token and request token secret
            var requestTokenInfo = await tinyOAuth.GetRequestTokenAsync();

            // Construct the authorization url
            var authorizationUrl = tinyOAuth.GetAuthorizationUrl(requestTokenInfo.RequestToken);

            // *** You will need to implement these methods yourself ***
             Process.Start(authorizationUrl);//, LaunchUriAsync(new Uri(authorizationUrl)) etc...
            //var verificationCode = await InputVerificationCodeAsync(authorizationUrl);

            // *** Important: Do not run this code before visiting and completing the authorization url ***
            //var accessTokenInfo = await tinyOAuth.GetAccessTokenAsync(requestTokenInfo.RequestToken, requestTokenInfo.RequestTokenSecret, verificationCode);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
