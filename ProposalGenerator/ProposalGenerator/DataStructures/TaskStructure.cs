using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProposalGenerator
{
    [Serializable()]
    public class TaskStructure
    {
        public int ID;
        public string rtftext;
        public string fee;
        public string Header { get; set; }
        public string Body { get; set; }
        public List<string> tags;
        public int serviceItemNum;
    }

    [Serializable()]
    public class TaskList
    {
        public List<TaskStructure> myTasks;
        public TaskList()
        {
            myTasks = new List<TaskStructure>();

        }
    }

    
    
    [Serializable()]
    public class AdditionalServiceList
    {
        public List<AdditionalServiceItem> itemList;

        public AdditionalServiceList()
        {
            itemList = new List<AdditionalServiceItem>();
        }
    }
    [Serializable()]
    public class AdditionalServiceItem
    {
        public string name;
        public string text;
        public string rfText;
        public List<string> ignoreTaskTags;
        public List<string> ignoreTypeTags;


        public AdditionalServiceItem()
        {
            ignoreTaskTags = new List<string>();
            ignoreTypeTags = new List<string>();
        }
    }

    public class TaskTags
    {
        public List<string> myTags;

        public TaskTags()
        {
            myTags = new List<string>();

            myTags.Add("Septic Repair");
            myTags.Add("NOI");
            myTags.Add("LOMA Application");
            myTags.Add("LOMA Zone AE");
            myTags.Add("Loma with Flood Plain Elevation");
        }
    }

    public class AlphabetticalTaskComparer: IComparer<TaskStructure>
    {
        public int Compare(TaskStructure a, TaskStructure b)
        {
            if(String.Compare(a.Header,b.Header) >0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
