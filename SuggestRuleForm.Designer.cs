namespace RoughSetProject2
{
    partial class SuggestRuleForm
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
            this.ruleGridview = new System.Windows.Forms.DataGridView();
            this.rules = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Strength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RuleImportance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Support = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxpercentLabel = new System.Windows.Forms.Label();
            this.maxreductLabel = new System.Windows.Forms.Label();
            this.maxaccuracyLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.randomLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ruleGridview)).BeginInit();
            this.SuspendLayout();
            // 
            // ruleGridview
            // 
            this.ruleGridview.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ruleGridview.BackgroundColor = System.Drawing.Color.OldLace;
            this.ruleGridview.ColumnHeadersHeight = 25;
            this.ruleGridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rules,
            this.Strength,
            this.RuleImportance,
            this.Support});
            this.ruleGridview.Location = new System.Drawing.Point(22, 242);
            this.ruleGridview.Name = "ruleGridview";
            this.ruleGridview.Size = new System.Drawing.Size(1094, 489);
            this.ruleGridview.TabIndex = 17;
            this.ruleGridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.strengthGridview_CellContentClick);
            // 
            // rules
            // 
            this.rules.HeaderText = "Rules";
            this.rules.Name = "rules";
            this.rules.Width = 750;
            // 
            // Strength
            // 
            this.Strength.HeaderText = "Strength";
            this.Strength.Name = "Strength";
            // 
            // RuleImportance
            // 
            this.RuleImportance.HeaderText = "RuleImportance";
            this.RuleImportance.Name = "RuleImportance";
            // 
            // Support
            // 
            this.Support.HeaderText = "Support";
            this.Support.Name = "Support";
            // 
            // maxpercentLabel
            // 
            this.maxpercentLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.maxpercentLabel.AutoSize = true;
            this.maxpercentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxpercentLabel.ForeColor = System.Drawing.Color.Navy;
            this.maxpercentLabel.Location = new System.Drawing.Point(27, 117);
            this.maxpercentLabel.Name = "maxpercentLabel";
            this.maxpercentLabel.Size = new System.Drawing.Size(66, 24);
            this.maxpercentLabel.TabIndex = 18;
            this.maxpercentLabel.Text = "label1";
            // 
            // maxreductLabel
            // 
            this.maxreductLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.maxreductLabel.AutoSize = true;
            this.maxreductLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxreductLabel.ForeColor = System.Drawing.Color.Navy;
            this.maxreductLabel.Location = new System.Drawing.Point(814, 117);
            this.maxreductLabel.Name = "maxreductLabel";
            this.maxreductLabel.Size = new System.Drawing.Size(66, 24);
            this.maxreductLabel.TabIndex = 19;
            this.maxreductLabel.Text = "label2";
            // 
            // maxaccuracyLabel
            // 
            this.maxaccuracyLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.maxaccuracyLabel.AutoSize = true;
            this.maxaccuracyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxaccuracyLabel.ForeColor = System.Drawing.Color.Red;
            this.maxaccuracyLabel.Location = new System.Drawing.Point(813, 189);
            this.maxaccuracyLabel.Name = "maxaccuracyLabel";
            this.maxaccuracyLabel.Size = new System.Drawing.Size(70, 25);
            this.maxaccuracyLabel.TabIndex = 20;
            this.maxaccuracyLabel.Text = "label3";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.BurlyWood;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(308, 33);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(552, 54);
            this.label1.TabIndex = 21;
            this.label1.Text = "          Rule Generation of Heart Disease Dataset\r\n By using JOHNSON\'s Algorithm" +
                " in Rough Set Theory";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // randomLabel
            // 
            this.randomLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.randomLabel.AutoSize = true;
            this.randomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.randomLabel.ForeColor = System.Drawing.Color.Navy;
            this.randomLabel.Location = new System.Drawing.Point(27, 189);
            this.randomLabel.Name = "randomLabel";
            this.randomLabel.Size = new System.Drawing.Size(66, 24);
            this.randomLabel.TabIndex = 22;
            this.randomLabel.Text = "label2";
            // 
            // SuggestRuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1148, 743);
            this.Controls.Add(this.randomLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maxaccuracyLabel);
            this.Controls.Add(this.maxreductLabel);
            this.Controls.Add(this.maxpercentLabel);
            this.Controls.Add(this.ruleGridview);
            this.Name = "SuggestRuleForm";
            this.Text = "SuggestRuleForm";
            this.Load += new System.EventHandler(this.SuggestRuleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ruleGridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ruleGridview;
        private System.Windows.Forms.Label maxpercentLabel;
        private System.Windows.Forms.Label maxreductLabel;
        private System.Windows.Forms.Label maxaccuracyLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn rules;
        private System.Windows.Forms.DataGridViewTextBoxColumn Strength;
        private System.Windows.Forms.DataGridViewTextBoxColumn RuleImportance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Support;
        private System.Windows.Forms.Label randomLabel;
    }
}