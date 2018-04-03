using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class Roster
    {

        public Roster() { }

        #region Variables
        protected Guid _RosterID;
        protected int _CreatedByID;
        protected int _AssignedToEomployeeID;
        protected DateTime _RosterDate;
        protected DateTime _RosterStartTime;
        protected DateTime _RosterEndTime;
        protected string _RosterSite = string.Empty;
        protected string _RosterTask = string.Empty;
        protected string _AssignedEmployeeEmail;
        #endregion

        #region Class Property
        public Guid RosterID { get { return _RosterID; } set {_RosterID = value; } }
        public int CreatedByID { get { return _CreatedByID; } set { _CreatedByID = value; } }
        public int AssignedToEomployeeID { get { return _AssignedToEomployeeID; } set { _AssignedToEomployeeID = value; } }
        public DateTime RosterDate { get { return _RosterDate; } set { _RosterDate = value; } }
        public DateTime RosterStartTime { get { return _RosterStartTime; } set { _RosterStartTime = value; } }
        public DateTime RosterEndTime { get { return _RosterEndTime; } set { _RosterEndTime = value; } }
        public string RosterSite { get { return _RosterSite; } set { _RosterSite = value; } }
        public string RosterTask { get { return _RosterTask; } set { _RosterTask = value; } }
        public string AssignedEmployeeEmail { get { return _AssignedEmployeeEmail; } set { _AssignedEmployeeEmail = value; } }
        #endregion
    }
}
