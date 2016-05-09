using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProposalGenerator
{
    class ProposalTypes
    {
        public List<string> myList;

        public ProposalTypes()
        {
            

            myList = new List<string>();
            myList.Add("ANR");
            myList.Add("General");
            myList.Add("LOMA Application");
            myList.Add("LOMA with Flood Plain Elevation");
            myList.Add("LOMA Zone AE");
            myList.Add("NOI");
            myList.Add("Septic Repair");
            myList.Add("Site Plan");
            myList.Add("Survey");

            //myList.Add("Design Development & Permitting");




            myList.Sort();
        }
    }

    class ProposalData
    {
        public int ID;
        public string Name;
        public bool contractType;

        public ProposalData(int inID, string inName, bool inContract)
        {
            ID = inID;
            Name = inName;
            contractType = inContract;
        }
    }

}
