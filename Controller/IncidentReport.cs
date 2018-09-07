using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controller
{
   public class IncidentReport
    {
       public IncidentReport()
       {
       }

       public Int64 ReportedBy { get; set; }
        public Int64 id { get; set; }


        public Int64 ReportedTo { get; set; }
        public string Severitylevel { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string ReportedLocation { get; set; }

        public DateTime reportDateTime { get; set; }

        public string ReportedDateTimeToShow { get; set; }

        public string Location { get; set; }
        public string ActionTaken { get; set; }
    }
}
