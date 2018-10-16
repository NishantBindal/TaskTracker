using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TaskTracker.DAL.Enitty;
using TaskTracker.DAL.Entity;

namespace TaskTracker.DAL.Context
{
    public class TaskTrackerContext : DbContext
    {
        public TaskTrackerContext(DbContextOptions options=null) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=TaskTracker;user id=swsadmin;password=SeniorWellnessSASpider1!;");
        }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Member> BoardMembers { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<AuthClientConfig> AuthClientConfigs { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
    }
}
