using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.DAL.Context;

namespace TaskTracker.DAL
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TaskTrackerContext>
    {
        public TaskTrackerContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TaskTrackerContext>();
            builder.UseSqlServer(
               " Data Source =.; Initial Catalog = TaskTracker; user id = swsadmin; password = SeniorWellnessSASpider1!; ");
            return new TaskTrackerContext(builder.Options);
        }
    }
}
