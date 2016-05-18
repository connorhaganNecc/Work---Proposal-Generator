using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace ProposalGenerator
{
    public static class TaskSerializer
    {
        //static FileStream ReadFileStream;
        //static TextWriter WriteFileStream;
        static XmlSerializer serialObj;

        static TaskSerializer()
        {
            try
            {
                serialObj = new XmlSerializer(typeof(ProposalGenerator.TaskList));
                //WriteFileStream = new StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory+ "tasks.xml");
                //ReadFileStream = new FileStream(System.AppDomain.CurrentDomain.BaseDirectory + "tasks.xml", FileMode.Open, FileAccess.Read);
            }
            catch
            {

            }
        }
        public static void SerializeTaskList(ProposalGenerator.TaskList inTaskList)
        {
            TextWriter WriteFileStream = new StreamWriter(Data.Settings.myData.TaskFileLoc);
            serialObj.Serialize(WriteFileStream, inTaskList);
            WriteFileStream.Close();
        }

        public static TaskList DeserializeTaskList()
        {
            FileStream ReadFileStream = new FileStream(Data.Settings.myData.TaskFileLoc, FileMode.Open, FileAccess.Read);
            TaskList myList =  serialObj.Deserialize(ReadFileStream) as TaskList;
            ReadFileStream.Close();
            return myList;
        }
    }
    public static class AdditionalItemsSerializer 
    {
        static XmlSerializer serialObj;

        static AdditionalItemsSerializer()
        {
            try
            {
                serialObj = new XmlSerializer(typeof(ProposalGenerator.AdditionalServiceList));
            }
            catch
            {

            }
        }
        public static void SerializeList(ProposalGenerator.AdditionalServiceList inList)
        {
            TextWriter WriteFileStream = new StreamWriter(Data.Settings.myData.AddItemsFileLoc);
            serialObj.Serialize(WriteFileStream, inList);
            WriteFileStream.Close();
        }
        public static AdditionalServiceList DeserializeList()
        {
            FileStream ReadFileStreawm = new FileStream(Data.Settings.myData.AddItemsFileLoc, FileMode.Open, FileAccess.Read);
            AdditionalServiceList myList = serialObj.Deserialize(ReadFileStreawm) as AdditionalServiceList;
            ReadFileStreawm.Close();
            return myList;
        }

    }
    public static class SettingsSerializer
    {
        //static FileStream ReadFileStream;
        //static TextWriter WriteFileStream;
        static XmlSerializer serialObj;

        static SettingsSerializer()
        {
            try
            {
                serialObj = new XmlSerializer(typeof(ProposalGenerator.Data.SettingsData));
                //WriteFileStream = new StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory+ "tasks.xml");
                //ReadFileStream = new FileStream(System.AppDomain.CurrentDomain.BaseDirectory + "tasks.xml", FileMode.Open, FileAccess.Read);
            }
            catch
            {

            }
        }
        public static void SerializeSettings(ProposalGenerator.Data.SettingsData inTaskList)
        {
            TextWriter WriteFileStream = new StreamWriter("Data/settings.xml");
            serialObj.Serialize(WriteFileStream, inTaskList);
            WriteFileStream.Close();
        }

        public static Data.SettingsData DeserializeSettings()
        {
            FileStream ReadFileStream = new FileStream("Data/settings.xml", FileMode.Open, FileAccess.Read);
            Data.SettingsData myData = serialObj.Deserialize(ReadFileStream) as Data.SettingsData;
            ReadFileStream.Close();
            return myData;
        }
    }

    public static class ContractTaskSerializer
    {
        //static FileStream ReadFileStream;
        //static TextWriter WriteFileStream;
        static XmlSerializer serialObj;

        static ContractTaskSerializer()
        {
            try
            {
                serialObj = new XmlSerializer(typeof(ProposalGenerator.ContractTaskList));
                //WriteFileStream = new StreamWriter(System.AppDomain.CurrentDomain.BaseDirectory+ "tasks.xml");
                //ReadFileStream = new FileStream(System.AppDomain.CurrentDomain.BaseDirectory + "tasks.xml", FileMode.Open, FileAccess.Read);
            }
            catch
            {

            }
        }
        public static void SerializeContractTasks(ProposalGenerator.ContractTaskList inTaskList)
        {
            TextWriter WriteFileStream = new StreamWriter("Data/ContractTasks.xml");
            serialObj.Serialize(WriteFileStream, inTaskList);
            WriteFileStream.Close();
        }

        public static ContractTaskList DeserializeContractTasks()
        {
            FileStream ReadFileStream = new FileStream("Data/ContractTasks.xml", FileMode.Open, FileAccess.Read);
            ContractTaskList myData = serialObj.Deserialize(ReadFileStream) as ContractTaskList;
            ReadFileStream.Close();
            return myData;
        }
    }

}
