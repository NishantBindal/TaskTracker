using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using TaskTracker.Utility;

namespace TaskTracker.Web.API.Controllers
{
    public class JiraAuthController : BaseController
    {
        public JiraAuthController()
        {
        }
        [HttpGet]
        public RedirectResult Get(string url)
        {




        
            HttpClient client = new HttpClient();
            var path = "http://localhost:51816/jiraconnect/initate?baseurl=https://sprintplanner.atlassian.net&password=qwerty&callbackUrl=https://localhost:44361/api/values";
            return new RedirectResult(path);
        }

    }
}
