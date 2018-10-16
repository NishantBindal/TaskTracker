using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Model.Jira
{
    public class CreateIssueResponse
    {
        public List<Issue> issues { get; set; }
        public List<object> errors { get; set; }
    }
}
