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
using System.Text.RegularExpressions;

namespace ELM_GUI
{
    public partial class AddCustomDevice_RxR_UC : UserControl
    {

        bool TB_MASTER_CONTROL = false;

        public AddCustomDevice_RxR_UC()
        {
            InitializeComponent();
        }

        /*
        private bool valid_input;
        private bool valid_vector_inputs()
        {
            //Checks for valid vecotr inputs across entire panel.


            return false;
        }
        
        private Regex generateRegexIntArray(int N)
        {
            string s = @"^\[";
            for (int n = 0; n < N; n++)
                s += @"\d+" + ",";
            s = s.Remove(s.Length - 1);
            s += @"\]$";
            return new Regex(s);
        }
        public bool isIntVectorValid_TB(TextBox tb)
        {
            Regex regex_intArray = generateRegexIntArray((int)(N_rows_nud.Value));
            return regex_intArray.IsMatch(tb.Text);
        }
        public bool isDoubleVectorValid_TB(TextBox tb)
        {
            Regex regex_doubleArray = generateRegexDoubleArray((int)(N_rows_nud.Value));
            return regex_doubleArray.IsMatch(tb.Text);
        }
        */

        //Vector valid inputs check.
        /*
        bool vecdata_isvalid;
        bool validate_textboxes()
        {
            //This function automatically:
            //Cleans double and int inputs when vectors have been turned into them.
            //Checks vector inputs where appropriate and returns a bool to tell whether they are all well.
            //Yeah so this basically just cleans up the whole picture doesn't it.
                //if there's an int to be entered it cleans it.
                //if there's a double to be entered it cleans it.
                //this saves me from typing the if structure into every single event handler.
                //stead i just have one fn to call.

            //DO THESE TEXTBOXES HOLD VALID DATA.
            //YES OR NO.

            int[] t_i = new int[(int)(N_rows_nud.Value)];
            double[] t_d = new double[(int)(N_rows_nud.Value)];

            ELM_GUI.cleanTextInput(newDeviceName_tb);

            if ((int)N_rows_nud.Value == 1)
            {
                //If it says "N/A" in there, that's ok IF the box is also readonly. Becuase the user might set it to
                //N/A but he'll never set it to readonly. GOOD.

                //LEFT FOUR are checked by being valid ints.
                ELM_GUI.cleanIntInput(Npads_tb);
                ELM_GUI.cleanDoubleInput(padX_tb);
                ELM_GUI.cleanDoubleInput(padY_tb);
                ELM_GUI.cleanDoubleInput(padSpace_tb);

                //RIGHT TWO are checked by holding "N/A" and being READONLY.
                    //If I want them to hold N/A and be READONLY, this would be the time to set it anyway.
                ELM_GUI.disableTB(offsetX_tb);
                ELM_GUI.disableTB(offsetY_tb);
            }
            else if ((int)N_rows_nud.Value == 2)
            {

                //LEFT FOUR are checked by being vectors
                t_i = ELM_GUI.textBoxToIntArray(Npads_tb);
                if (t_i[0] == -1) return false;
                t_d = ELM_GUI.textBoxToDoubleArray(padX_tb);
                if (t_d[0] == -1) return false;
                t_d = ELM_GUI.textBoxToDoubleArray(padY_tb);
                if (t_d[0] == -1) return false;
                t_d = ELM_GUI.textBoxToDoubleArray(padSpace_tb);
                if (t_d[0] == -1) return false;
                
                //RIGHT TWO are checked as doubles.
                ELM_GUI.cleanDoubleInput(offsetX_tb);
                ELM_GUI.cleanDoubleInput(offsetY_tb);
            }
            else
            {
                //Check left four as vectors.
                t_i = ELM_GUI.textBoxToIntArray(Npads_tb);
                if (t_i[0] == -1) return false;
                t_d = ELM_GUI.textBoxToDoubleArray(padX_tb);
                if (t_d[0] == -1) return false;
                t_d = ELM_GUI.textBoxToDoubleArray(padY_tb);
                if (t_d[0] == -1) return false;
                t_d = ELM_GUI.textBoxToDoubleArray(padSpace_tb);
                if (t_d[0] == -1) return false;

                //Check right two as vectors.
                t_d = ELM_GUI.textBoxToDoubleArray(offsetX_tb);
                if (t_d[0] == -1) return false;
                t_d = ELM_GUI.textBoxToDoubleArray(offsetY_tb);
                if (t_d[0] == -1) return false;
            }

            return true;
        }
        */

