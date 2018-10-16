using System;
using System.Collections.Generic;
using System.Linq;
using TaskTracker.Enums;
using TaskTracker.DAL.Context;
using TaskTracker.DAL.Entity;

namespace TaskTracker.DAL
{
    public class PublicLayer
    {
        public static List<Board> GetBoards()
        {
            using (var context = new TaskTrackerContext())
            {
                return context.Boards.ToList();
            }
        }

        public static Board GetBoardByID(long id)
        {
            using (var context = new TaskTrackerContext())
            {
                var board = context.Boards.Find(id);
                return board;
            }
        }

        public static List<Sprint> GetAllSprints()
        {
            using (var context = new TaskTrackerContext())
            {
                return context.Sprints.ToList();
            }
        }

        public static List<Sprint> GetAllSprintsByRange(DateTime startDate, DateTime endDate)
        {
            using (var context = new TaskTrackerContext())
            {
                return context.Sprints.Where(a => a.StartDate >= startDate && a.EndDate <= endDate).ToList();
            }
        }

        public static Sprint GetSprintByID(long id)
        {
            using (var context = new TaskTrackerContext())
            {
                var sprint = context.Sprints.Find(id);
                return sprint;
            }
        }
    }
}
