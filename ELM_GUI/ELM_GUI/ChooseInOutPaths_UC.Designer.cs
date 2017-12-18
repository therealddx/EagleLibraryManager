namespace ELM_GUI
{
    partial class ChooseInOutPaths_UC
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
            this.ChooseInputFilePath_tb = new System.Windows.Forms.TextBox();
            this.InputPath_lbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ChooseOutputFilePath_tb = new System.Windows.Forms.TextBox();
            this.OK_btn = new System.Windows.Forms.Button();
            this.ChooseInOutPaths_pnl = new System.Windows.Forms.Panel();
            this.ChooseInOutPaths_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChooseInputFilePath_tb
            // 
            this.ChooseInputFilePath_tb.Location = new System.Drawing.Point(107, 76);
            this.ChooseInputFilePath_tb.Name = "ChooseInputFilePath_tb";
            this.ChooseInputFilePath_tb.Size = new System.Drawing.Size(432, 20);
            this.ChooseInputFilePath_tb.TabIndex = 1;
            // 
            // InputPath_lbl
            // 
            this.InputPath_lbl.AutoSize = true;
            this.InputPath_lbl.Location = new System.Drawing.Point(104, 49);
            this.InputPath_lbl.Name = "InputPath_lbl";
            this.InputPath_lbl.Size = new System.Drawing.Size(192, 13);
            this.InputPath_lbl.TabIndex = 2;
            this.InputPath_lbl.Text = "Input File Path: Enter Absolute .lbr Path";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Output File Path: Enter Absolute .lbr Path";
            // 
            // ChooseOutputFilePath_tb
            // 
            this.ChooseOutputFilePath_tb.Location = new System.Drawing.Point(107, 146);
            this.ChooseOutputFilePath_tb.Name = "ChooseOutputFilePath_tb";
            this.ChooseOutputFilePath_tb.Size = new System.Drawing.Size(432, 20);
            this.ChooseOutputFilePath_tb.TabIndex = 3;
            // 
            // OK_btn
            // 
            this.OK_btn.Location = new System.Drawing.Point(451, 211);
            this.OK_btn.Name = "OK_btn";
            this.OK_btn.Size = new System.Drawing.Size(88, 44);
            this.OK_btn.TabIndex = 5;
            this.OK_btn.Text = "OK";
            this.OK_btn.UseVisualStyleBackColor = true;
            this.OK_btn.Click += new System.EventHandler(this.OK_btn_Click);
            // 
            // ChooseInOutPaths_pnl
            // 
            this.ChooseInOutPaths_pnl.Controls.Add(this.OK_btn);
            this.ChooseInOutPaths_pnl.Controls.Add(this.label1);
            this.ChooseInOutPaths_pnl.Controls.Add(this.ChooseOutputFilePath_tb);
            this.ChooseInOutPaths_pnl.Controls.Add(this.ChooseInputFilePath_tb);
            this.ChooseInOutPaths_pnl.Controls.Add(this.InputPath_lbl);
            this.ChooseInOutPaths_pnl.Location = new System.Drawing.Point(0, 0);
            this.ChooseInOutPaths_pnl.Name = "ChooseInOutPaths_pnl";
            this.ChooseInOutPaths_pnl.Size = new System.Drawing.Size(650, 300);
            this.ChooseInOutPaths_pnl.TabIndex = 6;
            // 
            // ChooseInOutPaths_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ChooseInOutPaths_pnl);
            this.Name = "ChooseInOutPaths_UC";
            this.Size = new System.Drawing.Size(650, 300);
            this.Load += new System.EventHandler(this.ChooseInOutPaths_UC_Load);
            this.ChooseInOutPaths_pnl.ResumeLayout(false);
            this.ChooseInOutPaths_pnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox ChooseInputFilePath_tb;
        private System.Windows.Forms.Label InputPath_lbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ChooseOutputFilePath_tb;
        private System.Windows.Forms.Button OK_btn;
        private System.Windows.Forms.Panel ChooseInOutPaths_pnl;
    }
}