        //Misc math helper fns.
        public int calc_RxR_numPads()
        {
            double[] dd = ELM_GUI.textBoxToDoubleArray(Npads_tb);
            int totalNumPads = 0;

            foreach (double d in dd)
                totalNumPads += (int)d;

            return totalNumPads;
        }

        //Housekeeping: Helpers for vector setup.
        public void setIntTextBox(TextBox tb, int numInputTerms)
        {
            //fill TB w/ "[]" and (N - 1) commas.
            tb.Text = "[";
            for (int n = 0; n < numInputTerms; n++)
                tb.Text += ",";
            tb.Text = tb.Text.Remove(tb.Text.Length - 1);
            tb.Text += "]";
        }
        public void setDoubleTextBox(TextBox tb, int numInputTerms)
        {
            tb.Text = "[";
            for (int n = 0; n < numInputTerms; n++)
                tb.Text += ".,";
            tb.Text = tb.Text.Remove(tb.Text.Length - 1);
            tb.Text += "]";
        }

        public void setAllTextBoxesForInput()
        {
            //set all textboxes to have #inputs corresponding to N_rows.
            setIntTextBox(Npads_tb, (int)N_rows_nud.Value);
            setDoubleTextBox(padX_tb, (int)N_rows_nud.Value);
            setDoubleTextBox(padY_tb, (int)N_rows_nud.Value);
            setDoubleTextBox(padSpace_tb, (int)N_rows_nud.Value);

            setDoubleTextBox(offsetX_tb, (int)(N_rows_nud.Value - 1));
            setDoubleTextBox(offsetY_tb, (int)(N_rows_nud.Value - 1));
        }
        public void setAllTextBoxesForOneRow()
        {
            ELM_GUI.enableTB(Npads_tb);
            ELM_GUI.enableTB(padX_tb);
            ELM_GUI.enableTB(padY_tb);
            ELM_GUI.enableTB(padSpace_tb);

            ELM_GUI.disableTB(offsetX_tb);
            ELM_GUI.disableTB(offsetY_tb);

            Npads_tb.Text = "";
            padX_tb.Text = "";
            padY_tb.Text = "";
            padSpace_tb.Text = "";
        }
        public void setAllTextBoxesForTwoRow()
        {
            ELM_GUI.enableTB(Npads_tb);
            ELM_GUI.enableTB(padX_tb);
            ELM_GUI.enableTB(padY_tb);
            ELM_GUI.enableTB(padSpace_tb);

            ELM_GUI.enableTB(offsetX_tb);
            ELM_GUI.enableTB(offsetY_tb);

            setIntTextBox(Npads_tb, (int)N_rows_nud.Value);
            setDoubleTextBox(padX_tb, (int)N_rows_nud.Value);
            setDoubleTextBox(padY_tb, (int)N_rows_nud.Value);
            setDoubleTextBox(padSpace_tb, (int)N_rows_nud.Value);

            offsetX_tb.Text = "";
            offsetY_tb.Text = "";
        }

        //Housekeeping: Numeric presentation.
        private void N_rows_nud_ValueChanged(object sender, EventArgs e)
        {
            if (N_rows_nud.Value == 0)
            {
                N_rows_nud.Value = 1;
            }
            else if (N_rows_nud.Value == 1)
            {
                setAllTextBoxesForOneRow();
            }
            else if (N_rows_nud.Value == 2)
            {
                setAllTextBoxesForTwoRow();
            }
            else
            {
                setAllTextBoxesForInput();
            }
        }
       
