using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controller
{
   public class Evidence
    {
       private int incidentID;
       private string fileName;

       public Evidence(int _incidentID, string _fileName)
       {
            incidentID = _incidentID;
            fileName = _fileName;
       }

       public int IncidentID
        {
           get { return incidentID; }
           set { incidentID = value; }
       }

       public string FileName
        {
           get { return fileName; }
           set { fileName = value; }
       }
    }
}
