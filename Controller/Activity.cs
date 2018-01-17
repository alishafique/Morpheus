using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class Activity
    {
        
        private int CompanyCreatedID;
        private int AssigneduserID;
        private string Activity_Name;
        private string Activity_Location;
        private string Activity_Type;
        private string Activity_Description;
        private string Activity_Status;
        private string startDate;
        private string formsURL;
        //private string startTime;
        //private string endTime;
        public Activity() { }

        public int companyCreatedID {  get { return CompanyCreatedID; } set { CompanyCreatedID = value; } }
        public int assigneduserID { get { return AssigneduserID; } set { AssigneduserID = value; } }
        public string activity_Name { get { return Activity_Name; } set { Activity_Name = value; } }
        public string activity_Location { get { return Activity_Location; } set { Activity_Location = value; } }
        public string activity_Type { get { return Activity_Type; } set { Activity_Type = value; } }
        public string activity_Description { get { return Activity_Description; } set { Activity_Description = value; } }
        public string activity_Status { get { return Activity_Status; } set { Activity_Status = value; } }
        public string StartDate { get { return startDate; } set { startDate = value; } }
        public string FormsURL { get { return formsURL; } set { formsURL = value; } }
        //public string StartTime { get { return startTime; } set { startTime = value; } }
        //public string EndTime { get { return endTime; } set { endTime = value; } }
    }
}
