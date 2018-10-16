using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TaskTracker.DAL.Context;
using TaskTracker.DAL.Entity;
using TaskTracker.Utility;

namespace TaskTracker.Services
{
    public class PublicLayer
    {
        private readonly TaskTrackerContext context;
        public PublicLayer(TaskTrackerContext context)
        {
            this.context = context;
        }
        public async Task<ServiceResult<List<Board>>> GetBoards()
        {
            try
            {
                return DAL.PublicLayer.GetBoards().SuccessResult();
            }
            catch (Exception ex)
            {
                return Responses.FailureNullResult<List<Board>>(ex.Message);
            }
        }
        public string GetPrivateKey()
        {
            try
            {
                return "";
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        public static ServiceResult<Board> GetBoardByID(long id)
        {
            try
            {
                return DAL.PublicLayer.GetBoardByID(id).SuccessResult();
            }
            catch (Exception ex)
            {
                return Responses.FailureNullResult<Board>(ex.Message);
            }
        }

        public static ServiceResult<List<Sprint>> GetAllSprints()
        {
            try
            {
                return DAL.PublicLayer.GetAllSprints().SuccessResult();
            }
            catch (Exception ex)
            {
                return Responses.FailureNullResult<List<Sprint>>(ex.Message);
            }
        }

        public static ServiceResult<List<Sprint>> GetAllSprintsByRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                return DAL.PublicLayer.GetAllSprintsByRange(startDate, endDate).SuccessResult();
            }
            catch (Exception ex)
            {
                return Responses.FailureNullResult<List<Sprint>>(ex.Message);
            }
        }

        public static ServiceResult<Sprint> GetSprintByID(long id)
        {
            try
            {
                return DAL.PublicLayer.GetSprintByID(id).SuccessResult();
            }
            catch (Exception ex)
            {
                return Responses.FailureNullResult<Sprint>(ex.Message);
            }
        }
    }
}