        //Housekeeping: Initialize
        private void AddCustomDevice_RxR_UC_Load(object sender, EventArgs e)
        {
            setAllTextBoxesForInput();

            //Load defaults.
            N_rows_nud.Value = 3;
            Npads_tb.Text = "[6,3,5]";
            padX_tb.Text = "[1.0,3.0,2.5]";
            padY_tb.Text = "[0.5,2.0,3.0]";
            padSpace_tb.Text = "[1.0,1.5,6.0]";

            offsetX_tb.Text = "[1.5,2.5]";
            offsetY_tb.Text = "[0,1.75]";

            newDeviceName_tb.Text = "DEFINEDROWSTEST";
        }
        
        //Execute.
        private void back_btn_Click(object sender, EventArgs e)
        {
            Visible = false;
            SendToBack();
        }

        public int stop_program(int[] Npads, double[] padX, double[] padY, double[] padSpace, double[] offsetX, double[] offsetY)
        {
            //These four should always have AT LEAST one value in them.
            //Even if N_rows_nud.Value == 1  we should not be seeing -1's here.
            if (Npads[0] == -1)// ||  ||  || )
                return 1;
            if (padX[0] == -1)
                return 2;
            if (padY[0] == -1)
                return 3;
            if (padSpace[0] == -1)
                return 4;

            //offsetX and offsetY are more complicated.
            //if N_rows_nud.Value >= 2 then these guys still pass back vectors which must have correct, legitimate,
            //meaningful, accessible information.
            //if N_rows_nud.Value == 1 then these guys can pass back anything, because on the C++ end we're going to iterate
            //from n = 0; n < (1-1), that is, n=0; n < 0;...so these guys will never be accessed anyways.
            if (offsetX[0] == -1 && N_rows_nud.Value >= 2)
                return 5;
            if (offsetY[0] == -1 && N_rows_nud.Value >= 2)
                return 6;

            return 0;
        }
        private void generate_btn_Click(object sender, EventArgs e)
        {
            /*
            AddDevice_RxR_GUI(
            char* inputPath,

	        char* d_name,
	        char* d_padNames,
	        int d_N_rows,
	        int* d_N_pads, double* d_padX, double* d_padY, double* d_padSpace, //length N_rows
	        double* d_horizontalOffset, double* d_verticalOffset, //length N_rows - 1

	        char* outputPath
            )
            */
            
            int initialNumDevices = ELM_GUI.CurrentSession.currentDeviceNameList.Length;

            int[] Npads = ELM_GUI.textBoxToIntArray(Npads_tb);
            double[] padX = ELM_GUI.textBoxToDoubleArray(padX_tb);
            double[] padY = ELM_GUI.textBoxToDoubleArray(padY_tb);
            double[] padSpace = ELM_GUI.textBoxToDoubleArray(padSpace_tb);
            int N_rows = (int)N_rows_nud.Value;
            double[] offsetX = ELM_GUI.textBoxToDoubleArray(offsetX_tb);
            double[] offsetY = ELM_GUI.textBoxToDoubleArray(offsetY_tb);

            //Check vector inputs.
            //First: Are we able to attain enough, meaningful, information from each textbox.
            //That means actual numbers must be entered in.
            //Yes. If legitimate values are put in, even for the edge cases, the program works.
            //What protects us from accessing junk information in the "undersized" double[] vectors
            //is d_N_rows. It defines a universal length vector for everything. Then on the C++ level
            //we intentionally block ourselves from that junk information by a simple counter.
            //Second: Does valid input data hurt if we only have 1 or two rows.
            //No.... see above.

            //Stop program operation in this line if any inputs are invalid.
            //If you have a textBoxToArray call that gives you the [-1......] vector, AND that data is actuallly going
            //to be something that C++ tries to read from, then you need to stop operation here.
            //is not readonly and saying "N/A", that's how you know that this textbox has some invalid data. Or, rather,
            //needs data input into it.
            if (stop_program(Npads, padX, padY, padSpace, offsetX, offsetY) != 0)
            {
                MessageBox.Show("One or more input boxes on this page are lacking sufficient information.");
            }
            else
            {
                IntPtr newDeviceList_IntPtr = ELM_GUI.AddDevice_RxR_GUI(
                ELM_GUI.stringToCharArray(ELM_GUI.CurrentSession.inputPath),//char[] inputPath

                ELM_GUI.stringToCharArray(newDeviceName_tb.Text), //char[] d_name
                ELM_GUI.stringArrayToCharArray(ELM_GUI.textBoxToPadNamesList(newDeviceName_tb, calc_RxR_numPads())), //char[] padNames
                N_rows, //int d_N_rows
                Npads, padX, padY, padSpace, //d_N_pads, d_padX, d_padY, d_padSpace
                offsetX, offsetY, //d_horizontalOffset, d_verticalOffset

                ELM_GUI.stringToCharArray(ELM_GUI.CurrentSession.outputPath) //char[] outputPath
                );

                ELM_GUI.postDeviceAdd(newDeviceList_IntPtr, initialNumDevices);
                foreach (string x in ELM_GUI.CurrentSession.currentDeviceNameList)
                    Debug.WriteLine(x);
                Debug.WriteLine("New num devices: " + ELM_GUI.CurrentSession.currentDeviceNameList.Length +
                    "\nOld num devices: " + initialNumDevices);
            }
            
        }

