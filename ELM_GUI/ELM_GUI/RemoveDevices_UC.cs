using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELM_GUI;

namespace ELM_GUI
{
    public partial class RemoveDevices_UC : UserControl
    {
        public RemoveDevices_UC()
        {
            InitializeComponent();
        }
        
        //Done using.
        private void RemoveDevicesUC_Back_btn_Click(object sender, EventArgs e)
        {
            SendToBack();
            Visible = false;
        }
        
        //Using.
        private void updateDeviceList()
        {
            //Given ELM_GUI.CurrentSession.currentDeviceNameList as a string[], how do we 
            //push that into the listboxlabel.textstringobjectcollection<><><TTT<>><T><T
            if (Visible == true)
            {
                //Remove everything that was there.
                DeviceList_lb.Items.Clear();

                //Add new things.
                for (int n = 0; n < ELM_GUI.CurrentSession.currentDeviceNameList.Length; n++)
                {
                    DeviceList_lb.Items.Add(ELM_GUI.CurrentSession.currentDeviceNameList[n]);
                }
            }
        }
        private void RemoveDevicesUC_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible == true)
            {
                updateDeviceList();
            }
        }
        
        private string[] SOCtoStringArray(ListBox.SelectedObjectCollection soc)
        {
            string[] names = new string[soc.Count];

            int n = 0;
            foreach (string x in soc)
            {
                names[n] = x;
                n++;
            }
            return names;
        }
        private void RemoveDevicesUC_Remove_btn_Click(object sender, EventArgs e)
        {
            //Do all the calls for removing selected devices based on selected items in DeviceList_lbl.
            //DeviceList_lb.SelectedItems

            //GetCurrentDeviceNameList_GUI(char[] path);

            //Calculate namesToRemove.
            ListBox.SelectedObjectCollection selectedNames = DeviceList_lb.SelectedItems;
            //foreach (string x in selectedNames)
            //{
            //    MessageBox.Show(x);
            //}

            string[] namesToRemove = SOCtoStringArray(selectedNames);
            string namesToRemoveString = ELM_GUI.stringArrayToString(namesToRemove);

            //Calculate output path.
            string outputPath = "C:\\Users\\Mehdy Faik\\AppData\\Roaming\\SPB_16.6\\eagle\\Library_Holder\\General_Passives_Test1.lbr";

            //Call.
            IntPtr val_PTR = ELM_GUI.RemoveDevices_GUI(ELM_GUI.stringToCharArray(ELM_GUI.CurrentSession.inputPath),
                                                       ELM_GUI.stringToCharArray(namesToRemoveString),
                                                       ELM_GUI.stringToCharArray(ELM_GUI.CurrentSession.outputPath)
                                                       );
            //Interpret.
            ELM_GUI.CurrentSession.ProcessIntPtrToStringArray(val_PTR);

            //Update namelist in device box.
            updateDeviceList();
            
        }
    }
}
