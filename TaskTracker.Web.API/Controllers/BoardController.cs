using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Contracts;
using TaskTracker.DAL.Context;

namespace TaskTracker.Web.API.Controllers
{
    public class BoardController : BaseController
    {
        private IProjectManagementClient _projectManagementClient;
        private TaskTrackerContext _taskTrackerContext;
        public BoardController(IProjectManagementClient projectManagementClient, TaskTrackerContext taskTrackerContext)
        {
            _projectManagementClient = projectManagementClient;
            _taskTrackerContext = taskTrackerContext;
        }
    }
}