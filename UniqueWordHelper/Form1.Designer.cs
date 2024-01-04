namespace UniqueWordHelper
{
    partial class Form1
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
            this.btnStart = new System.Windows.Forms.Button();
            this.txtFolderPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioMemory = new System.Windows.Forms.RadioButton();
            this.radioDB = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(317, 363);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(274, 133);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Process";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtFolderPath
            // 
            this.txtFolderPath.Location = new System.Drawing.Point(276, 113);
            this.txtFolderPath.Name = "txtFolderPath";
            this.txtFolderPath.Size = new System.Drawing.Size(487, 38);
            this.txtFolderPath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Folder Path";
            // 
            // radioMemory
            // 
            this.radioMemory.AutoSize = true;
            this.radioMemory.Checked = true;
            this.radioMemory.Location = new System.Drawing.Point(32, 65);
            this.radioMemory.Name = "radioMemory";
            this.radioMemory.Size = new System.Drawing.Size(153, 36);
            this.radioMemory.TabIndex = 3;
            this.radioMemory.TabStop = true;
            this.radioMemory.Text = "Memory";
            this.radioMemory.UseVisualStyleBackColor = true;
            // 
            // radioDB
            // 
            this.radioDB.AutoSize = true;
            this.radioDB.Location = new System.Drawing.Point(305, 65);
            this.radioDB.Name = "radioDB";
            this.radioDB.Size = new System.Drawing.Size(174, 36);
            this.radioDB.TabIndex = 4;
            this.radioDB.Text = "Database";
            this.radioDB.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioMemory);
            this.groupBox1.Controls.Add(this.radioDB);
            this.groupBox1.Location = new System.Drawing.Point(180, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 151);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose one";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 520);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFolderPath);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtFolderPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioMemory;
        private System.Windows.Forms.RadioButton radioDB;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

