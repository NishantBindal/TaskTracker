//using System;
//using System.Linq;
//using TaskTracker.Enums;
//using TaskTracker.Enums.Enumerators;
//using TaskTracker.DAL.Context;
//using TaskTracker.DAL.Entity;

//namespace TaskTracker.DAL
//{
//    public class AdminLayer
//    {
//        public static Messages AddBoard(Board board)
//        {
//            using (var context = new TaskTrackerContext())
//            {
//                var dbBoard = context.Boards.FirstOrDefault(a => a.Name.ToLower() == board.Name.ToLower());
//                if (dbBoard != null)
//                {
//                    return Messages.RecordAlreadyExists;
//                }

//                context.Boards.Add(board);
//                context.SaveChanges();
//                return Messages.Success;
//            }
//        }

//        public static Messages UpdateBoard(Board board)
//        {
//            using (var context = new TaskTrackerContext())
//            {
//                var dbBoard = context.Boards.Find(board.ID);
//                if (dbBoard == null)
//                {
//                    return Messages.RecordNotFound;
//                }

//                context.Boards.Update(board);
//                context.SaveChanges();
//                return Messages.Success;
//            }
//        }

//        public static Messages AddBoardMember(Member member)
//        {
//            using (var context = new TaskTrackerContext())
//            {
//                var dbMember = context.BoardMembers.FirstOrDefault(a => a.Name.ToLower() == member.Name.ToLower());
//                if (dbMember != null)
//                {
//                    return Messages.RecordAlreadyExists;
//                }

//                member.ID = Guid.NewGuid();
//                context.BoardMembers.Add(member);
//                context.SaveChanges();
//                return Messages.Success;
//            }
//        }
//    }
//}
