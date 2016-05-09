using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProposalGenerator
{
    public class DataManager
    {
        /// <summary>
        /// Holds important data that may need to be reused.
        /// </summary>

        /// <example>
        /// Such as property town, client name, etc.
        /// </example>

        public ContactData Client;

        public AddressExData PropertyLocation;
        public bool propertyDataSameAsClient = false;


        public ContactData MCGContact;

        public string DearLine;
        public string CustomParagraph;

        public TaskList SelectedTasks;
        public string ProposalType;

        public string ClosingType;
        public string TermsType;

        public float retainerAmount;

        public bool useCustomReLine;
        public string CustomReLine;

        public string SigCloser;

        public List<string> AdditServNotInc;
        public List<string> Assumptions;

        public bool PAGE1VISIT = false;
        public bool PAGE2VISIT = false;
        public bool PAGE3VISIT = false;
        public bool PAGE4VISIT = false;
        public bool PAGE5VISIT = false;
        public bool PAGE6VISIT = false;

        public DataManager()
        {
            Init();
        }

        public float soilTestingFee;
        public float septicReviewFee;
        public int septicReviewNum;

        void Init()
        {
            propertyDataSameAsClient = false;
            PropertyLocation = new AddressExData();
            Client = new ContactData();
            MCGContact = new ContactData();

            SelectedTasks = new TaskList();
            SelectedTasks.myTasks = new List<TaskStructure>();

            MCGContact.title = "None";
            MCGContact.FirstName = "THE MORIN-CAMERON GROUP, INC.";
            MCGContact.LastName = "";
            MCGContact.street = "447 BOSTON STREET";
            MCGContact.state = "MA";
            MCGContact.town = "TOPSFIELD";
            MCGContact.zip = "01983";

            DearLine = "Dear ";

            AdditServNotInc = new List<string>();

            soilTestingFee = 0;
            septicReviewFee = 0;

            PAGE1VISIT = false;
            PAGE2VISIT = false;
            PAGE3VISIT = false;
            PAGE4VISIT = false;
            PAGE5VISIT = false;
            PAGE6VISIT = false;
    }
    }
}
