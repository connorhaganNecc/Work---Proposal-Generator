using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProposalGenerator
{

    class ClosingTypes
    {
        public List<string> myList;

        public ClosingTypes()
        {
            myList = new List<string>();
            myList.Add("Closing with authorization form");
            myList.Add("Closing without authorization form");
            myList.Add("Closing without retainer");
        }
    }
}
