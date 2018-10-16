using System;
using System.Collections.Generic;
using TaskTracker.Model;
using TaskTracker.Model.Jira;

namespace TaskTracker.Contracts
{
    public interface IProjectManagementClient
    {
        IEnumerable<Project> GetProjects(Model.UserSession userSession);
        IEnumerable<CreateIssueResponse> CreateBulkIssue(IEnumerable<CreateIssue> issues, Model.UserSession userSession);
        List<User> GetUsers(string projectKey, Model.UserSession userSession);
        Issue GetIssue(string KeyId, Model.UserSession userSession);
    }
}