using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controller
{
    public class Address
    {
        private string streetAddress;
        private string Add_state;
        private string postcode;
        private string suburb;
        public Address() { }

        public string StreetAddress
        {
            get { return streetAddress; }
            set { streetAddress = value; }
        }

        public string State
        {
            get { return Add_state; }
            set { Add_state = value; }
        }

        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }
        public string Suburb
        {
            get { return suburb; }
            set { suburb = value;}
        }

    }


}
