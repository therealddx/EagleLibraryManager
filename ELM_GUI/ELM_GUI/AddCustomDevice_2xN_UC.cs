using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ELM_GUI
{
    public partial class AddCustomDevice_2xN_UC : UserControl
    {
        public AddCustomDevice_2xN_UC()
        {
            InitializeComponent();
        }

        //Housework fns.
        private void newDeviceName_tb_TextChanged(object sender, EventArgs e)
        {
            // ELM_GUI.cleanTextInput(newDeviceName_tb);
        }
        private void N_tb_TextChanged(object sender, EventArgs e)
        {
            //ELM_GUI.cleanIntInput(N_tb);
        }
        private void space_x_tb_TextChanged(object sender, EventArgs e)
        {
            //ELM_GUI.cleanDoubleInput(space_x_tb);
        }
        private void space_y_tb_TextChanged(object sender, EventArgs e)
        {
            //ELM_GUI.cleanDoubleInput(space_y_tb);
        }
        private void dim_x_tb_TextChanged(object sender, EventArgs e)
        {
            //ELM_GUI.cleanDoubleInput(dim_x_tb);
        }
        private void dim_y_tb_TextChanged(object sender, EventArgs e)
        {
            //ELM_GUI.cleanDoubleInput(dim_y_tb);
        }
        private void padNames_tb_TextChanged(object sender, EventArgs e)
        {
            //ELM_GUI.cleanTextInput(padNames_tb);
        }

        private void AddCustomDevice_2xN_UC_Load(object sender, EventArgs e)
        {
            newDeviceName_tb.Text = "NEW_2XN";
            space_x_tb.Text = "1.0";
            space_y_tb.Text = "2.0";
            dim_x_tb.Text = "0.5";
            dim_y_tb.Text = "1.0";
            N_tb.Text = "6";
        }
        private void convertUnitToMM(double[] x)
        {
            for (int n = 0; n < x.Length; n++)
            {
                if (mil_rb.Checked)
                {
                    x[n] *= 0.0254;
                }
                else
                {
                    x[n] = x[n];
                }
            }
        }

        //Execute.
        private void generateDevice_btn_Click(object sender, EventArgs e)
        {
            //Generate the arguments to put into the Pinvoke.
            int N = Convert.ToInt32(N_tb.Text);
            char[] padNames = ELM_GUI.stringArrayToCharArray(
                                      ELM_GUI.textBoxToPadNamesList(padNames_tb, 2*N));

            double[] meas = new double[] { Convert.ToDouble(space_x_tb.Text), Convert.ToDouble(space_y_tb.Text), Convert.ToDouble(dim_x_tb.Text), Convert.ToDouble(dim_y_tb.Text) };
            convertUnitToMM(meas);
            double space_x = meas[0];
            double space_y = meas[1];
            double dim_x =   meas[2];
            double dim_y =   meas[3];

            int initialNumDevices = ELM_GUI.CurrentSession.currentDeviceNameList.Length;

            //Call the Pinvoke.
            IntPtr newDeviceList_IntPtr = ELM_GUI.AddDevice_2xN_GUI(
                ELM_GUI.stringToCharArray(ELM_GUI.CurrentSession.inputPath),
            
                ELM_GUI.stringToCharArray(newDeviceName_tb.Text),
                padNames,
                space_x, space_y, dim_x, dim_y, N,
            
                ELM_GUI.stringToCharArray(ELM_GUI.CurrentSession.outputPath)
                );
            ELM_GUI.postDeviceAdd(newDeviceList_IntPtr, initialNumDevices);
            
            //Push form to back.
            SendToBack();
            Visible = false;
        }
        private void back_btn_Click(object sender, EventArgs e)
        {
            SendToBack();
            Visible = false;
        }
    }
}
