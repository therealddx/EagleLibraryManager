namespace ELM_GUI
{
    partial class AddCustomDevice_UC
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
            this.AddCustomDeviceBasePanel_pnl = new System.Windows.Forms.Panel();
            this.Back_btn = new System.Windows.Forms.Button();
            this.squareQuadRow_btn = new System.Windows.Forms.Button();
            this.RowByRow_btn = new System.Windows.Forms.Button();
            this.TwoxN_btn = new System.Windows.Forms.Button();
            this.AddCustomDeviceBasePanel_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddCustomDeviceBasePanel_pnl
            // 
            this.AddCustomDeviceBasePanel_pnl.Controls.Add(this.Back_btn);
            this.AddCustomDeviceBasePanel_pnl.Controls.Add(this.squareQuadRow_btn);
            this.AddCustomDeviceBasePanel_pnl.Controls.Add(this.RowByRow_btn);
            this.AddCustomDeviceBasePanel_pnl.Controls.Add(this.TwoxN_btn);
            this.AddCustomDeviceBasePanel_pnl.Location = new System.Drawing.Point(0, 0);
            this.AddCustomDeviceBasePanel_pnl.Name = "AddCustomDeviceBasePanel_pnl";
            this.AddCustomDeviceBasePanel_pnl.Size = new System.Drawing.Size(650, 300);
            this.AddCustomDeviceBasePanel_pnl.TabIndex = 0;
            // 
            // Back_btn
            // 
            this.Back_btn.Location = new System.Drawing.Point(34, 253);
            this.Back_btn.Name = "Back_btn";
            this.Back_btn.Size = new System.Drawing.Size(75, 23);
            this.Back_btn.TabIndex = 1;
            this.Back_btn.Text = "Back";
            this.Back_btn.UseVisualStyleBackColor = true;
            this.Back_btn.Click += new System.EventHandler(this.Back_btn_Click);
            // 
            // squareQuadRow_btn
            // 
            this.squareQuadRow_btn.Location = new System.Drawing.Point(393, 179);
            this.squareQuadRow_btn.Name = "squareQuadRow_btn";
            this.squareQuadRow_btn.Size = new System.Drawing.Size(121, 61);
            this.squareQuadRow_btn.TabIndex = 7;
            this.squareQuadRow_btn.Text = "Square Quad Row";
            this.squareQuadRow_btn.UseVisualStyleBackColor = true;
            this.squareQuadRow_btn.Click += new System.EventHandler(this.RectangularArrays_btn_Click);
            // 
            // RowByRow_btn
            // 
            this.RowByRow_btn.Location = new System.Drawing.Point(122, 179);
            this.RowByRow_btn.Name = "RowByRow_btn";
            this.RowByRow_btn.Size = new System.Drawing.Size(102, 61);
            this.RowByRow_btn.TabIndex = 6;
            this.RowByRow_btn.Text = "Row-by-Row Capture";
            this.RowByRow_btn.UseVisualStyleBackColor = true;
            this.RowByRow_btn.Click += new System.EventHandler(this.RowByRow_btn_Click);
            // 
            // TwoxN_btn
            // 
            this.TwoxN_btn.Location = new System.Drawing.Point(122, 55);
            this.TwoxN_btn.Name = "TwoxN_btn";
            this.TwoxN_btn.Size = new System.Drawing.Size(102, 60);
            this.TwoxN_btn.TabIndex = 4;
            this.TwoxN_btn.Text = "2xN";
            this.TwoxN_btn.UseVisualStyleBackColor = true;
            this.TwoxN_btn.Click += new System.EventHandler(this.TwoxN_btn_Click);
            // 
            // AddCustomDevice_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AddCustomDeviceBasePanel_pnl);
            this.Name = "AddCustomDevice_UC";
            this.Size = new System.Drawing.Size(650, 300);
            this.AddCustomDeviceBasePanel_pnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel AddCustomDeviceBasePanel_pnl;
        private System.Windows.Forms.Button TwoxN_btn;
        private System.Windows.Forms.Button squareQuadRow_btn;
        private System.Windows.Forms.Button RowByRow_btn;
        private System.Windows.Forms.Button Back_btn;
    }
}
