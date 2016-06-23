namespace LifePerformanceMitch
{
    partial class MainForm
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
            this.HuurcontractBtn = new System.Windows.Forms.Button();
            this.ExportBtn = new System.Windows.Forms.Button();
            this.HuurcontractLbx = new System.Windows.Forms.ListBox();
            this.HuurLbx = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NaamTb = new System.Windows.Forms.TextBox();
            this.EmailTb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.KlantBtn = new System.Windows.Forms.Button();
            this.BudgetBtn = new System.Windows.Forms.Button();
            this.MeerBtn = new System.Windows.Forms.Button();
            this.Dagprijs = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MeerNaamTbx = new System.Windows.Forms.TextBox();
            this.MotorChk = new System.Windows.Forms.CheckBox();
            this.SpierChk = new System.Windows.Forms.CheckBox();
            this.PrijsNm = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.PrijsNm)).BeginInit();
            this.SuspendLayout();
            // 
            // HuurcontractBtn
            // 
            this.HuurcontractBtn.Location = new System.Drawing.Point(22, 28);
            this.HuurcontractBtn.Name = "HuurcontractBtn";
            this.HuurcontractBtn.Size = new System.Drawing.Size(198, 23);
            this.HuurcontractBtn.TabIndex = 0;
            this.HuurcontractBtn.Text = "Voeg huurcontract toe";
            this.HuurcontractBtn.UseVisualStyleBackColor = true;
            this.HuurcontractBtn.Click += new System.EventHandler(this.HuurcontractBtn_Click);
            // 
            // ExportBtn
            // 
            this.ExportBtn.Location = new System.Drawing.Point(459, 318);
            this.ExportBtn.Name = "ExportBtn";
            this.ExportBtn.Size = new System.Drawing.Size(198, 23);
            this.ExportBtn.TabIndex = 1;
            this.ExportBtn.Text = "Exporteer";
            this.ExportBtn.UseVisualStyleBackColor = true;
            this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // HuurcontractLbx
            // 
            this.HuurcontractLbx.FormattingEnabled = true;
            this.HuurcontractLbx.Location = new System.Drawing.Point(26, 193);
            this.HuurcontractLbx.Name = "HuurcontractLbx";
            this.HuurcontractLbx.Size = new System.Drawing.Size(143, 238);
            this.HuurcontractLbx.TabIndex = 2;
            this.HuurcontractLbx.SelectedIndexChanged += new System.EventHandler(this.HuurcontractLbx_SelectedIndexChanged);
            // 
            // HuurLbx
            // 
            this.HuurLbx.FormattingEnabled = true;
            this.HuurLbx.Location = new System.Drawing.Point(247, 193);
            this.HuurLbx.Name = "HuurLbx";
            this.HuurLbx.Size = new System.Drawing.Size(143, 238);
            this.HuurLbx.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Huur lijst";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Huurcontracten";
            // 
            // NaamTb
            // 
            this.NaamTb.Location = new System.Drawing.Point(557, 21);
            this.NaamTb.Name = "NaamTb";
            this.NaamTb.Size = new System.Drawing.Size(100, 20);
            this.NaamTb.TabIndex = 6;
            // 
            // EmailTb
            // 
            this.EmailTb.Location = new System.Drawing.Point(557, 59);
            this.EmailTb.Name = "EmailTb";
            this.EmailTb.Size = new System.Drawing.Size(100, 20);
            this.EmailTb.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(554, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Naam";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(554, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "E-Mailadres";
            // 
            // KlantBtn
            // 
            this.KlantBtn.Location = new System.Drawing.Point(557, 85);
            this.KlantBtn.Name = "KlantBtn";
            this.KlantBtn.Size = new System.Drawing.Size(108, 23);
            this.KlantBtn.TabIndex = 10;
            this.KlantBtn.Text = "Voeg klant toe";
            this.KlantBtn.UseVisualStyleBackColor = true;
            this.KlantBtn.Click += new System.EventHandler(this.KlantBtn_Click);
            // 
            // BudgetBtn
            // 
            this.BudgetBtn.Location = new System.Drawing.Point(26, 438);
            this.BudgetBtn.Name = "BudgetBtn";
            this.BudgetBtn.Size = new System.Drawing.Size(143, 23);
            this.BudgetBtn.TabIndex = 11;
            this.BudgetBtn.Text = "Budget check";
            this.BudgetBtn.UseVisualStyleBackColor = true;
            this.BudgetBtn.Click += new System.EventHandler(this.BudgetBtn_Click);
            // 
            // MeerBtn
            // 
            this.MeerBtn.Location = new System.Drawing.Point(427, 90);
            this.MeerBtn.Name = "MeerBtn";
            this.MeerBtn.Size = new System.Drawing.Size(108, 23);
            this.MeerBtn.TabIndex = 16;
            this.MeerBtn.Text = "Voeg meer toe";
            this.MeerBtn.UseVisualStyleBackColor = true;
            this.MeerBtn.Click += new System.EventHandler(this.MeerBtn_Click);
            // 
            // Dagprijs
            // 
            this.Dagprijs.AutoSize = true;
            this.Dagprijs.Location = new System.Drawing.Point(424, 48);
            this.Dagprijs.Name = "Dagprijs";
            this.Dagprijs.Size = new System.Drawing.Size(45, 13);
            this.Dagprijs.TabIndex = 15;
            this.Dagprijs.Text = "Dagprijs";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(424, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Naam";
            // 
            // MeerNaamTbx
            // 
            this.MeerNaamTbx.Location = new System.Drawing.Point(427, 21);
            this.MeerNaamTbx.Name = "MeerNaamTbx";
            this.MeerNaamTbx.Size = new System.Drawing.Size(100, 20);
            this.MeerNaamTbx.TabIndex = 12;
            // 
            // MotorChk
            // 
            this.MotorChk.AutoSize = true;
            this.MotorChk.Location = new System.Drawing.Point(427, 119);
            this.MotorChk.Name = "MotorChk";
            this.MotorChk.Size = new System.Drawing.Size(53, 17);
            this.MotorChk.TabIndex = 17;
            this.MotorChk.Text = "Motor";
            this.MotorChk.UseVisualStyleBackColor = true;
            // 
            // SpierChk
            // 
            this.SpierChk.AutoSize = true;
            this.SpierChk.Location = new System.Drawing.Point(427, 142);
            this.SpierChk.Name = "SpierChk";
            this.SpierChk.Size = new System.Drawing.Size(50, 17);
            this.SpierChk.TabIndex = 18;
            this.SpierChk.Text = "Spier";
            this.SpierChk.UseVisualStyleBackColor = true;
            // 
            // PrijsNm
            // 
            this.PrijsNm.DecimalPlaces = 2;
            this.PrijsNm.Location = new System.Drawing.Point(427, 64);
            this.PrijsNm.Name = "PrijsNm";
            this.PrijsNm.Size = new System.Drawing.Size(120, 20);
            this.PrijsNm.TabIndex = 19;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 536);
            this.Controls.Add(this.PrijsNm);
            this.Controls.Add(this.SpierChk);
            this.Controls.Add(this.MotorChk);
            this.Controls.Add(this.MeerBtn);
            this.Controls.Add(this.Dagprijs);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MeerNaamTbx);
            this.Controls.Add(this.BudgetBtn);
            this.Controls.Add(this.KlantBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EmailTb);
            this.Controls.Add(this.NaamTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HuurLbx);
            this.Controls.Add(this.HuurcontractLbx);
            this.Controls.Add(this.ExportBtn);
            this.Controls.Add(this.HuurcontractBtn);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.PrijsNm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button HuurcontractBtn;
        private System.Windows.Forms.Button ExportBtn;
        private System.Windows.Forms.ListBox HuurcontractLbx;
        private System.Windows.Forms.ListBox HuurLbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NaamTb;
        private System.Windows.Forms.TextBox EmailTb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button KlantBtn;
        private System.Windows.Forms.Button BudgetBtn;
        private System.Windows.Forms.Button MeerBtn;
        private System.Windows.Forms.Label Dagprijs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox MeerNaamTbx;
        private System.Windows.Forms.CheckBox MotorChk;
        private System.Windows.Forms.CheckBox SpierChk;
        private System.Windows.Forms.NumericUpDown PrijsNm;
    }
}

