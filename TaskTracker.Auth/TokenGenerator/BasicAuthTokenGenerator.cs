using System;
using System.Net;
using System.Net.Http;
using System.Text;
using DotNetAuth.OAuth1a;
using TaskTracker.Auth.Contracts;
using TaskTracker.Auth.Dal;
using TaskTracker.Auth.Models;
using TaskTracker.Model.Auth;

namespace TaskTracker.Auth.TokenGenerator
{
    public class BasicAuthTokenGenerator:ITokenGenerator
    {
        public BasicAuthTokenGenerator()
        {

        }
        public ValidateClientResult ValidateClient(AuthTokenParameters authTokenParameters, OAuth10aStateManager oAuth10AStateManager)
        {
            if (!TriggerDummyRequest(authTokenParameters.BaseUrl, authTokenParameters.UserName, authTokenParameters.Password))
                return new Auth.Models.ValidateClientResult() { Status = false ,RedirectionUrl="/login"};

            TaskTrackerDalForAuth taskTrackerDalForAuth = new TaskTrackerDalForAuth();
            taskTrackerDalForAuth.CreateAuthClientConfig(authTokenParameters.UserName, authTokenParameters.Password, authTokenParameters.BaseUrl);
            return new Auth.Models.ValidateClientResult();
        }
        
        public bool ValidateUserActionAndGenerateUserSession(AuthTokenParameters authTokenParameters, OAuth10aStateManager oAuth10AStateManager)
        {
            TaskTrackerDalForAuth taskTrackerDalForAuth=new TaskTrackerDalForAuth();
            taskTrackerDalForAuth.SaveUserSession(authTokenParameters.AuthClientConfigId);
            return true;
        }

        private bool TriggerDummyRequest(string baseUrl, string userName, string password)
        {
            var httpClient = new HttpClient();
            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(userName + ":" + password));

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", svcCredentials);

            var response = httpClient.GetAsync(baseUrl +"/ rest/api/2/issue/" + "project").GetAwaiter().GetResult();
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }
            return true;
        }
    }
}