using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class Employee
    {
        private string username;
        private int UserId;
        private string emp_name;
        private DateTime created_dateTime;
        private DateTime date_of_birth;
        private string Address;
        private string suburb;
        private string state;
        private string postcode;
        private string TFN;
        private string ABN;
        private int createdByCompanyId;
        private string license;
        private string mobile;
        public Employee() { }

        public string License
        {
            get { return license; }
            set { license = value; }
        }
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
        public string T_FN
        {
            get { return TFN; }
            set { TFN = value; }
        }
        public string A_BN
        {
            get { return ABN; }
            set { ABN = value; }
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public int UserID
        {
            get { return UserId; }
            set { UserId = value; }
        }

        public string Emp_name
        {
            get { return emp_name; }
            set { emp_name = value; }
        }
     public DateTime Created_dateTime
        {
            get { return created_dateTime; }
            set { created_dateTime = value; }
        }
     public DateTime Date_of_birth
        {
            get { return date_of_birth; }
            set { date_of_birth = value; }
        }
     public string address
        {
            get { return Address; }
            set { Address = value; }
        }
        public string State
        {
            get { return state; }
            set { state = value; }
        }
     public string Suburb
        {
            get { return suburb; }
            set { suburb = value; }
        }
     public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }
        public int CreatedByCompanyId
        {
            get { return createdByCompanyId; }
            set { createdByCompanyId = value; }
        }

    }
}
