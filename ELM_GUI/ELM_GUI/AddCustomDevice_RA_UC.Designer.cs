namespace ELM_GUI
{
    partial class AddCustomDevice_RA_UC
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lateralPads_gb = new System.Windows.Forms.GroupBox();
            this.padSpace_tb = new System.Windows.Forms.TextBox();
            this.REF_tb = new System.Windows.Forms.TextBox();
            this.REF_X_lbl = new System.Windows.Forms.Label();
            this.newDeviceName_tb = new System.Windows.Forms.TextBox();
            this.deviceName_lbl = new System.Windows.Forms.Label();
            this.N_tb = new System.Windows.Forms.TextBox();
            this.lateralPads_width_lbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lateralPads_length_lbl = new System.Windows.Forms.Label();
            this.lateralPads_width_tb = new System.Windows.Forms.TextBox();
            this.lateralPads_length_tb = new System.Windows.Forms.TextBox();
            this.padSpace_lbl = new System.Windows.Forms.Label();
            this.centerPads_gb = new System.Windows.Forms.GroupBox();
            this.noCenterPad_rb = new System.Windows.Forms.RadioButton();
            this.centeredPad_rb = new System.Windows.Forms.RadioButton();
            this.centeredPadX_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cornerPads_gb = new System.Windows.Forms.GroupBox();
            this.corner_copyLateral_rb = new System.Windows.Forms.RadioButton();
            this.noCornerPad_rb = new System.Windows.Forms.RadioButton();
            this.customCornerPad_rb = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.ccp_ref_tb = new System.Windows.Forms.TextBox();
            this.ccp_dim_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.back_btn = new System.Windows.Forms.Button();
            this.generateDevice_btn = new System.Windows.Forms.Button();
            this.padNames_tb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.lateralPads_gb.SuspendLayout();
            this.centerPads_gb.SuspendLayout();
            this.cornerPads_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lateralPads_gb);
            this.panel1.Controls.Add(this.centerPads_gb);
            this.panel1.Controls.Add(this.cornerPads_gb);
            this.panel1.Controls.Add(this.back_btn);
            this.panel1.Controls.Add(this.generateDevice_btn);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 300);
            this.panel1.TabIndex = 0;
            // 
            // lateralPads_gb
            // 
            this.lateralPads_gb.Controls.Add(this.label4);
            this.lateralPads_gb.Controls.Add(this.padNames_tb);
            this.lateralPads_gb.Controls.Add(this.padSpace_tb);
            this.lateralPads_gb.Controls.Add(this.REF_tb);
            this.lateralPads_gb.Controls.Add(this.REF_X_lbl);
            this.lateralPads_gb.Controls.Add(this.newDeviceName_tb);
            this.lateralPads_gb.Controls.Add(this.deviceName_lbl);
            this.lateralPads_gb.Controls.Add(this.N_tb);
            this.lateralPads_gb.Controls.Add(this.lateralPads_width_lbl);
            this.lateralPads_gb.Controls.Add(this.label8);
            this.lateralPads_gb.Controls.Add(this.lateralPads_length_lbl);
            this.lateralPads_gb.Controls.Add(this.lateralPads_width_tb);
            this.lateralPads_gb.Controls.Add(this.lateralPads_length_tb);
            this.lateralPads_gb.Controls.Add(this.padSpace_lbl);
            this.lateralPads_gb.Location = new System.Drawing.Point(20, 10);
            this.lateralPads_gb.Name = "lateralPads_gb";
            this.lateralPads_gb.Size = new System.Drawing.Size(177, 229);
            this.lateralPads_gb.TabIndex = 71;
            this.lateralPads_gb.TabStop = false;
            this.lateralPads_gb.Text = "Lateral Pads";
            // 
            // padSpace_tb
            // 
            this.padSpace_tb.Location = new System.Drawing.Point(80, 152);
            this.padSpace_tb.Name = "padSpace_tb";
            this.padSpace_tb.Size = new System.Drawing.Size(50, 20);
            this.padSpace_tb.TabIndex = 38;
            this.padSpace_tb.TextChanged += new System.EventHandler(this.padSpace_tb_TextChanged);
            // 
            // REF_tb
            // 
            this.REF_tb.Location = new System.Drawing.Point(79, 59);
            this.REF_tb.Name = "REF_tb";
            this.REF_tb.Size = new System.Drawing.Size(51, 20);
            this.REF_tb.TabIndex = 16;
            this.REF_tb.TextChanged += new System.EventHandler(this.REF_tb_TextChanged);
            // 
            // REF_X_lbl
            // 
            this.REF_X_lbl.AutoSize = true;
            this.REF_X_lbl.Location = new System.Drawing.Point(45, 62);
            this.REF_X_lbl.Name = "REF_X_lbl";
            this.REF_X_lbl.Size = new System.Drawing.Size(28, 13);
            this.REF_X_lbl.TabIndex = 17;
            this.REF_X_lbl.Text = "REF";
            // 
            // newDeviceName_tb
            // 
            this.newDeviceName_tb.Location = new System.Drawing.Point(48, 19);
            this.newDeviceName_tb.Name = "newDeviceName_tb";
            this.newDeviceName_tb.Size = new System.Drawing.Size(82, 20);
            this.newDeviceName_tb.TabIndex = 30;
            this.newDeviceName_tb.TextChanged += new System.EventHandler(this.newDeviceName_tb_TextChanged);
            // 
            // deviceName_lbl
            // 
            this.deviceName_lbl.AutoSize = true;
            this.deviceName_lbl.Location = new System.Drawing.Point(7, 26);
            this.deviceName_lbl.Name = "deviceName_lbl";
            this.deviceName_lbl.Size = new System.Drawing.Size(35, 13);
            this.deviceName_lbl.TabIndex = 29;
            this.deviceName_lbl.Text = "Name";
            // 
            // N_tb
            // 
            this.N_tb.Location = new System.Drawing.Point(79, 82);
            this.N_tb.Name = "N_tb";
            this.N_tb.Size = new System.Drawing.Size(51, 20);
            this.N_tb.TabIndex = 61;
            this.N_tb.TextChanged += new System.EventHandler(this.N_tb_TextChanged);
            // 
            // lateralPads_width_lbl
            // 
            this.lateralPads_width_lbl.AutoSize = true;
            this.lateralPads_width_lbl.Location = new System.Drawing.Point(17, 112);
            this.lateralPads_width_lbl.Name = "lateralPads_width_lbl";
            this.lateralPads_width_lbl.Size = new System.Drawing.Size(57, 13);
            this.lateralPads_width_lbl.TabIndex = 18;
            this.lateralPads_width_lbl.Text = "Pad Width";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 60;
            this.label8.Text = "# / Side";
            // 
            // lateralPads_length_lbl
            // 
            this.lateralPads_length_lbl.AutoSize = true;
            this.lateralPads_length_lbl.Location = new System.Drawing.Point(12, 136);
            this.lateralPads_length_lbl.Name = "lateralPads_length_lbl";
            this.lateralPads_length_lbl.Size = new System.Drawing.Size(62, 13);
            this.lateralPads_length_lbl.TabIndex = 19;
            this.lateralPads_length_lbl.Text = "Pad Length";
            // 
            // lateralPads_width_tb
            // 
            this.lateralPads_width_tb.Location = new System.Drawing.Point(80, 105);
            this.lateralPads_width_tb.Name = "lateralPads_width_tb";
            this.lateralPads_width_tb.Size = new System.Drawing.Size(50, 20);
            this.lateralPads_width_tb.TabIndex = 20;
            this.lateralPads_width_tb.TextChanged += new System.EventHandler(this.lateralPads_width_tb_TextChanged);
            // 
            // lateralPads_length_tb
            // 
            this.lateralPads_length_tb.Location = new System.Drawing.Point(80, 129);
            this.lateralPads_length_tb.Name = "lateralPads_length_tb";
            this.lateralPads_length_tb.Size = new System.Drawing.Size(50, 20);
            this.lateralPads_length_tb.TabIndex = 21;
            this.lateralPads_length_tb.TextChanged += new System.EventHandler(this.lateralPads_length_tb_TextChanged);
            // 
            // padSpace_lbl
            // 
            this.padSpace_lbl.AutoSize = true;
            this.padSpace_lbl.Location = new System.Drawing.Point(15, 159);
            this.padSpace_lbl.Name = "padSpace_lbl";
            this.padSpace_lbl.Size = new System.Drawing.Size(60, 13);
            this.padSpace_lbl.TabIndex = 37;
            this.padSpace_lbl.Text = "Pad Space";
            // 
            // centerPads_gb
            // 
            this.centerPads_gb.Controls.Add(this.noCenterPad_rb);
            this.centerPads_gb.Controls.Add(this.centeredPad_rb);
            this.centerPads_gb.Controls.Add(this.centeredPadX_tb);
            this.centerPads_gb.Controls.Add(this.label1);
            this.centerPads_gb.Location = new System.Drawing.Point(203, 10);
            this.centerPads_gb.Name = "centerPads_gb";
            this.centerPads_gb.Size = new System.Drawing.Size(147, 109);
            this.centerPads_gb.TabIndex = 70;
            this.centerPads_gb.TabStop = false;
            this.centerPads_gb.Text = "Center Pad(s)?";
            // 
            // noCenterPad_rb
            // 
            this.noCenterPad_rb.AutoSize = true;
            this.noCenterPad_rb.Location = new System.Drawing.Point(6, 14);
            this.noCenterPad_rb.Name = "noCenterPad_rb";
            this.noCenterPad_rb.Size = new System.Drawing.Size(51, 17);
            this.noCenterPad_rb.TabIndex = 45;
            this.noCenterPad_rb.TabStop = true;
            this.noCenterPad_rb.Text = "None";
            this.noCenterPad_rb.UseVisualStyleBackColor = true;
            this.noCenterPad_rb.CheckedChanged += new System.EventHandler(this.noCenterPad_rb_CheckedChanged);
            // 
            // centeredPad_rb
            // 
            this.centeredPad_rb.AutoSize = true;
            this.centeredPad_rb.Location = new System.Drawing.Point(6, 61);
            this.centeredPad_rb.Name = "centeredPad_rb";
            this.centeredPad_rb.Size = new System.Drawing.Size(130, 17);
            this.centeredPad_rb.TabIndex = 44;
            this.centeredPad_rb.TabStop = true;
            this.centeredPad_rb.Text = "Centered Square Pad:";
            this.centeredPad_rb.UseVisualStyleBackColor = true;
            this.centeredPad_rb.CheckedChanged += new System.EventHandler(this.centeredPad_rb_CheckedChanged);
            // 
            // centeredPadX_tb
            // 
            this.centeredPadX_tb.Location = new System.Drawing.Point(83, 81);
            this.centeredPadX_tb.Name = "centeredPadX_tb";
            this.centeredPadX_tb.Size = new System.Drawing.Size(50, 20);
            this.centeredPadX_tb.TabIndex = 47;
            this.centeredPadX_tb.TextChanged += new System.EventHandler(this.centeredPadX_tb_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Dim";
            // 
            // cornerPads_gb
            // 
            this.cornerPads_gb.Controls.Add(this.corner_copyLateral_rb);
            this.cornerPads_gb.Controls.Add(this.noCornerPad_rb);
            this.cornerPads_gb.Controls.Add(this.customCornerPad_rb);
            this.cornerPads_gb.Controls.Add(this.label3);
            this.cornerPads_gb.Controls.Add(this.ccp_ref_tb);
            this.cornerPads_gb.Controls.Add(this.ccp_dim_tb);
            this.cornerPads_gb.Controls.Add(this.label2);
            this.cornerPads_gb.Location = new System.Drawing.Point(203, 123);
            this.cornerPads_gb.Name = "cornerPads_gb";
            this.cornerPads_gb.Size = new System.Drawing.Size(182, 125);
            this.cornerPads_gb.TabIndex = 69;
            this.cornerPads_gb.TabStop = false;
            this.cornerPads_gb.Text = "Corner Pads?";
            // 
            // corner_copyLateral_rb
            // 
            this.corner_copyLateral_rb.AutoSize = true;
            this.corner_copyLateral_rb.Location = new System.Drawing.Point(6, 47);
            this.corner_copyLateral_rb.Name = "corner_copyLateral_rb";
            this.corner_copyLateral_rb.Size = new System.Drawing.Size(111, 17);
            this.corner_copyLateral_rb.TabIndex = 50;
            this.corner_copyLateral_rb.TabStop = true;
            this.corner_copyLateral_rb.Text = "Copy Lateral Pads";
            this.corner_copyLateral_rb.UseVisualStyleBackColor = true;
            this.corner_copyLateral_rb.CheckedChanged += new System.EventHandler(this.corner_copyLateral_rb_CheckedChanged);
            // 
            // noCornerPad_rb
            // 
            this.noCornerPad_rb.AutoSize = true;
            this.noCornerPad_rb.Location = new System.Drawing.Point(6, 23);
            this.noCornerPad_rb.Name = "noCornerPad_rb";
            this.noCornerPad_rb.Size = new System.Drawing.Size(51, 17);
            this.noCornerPad_rb.TabIndex = 72;
            this.noCornerPad_rb.TabStop = true;
            this.noCornerPad_rb.Text = "None";
            this.noCornerPad_rb.UseVisualStyleBackColor = true;
            this.noCornerPad_rb.CheckedChanged += new System.EventHandler(this.noCornerPad_rb_CheckedChanged);
            // 
            // customCornerPad_rb
            // 
            this.customCornerPad_rb.AutoSize = true;
            this.customCornerPad_rb.Location = new System.Drawing.Point(6, 70);
            this.customCornerPad_rb.Name = "customCornerPad_rb";
            this.customCornerPad_rb.Size = new System.Drawing.Size(123, 17);
            this.customCornerPad_rb.TabIndex = 64;
            this.customCornerPad_rb.TabStop = true;
            this.customCornerPad_rb.Text = "Square Corner Pads:";
            this.customCornerPad_rb.UseVisualStyleBackColor = true;
            this.customCornerPad_rb.CheckedChanged += new System.EventHandler(this.customCornerPad_rb_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 68;
            this.label3.Text = "REF";
            // 
            // ccp_ref_tb
            // 
            this.ccp_ref_tb.Location = new System.Drawing.Point(116, 96);
            this.ccp_ref_tb.Name = "ccp_ref_tb";
            this.ccp_ref_tb.Size = new System.Drawing.Size(50, 20);
            this.ccp_ref_tb.TabIndex = 66;
            this.ccp_ref_tb.TextChanged += new System.EventHandler(this.ccp_ref_tb_TextChanged);
            // 
            // ccp_dim_tb
            // 
            this.ccp_dim_tb.Location = new System.Drawing.Point(32, 96);
            this.ccp_dim_tb.Name = "ccp_dim_tb";
            this.ccp_dim_tb.Size = new System.Drawing.Size(50, 20);
            this.ccp_dim_tb.TabIndex = 65;
            this.ccp_dim_tb.TextChanged += new System.EventHandler(this.ccp_dim_tb_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 67;
            this.label2.Text = "Dim";
            // 
            // back_btn
            // 
            this.back_btn.Location = new System.Drawing.Point(20, 260);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(163, 27);
            this.back_btn.TabIndex = 28;
            this.back_btn.Text = "Back";
            this.back_btn.UseVisualStyleBackColor = true;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // generateDevice_btn
            // 
            this.generateDevice_btn.Location = new System.Drawing.Point(203, 260);
            this.generateDevice_btn.Name = "generateDevice_btn";
            this.generateDevice_btn.Size = new System.Drawing.Size(431, 27);
            this.generateDevice_btn.TabIndex = 27;
            this.generateDevice_btn.Text = "Generate Device";
            this.generateDevice_btn.UseVisualStyleBackColor = true;
            this.generateDevice_btn.Click += new System.EventHandler(this.generateDevice_btn_Click);
            // 
            // padNames_tb
            // 
            this.padNames_tb.Location = new System.Drawing.Point(79, 183);
            this.padNames_tb.Name = "padNames_tb";
            this.padNames_tb.Size = new System.Drawing.Size(51, 20);
            this.padNames_tb.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "Pad Names";
            // 
            // AddCustomDevice_RA_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "AddCustomDevice_RA_UC";
            this.Size = new System.Drawing.Size(650, 300);
            this.Load += new System.EventHandler(this.AddCustomDevice_RA_UC_Load);
            this.panel1.ResumeLayout(false);
            this.lateralPads_gb.ResumeLayout(false);
            this.lateralPads_gb.PerformLayout();
            this.centerPads_gb.ResumeLayout(false);
            this.centerPads_gb.PerformLayout();
            this.cornerPads_gb.ResumeLayout(false);
            this.cornerPads_gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox lateralPads_length_tb;
        private System.Windows.Forms.TextBox lateralPads_width_tb;
        private System.Windows.Forms.Label lateralPads_length_lbl;
        private System.Windows.Forms.Label lateralPads_width_lbl;
        private System.Windows.Forms.Label REF_X_lbl;
        private System.Windows.Forms.TextBox REF_tb;
        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.Button generateDevice_btn;
        private System.Windows.Forms.TextBox newDeviceName_tb;
        private System.Windows.Forms.Label deviceName_lbl;
        private System.Windows.Forms.TextBox padSpace_tb;
        private System.Windows.Forms.Label padSpace_lbl;
        private System.Windows.Forms.TextBox centeredPadX_tb;
        private System.Windows.Forms.RadioButton noCenterPad_rb;
        private System.Windows.Forms.RadioButton centeredPad_rb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox N_tb;
        private System.Windows.Forms.RadioButton customCornerPad_rb;
        private System.Windows.Forms.TextBox ccp_ref_tb;
        private System.Windows.Forms.TextBox ccp_dim_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox cornerPads_gb;
        private System.Windows.Forms.GroupBox centerPads_gb;
        private System.Windows.Forms.GroupBox lateralPads_gb;
        private System.Windows.Forms.RadioButton noCornerPad_rb;
        private System.Windows.Forms.RadioButton corner_copyLateral_rb;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox padNames_tb;
    }
}
