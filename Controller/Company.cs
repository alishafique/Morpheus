using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controller
{
   public class Company
    {
      
       private int intmembership_id;
       private string strcompanyName;
       private string strcompany_email;
       private DateTime dtcreated_date_time;
       private int intcompanyType_id;
       private string mobileNo;
       private string landlineNo;
       public Company()
       {
       }

        public string ABN { get; set; }
        public string Mobile
        {
            get { return mobileNo; }
            set { mobileNo = value; }
        }
        public string Landline
        {
            get { return landlineNo; }
            set { landlineNo = value; }
        }
       public int membership_id
       {
           get { return intmembership_id; }
           set { intmembership_id = value; }
       }
       public string companyName
       {
           get { return strcompanyName; }
           set { strcompanyName = value; }
       }
       public string company_email
       {
           get { return strcompany_email; }
           set { strcompany_email = value; }
       }
       public DateTime created_date_time
       {
           get { return dtcreated_date_time; }
           set { dtcreated_date_time = value; }
       }
       public int companyType_id
       {
           get { return intcompanyType_id; }
           set { intcompanyType_id = value; }
       }
    }
}
