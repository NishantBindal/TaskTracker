using Newtonsoft.Json;
using OAuth;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using TaskTracker.Contracts;
using TaskTracker.DAL.Context;
using TaskTracker.DAL.Enitty;
using TaskTracker.Model;
using TaskTracker.Model.Jira;
using TaskTracker.UtilitiesDotNetStandard;
using TaskTracker.Utility;
using TinyOAuth1;
using static System.Net.WebRequestMethods;

namespace TaskTracker.ProjectManagementServices
{
    public class Jira : IProjectManagement
    {
        //protected string JIRA_BASE_URL = "https://sprintplanner.atlassian.net/";
        //protected string apiUrlBase = "https://vaticahealth.atlassian.net/rest/api/latest/";
        //protected string apiUrlBase = "https://quovantislabs.atlassian.net/rest/api/latest/";
        private TaskTrackerContext _taskTrackerContext;
        
        public Jira(TaskTrackerContext taskTrackerContext)
        {


            _taskTrackerContext = taskTrackerContext;
        }
        public IEnumerable<Project> GetProjects(Model.UserSession userSession)
        {
            IEnumerable<Project> projects = GetObject<IEnumerable<Project>>("project",userSession);
            return projects;
        }
        public List<User> GetUsers(string projectKey,Model.UserSession userSession)
        {
            try
            {
                var apiResponse = GetObject<List<User>>($"user/assignable/multiProjectSearch?projectKeys={ projectKey }");
                return apiResponse;

            }
            catch (Exception ex)
            {
                return null;
            }


        }
        public Issue GetIssue(string KeyId, Model.UserSession userSession)
        {
            try
            {
               
                var apiResponse = GetObject<Issue>($"issue/{KeyId}",userSession);
                return apiResponse;

            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public IEnumerable<CreateIssueResponse> CreateBulkIssue(IEnumerable<CreateIssue> issues, Model.UserSession userSession)
        {

            try
            {
                var apiResponse = PostObject<IEnumerable<CreateIssueResponse>>($"issue/bulk", issues,userSession);
                return apiResponse;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        protected T GetObject<T>(string extendedUrl, Model.UserSession userSession =null)
        {
            string jsonResult;
            string Url = userSession.AuthClientConfig.BaseUri + "/rest/api/2/" + extendedUrl;
            using (var client = new HttpClient())
            {
                SetAuthorizatonHeader(client,userSession,Url,Http.Get);
                var response = client.GetAsync(Url).GetAwaiter().GetResult();
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }
                else if (response.StatusCode == HttpStatusCode.OK)
                {
                    jsonResult = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    return JsonConvert.DeserializeObject<T>(jsonResult);
                }
            }
            return JsonConvert.DeserializeObject<T>("");
        }

        protected T PostObject<T>(string extendedUrl, object data, Model.UserSession userSession) where T : class
        {
            string jsonResult;
            string Url = userSession.AuthClientConfig.BaseUri + "/"  + extendedUrl;

            // CommentNew newc = new CommentNew { body = data };

            // StringContent queryString = new StringContent(, Encoding.UTF8, "application/json");
            StringContent queryString = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            using (var client = new HttpClient())
            {
                var response = client.PostAsync(Url, queryString).GetAwaiter().GetResult();
                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }

                else if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
                {
                    jsonResult = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    return JsonConvert.DeserializeObject<T>(jsonResult);
                }
            }
            return null;
        }

        //OAuth oauth_consumer_key = "jira", oauth_nonce = "LyiqlQJcnUmcvqNvMPJLzNyPTEQnlKFFrFqlGayGg", oauth_signature_method = "RSA-SHA1", oauth_timestamp = "1539430294", oauth_version = "1.0", oauth_token = "fdfgfgfg", oauth_signature = "X%2F%2BVnUmrxKOqQxgXPJ6n1kBTMI1Igq7b1Cd6Kziq8QbkF7yVZGnP8c6azof0hlzf2LF013oFqDnf2NEpvSqeCWpn7YPg7PgAzEY%2Bzn5RI3NQcXsGMoSLZeVjQL%2FthWbAzeAfZUrz9fx2tV%2BQzSZS7bpmQ%2BeShO5IEGeq6EjgajU%3D"
        private void SetAuthorizatonHeader(HttpClient client, Model.UserSession userSession,string url,string requestType)
        {
            var key = PemKeyUtils.GetRSAProviderFromString(userSession.AuthClientConfig.ConsumerSecret);
       
            var oauth = new OAuth.OAuthRequest();
            oauth.RequestUrl = url;
            oauth.Method = requestType;
            oauth.ConsumerKey = userSession.AuthClientConfig.ConsumerKey;
            oauth.ConsumerSecret = userSession.AuthClientConfig.ConsumerSecret;
            oauth.SignatureMethod = OAuthSignatureMethod.RsaSha1;
            oauth.Token = userSession.AccessToken;
            oauth.TokenSecret = userSession.AccessSecret;
            oauth.Version = "1.0";
            oauth.Type = OAuthRequestType.ProtectedResource;

            var authorizationHeader = oauth.GetAuthorizationHeader();

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("OAuth", authorizationHeader.Substring(5));
        }
        public static string ToXmlString( RSA rsa, bool includePrivateParameters)
        {
            RSAParameters parameters = rsa.ExportParameters(includePrivateParameters);

            return string.Format("<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent><P>{2}</P><Q>{3}</Q><DP>{4}</DP><DQ>{5}</DQ><InverseQ>{6}</InverseQ><D>{7}</D></RSAKeyValue>",
                  parameters.Modulus != null ? Convert.ToBase64String(parameters.Modulus) : null,
                  parameters.Exponent != null ? Convert.ToBase64String(parameters.Exponent) : null,
                  parameters.P != null ? Convert.ToBase64String(parameters.P) : null,
                  parameters.Q != null ? Convert.ToBase64String(parameters.Q) : null,
                  parameters.DP != null ? Convert.ToBase64String(parameters.DP) : null,
                  parameters.DQ != null ? Convert.ToBase64String(parameters.DQ) : null,
                  parameters.InverseQ != null ? Convert.ToBase64String(parameters.InverseQ) : null,
                  parameters.D != null ? Convert.ToBase64String(parameters.D) : null);
        }

    }
}
