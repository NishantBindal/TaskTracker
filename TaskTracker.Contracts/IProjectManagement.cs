using System;
using System.Collections.Generic;
using System.Text;
using TaskTracker.Model.Jira;

namespace TaskTracker.Contracts
{
    public interface IProjectManagement
    {
        IEnumerable<Project> GetProjects(Model.UserSession userSession);
        IEnumerable<CreateIssueResponse> CreateBulkIssue(IEnumerable<CreateIssue> issues, Model.UserSession userSession);
        List<User> GetUsers(string projectKey, Model.UserSession userSession);
        Issue GetIssue(string KeyId, Model.UserSession userSession);
    }
}
