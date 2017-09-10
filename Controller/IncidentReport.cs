using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controller
{
   public class IncidentReport
    {
       private int reportedBy;
       private int reportedTo;
       private string severitylevel;
       private string description;
       private string status;
       private DateTime dateTime;
       private string location;
       private string actionTaken;
       public IncidentReport()
       {
       }

       public int ReportedBy
       {
           get { return reportedBy; }
           set { reportedBy = value; }
       }

       public int ReportedTo
       {
           get { return reportedTo; }
           set { reportedTo = value; }
       }
       public string Severitylevel
       {
           get { return severitylevel; }
           set { severitylevel = value; }
       }
       public string Description
       {
           get { return description; }
           set { description = value; }
       }
       public string Status
       {
           get { return status; }
           set { status = value; }
       }

       public DateTime reportDateTime
       {
           get { return dateTime; }
           set { dateTime = value; }
       }

       public string Location
       {
           get { return location; }
           set { location = value; }
       }
       public string ActionTaken
       {
           get { return actionTaken; }
           set { actionTaken = value; }
       }
    }
}
