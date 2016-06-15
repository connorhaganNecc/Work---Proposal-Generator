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
        public List<string> AddServ;

        public List<ContractTask> myTaskList;

        public bool PAGE1VISIT;
        public bool PAGE2VISIT;
        public bool PAGE3VISIT;
        public bool PAGE4VISIT;
        public bool PAGE5VISIT;
        public bool PAGE6VISIT;
        public bool PAGE7VISIT;
        public bool PAGE8VISIT;

        public bool hasSubSubtasks;

        public float retainer = 0;

        public class Author
        {
            public string name;
            public string title;

            public Author()
            {
                name = "";
                title = "";
            }
        }

        public Author author;

        public string TermsType;

        public ContractDataManager()
        {
            Client = new ContactData();
            Property = new AddressExData();
            Assumptions = new List<string>();
            myTaskList = new List<ContractTask>();
            AddServ = new List<string>();
            author = new Author();
        }
    }
}
