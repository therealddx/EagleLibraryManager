using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ELM_GUI
{
    public partial class ChooseInOutPaths_UC : UserControl
    {
        public ChooseInOutPaths_UC()
        {
            InitializeComponent();
        }
        
        //Upon FormLoad: Put in tb's what current paths are.
        private void ChooseInOutPaths_UC_Load(object sender, EventArgs e)
        {
            if (ELM_GUI.CurrentSession.inputPath != string.Empty)
            {
                ChooseInputFilePath_tb.Text = ELM_GUI.CurrentSession.inputPath;
            }
            if (ELM_GUI.CurrentSession.outputPath != string.Empty)
            {
                ChooseOutputFilePath_tb.Text = ELM_GUI.CurrentSession.outputPath;
            }
            //allow changing
        }
        
        //Upon OK click: 
        private void OK_btn_Click(object sender, EventArgs e)
        {
            //If paths don't exist, re-enter.
            if (!File.Exists(ChooseInputFilePath_tb.Text))//) || (!File.Exists(ChooseOutputFilePath_tb.Text)))
            {
                MessageBox.Show("Path can't be found - please review your path.");
            }

            //If paths exist, get current device list.
            else
            {
                ELM_GUI.CurrentSession.inputPath = ChooseInputFilePath_tb.Text;
                ELM_GUI.CurrentSession.outputPath = ChooseOutputFilePath_tb.Text;
                
                IntPtr p = ELM_GUI.GetCurrentDeviceNameList_GUI(ELM_GUI.stringToCharArray(ELM_GUI.CurrentSession.inputPath));
                ELM_GUI.CurrentSession.ProcessIntPtrToStringArray(p);
                
                MessageBox.Show("Loaded (" + ELM_GUI.CurrentSession.currentDeviceNameList.Length + ")" +
                    " devices from:\n " + ELM_GUI.CurrentSession.inputPath);
                
                SendToBack();
                Visible = false;
            }
        }
    }
}
