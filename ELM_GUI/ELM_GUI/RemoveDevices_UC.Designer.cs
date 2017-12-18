namespace ELM_GUI
{
    partial class RemoveDevices_UC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DeviceList_lb = new System.Windows.Forms.ListBox();
            this.RemoveDevicesUC_Remove_btn = new System.Windows.Forms.Button();
            this.RemoveDevicesUC_Back_btn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeviceList_lb
            // 
            this.DeviceList_lb.FormattingEnabled = true;
            this.DeviceList_lb.Location = new System.Drawing.Point(81, 10);
            this.DeviceList_lb.Name = "DeviceList_lb";
            this.DeviceList_lb.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.DeviceList_lb.Size = new System.Drawing.Size(113, 277);
            this.DeviceList_lb.TabIndex = 0;
            // 
            // RemoveDevicesUC_Remove_btn
            // 
            this.RemoveDevicesUC_Remove_btn.Location = new System.Drawing.Point(279, 10);
            this.RemoveDevicesUC_Remove_btn.Name = "RemoveDevicesUC_Remove_btn";
            this.RemoveDevicesUC_Remove_btn.Size = new System.Drawing.Size(294, 185);
            this.RemoveDevicesUC_Remove_btn.TabIndex = 1;
            this.RemoveDevicesUC_Remove_btn.Text = "Remove";
            this.RemoveDevicesUC_Remove_btn.UseVisualStyleBackColor = true;
            this.RemoveDevicesUC_Remove_btn.Click += new System.EventHandler(this.RemoveDevicesUC_Remove_btn_Click);
            // 
            // RemoveDevicesUC_Back_btn
            // 
            this.RemoveDevicesUC_Back_btn.Location = new System.Drawing.Point(279, 201);
            this.RemoveDevicesUC_Back_btn.Name = "RemoveDevicesUC_Back_btn";
            this.RemoveDevicesUC_Back_btn.Size = new System.Drawing.Size(294, 86);
            this.RemoveDevicesUC_Back_btn.TabIndex = 2;
            this.RemoveDevicesUC_Back_btn.Text = "Back";
            this.RemoveDevicesUC_Back_btn.UseVisualStyleBackColor = true;
            this.RemoveDevicesUC_Back_btn.Click += new System.EventHandler(this.RemoveDevicesUC_Back_btn_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(663, 113);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(8, 4);
            this.listBox1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DeviceList_lb);
            this.panel1.Controls.Add(this.RemoveDevicesUC_Remove_btn);
            this.panel1.Controls.Add(this.RemoveDevicesUC_Back_btn);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 300);
            this.panel1.TabIndex = 4;
            // 
            // RemoveDevices_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBox1);
            this.Name = "RemoveDevices_UC";
            this.Size = new System.Drawing.Size(650, 300);
            this.VisibleChanged += new System.EventHandler(this.RemoveDevicesUC_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox DeviceList_lb;
        private System.Windows.Forms.Button RemoveDevicesUC_Remove_btn;
        private System.Windows.Forms.Button RemoveDevicesUC_Back_btn;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel1;
    }
}
