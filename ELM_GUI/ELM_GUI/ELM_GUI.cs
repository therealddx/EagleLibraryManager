using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELM_GUI_lib;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ELM_GUI
{
    public partial class ELM_GUI : Form
    {
        //Ok.... Functionally this has what I want at the barebones. Things I can do.
           /*
            * 
            * Visuals: White silkscreen-esque text. Better-written message boxes, control placement, tab indexing.
            * Standardize textbox label names. Add images to visualize what each package does. Make all generate buttons
            * and back buttons the same size. Allow "Back" button in Choose file section. Put overwrite button in choosefile
            * section. Put readfiledialog and savefiledialog in choosefile section. Strengthen the textboxes in the
            * RxR section. Add padnames textboxes to all forms.
            * 
            * Write descriptions + help where applicable. 
            * Reset project to make you pick a file before you're allowed to Add / Remove.
            * 
            * Functional: Allow copy-to-inner on QFP section, OR allow copy to square grid array on Defined Rows.
            * Really prefer to make Defined Rows be the most, yknow, custom deal, and allow copy-to-inner on QFP.
            * Then it would cover the QFP, QFN, and BGA.
            * 
            * */

        //What I need is a parsing scheme to cross the boundary.
        //I have char[] in common.
        //If i want to pass an array of strings, I have to have an "encode" and "decode"
        //function on the C# and C++ ends that parses b/w char[], string/std::string, and string[]/std::vector<std::string>.
        //That is honestly going to be the simplest way to ensure clean, consistent flow of text information across
        //the boundary.

        //Does the same logic hold for passing arrays of values? Yes, probably, but even better, because
        //double[] is allowable more or less in both c# and c++. good. ok, so what are we doing.

        //C#: string to char[] (string.tochararray)
        //C#: string[] to char[] (stringArrayToCharArray)
        //C#: char[] to string (string constructor)
        //C#: char[] to string[] (charArrayToStringArray)
        
        public static string stringArrayToString(string[] stringsIn)
        {
            //for each string in stringsIn.
            //stringOut = stringOut.append(stringsIn[n] + ',');

            string stringOut = string.Empty;
            string append = string.Empty;
            foreach(string s in stringsIn)
            {
                stringOut = stringOut + s + ",";
            }
            return stringOut;
        }
        public static unsafe char[] stringArrayToCharArray(string[] stringsIn)
        {
            char[] charArrayOut;
            int charArrayLength = 0;
            for (int n = 0; n < stringsIn.Length; n++)
            {
                //take current string of stringsIn.
                //add its length to charArrayLength.
                //add one for the comma.
                charArrayLength += stringsIn[n].Length + 1;
            }
            charArrayLength++; //for null at end

            //charArrayOut = new char[charArrayLength];
            charArrayOut = new char[charArrayLength];// (char*)Marshal.AllocHGlobal(charArrayLength);

            int k = 0;
            for (int n = 0; n < stringsIn.Length; n++)
            {
                //take current string in stringsIn[].
                //put each of its letters into charArrayOut.
                //tack a comma on.

                for (int m = 0; m < stringsIn[n].Length; m++)
                {
                    charArrayOut[k + m] = stringsIn[n][m];
                }
                charArrayOut[k + stringsIn[n].Length] = ',';
                k += stringsIn[n].Length + 1;
            }
            charArrayOut[charArrayLength - 1] = '\0';
            
            return charArrayOut;
        }
        public static unsafe char[] stringToCharArray(string stringIn)
        {
            char[] charArrayOut;
            int charArrayLength = stringIn.Length + 1;

            charArrayOut = new char[charArrayLength];// (char*)Marshal.AllocHGlobal(charArrayLength);
            
            for (int n = 0; n < charArrayLength - 1; n++)
            {
                charArrayOut[n] = stringIn[n];
            }
                
            charArrayOut[charArrayLength - 1] = '\0';
            return charArrayOut;
        }
        public static string[] charArrayToStringArray(string charsIn)
        {
            return charsIn.Split(',');
        }
        
        [DllImport("ELM_GUI_lib.dll", CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern IntPtr RemoveDevices_GUI(char[] path, char[] namesToRemove, char[] outputPath);

        [DllImport("ELM_GUI_lib.dll", CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern IntPtr GetCurrentDeviceNameList_GUI(char[] path);
        
        [DllImport("ELM_GUI_lib.dll", CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern IntPtr AddDevice_2xN_GUI(
            char[] inputPath,

            char[] d_name,
            char[] padNames,
            double space_x, double space_y, double dim_x, double dim_y, int N,
            
            char[] outputPath
            );

        [DllImport("ELM_GUI_lib.dll", CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern IntPtr AddDevice_RA_GUI(
             char[] inputPath,
             
             char[] d_name,
             char[] padNames,
             double d_REF, int d_N, double d_padW, double d_padL, double d_padSpace,
             double d_centeredSquarePad,
             double d_cornerSquarePads_REF, double d_cornerSquarePads_DIM,

             char[] outputPath
            );

        [DllImport("ELM_GUI_lib.dll", CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern IntPtr AddDevice_RxR_GUI(
            char[] inputPath,

            char[] d_name,
            char[] d_padNames,
            int d_N_rows,
            int[] d_N_pads, double[] d_padX, double[] d_padY, double[] d_padSpace, //length N_rows
            double[] d_horizontalOffset, double[] d_verticalOffset, //length N_rows - 1

            char[] outputPath
            );
        
        //[DllImport("ELM_GUI_lib.dll", CallingConvention = CallingConvention.StdCall)]
        //public unsafe static extern IntPtr GetCurrentDeviceList_GUI(char[] path);

        //The standard is that all char[]s are comma-delimited:
        //xyz,xyz,xyz,xyz,xyz... etc.
        
        public ELM_GUI()
        {
            InitializeComponent();
        }
        
        //ELM-specific information.
        public static class CurrentSession
        {
            public static string inputPath;
            public static string outputPath;
            public static string[] currentDeviceNameList;

            //Session UCs
            public static ChooseInOutPaths_UC chooseInOutPaths_UC1;
            public static RemoveDevices_UC removeDevices_UC1;
            public static AddCustomDevice_UC addCustomDevice_UC1;
            public static AddCustomDevice_2xN_UC addCustomDevice_2xN_UC1;
            public static AddCustomDevice_RA_UC addCustomDevice_RA_UC1;
            public static AddCustomDevice_RxR_UC addCustomDevice_RxR_UC1;

            public static void ProcessIntPtrToStringArray(IntPtr p)
            {
                string currentDeviceNameList_string = Marshal.PtrToStringAnsi(p);

                if (!String.IsNullOrEmpty(currentDeviceNameList_string))
                {
                    //Nip last comma and split by commas.
                    currentDeviceNameList_string.Remove(currentDeviceNameList_string.Length - 1);
                    currentDeviceNameList = currentDeviceNameList_string.Remove(
                        currentDeviceNameList_string.Length - 1).Split(',');
                }
                else
                {
                    currentDeviceNameList = new string[0];
                }
            }
        }
        
        //Cleaning textboxes.
        public static bool validTextInput(char c)
        {
            if ((c >= 48 && c <= 57) || (c >= 65 && c <= 90) || (c >= 97 && c <= 122) || c == 32 || c == 95 || c == 36)
                return true;
            else
                return false;
        }
        public static void cleanTextInput(TextBox tb)
        {
            if (tb.Text != "")
            {
                int oldSelectionStart = tb.SelectionStart;

                foreach (char c in tb.Text)
                {
                    if (!validTextInput(c))
                    {
                        tb.Text = tb.Text.Replace(c.ToString(),"");
                        oldSelectionStart--;
                    }
                }
                
                tb.Text = tb.Text.ToUpper();
                tb.Text = tb.Text.Replace(" ", "_");

                tb.SelectionStart = oldSelectionStart;
            }
        }
        public static void cleanIntInput(TextBox tb)
        {
            if (tb.Text != "")
            {
                foreach (char c in tb.Text)
                {
                    if (!Char.IsNumber(c))
                    {
                        tb.Text = tb.Text.Replace(c.ToString(), "");
                    }
                }
                
                tb.SelectionStart = tb.Text.Length;
            }
        }
        public static void cleanDoubleInput(TextBox tb)
        {
            if (tb.Text != "")
            {
                //This loop automatically removes all non-number, non-period junk from the tb.
                foreach (char c in tb.Text)
                {
                    if (!Char.IsNumber(c))
                    {
                        //Anything but a period is gone automatically.
                        if (c != '.')
                            tb.Text = tb.Text.Replace(c.ToString(), "");
                    }
                }
            }

            //If there's too many periods in there.
            if (tb.Text.Count(x => x == '.') > 1)
            {
                if ((tb.Text != "") && (tb.Focused == true))
                {
                    //If the user DID IN FACT just input a '.'.
                    if (tb.Text[tb.SelectionStart - 1] == '.')
                    {
                        //Remove the period at this index.
                        tb.Text = tb.Text.Remove(tb.SelectionStart - 1, 1);
                    }
                }
            }

            tb.SelectionStart = tb.Text.Length;
        }
        public static void cutLast(TextBox tb)
        {
            if (tb.Text != "")
            {
                tb.Text.Remove(tb.Text.Length - 1, 1);
            }
            tb.SelectionStart = tb.Text.Length;
        }

        public static void postDeviceAdd(IntPtr newDeviceList_IntPtr, int initialNumDevices)
        {
            ELM_GUI.CurrentSession.ProcessIntPtrToStringArray(newDeviceList_IntPtr);

            if (ELM_GUI.CurrentSession.currentDeviceNameList.Length == initialNumDevices)
            {
                MessageBox.Show("A device with that name already exists in this .lbr.\n" +
                    "Returning to main screen.");
            }
            else
            {
                MessageBox.Show("Device added... Please check .lbr.");
            }
        }
        public static double[] textBoxToDoubleArray(TextBox tb)
        {
            //Burden of only allowing certain # of values
            //is shifted to eventhandler for tb.
            string[] s = tb.Text.Replace("[", "").Replace("]", "").Trim().Split(',');
            double[] d = new double[s.Length];

            for (int n = 0; n < s.Length; n++)
            {
                if (!Double.TryParse(s[n], out d[n]))
                {
                    d[0] = -1;
                    return d;
                }
            }   
            return d;
        }
        public static int[] textBoxToIntArray(TextBox tb)
        {
            //Burden of only allowing certain # of values
            //is shifted to eventhandler for tb.
            string[] s = tb.Text.Replace("[", "").Replace("]", "").Trim().Split(',');
            int[] d = new int[s.Length];
            
            for (int n = 0; n < s.Length; n++)
            {
                if (!Int32.TryParse(s[n], out d[n]))
                {
                    d[0] = -1;
                    return d;
                }
               
            }
            return d;
        }
        public static string[] textBoxToPadNamesList(TextBox tb, int length)
        {
            string[] vec = new string[length];
            string[] tbStringArray = tb.Text.Split(',');

            //If lengths are indeed equal.
            if (tbStringArray.Length == length)
            {
                for (int n = 0; n < length; n++)
                    vec[n] = tbStringArray[n];
            }
            else
            {
                //Else, you only assign whatever the first term is.
                for (int n = 0; n < length; n++) { 
                    vec[n] = "P$" + Convert.ToString(n + 1);
                }
            }

            return vec;
        }
        public static void disableTB(TextBox tb)
        {
            tb.Text = "N/A";
            tb.ReadOnly = true;
        }
        public static void enableTB(TextBox tb)
        {
            tb.Text = "";
            tb.ReadOnly = false;
        }
        public static void disableCB(CheckBox cb)
        {
            cb.Checked = false;
            cb.Enabled = false;
        }
        public static void enableCB(CheckBox cb)
        {
            cb.Checked = false;
            cb.Enabled = true;
        }
        
        //Initialization
        private void Form1_Load(object sender, EventArgs e)
        {

            CurrentSession.inputPath = "C:\\Users\\Mehdy Faik\\AppData\\Roaming\\SPB_16.6\\eagle\\Library_Holder\\General_Passives_Test.lbr";
            CurrentSession.outputPath = "C:\\Users\\Mehdy Faik\\AppData\\Roaming\\SPB_16.6\\eagle\\Library_Holder\\General_Passives_Test.lbr";
            
            //Initialize UCs.

            //1. Make new object.
            CurrentSession.chooseInOutPaths_UC1 = new ChooseInOutPaths_UC();
            CurrentSession.removeDevices_UC1 = new RemoveDevices_UC();
            CurrentSession.addCustomDevice_UC1 = new AddCustomDevice_UC();
            CurrentSession.addCustomDevice_2xN_UC1 = new AddCustomDevice_2xN_UC();
            CurrentSession.addCustomDevice_RA_UC1 = new AddCustomDevice_RA_UC();
            CurrentSession.addCustomDevice_RxR_UC1 = new AddCustomDevice_RxR_UC();

            //2. Make invisible to start.
            CurrentSession.chooseInOutPaths_UC1.Visible = false;
            CurrentSession.removeDevices_UC1.Visible = false;
            CurrentSession.addCustomDevice_UC1.Visible = false;
            CurrentSession.addCustomDevice_2xN_UC1.Visible = false;
            CurrentSession.addCustomDevice_RA_UC1.Visible = false;
            CurrentSession.addCustomDevice_RxR_UC1.Visible = false;

            //3. Location to 0,0.
            CurrentSession.chooseInOutPaths_UC1.Location = new Point(0, 0);
            CurrentSession.removeDevices_UC1.Location = new Point(0, 0);
            CurrentSession.addCustomDevice_UC1.Location = new Point(0, 0);
            CurrentSession.addCustomDevice_2xN_UC1.Location = new Point(0, 0);
            CurrentSession.addCustomDevice_RA_UC1.Location = new Point(0, 0);
            CurrentSession.addCustomDevice_RxR_UC1.Location = new Point(0, 0);

            //4. Tack em onto FrontPanel.
            FrontPanel_pnl.Controls.Add(CurrentSession.chooseInOutPaths_UC1);
            FrontPanel_pnl.Controls.Add(CurrentSession.removeDevices_UC1);
            FrontPanel_pnl.Controls.Add(CurrentSession.addCustomDevice_UC1);
            FrontPanel_pnl.Controls.Add(CurrentSession.addCustomDevice_2xN_UC1);
            FrontPanel_pnl.Controls.Add(CurrentSession.addCustomDevice_RA_UC1);
            FrontPanel_pnl.Controls.Add(CurrentSession.addCustomDevice_RxR_UC1);
        }
        
        //Action.
        //Show controls.
        private void ChoosePaths_btn_Click(object sender, EventArgs e)
        {
            CurrentSession.chooseInOutPaths_UC1.Visible = true;
            CurrentSession.chooseInOutPaths_UC1.BringToFront();
        }
        private void RemoveDevices_btn_Click(object sender, EventArgs e)
        {
            if ((CurrentSession.inputPath.Equals(string.Empty)) || (CurrentSession.outputPath.Equals(string.Empty)))
            {
                MessageBox.Show("Please use the Choose File button above to choose a file to\n" +
                                 "read from as well as a file to save changes to.");
            }
            else
            {
                CurrentSession.removeDevices_UC1.Visible = true;
                CurrentSession.removeDevices_UC1.BringToFront();
            }
        }
        private void AddCustomDevice_btn_Click(object sender, EventArgs e)
        {
            if ((CurrentSession.inputPath.Equals(string.Empty)) || (CurrentSession.outputPath.Equals(string.Empty)))
            {
                MessageBox.Show("Please use the Choose File button above to choose a file to\n" +
                                 "read from as well as a file to save changes to.");
            }
            else
            {
                CurrentSession.addCustomDevice_UC1.Visible = true;
                CurrentSession.addCustomDevice_UC1.BringToFront();
            }
        }

        //So that kinda poops on our dreams of doing it easy...
        //memory doesn't... stay. Memory that's loaded in, that is.
        //THEN. Options from here.
        //Consolidate. You pick a file solely to give me the path.
        //But every call to add() or remove() does an independent executable job of loading data to memory, processing, and saving.
        //Well, what this means is that you simplify / trim / core down the functionality even further.

        //This is UNLESS there is a way to accesssssssss the RAM that's in......... the C++....?
        //Dude, are you like, file access phobic? Who says you want to hold on to the filestream connection during program execution outside
        //of button usage anyways?
        
        //What did we learn from this fiasco?
        //Do not use readIn.getline().
        //Use std::getline(readIn, buf_string, '\n').
        //char buf goes into PInvoked method to serve as "char pointer / array". Use the most complex, high-level
        //data types you can get.
        //Broke down functions into individual pieces, MULTIPLE TIMES, slowly converging to a a solution.
        //Take care of accumulators.
        //Marshal coming out from an IntPtr to a string. In this case, we used PtrToString Ansi(IntPtr).
        //Data sent in is best sent as buffers. On this end I perceive buffers because C# gives me more power with buffers, and pointers
        //are awkward to work with in C# - they require buffers first anyways. When you send as a char buf, you guarantee that the C++ end
        //will understand it, because the char buf is automatically generated out of the string (the God-mode of character memory) to have the
        //right formatting.
        //Data captured on the C++ end can be buffers or char*. In the C++ realm it's just as well you deal with either because now you're
        //in totally unmanaged space where a string is always as simple as chars with a null after it. So you take in the char bufs that the 
        //C# fn handed in and work on them as needed. Is that technically correct? Not strictly speaking. But it works as a convention to keep
        //you grounded and moving.
    }
}
