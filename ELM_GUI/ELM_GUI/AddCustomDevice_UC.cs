using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELM_GUI
{
    public partial class AddCustomDevice_UC : UserControl
    {
        public AddCustomDevice_UC()
        {
            InitializeComponent();
        }

        private void TwoxN_btn_Click(object sender, EventArgs e)
        {
            ELM_GUI.CurrentSession.addCustomDevice_2xN_UC1.Visible = true;
            ELM_GUI.CurrentSession.addCustomDevice_2xN_UC1.BringToFront();
        }
        private void RectangularArrays_btn_Click(object sender, EventArgs e)
        {
            ELM_GUI.CurrentSession.addCustomDevice_RA_UC1.Visible = true;
            ELM_GUI.CurrentSession.addCustomDevice_RA_UC1.BringToFront();
        }
        private void RowByRow_btn_Click(object sender, EventArgs e)
        {
            ELM_GUI.CurrentSession.addCustomDevice_RxR_UC1.Visible = true;
            ELM_GUI.CurrentSession.addCustomDevice_RxR_UC1.BringToFront();
        }
        private void Back_btn_Click(object sender, EventArgs e)
        {
            ELM_GUI.CurrentSession.addCustomDevice_UC1.Visible = false;
            ELM_GUI.CurrentSession.addCustomDevice_UC1.BringToFront();
        }
    }
}
