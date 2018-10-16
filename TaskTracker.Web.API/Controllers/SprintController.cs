using Microsoft.EntityFrameworkCore;
using System.Linq;
using TaskTracker.Contracts;
using TaskTracker.DAL.Context;
using TaskTracker.DAL.Enitty;

namespace TaskTracker.Web.API.Controllers
{
    public class SprintController : BaseController
    {
        private IProjectManagementClient _projectManagementClient;
        private TaskTrackerContext _taskTrackerContext;
        public SprintController(IProjectManagementClient projectManagementClient, TaskTrackerContext taskTrackerContext)
        {
            _projectManagementClient = projectManagementClient;
            _taskTrackerContext = taskTrackerContext;
        }
        public void Get(string boardId,int clientId)
        {
            var userSession = _taskTrackerContext.UserSessions.Where(session => session.UserSessionId == clientId)
        .Include(session => session.AuthClientConfig).ToList() ;
            Model.UserSession userSessionModel = ExpressMapper.Mapper.Map<UserSession, Model.UserSession>(userSession.FirstOrDefault());

            _projectManagementClient.GetIssue("SPRIN-1", userSessionModel);
            _projectManagementClient.GetProjects(userSessionModel);
        }
    }
}