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

        public bool PAGE1VISIT;
        public bool PAGE2VISIT;
        public bool PAGE3VISIT;

        public ContractDataManager()
        {
            Assumptions = new List<string>();
        }
    }
}