        //Experiment.
        private string trimBrackets(string input)
        {
            int innerBracketInd_L = input.LastIndexOf('[');
            int innerBracketInd_R = input.IndexOf(']');
            
            return input.Substring(input.LastIndexOf('['), innerBracketInd_R - innerBracketInd_L + 1);
        }
        private string trimCommasPeriods(string input)
        {
            //Second: I want N periods and N-1 commas.
            //Go through.
            //if you see a period, activate period flag.
            //if you see a period and period flag is on, remove it.
            //if you see a comma, activate comma flag.
            //if you see a comma and comma flag is on, remove it.
            //if you see a period, turn off comma flag.
            //you are allowed to see a comma again if you just saw a period.
            //if you see a comma, turn off period flag.
            //you are allowed to see a period again if you just saw a comma.

            bool period_FLAG = false;
            bool comma_FLAG = false;
            for (int n = 0; n < input.Length; n++)
            {
                char curchar = input[n];

                if (curchar == '.')
                {
                    comma_FLAG = false;
                    if (period_FLAG == true)
                    {
                        input = input.Remove(n, 1);
                        n--;
                    }
                    period_FLAG = true;
                }
                else if (curchar == ',')
                {
                    period_FLAG = false;
                    if (comma_FLAG == true)
                    {
                        input = input.Remove(n, 1);
                        n--;
                    }
                    comma_FLAG = true;
                }
            }

            return input;
        }
        
