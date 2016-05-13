using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProposalGenerator
{
    public class ContractDataManager
    {
        public ContactData Client;
        public AddressExData Property;

        public string ProposalType;

        public bool propertyDataSameAsClient;

        public string CustomParagraph;

        public List<string> Assumptions;

        public ContractTaskList myTaskList;

        public bool PAGE1VISIT;
        public bool PAGE2VISIT;
        public bool PAGE3VISIT;

        public ContractDataManager()
        {
            Client = new ContactData();
            Property = new AddressExData();
            Assumptions = new List<string>();
            myTaskList = new ContractTaskList();
        }
    }
}
