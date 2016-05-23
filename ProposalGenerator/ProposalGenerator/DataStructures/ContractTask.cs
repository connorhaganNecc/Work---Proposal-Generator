using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProposalGenerator
{
    [Serializable()]
    public class ContractTaskList
    {
        public List<ContractTask> myTasks;
        public ContractTaskList()
        {
            myTasks = new List<ContractTask>();
        }
    }
    [Serializable()]
    public class ContractTask
    {
        public string HeadLevelItem;
        public string Description;
        public int ServiceItemNum;
        public List<ContractSubTask> subTasks;

        public bool allowsSubTasks;

        public ContractTask()
        {
            subTasks = new List<ContractSubTask>();

            allowsSubTasks = false;
        }
    }
    [Serializable()]
    public class ContractSubTask
    {
        public ContractSubtaskClass myClass;
        public string text;
        public string rtfText;
        public string name;
        public bool allowSubSub = false;

        public List<SubSubtask> SubItems;

        public ContractSubTask()
        {
            SubItems = new List<SubSubtask>();
        }
        public ContractSubTask(ContractSubtaskClass inClass)
        {
            myClass = inClass;
            SubItems = new List<SubSubtask>();
        }
    }
    [Serializable()]
    public class SubSubtask
    {
        public string name;
        public string description;
    }
    public enum ContractSubtaskClass
    {
        Bullet,
        Letter
    }

    class BasicContractTasks
    {
        public List<ContractTask> ContractTaskList;

        public BasicContractTasks()
        {
            ContractTaskList = new List<ContractTask>();

            ContractTask newTask = new ContractTask();
            newTask.HeadLevelItem = "EXISTING CONDITIONS SURVEY AND PLAN";
            newTask.ServiceItemNum = 300;
            newTask.Description = "MCG will perform a property line and existing conditions surveys plan including the following:";
            newTask.allowsSubTasks = true;
            ContractTaskList.Add(newTask);

            newTask = new ContractTask();

            newTask.HeadLevelItem = "DESIGN DEVELOPMENT";
            newTask.ServiceItemNum = 400;
            newTask.Description = "Utilizing the design concept approved by the Client an, MCG will prepare and include the following as part of the site development permit plans for submittal to the %TOWN% Boards:";
            newTask.allowsSubTasks = true;
            ContractTaskList.Add(newTask);

            newTask = new ContractTask();

            newTask.HeadLevelItem = "Permitting";
            newTask.ServiceItemNum = 500;
            newTask.Description = "NULL";
            newTask.allowsSubTasks = true;
            ContractTaskList.Add(newTask);

            newTask = new ContractTask();

            newTask.HeadLevelItem = "PROJECT MEETINGS & PREPARATION";
            newTask.ServiceItemNum = 600;
            newTask.Description = "A project manager or professional engineer will attend the meetings.";
            newTask.allowsSubTasks = true;
            ContractTaskList.Add(newTask);

            newTask = new ContractTask();

            newTask.HeadLevelItem = "SOIL TESTING";
            newTask.ServiceItemNum = 0;
            newTask.Description = "MCG will perform soil testing to verify soil conditions on the site for the purpose of siting proposed on-site wastewater disposal systems and demonstrating that the parcels are buildable.  Scope includes researching and review of NRCS Soil Conservation Service (SCS) soil maps, groundwater conditions and surface geological maps.  A total of 20 hours of field time by a certified soil evaluator plus time to prepare test hole forms has been included in the scope of services.";
            ContractTaskList.Add(newTask);

            newTask = new ContractTask();

            newTask.HeadLevelItem = "CONCEPT PLAN";
            newTask.ServiceItemNum = 0;
            newTask.Description = "MCG will prepare two (2) subdivision plans.  The first plan will illustrate a subdivision in full compliance with applicable zoning and subdivision regulations.  The “by-right” concept will illustrate the maximum development potential of the site taking into consideration soil information, wetlands and applicable zoning constraints.  The second concept plan will incorporate waivers under the subdivision regulations to minimize the development footprint.  Anticipated waivers may include but not be limited to roadway width, right of way width, sidewalks, curbing, stormwater management (country drainage) and reduced cul-de-sac diameter and off-centerline alignment.  Once the client approves the 2 concept plans, they will be updated to presentation quality format in color for use in informal meetings with the Conservation Commission and Planning Board.";
            ContractTaskList.Add(newTask);
        }
        
    }
}
