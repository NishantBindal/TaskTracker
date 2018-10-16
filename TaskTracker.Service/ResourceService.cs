using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TaskTracker.Contracts;
using TaskTracker.DAL.Context;
using TaskTracker.DAL.Entity;
using TaskTracker.Model;
using TaskTracker.Model.Jira;
using TaskTracker.Utility;

namespace TaskTracker.Service
{
    public class ResourceService
    {
        private readonly TaskTrackerContext _context;
        private readonly IResponses _response;
        private readonly IProjectManagement _projectManagement;
        private readonly UserSession _userSession;
        public ResourceService(TaskTrackerContext context,IResponses responses,IProjectManagement projectManagement)
        {
            this._context = context;
            this._response = responses;
            this._projectManagement = projectManagement;
        }
        public async Task<ServiceResult<IEnumerable<Board>>> GetBoards()
        {
            try
            {
                return _response.SuccessResult(ExpressMapper.Mapper.Map<IEnumerable<Model.Jira.Project>, IEnumerable<Board>>(_projectManagement.GetProjects(_userSession)));
            }
            catch (Exception ex)
            {
                return _response.FailureNullResult<IEnumerable<Board>>(ex.Message);
            }
        }
        public ServiceResult<Board> GetBoardByID(long id)
        {
            try
            {
                return _response.SuccessResult(DAL.PublicLayer.GetBoardByID(id));
            }
            catch (Exception ex)
            {
                return _response.FailureNullResult<Board>(ex.Message);
            }
        }

        public ServiceResult<List<Sprint>> GetAllSprints()
        {
            try
            {
                return _response.SuccessResult(DAL.PublicLayer.GetAllSprints());
            }
            catch (Exception ex)
            {
                return _response.FailureNullResult<List<Sprint>>(ex.Message);
            }
        }

        public ServiceResult<List<Sprint>> GetAllSprintsByRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                return _response.SuccessResult(DAL.PublicLayer.GetAllSprintsByRange(startDate, endDate));
            }
            catch (Exception ex)
            {
                return _response.FailureNullResult<List<Sprint>>(ex.Message);
            }
        }

        public ServiceResult<Sprint> GetSprintByID(long id)
        {
            try
            {
                return _response.SuccessResult(DAL.PublicLayer.GetSprintByID(id));
            }
            catch (Exception ex)
            {
                return _response.FailureNullResult<Sprint>(ex.Message);
            }
        }
    }
}
