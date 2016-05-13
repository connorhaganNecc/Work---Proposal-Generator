using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProposalGenerator
{
    public class AddressData
    {
        public string street;
        public string town;
        public string state;
        public string zip;

        virtual public void ToUpper()
        {
            street = street.ToUpper();
            town = town.ToUpper();
            state = state.ToUpper();
            zip = zip.ToUpper();
        }

        public string StreetTownStateStr()
        {
            return street + ", " + town + ", " + state; 
        }
    }

    public class AddressExData : AddressData
    {
        public string map;
        public string lot;
        public string block;

        override public void ToUpper()
        {
            map = map.ToUpper();
            lot = lot.ToUpper();
            block = block.ToUpper();
            base.ToUpper();
        }
    }

    public class ContactData : AddressData
    {
        public string FirstName;
        public string LastName;
        public string phone;
        public string co;
        public string title;

        public ContactData()
        {
            title = "";
            co = "NULL";
        }

        override public void ToUpper()
        {
            FirstName = FirstName.ToUpper();
            LastName = LastName.ToUpper();
            title = title.ToUpper();
            phone = phone.ToUpper();
            base.ToUpper();
        }
    }
}
