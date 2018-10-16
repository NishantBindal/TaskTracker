using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.Model.Jira
{
    public class Issuetype
    {
        public string id { get; set; }
    }

    public class Assignee
    {
        public string name { get; set; }
    }
    public class Timetracking
    {
        public string originalEstimate { get; set; }
        public string remainingEstimate { get; set; }
    }
    public class Parent
    {
        public string key { get; set; }
    }

    public class Fields
    {
        public Fields()
        {
            this.SourceProject = new Project();
            this.Parent = new Parent();
            this.Assignee = new Assignee();
            this.IssueType = new Issuetype();
            this.TimeTracking = new Timetracking();
        }


        public Parent Parent { get; set; }
        public Project SourceProject { get; set; }
        public Assignee Assignee { get; set; }
        public Issuetype IssueType { get; set; }
        public string Description { get; set; }

        public string Summary { get; set; }

        //public Reporter reporter { get; set; }
        //public Priority priority { get; set; }
        //public List<string> labels { get; set; }
        public Timetracking TimeTracking { get; set; }
        //public Security security { get; set; }
        //public List<Version> versions { get; set; }
        //public string environment { get; set; }

        //public string duedate { get; set; }
        //public List<FixVersion> fixVersions { get; set; }
        //public List<Component> components { get; set; }
        //public List<string> customfield_30000 { get; set; }
        //public Customfield80000 customfield_80000 { get; set; }
        //public string customfield_20000 { get; set; }
        //public string customfield_40000 { get; set; }
        //public List<string> customfield_70000 { get; set; }
        //public string customfield_60000 { get; set; }
        //public string customfield_50000 { get; set; }
        //public string customfield_10000 { get; set; }
        public string customfield_11400 { get; set; }//start date

        public string customfield_10032 { get; set; }//due date

    }
}
