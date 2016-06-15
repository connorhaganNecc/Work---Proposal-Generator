using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace ProposalGenerator.Data
{
    static class Settings
    {
        public static SettingsData myData;

        static Settings()
        {
            myData = new SettingsData();
            myData = SettingsSerializer.DeserializeSettings();
        }

        public static void OpenTaskFileDialog()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "tasks";
            dlg.DefaultExt = ".xml";
            dlg.Filter = "Tasks.xml (.xml)|tasks.xml";

            //Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                myData.TaskFileLoc = dlg.FileName;
            }
        }
        public static void OpenContractTaskFileDialog()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "ContractTasks";
            dlg.DefaultExt = ".xml";
            dlg.Filter = "ContractTasks.xml (.xml)|ContractTasks.xml";

            //Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                myData.ContractTaskLoc = dlg.FileName;
            }
        }
        public static void OpenAddFileDialog()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "AddServices";
            dlg.DefaultExt = ".xml";
            dlg.Filter = "AddServices.xml (.xml)|AddServices.xml";

            //Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                myData.AddItemsFileLoc = dlg.FileName;
            }
        }
        public static void OpenOutputFileDialog()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                myData.DefaultOutputDirectory = fbd.SelectedPath;
            }
        }
    }

    [Serializable()]
    public class SettingsData
    {
        public string TaskFileLoc;
        public string DefaultOutputDirectory;
        public string AddItemsFileLoc;
        public string ContractTaskLoc;

        public SettingsData()
        {
            TaskFileLoc = "NOTHING";
            DefaultOutputDirectory = "NOTHING";
            AddItemsFileLoc = "NOTHING";
            ContractTaskLoc = "NOTHING";
        }
    }
}
