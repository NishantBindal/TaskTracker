using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Model.Jira
{
    public class CreateIssue
    {
        public IEnumerable<Fields> Fields { get; set; }
    }
}
