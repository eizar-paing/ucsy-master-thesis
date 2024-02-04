namespace RoughSetProject2
{
    partial class InconsistentForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.labeldependency = new System.Windows.Forms.Label();
            this.labelacc = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trestbps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fbs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.restecg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thalach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.op = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slope = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.td = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.MediumBlue;
            this.button1.Location = new System.Drawing.Point(1070, 466);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 34);
            this.button1.TabIndex = 13;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labeldependency
            // 
            this.labeldependency.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labeldependency.AutoSize = true;
            this.labeldependency.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldependency.ForeColor = System.Drawing.Color.DarkViolet;
            this.labeldependency.Location = new System.Drawing.Point(326, 515);
            this.labeldependency.Name = "labeldependency";
            this.labeldependency.Size = new System.Drawing.Size(52, 18);
            this.labeldependency.TabIndex = 12;
            this.labeldependency.Text = "label5";
            // 
            // labelacc
            // 
            this.labelacc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelacc.AutoSize = true;
            this.labelacc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelacc.ForeColor = System.Drawing.Color.DarkViolet;
            this.labelacc.Location = new System.Drawing.Point(326, 466);
            this.labelacc.Name = "labelacc";
            this.labelacc.Size = new System.Drawing.Size(52, 17);
            this.labelacc.TabIndex = 11;
            this.labelacc.Text = "label4";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkViolet;
            this.label3.Location = new System.Drawing.Point(88, 515);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Dependency :";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkViolet;
            this.label2.Location = new System.Drawing.Point(111, 464);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Accuracy :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(53, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "Inconsistent Patients";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.OldLace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.age,
            this.sex,
            this.cp,
            this.trestbps,
            this.chol,
            this.fbs,
            this.restecg,
            this.thalach,
            this.exang,
            this.op,
            this.slope,
            this.ca,
            this.thal,
            this.td});
            this.dataGridView1.Location = new System.Drawing.Point(33, 137);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1143, 295);
            this.dataGridView1.TabIndex = 14;
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.Width = 50;
            // 
            // age
            // 
            this.age.HeaderText = "Age";
            this.age.Name = "age";
            this.age.Width = 70;
            // 
            // sex
            // 
            this.sex.HeaderText = "Sex";
            this.sex.Name = "sex";
            this.sex.Width = 70;
            // 
            // cp
            // 
            this.cp.HeaderText = "Cp";
            this.cp.Name = "cp";
            // 
            // trestbps
            // 
            this.trestbps.HeaderText = "Trestbps";
            this.trestbps.Name = "trestbps";
            // 
            // chol
            // 
            this.chol.HeaderText = "Chol";
            this.chol.Name = "chol";
            // 
            // fbs
            // 
            this.fbs.HeaderText = "Fbs";
            this.fbs.Name = "fbs";
            this.fbs.Width = 50;
            // 
            // restecg
            // 
            this.restecg.HeaderText = "RestEcg";
            this.restecg.Name = "restecg";
            // 
            // thalach
            // 
            this.thalach.HeaderText = "Thalach";
            this.thalach.Name = "thalach";
            // 
            // exang
            // 
            this.exang.HeaderText = "Exang";
            this.exang.Name = "exang";
            this.exang.Width = 60;
            // 
            // op
            // 
            this.op.HeaderText = "Op";
            this.op.Name = "op";
            this.op.Width = 50;
            // 
            // slope
            // 
            this.slope.HeaderText = "Slope";
            this.slope.Name = "slope";
            this.slope.Width = 50;
            // 
            // ca
            // 
            this.ca.HeaderText = "Ca";
            this.ca.Name = "ca";
            this.ca.Width = 50;
            // 
            // thal
            // 
            this.thal.HeaderText = "Thal";
            this.thal.Name = "thal";
            // 
            // td
            // 
            this.td.HeaderText = "TD";
            this.td.Name = "td";
            this.td.Width = 50;
            // 
            // InconsistentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1211, 596);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labeldependency);
            this.Controls.Add(this.labelacc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "InconsistentForm";
            this.Text = "InconsistentForm";
            this.Load += new System.EventHandler(this.InconsistentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labeldependency;
        private System.Windows.Forms.Label labelacc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn age;
        private System.Windows.Forms.DataGridViewTextBoxColumn sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn cp;
        private System.Windows.Forms.DataGridViewTextBoxColumn trestbps;
        private System.Windows.Forms.DataGridViewTextBoxColumn chol;
        private System.Windows.Forms.DataGridViewTextBoxColumn fbs;
        private System.Windows.Forms.DataGridViewTextBoxColumn restecg;
        private System.Windows.Forms.DataGridViewTextBoxColumn thalach;
        private System.Windows.Forms.DataGridViewTextBoxColumn exang;
        private System.Windows.Forms.DataGridViewTextBoxColumn op;
        private System.Windows.Forms.DataGridViewTextBoxColumn slope;
        private System.Windows.Forms.DataGridViewTextBoxColumn ca;
        private System.Windows.Forms.DataGridViewTextBoxColumn thal;
        private System.Windows.Forms.DataGridViewTextBoxColumn td;
    }
}