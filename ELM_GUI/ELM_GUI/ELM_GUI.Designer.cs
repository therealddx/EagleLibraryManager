namespace ELM_GUI
{
    partial class ELM_GUI
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.header_lbl = new System.Windows.Forms.Label();
            this.ReadFileIn_ofd = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.WriteFileOut_sfd = new System.Windows.Forms.SaveFileDialog();
            this.AddCustomDevice_btn = new System.Windows.Forms.Button();
            this.ChoosePaths_btn = new System.Windows.Forms.Button();
            this.RemoveDevices_btn = new System.Windows.Forms.Button();
            this.FrontPanel_pnl = new System.Windows.Forms.Panel();
            this.FrontPanel_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // header_lbl
            // 
            this.header_lbl.AutoSize = true;
            this.header_lbl.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold);
            this.header_lbl.ForeColor = System.Drawing.Color.White;
            this.header_lbl.Location = new System.Drawing.Point(12, 9);
            this.header_lbl.Name = "header_lbl";
            this.header_lbl.Size = new System.Drawing.Size(414, 36);
            this.header_lbl.TabIndex = 1;
            this.header_lbl.Text = "Eagle Library Manager";
            // 
            // ReadFileIn_ofd
            // 
            this.ReadFileIn_ofd.FileName = "<>";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(558, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            // 
            // WriteFileOut_sfd
            // 
            this.WriteFileOut_sfd.FileName = "<>";
            // 
            // AddCustomDevice_btn
            // 
            this.AddCustomDevice_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.AddCustomDevice_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.AddCustomDevice_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.AddCustomDevice_btn.Location = new System.Drawing.Point(0, 75);
            this.AddCustomDevice_btn.Name = "AddCustomDevice_btn";
            this.AddCustomDevice_btn.Size = new System.Drawing.Size(300, 226);
            this.AddCustomDevice_btn.TabIndex = 2;
            this.AddCustomDevice_btn.Text = "Add Custom Device";
            this.AddCustomDevice_btn.UseVisualStyleBackColor = false;
            this.AddCustomDevice_btn.Click += new System.EventHandler(this.AddCustomDevice_btn_Click);
            // 
            // ChoosePaths_btn
            // 
            this.ChoosePaths_btn.Location = new System.Drawing.Point(0, 0);
            this.ChoosePaths_btn.Name = "ChoosePaths_btn";
            this.ChoosePaths_btn.Size = new System.Drawing.Size(650, 50);
            this.ChoosePaths_btn.TabIndex = 7;
            this.ChoosePaths_btn.Text = "Choose Path to Read from / Path to Save to";
            this.ChoosePaths_btn.UseVisualStyleBackColor = true;
            this.ChoosePaths_btn.Click += new System.EventHandler(this.ChoosePaths_btn_Click);
            // 
            // RemoveDevices_btn
            // 
            this.RemoveDevices_btn.BackColor = System.Drawing.Color.RoyalBlue;
            this.RemoveDevices_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.RemoveDevices_btn.Location = new System.Drawing.Point(350, 73);
            this.RemoveDevices_btn.Name = "RemoveDevices_btn";
            this.RemoveDevices_btn.Size = new System.Drawing.Size(300, 227);
            this.RemoveDevices_btn.TabIndex = 3;
            this.RemoveDevices_btn.Text = "Remove Devices";
            this.RemoveDevices_btn.UseVisualStyleBackColor = false;
            this.RemoveDevices_btn.Click += new System.EventHandler(this.RemoveDevices_btn_Click);
            // 
            // FrontPanel_pnl
            // 
            this.FrontPanel_pnl.Controls.Add(this.RemoveDevices_btn);
            this.FrontPanel_pnl.Controls.Add(this.ChoosePaths_btn);
            this.FrontPanel_pnl.Controls.Add(this.AddCustomDevice_btn);
            this.FrontPanel_pnl.Location = new System.Drawing.Point(19, 49);
            this.FrontPanel_pnl.Name = "FrontPanel_pnl";
            this.FrontPanel_pnl.Size = new System.Drawing.Size(650, 300);
            this.FrontPanel_pnl.TabIndex = 8;
            // 
            // ELM_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.FrontPanel_pnl);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.header_lbl);
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "ELM_GUI";
            this.Opacity = 0.97D;
            this.Text = "Eagle Library Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FrontPanel_pnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label header_lbl;
        private System.Windows.Forms.OpenFileDialog ReadFileIn_ofd;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.SaveFileDialog WriteFileOut_sfd;
        private System.Windows.Forms.Button AddCustomDevice_btn;
        private System.Windows.Forms.Button ChoosePaths_btn;
        private System.Windows.Forms.Button RemoveDevices_btn;
        private System.Windows.Forms.Panel FrontPanel_pnl;
    }
}

