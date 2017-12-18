namespace ELM_GUI
{
    partial class AddCustomDevice_RxR_UC
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
            this.generate_btn = new System.Windows.Forms.Button();
            this.back_btn = new System.Windows.Forms.Button();
            this.newDeviceName_tb = new System.Windows.Forms.TextBox();
            this.interRowDefinition_gb = new System.Windows.Forms.GroupBox();
            this.N_rows_nud = new System.Windows.Forms.NumericUpDown();
            this.Nrows_lbl = new System.Windows.Forms.Label();
            this.offsetY_tb = new System.Windows.Forms.TextBox();
            this.offsetY_lbl = new System.Windows.Forms.Label();
            this.offsetX_tb = new System.Windows.Forms.TextBox();
            this.offsetX_lbl = new System.Windows.Forms.Label();
            this.rowDefinitions_gb = new System.Windows.Forms.GroupBox();
            this.padSpace_tb = new System.Windows.Forms.TextBox();
            this.padSpace_lbl = new System.Windows.Forms.Label();
            this.padY_tb = new System.Windows.Forms.TextBox();
            this.padY_lbl = new System.Windows.Forms.Label();
            this.padX_tb = new System.Windows.Forms.TextBox();
            this.padX_lbl = new System.Windows.Forms.Label();
            this.Npads_tb = new System.Windows.Forms.TextBox();
            this.Npads_lbl = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.padNames_lbl = new System.Windows.Forms.Label();
            this.optional_gb = new System.Windows.Forms.GroupBox();
            this.deviceName_gb = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.interRowDefinition_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.N_rows_nud)).BeginInit();
            this.rowDefinitions_gb.SuspendLayout();
            this.optional_gb.SuspendLayout();
            this.deviceName_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Green;
            this.panel1.Controls.Add(this.deviceName_gb);
            this.panel1.Controls.Add(this.optional_gb);
            this.panel1.Controls.Add(this.generate_btn);
            this.panel1.Controls.Add(this.back_btn);
            this.panel1.Controls.Add(this.interRowDefinition_gb);
            this.panel1.Controls.Add(this.rowDefinitions_gb);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 300);
            this.panel1.TabIndex = 0;
            // 
            // generate_btn
            // 
            this.generate_btn.BackColor = System.Drawing.Color.Black;
            this.generate_btn.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold);
            this.generate_btn.ForeColor = System.Drawing.Color.White;
            this.generate_btn.Location = new System.Drawing.Point(331, 240);
            this.generate_btn.Name = "generate_btn";
            this.generate_btn.Size = new System.Drawing.Size(319, 40);
            this.generate_btn.TabIndex = 18;
            this.generate_btn.Text = "Generate";
            this.generate_btn.UseVisualStyleBackColor = false;
            this.generate_btn.Click += new System.EventHandler(this.generate_btn_Click);
            // 
            // back_btn
            // 
            this.back_btn.BackColor = System.Drawing.Color.White;
            this.back_btn.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_btn.ForeColor = System.Drawing.Color.Black;
            this.back_btn.Location = new System.Drawing.Point(0, 240);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(332, 40);
            this.back_btn.TabIndex = 17;
            this.back_btn.Text = "Back";
            this.back_btn.UseVisualStyleBackColor = false;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // newDeviceName_tb
            // 
            this.newDeviceName_tb.Location = new System.Drawing.Point(9, 17);
            this.newDeviceName_tb.Name = "newDeviceName_tb";
            this.newDeviceName_tb.Size = new System.Drawing.Size(316, 20);
            this.newDeviceName_tb.TabIndex = 15;
            this.newDeviceName_tb.TextChanged += new System.EventHandler(this.newDeviceName_tb_TextChanged);
            // 
            // interRowDefinition_gb
            // 
            this.interRowDefinition_gb.Controls.Add(this.N_rows_nud);
            this.interRowDefinition_gb.Controls.Add(this.offsetY_tb);
            this.interRowDefinition_gb.Controls.Add(this.offsetY_lbl);
            this.interRowDefinition_gb.Controls.Add(this.offsetX_tb);
            this.interRowDefinition_gb.Controls.Add(this.offsetX_lbl);
            this.interRowDefinition_gb.Controls.Add(this.Nrows_lbl);
            this.interRowDefinition_gb.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.interRowDefinition_gb.ForeColor = System.Drawing.Color.White;
            this.interRowDefinition_gb.Location = new System.Drawing.Point(163, 47);
            this.interRowDefinition_gb.Name = "interRowDefinition_gb";
            this.interRowDefinition_gb.Size = new System.Drawing.Size(169, 107);
            this.interRowDefinition_gb.TabIndex = 0;
            this.interRowDefinition_gb.TabStop = false;
            this.interRowDefinition_gb.Text = "Inter-Row Spec";
            // 
            // N_rows_nud
            // 
            this.N_rows_nud.Location = new System.Drawing.Point(69, 22);
            this.N_rows_nud.Name = "N_rows_nud";
            this.N_rows_nud.Size = new System.Drawing.Size(82, 20);
            this.N_rows_nud.TabIndex = 14;
            this.N_rows_nud.ValueChanged += new System.EventHandler(this.N_rows_nud_ValueChanged);
            // 
            // Nrows_lbl
            // 
            this.Nrows_lbl.AutoSize = true;
            this.Nrows_lbl.Location = new System.Drawing.Point(21, 23);
            this.Nrows_lbl.Name = "Nrows_lbl";
            this.Nrows_lbl.Size = new System.Drawing.Size(49, 14);
            this.Nrows_lbl.TabIndex = 12;
            this.Nrows_lbl.Text = "# Rows";
            // 
            // offsetY_tb
            // 
            this.offsetY_tb.Location = new System.Drawing.Point(69, 75);
            this.offsetY_tb.Name = "offsetY_tb";
            this.offsetY_tb.Size = new System.Drawing.Size(82, 20);
            this.offsetY_tb.TabIndex = 11;
            this.offsetY_tb.TextChanged += new System.EventHandler(this.any_tb_TextChanged);
            this.offsetY_tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.offsetY_tb_KeyDown);
            // 
            // offsetY_lbl
            // 
            this.offsetY_lbl.AutoSize = true;
            this.offsetY_lbl.Location = new System.Drawing.Point(7, 77);
            this.offsetY_lbl.Name = "offsetY_lbl";
            this.offsetY_lbl.Size = new System.Drawing.Size(63, 14);
            this.offsetY_lbl.TabIndex = 10;
            this.offsetY_lbl.Text = "Offset Y";
            // 
            // offsetX_tb
            // 
            this.offsetX_tb.Location = new System.Drawing.Point(69, 49);
            this.offsetX_tb.Name = "offsetX_tb";
            this.offsetX_tb.Size = new System.Drawing.Size(82, 20);
            this.offsetX_tb.TabIndex = 9;
            this.offsetX_tb.TextChanged += new System.EventHandler(this.any_tb_TextChanged);
            this.offsetX_tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.offsetX_tb_KeyDown);
            // 
            // offsetX_lbl
            // 
            this.offsetX_lbl.AutoSize = true;
            this.offsetX_lbl.Location = new System.Drawing.Point(7, 52);
            this.offsetX_lbl.Name = "offsetX_lbl";
            this.offsetX_lbl.Size = new System.Drawing.Size(63, 14);
            this.offsetX_lbl.TabIndex = 8;
            this.offsetX_lbl.Text = "Offset X";
            // 
            // rowDefinitions_gb
            // 
            this.rowDefinitions_gb.Controls.Add(this.padSpace_tb);
            this.rowDefinitions_gb.Controls.Add(this.padSpace_lbl);
            this.rowDefinitions_gb.Controls.Add(this.padY_tb);
            this.rowDefinitions_gb.Controls.Add(this.padY_lbl);
            this.rowDefinitions_gb.Controls.Add(this.padX_tb);
            this.rowDefinitions_gb.Controls.Add(this.padX_lbl);
            this.rowDefinitions_gb.Controls.Add(this.Npads_tb);
            this.rowDefinitions_gb.Controls.Add(this.Npads_lbl);
            this.rowDefinitions_gb.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rowDefinitions_gb.ForeColor = System.Drawing.Color.White;
            this.rowDefinitions_gb.Location = new System.Drawing.Point(0, 47);
            this.rowDefinitions_gb.Name = "rowDefinitions_gb";
            this.rowDefinitions_gb.Size = new System.Drawing.Size(157, 137);
            this.rowDefinitions_gb.TabIndex = 0;
            this.rowDefinitions_gb.TabStop = false;
            this.rowDefinitions_gb.Text = "Row Spec";
            // 
            // padSpace_tb
            // 
            this.padSpace_tb.Location = new System.Drawing.Point(59, 104);
            this.padSpace_tb.Name = "padSpace_tb";
            this.padSpace_tb.Size = new System.Drawing.Size(92, 20);
            this.padSpace_tb.TabIndex = 7;
            this.padSpace_tb.TextChanged += new System.EventHandler(this.any_tb_TextChanged);
            this.padSpace_tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.padSpace_tb_KeyDown);
            // 
            // padSpace_lbl
            // 
            this.padSpace_lbl.AutoSize = true;
            this.padSpace_lbl.Location = new System.Drawing.Point(33, 105);
            this.padSpace_lbl.Name = "padSpace_lbl";
            this.padSpace_lbl.Size = new System.Drawing.Size(28, 14);
            this.padSpace_lbl.TabIndex = 6;
            this.padSpace_lbl.Text = "REF";
            // 
            // padY_tb
            // 
            this.padY_tb.Location = new System.Drawing.Point(59, 77);
            this.padY_tb.Name = "padY_tb";
            this.padY_tb.Size = new System.Drawing.Size(92, 20);
            this.padY_tb.TabIndex = 5;
            this.padY_tb.TextChanged += new System.EventHandler(this.any_tb_TextChanged);
            this.padY_tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.padY_tb_KeyDown);
            // 
            // padY_lbl
            // 
            this.padY_lbl.AutoSize = true;
            this.padY_lbl.Location = new System.Drawing.Point(19, 78);
            this.padY_lbl.Name = "padY_lbl";
            this.padY_lbl.Size = new System.Drawing.Size(42, 14);
            this.padY_lbl.TabIndex = 4;
            this.padY_lbl.Text = "Pad Y";
            // 
            // padX_tb
            // 
            this.padX_tb.Location = new System.Drawing.Point(59, 51);
            this.padX_tb.Name = "padX_tb";
            this.padX_tb.Size = new System.Drawing.Size(92, 20);
            this.padX_tb.TabIndex = 3;
            this.padX_tb.TextChanged += new System.EventHandler(this.any_tb_TextChanged);
            this.padX_tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.padX_tb_KeyDown);
            // 
            // padX_lbl
            // 
            this.padX_lbl.AutoSize = true;
            this.padX_lbl.Location = new System.Drawing.Point(19, 53);
            this.padX_lbl.Name = "padX_lbl";
            this.padX_lbl.Size = new System.Drawing.Size(42, 14);
            this.padX_lbl.TabIndex = 2;
            this.padX_lbl.Text = "Pad X";
            // 
            // Npads_tb
            // 
            this.Npads_tb.Location = new System.Drawing.Point(59, 23);
            this.Npads_tb.Name = "Npads_tb";
            this.Npads_tb.Size = new System.Drawing.Size(92, 20);
            this.Npads_tb.TabIndex = 1;
            this.Npads_tb.TextChanged += new System.EventHandler(this.any_tb_TextChanged);
            this.Npads_tb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Npads_tb_KeyDown);
            // 
            // Npads_lbl
            // 
            this.Npads_lbl.AutoSize = true;
            this.Npads_lbl.Location = new System.Drawing.Point(13, 24);
            this.Npads_lbl.Name = "Npads_lbl";
            this.Npads_lbl.Size = new System.Drawing.Size(49, 14);
            this.Npads_lbl.TabIndex = 0;
            this.Npads_lbl.Text = "# Pads";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(89, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(236, 20);
            this.textBox1.TabIndex = 19;
            // 
            // padNames_lbl
            // 
            this.padNames_lbl.AutoSize = true;
            this.padNames_lbl.Location = new System.Drawing.Point(6, 18);
            this.padNames_lbl.Name = "padNames_lbl";
            this.padNames_lbl.Size = new System.Drawing.Size(77, 14);
            this.padNames_lbl.TabIndex = 20;
            this.padNames_lbl.Text = "Pad Names:";
            // 
            // optional_gb
            // 
            this.optional_gb.Controls.Add(this.padNames_lbl);
            this.optional_gb.Controls.Add(this.textBox1);
            this.optional_gb.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optional_gb.ForeColor = System.Drawing.Color.White;
            this.optional_gb.Location = new System.Drawing.Point(0, 189);
            this.optional_gb.Name = "optional_gb";
            this.optional_gb.Size = new System.Drawing.Size(332, 45);
            this.optional_gb.TabIndex = 21;
            this.optional_gb.TabStop = false;
            this.optional_gb.Text = "Optional";
            // 
            // deviceName_gb
            // 
            this.deviceName_gb.Controls.Add(this.newDeviceName_tb);
            this.deviceName_gb.Font = new System.Drawing.Font("Courier New", 8.5F, System.Drawing.FontStyle.Bold);
            this.deviceName_gb.ForeColor = System.Drawing.Color.White;
            this.deviceName_gb.Location = new System.Drawing.Point(0, 4);
            this.deviceName_gb.Name = "deviceName_gb";
            this.deviceName_gb.Size = new System.Drawing.Size(332, 44);
            this.deviceName_gb.TabIndex = 22;
            this.deviceName_gb.TabStop = false;
            this.deviceName_gb.Text = "Device Name";
            // 
            // AddCustomDevice_RxR_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "AddCustomDevice_RxR_UC";
            this.Size = new System.Drawing.Size(650, 300);
            this.Load += new System.EventHandler(this.AddCustomDevice_RxR_UC_Load);
            this.panel1.ResumeLayout(false);
            this.interRowDefinition_gb.ResumeLayout(false);
            this.interRowDefinition_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.N_rows_nud)).EndInit();
            this.rowDefinitions_gb.ResumeLayout(false);
            this.rowDefinitions_gb.PerformLayout();
            this.optional_gb.ResumeLayout(false);
            this.optional_gb.PerformLayout();
            this.deviceName_gb.ResumeLayout(false);
            this.deviceName_gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox interRowDefinition_gb;
        private System.Windows.Forms.GroupBox rowDefinitions_gb;
        private System.Windows.Forms.TextBox Npads_tb;
        private System.Windows.Forms.Label Npads_lbl;
        private System.Windows.Forms.TextBox padY_tb;
        private System.Windows.Forms.Label padY_lbl;
        private System.Windows.Forms.TextBox padX_tb;
        private System.Windows.Forms.Label padX_lbl;
        private System.Windows.Forms.TextBox padSpace_tb;
        private System.Windows.Forms.Label padSpace_lbl;
        private System.Windows.Forms.TextBox offsetY_tb;
        private System.Windows.Forms.Label offsetY_lbl;
        private System.Windows.Forms.TextBox offsetX_tb;
        private System.Windows.Forms.Label offsetX_lbl;
        private System.Windows.Forms.Label Nrows_lbl;
        private System.Windows.Forms.NumericUpDown N_rows_nud;
        private System.Windows.Forms.TextBox newDeviceName_tb;
        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.Button generate_btn;
        private System.Windows.Forms.Label padNames_lbl;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox optional_gb;
        private System.Windows.Forms.GroupBox deviceName_gb;
    }
}
