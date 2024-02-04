namespace RoughSetProject2
{
    partial class RuleForm
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
            this.strengthGridview = new System.Windows.Forms.DataGridView();
            this.accuracybutton = new System.Windows.Forms.Button();
            this.strengthbutton = new System.Windows.Forms.Button();
            this.accuracyLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.valuedataGridView = new System.Windows.Forms.DataGridView();
            this.reductLabel = new System.Windows.Forms.Label();
            this.percentLabel = new System.Windows.Forms.Label();
            this.randomLabel = new System.Windows.Forms.Label();
            this.rules = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.strength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ruleImportance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.support = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descriptions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.strengthGridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valuedataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // strengthGridview
            // 
            this.strengthGridview.BackgroundColor = System.Drawing.Color.OldLace;
            this.strengthGridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.strengthGridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rules,
            this.strength,
            this.ruleImportance,
            this.support});
            this.strengthGridview.Location = new System.Drawing.Point(12, 144);
            this.strengthGridview.Name = "strengthGridview";
            this.strengthGridview.Size = new System.Drawing.Size(859, 500);
            this.strengthGridview.TabIndex = 16;
            this.strengthGridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.strengthGridview_CellContentClick_1);
            // 
            // accuracybutton
            // 
            this.accuracybutton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.accuracybutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accuracybutton.ForeColor = System.Drawing.Color.MediumBlue;
            this.accuracybutton.Location = new System.Drawing.Point(651, 653);
            this.accuracybutton.Name = "accuracybutton";
            this.accuracybutton.Size = new System.Drawing.Size(220, 39);
            this.accuracybutton.TabIndex = 15;
            this.accuracybutton.Text = "Calculate Accuracy";
            this.accuracybutton.UseVisualStyleBackColor = false;
            this.accuracybutton.Click += new System.EventHandler(this.accuracybutton_Click);
            // 
            // strengthbutton
            // 
            this.strengthbutton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.strengthbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strengthbutton.ForeColor = System.Drawing.Color.MediumBlue;
            this.strengthbutton.Location = new System.Drawing.Point(441, 653);
            this.strengthbutton.Name = "strengthbutton";
            this.strengthbutton.Size = new System.Drawing.Size(204, 39);
            this.strengthbutton.TabIndex = 14;
            this.strengthbutton.Text = "Calculate Strength";
            this.strengthbutton.UseVisualStyleBackColor = false;
            this.strengthbutton.Click += new System.EventHandler(this.strengthbutton_Click);
            // 
            // accuracyLabel
            // 
            this.accuracyLabel.AutoSize = true;
            this.accuracyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accuracyLabel.ForeColor = System.Drawing.Color.Navy;
            this.accuracyLabel.Location = new System.Drawing.Point(1167, 591);
            this.accuracyLabel.Name = "accuracyLabel";
            this.accuracyLabel.Size = new System.Drawing.Size(0, 20);
            this.accuracyLabel.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(909, 591);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Accuracy:";
            // 
            // valuedataGridView
            // 
            this.valuedataGridView.BackgroundColor = System.Drawing.Color.OldLace;
            this.valuedataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.valuedataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descriptions,
            this.Column1});
            this.valuedataGridView.Location = new System.Drawing.Point(877, 144);
            this.valuedataGridView.Name = "valuedataGridView";
            this.valuedataGridView.Size = new System.Drawing.Size(483, 405);
            this.valuedataGridView.TabIndex = 11;
            this.valuedataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.valuedataGridView_CellContentClick);
            // 
            // reductLabel
            // 
            this.reductLabel.AutoSize = true;
            this.reductLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reductLabel.ForeColor = System.Drawing.Color.Navy;
            this.reductLabel.Location = new System.Drawing.Point(562, 110);
            this.reductLabel.Name = "reductLabel";
            this.reductLabel.Size = new System.Drawing.Size(57, 20);
            this.reductLabel.TabIndex = 10;
            this.reductLabel.Text = "label2";
            // 
            // percentLabel
            // 
            this.percentLabel.AutoSize = true;
            this.percentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.percentLabel.ForeColor = System.Drawing.Color.Navy;
            this.percentLabel.Location = new System.Drawing.Point(14, 67);
            this.percentLabel.Name = "percentLabel";
            this.percentLabel.Size = new System.Drawing.Size(66, 24);
            this.percentLabel.TabIndex = 9;
            this.percentLabel.Text = "label1";
            // 
            // randomLabel
            // 
            this.randomLabel.AutoSize = true;
            this.randomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.randomLabel.ForeColor = System.Drawing.Color.Navy;
            this.randomLabel.Location = new System.Drawing.Point(14, 110);
            this.randomLabel.Name = "randomLabel";
            this.randomLabel.Size = new System.Drawing.Size(57, 20);
            this.randomLabel.TabIndex = 17;
            this.randomLabel.Text = "label2";
            // 
            // rules
            // 
            this.rules.HeaderText = "Rules";
            this.rules.Name = "rules";
            this.rules.Width = 550;
            // 
            // strength
            // 
            this.strength.HeaderText = "Strength";
            this.strength.Name = "strength";
            this.strength.Width = 90;
            // 
            // ruleImportance
            // 
            this.ruleImportance.HeaderText = "RuleImportance";
            this.ruleImportance.Name = "ruleImportance";
            // 
            // support
            // 
            this.support.HeaderText = "Support";
            this.support.Name = "support";
            this.support.Width = 90;
            // 
            // Descriptions
            // 
            this.Descriptions.HeaderText = "Attributes:";
            this.Descriptions.Name = "Descriptions";
            this.Descriptions.Width = 80;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Values:";
            this.Column1.Name = "Column1";
            this.Column1.Width = 400;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.BurlyWood;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(402, 9);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(552, 54);
            this.label2.TabIndex = 22;
            this.label2.Text = "          Rule Generation of Heart Disease Dataset\r\n By using JOHNSON\'s Algorithm" +
                " in Rough Set Theory";
            this.label2.UseCompatibleTextRendering = true;
            // 
            // RuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1366, 701);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.randomLabel);
            this.Controls.Add(this.strengthGridview);
            this.Controls.Add(this.accuracybutton);
            this.Controls.Add(this.strengthbutton);
            this.Controls.Add(this.accuracyLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.valuedataGridView);
            this.Controls.Add(this.reductLabel);
            this.Controls.Add(this.percentLabel);
            this.Name = "RuleForm";
            this.Text = "RuleForm";
            this.Load += new System.EventHandler(this.RuleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.strengthGridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valuedataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView strengthGridview;
        private System.Windows.Forms.Button accuracybutton;
        private System.Windows.Forms.Button strengthbutton;
        private System.Windows.Forms.Label accuracyLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView valuedataGridView;
        private System.Windows.Forms.Label reductLabel;
        private System.Windows.Forms.Label percentLabel;
        private System.Windows.Forms.Label randomLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn rules;
        private System.Windows.Forms.DataGridViewTextBoxColumn strength;
        private System.Windows.Forms.DataGridViewTextBoxColumn ruleImportance;
        private System.Windows.Forms.DataGridViewTextBoxColumn support;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descriptions;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label2;
    }
}