        private void cleanVectorInput(TextBox tb, KeyEventArgs e)
        {
            
            char c = (char)e.KeyValue;
           
            if (tb.SelectionLength > 0)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
            
            else
            {
                //ESPECIALLY suppress the delete key.
                if (c == (char)Keys.Delete)
                {
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                }
                
                //Kick it out if it's not a number.
                if ((!char.IsNumber(c) && !char.IsControl(c) && c != '.' && c != ',' && c != (char)Keys.Left && c != (char)Keys.Right) || (c == (char)Keys.OemMinus))
                {
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                }
                //Kick it out if it's before '[' or ']'.
                else if (char.IsNumber(c) && (tb.SelectionStart == 0 || tb.SelectionStart == tb.Text.Length))
                {
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                }
                //Advance the cursor for convenience if it's a ',' or '.'.
                else if ((c == (char)Keys.OemPeriod) || (c == (char)Keys.Oemcomma))
                {
                    tb.SelectionStart++;
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                }
                
                //Deleting characters.
                if (c == (char)Keys.Back)
                {
                    //Well, C# is stupid, so it automatically deletes my shit.
                    //So I just insert the character into that spot if I want to.

                    if (tb.SelectionStart != 0)
                    {
                        int oldSelectionStart = tb.SelectionStart;
                        char charBefore = tb.Text[tb.SelectionStart - 1];
                        
                        if (!char.IsNumber(charBefore) && tb.SelectionLength == 0)
                        {
                            tb.Text = tb.Text.Insert(tb.SelectionStart, charBefore.ToString());
                            tb.SelectionStart = oldSelectionStart;
                        }
                    }
                }

                //Reset box if the GLITCH was exploited.
                
            }
        }
        private void Npads_tb_KeyDown(object sender, KeyEventArgs e)
        {
            //if (N_rows_nud.Value == 1)
            //{
            //    ELM_GUI.cleanIntInput(Npads_tb);
            //}
            if (N_rows_nud.Value > 1)
            {
                cleanVectorInput(Npads_tb, e);
            }
        }
        private void padX_tb_KeyDown(object sender, KeyEventArgs e)
        {
            //if (N_rows_nud.Value == 1)
            //{
            //    ELM_GUI.cleanDoubleInput(padX_tb);
            //}
            if (N_rows_nud.Value > 1)
            {
                cleanVectorInput(padX_tb, e);
            }
        }
        private void padY_tb_KeyDown(object sender, KeyEventArgs e)
        {
            //if (N_rows_nud.Value == 1)
            //{
            //    ELM_GUI.cleanDoubleInput(padY_tb);
            //}
            if (N_rows_nud.Value > 1)
            {
                cleanVectorInput(padY_tb, e);
            }
        }
        private void padSpace_tb_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            if (N_rows_nud.Value == 1)
            {
                ELM_GUI.cleanDoubleInput(padSpace_tb);
            }
            */
            if (N_rows_nud.Value > 1)
            {
                cleanVectorInput(padSpace_tb, e);
            }
        }

        private void offsetX_tb_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            if (N_rows_nud.Value <= 2)
            {
                ELM_GUI.cleanDoubleInput(offsetX_tb);
            }
            */
            if (N_rows_nud.Value > 2)
            {
                cleanVectorInput(offsetX_tb, e);
            }
        }
        private void offsetY_tb_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            if (N_rows_nud.Value <= 2)
            {
                ELM_GUI.cleanDoubleInput(offsetY_tb);
            }
            */
            if (N_rows_nud.Value > 2)
            {
                cleanVectorInput(offsetY_tb, e);
            }
        }

        private void any_tb_TextChanged(object sender, EventArgs e)
        {
            if (TB_MASTER_CONTROL == false)
            {
                if (N_rows_nud.Value == 1)
                {
                    //Clean values.
                    ELM_GUI.cleanIntInput(Npads_tb);
                    ELM_GUI.cleanDoubleInput(padX_tb);
                    ELM_GUI.cleanDoubleInput(padY_tb);
                    ELM_GUI.cleanDoubleInput(padSpace_tb);
                    
                    ELM_GUI.disableTB(offsetX_tb);
                    ELM_GUI.disableTB(offsetY_tb);
                }
                if (N_rows_nud.Value == 2)
                {
                    //ELM_GUI.enableTB(offsetX_tb);
                    //ELM_GUI.enableTB(offsetY_tb);

                    ELM_GUI.cleanDoubleInput(offsetX_tb);
                    ELM_GUI.cleanDoubleInput(offsetY_tb);
                    //setAllTextBoxesForTwoRow();
                }
                //else
                //{
                //    setAllTextBoxesForInput();
                //}
            }
        }
       
        private void newDeviceName_tb_TextChanged(object sender, EventArgs e)
        {
            ELM_GUI.cleanTextInput(newDeviceName_tb);
        }
        
    }
}
