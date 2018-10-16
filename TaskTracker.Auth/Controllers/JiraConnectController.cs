using DotNetAuth.OAuth1a;
using RestSharp;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using TaskTracker.Auth.Contracts;
using TaskTracker.Auth.Dal;
using TaskTracker.Auth.Utility;
using TaskTracker.Model;

namespace TaskTracker.Auth.Controllers
{
    public class JiraConnectController : Controller
    {
        private ApplicationCredentials JiraApplicationCredentials;
        private JIRAOAuth1aProvider JiraOAuth1AProvider;
        private OAuth10aStateManager OAuth10AStateManager;
        private ITokenGenerator _tokenGenerator;
        public JiraConnectController(ITokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
            OAuth10AStateManager = new OAuth10aStateManager((k, v) => Session[k] = v, k => (string)Session[k]);
        }

        [HttpGet]
        public ActionResult Initate(string baseUrl, string password, string callbackUrl)
        {
            var result=_tokenGenerator.ValidateClient(new Model.Auth.AuthTokenParameters(), OAuth10AStateManager);
            
            return new RedirectResult(result.RedirectionUrl);// authorizationUri.Result.AbsoluteUri);
        }

        [HttpGet]
        public RedirectResult Callback(string baseUrl, string callbackUrl,int authClientConfigId)
        {
            //IssueInfo(baseUrl,accessTokenInfo);
            _tokenGenerator.ValidateUserActionAndGenerateUserSession(new Model.Auth.AuthTokenParameters(), OAuth10AStateManager);
            return new RedirectResult(callbackUrl+"?clientId="+authClientConfigId);
        }

        
    }

}