using DotNetAuth.OAuth1a;
using System;
using TaskTracker.Auth.Contracts;
using TaskTracker.Auth.Dal;
using TaskTracker.Auth.Utility;
using TaskTracker.Model;
using TaskTracker.Model.Auth;

namespace TaskTracker.Auth.TokenGenerator
{
    public class OauthOneTokenGenerator:ITokenGenerator
    {
        public Auth.Models.ValidateClientResult ValidateClient(AuthTokenParameters authTokenParameters, OAuth10aStateManager oAuth10AStateManager)
        {
            TaskTrackerDalForAuth taskTrackerDalForAuth = new TaskTrackerDalForAuth();
            var authClientConfig = taskTrackerDalForAuth.GetClientConfig(authTokenParameters.BaseUrl);
            authClientConfig.Password = authTokenParameters.Password;
            if (!authClientConfig.IsPasswordMatched)
                return new Auth.Models.ValidateClientResult() { Status = false };

            var JiraApplicationCredentials = new ApplicationCredentials
            {
                ConsumerKey = authClientConfig.ConsumerKey,
                ConsumerSecret = authClientConfig.ConsumerSecretKey.ToXmlString(true)
            };
            var callback = authTokenParameters.RequestUrl.GetLeftPart(UriPartial.Authority) + "/JiraConnect/Callback?baseUrl=" + authTokenParameters.BaseUrl + "&callbackUrl=" + authTokenParameters.CallbackUrl + "&authClientConfigId=" + authClientConfig.Id;
            var JiraOAuth1AProvider = new JIRAOAuth1aProvider(authTokenParameters.BaseUrl);
            var authorizationUri = OAuth1aProcess.GetAuthorizationUri(JiraOAuth1AProvider, JiraApplicationCredentials,
                                                                      callback, oAuth10AStateManager);
            authorizationUri.Wait();
            return new Auth.Models.ValidateClientResult(){ Status = true, RedirectionUrl= authorizationUri.Result.AbsoluteUri };
            }
        public bool ValidateUserActionAndGenerateUserSession(AuthTokenParameters authTokenParameters, OAuth10aStateManager oAuth10AStateManager)
        {

            TaskTrackerDalForAuth taskTrackerDalForAuth = new TaskTrackerDalForAuth();
            var authClientConfig = taskTrackerDalForAuth.GetClientConfig(authTokenParameters.BaseUrl);

            var JiraApplicationCredentials = new ApplicationCredentials
            {
                ConsumerKey = authClientConfig.ConsumerKey,
                ConsumerSecret = authClientConfig.ConsumerSecretKey.ToXmlString(true)
            };
            var JiraOAuth1AProvider = new JIRAOAuth1aProvider(authTokenParameters.BaseUrl);
            var processUserResponse = OAuth1aProcess.ProcessUserResponse(JiraOAuth1AProvider, JiraApplicationCredentials,
                                                                         authTokenParameters.RequestUrl, oAuth10AStateManager);
            processUserResponse.Wait();
            AccessTokenInfo accessTokenInfo = new AccessTokenInfo()
            {
                AccessToken = processUserResponse.Result.AllParameters["oauth_token"],
                AccessTokenSecret = processUserResponse.Result.AllParameters["oauth_token_secret"],
            };
            if (!taskTrackerDalForAuth.SaveUserSession(authTokenParameters.AuthClientConfigId, accessTokenInfo))
                authTokenParameters.AuthClientConfigId = 0;
            return true;
        }
    }
}