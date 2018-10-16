using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Model.Jira
{
    public class Project
    {
        public string expand { get; set; }
        public string self { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public string projectTypeKey { get; set; }
        //public string Expand { get; set; }
        //public string Self { get; set; }
        //public string Id { get; set; }
        //public string Key { get; set; }
        //public string Name { get; set; }
        //public string ProjectTypeKey { get; set; }
    }
}
