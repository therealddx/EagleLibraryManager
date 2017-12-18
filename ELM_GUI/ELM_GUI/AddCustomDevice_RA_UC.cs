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
    public partial class AddCustomDevice_RA_UC : UserControl
    {
        public AddCustomDevice_RA_UC()
        {
            InitializeComponent();
        }

        //Math helpers.
        int calc_RA_numPads(int d_N, double d_cornerSquarePads_DIM, double d_centeredSquarePad_DIM)
        {
            int returnThis = 4 * d_N;
            if (d_cornerSquarePads_DIM > 0) //dim >= 10000 still satisfies this. so the value gets passed in.
                returnThis += 4;
            if (d_centeredSquarePad_DIM > 0)
                returnThis++;

            return returnThis;
        }
        double calc_cornerSquarePads_DIM()
        {
            
            if (noCornerPad_rb.Checked == true) //If you don't want corner pads, that's -1.
            {
                return -1;
            }
            else if (corner_copyLateral_rb.Checked == true) //If you want to copy lateral, that's that big # send
            {
                return 20000;
            }
            else //else that's you want to custom, send data
            {
                return Convert.ToDouble(ccp_dim_tb.Text);
            }

        }

        //Housework fns.
        private void AddCustomDevice_RA_UC_Load(object sender, EventArgs e)
        {
            centeredPad_rb.Checked = true;
            noCenterPad_rb.Checked = false;
            noCenterPad_rb.Checked = true;

            noCornerPad_rb.Checked = false;
            noCornerPad_rb.Checked = true;

            newDeviceName_tb.Text = "NEW_RECTANGULAR_ARRAY";
            REF_tb.Text = "5.0";
            N_tb.Text = "6";
            lateralPads_width_tb.Text = "0.2";
            lateralPads_length_tb.Text = "0.5";
            padSpace_tb.Text = "0.5";
        }
        private void newDeviceName_tb_TextChanged(object sender, EventArgs e)
        {
            //ELM_GUI.cleanTextInput(newDeviceName_tb);
        }
        private void N_tb_TextChanged(object sender, EventArgs e)
        {
            //ELM_GUI.cleanIntInput(N_tb);
        }
        private void padSpace_tb_TextChanged(object sender, EventArgs e)
        {
//            ELM_GUI.cleanDoubleInput(padSpace_tb);
        }
        private void centeredPadX_tb_TextChanged(object sender, EventArgs e)
        {
            //ELM_GUI.cleanDoubleInput(centeredPadX_tb);
        }
        private void ccp_dim_tb_TextChanged(object sender, EventArgs e)
        {
            //ELM_GUI.cleanDoubleInput(ccp_dim_tb);
        }
        private void ccp_ref_tb_TextChanged(object sender, EventArgs e)
        {
            //ELM_GUI.cleanDoubleInput(ccp_ref_tb);
        }

        //Center pads.
        private void centeredPad_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (centeredPad_rb.Checked == true)
            {
                ELM_GUI.enableTB(centeredPadX_tb);
            }
        }
        private void noCenterPad_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (noCenterPad_rb.Checked == true)
            {
                ELM_GUI.disableTB(centeredPadX_tb);
            }
        }
       
        //Corner pads.
        private void customCornerPad_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (customCornerPad_rb.Checked == true)
            {
                ELM_GUI.enableTB(ccp_dim_tb);
                ELM_GUI.enableTB(ccp_ref_tb);
            }
        }
        private void noCornerPad_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (noCornerPad_rb.Checked == true)
            {
                ELM_GUI.disableTB(ccp_dim_tb);
                ELM_GUI.disableTB(ccp_ref_tb);
            }
        }
        private void corner_copyLateral_rb_CheckedChanged(object sender, EventArgs e)
        {
            if (corner_copyLateral_rb.Checked == true)
            {
                ccp_dim_tb.ReadOnly = true;
                ccp_ref_tb.ReadOnly = true;

                ccp_ref_tb.Text = REF_tb.Text;
                ccp_dim_tb.Text = lateralPads_width_tb.Text + "x" + lateralPads_length_tb.Text;
            }
        }

        private void REF_tb_TextChanged(object sender, EventArgs e)
        {
            /*
            ELM_GUI.cleanDoubleInput(REF_tb);

            if (corner_copyLateral_rb.Checked == true)
            {
                //ccp_ref_tb set
                ccp_ref_tb.Text = REF_tb.Text;
            }
            */
        }
        private void lateralPads_width_tb_TextChanged(object sender, EventArgs e)
        {
            /*
            ELM_GUI.cleanDoubleInput(lateralPads_width_tb);

            if (corner_copyLateral_rb.Checked == true)
            {
                //ccp_dim_tb is always width_tb x length_tb.
                ccp_dim_tb.Text = lateralPads_width_tb.Text + "x" + lateralPads_length_tb.Text;
            }
            */
        }
        private void lateralPads_length_tb_TextChanged(object sender, EventArgs e)
        {
            /*
            ELM_GUI.cleanDoubleInput(lateralPads_length_tb);

            if (corner_copyLateral_rb.Checked == true)
            {
                //ccp_dim_tb is always width_tb x length_tb.
                ccp_dim_tb.Text = lateralPads_width_tb.Text + "x" + lateralPads_length_tb.Text;
            }
            */
        }
        
        //Execute.
        private void back_btn_Click(object sender, EventArgs e)
        {
            Visible = false;
            SendToBack();
        }
        private void generateDevice_btn_Click(object sender, EventArgs e)
        {
            /*
             Arguments.
             char* name,
             double ref, int N, double padW, double padL, double padSpace,
             double centeredSquarePad,
             double cornerSquarePads_REF, double cornerSquarePads_DIM
            
            Definition for centeredSquarePad_DIM:
                <=0: None.
                 >0: give me a centered squared pad with the dim.

            Definition for cornerSquarePads_DIM:
                <=0: None.
                >0, <10000: give me those corner pads with dim and ref given.
                >=10000: give me those corner pads with dim and ref equal to the lateral pads.
            
            As is, how many args is this. This is 8 args.

            If we used rectangular instead of square, what would we have.
             */

            //Under "Corner Pads":
                //If "Copy Lateral Pads" is checked:
                    //cornerSquarePads_REF then follows REF_tb
                    //cornerSquarePads_DIM then follows pad length and width..... but to communicate this in one variable
                    //I'll need to agree on a value to set cornerSquarePads_DIM to.

                //Process of events.
                    //When Copy Lateral Pads is checked under Corner pads, I now have event handlers to show the
                    //user in an accurate manner what is happening. That is a good thing.
                    //However on the backend what i'm doing is setting d_cornerSquarePads_DIM to be over 10000.
                    //So i need a fn for that.

            double d_REF = Convert.ToDouble(REF_tb.Text);
            int d_N = Convert.ToInt32(N_tb.Text);
            double d_padW = Convert.ToDouble(lateralPads_width_tb.Text);
            double d_padL = Convert.ToDouble(lateralPads_length_tb.Text);
            double d_padSpace = Convert.ToDouble(padSpace_tb.Text);
            
            double d_centeredSquarePad_DIM = centeredPadX_tb.Text == "N/A" ? -1 : Convert.ToDouble(centeredPadX_tb.Text);
            double d_cornerSquarePads_REF = ccp_ref_tb.Text == "N/A" ? -1 : Convert.ToDouble(ccp_ref_tb.Text);
            double d_cornerSquarePads_DIM = calc_cornerSquarePads_DIM();

            int numPads = calc_RA_numPads(d_N, d_cornerSquarePads_DIM, d_centeredSquarePad_DIM);
            char[] padNames = ELM_GUI.stringArrayToCharArray(ELM_GUI.textBoxToPadNamesList(padNames_tb, numPads));

            int initialNumDevices = ELM_GUI.CurrentSession.currentDeviceNameList.Length;

            IntPtr newDeviceList_IntPtr = ELM_GUI.AddDevice_RA_GUI(
                 ELM_GUI.stringToCharArray(ELM_GUI.CurrentSession.inputPath),//char[] inputPath,
                 ELM_GUI.stringToCharArray(newDeviceName_tb.Text),//char[] d_name,
                 padNames,//char[] padNames,

                 d_REF, d_N, d_padW, d_padL, d_padSpace,
                 d_centeredSquarePad_DIM,
                 d_cornerSquarePads_REF, d_cornerSquarePads_DIM,
                 
                 ELM_GUI.stringToCharArray(ELM_GUI.CurrentSession.outputPath)//char[] outputPath
            );
            
            ELM_GUI.postDeviceAdd(newDeviceList_IntPtr, initialNumDevices);
            foreach (string x in ELM_GUI.CurrentSession.currentDeviceNameList)
                Debug.WriteLine(x);
            Debug.WriteLine("New num devices: " + ELM_GUI.CurrentSession.currentDeviceNameList.Length +
                "\nOld num devices: " + initialNumDevices);
        }

        
    }
}
