namespace Process_Dism
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDismCommand = new System.Windows.Forms.ComboBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnWimMount = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnWimDismount = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnWimRemount = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dism command:";
            // 
            // comboBoxDismCommand
            // 
            this.comboBoxDismCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDismCommand.FormattingEnabled = true;
            this.comboBoxDismCommand.Items.AddRange(new object[] {
            "/online /Get-Features",
            "/online /Get-FeatureInfo /FeatureName:IIS-WebServer",
            "/online /Cleanup-Image /CheckHealth",
            "/online /Cleanup-Image /ScanHealth"});
            this.comboBoxDismCommand.Location = new System.Drawing.Point(153, 34);
            this.comboBoxDismCommand.Name = "comboBoxDismCommand";
            this.comboBoxDismCommand.Size = new System.Drawing.Size(206, 21);
            this.comboBoxDismCommand.TabIndex = 1;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(181, 71);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(121, 35);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output:";
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxOutput.Location = new System.Drawing.Point(62, 278);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.Size = new System.Drawing.Size(580, 173);
            this.richTextBoxOutput.TabIndex = 4;
            this.richTextBoxOutput.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 467);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(698, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // btnWimMount
            // 
            this.btnWimMount.Location = new System.Drawing.Point(26, 29);
            this.btnWimMount.Name = "btnWimMount";
            this.btnWimMount.Size = new System.Drawing.Size(105, 23);
            this.btnWimMount.TabIndex = 6;
            this.btnWimMount.Text = "Mount WIM";
            this.btnWimMount.UseVisualStyleBackColor = true;
            this.btnWimMount.Click += new System.EventHandler(this.btnWimMount_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxDismCommand);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnRun);
            this.groupBox1.Location = new System.Drawing.Point(123, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 126);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // btnWimDismount
            // 
            this.btnWimDismount.Location = new System.Drawing.Point(153, 29);
            this.btnWimDismount.Name = "btnWimDismount";
            this.btnWimDismount.Size = new System.Drawing.Size(105, 23);
            this.btnWimDismount.TabIndex = 8;
            this.btnWimDismount.Text = "Dismount WIM";
            this.btnWimDismount.UseVisualStyleBackColor = true;
            this.btnWimDismount.Click += new System.EventHandler(this.btnWimDismount_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnWimRemount);
            this.groupBox2.Controls.Add(this.btnWimMount);
            this.groupBox2.Controls.Add(this.btnWimDismount);
            this.groupBox2.Location = new System.Drawing.Point(123, 171);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(451, 71);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // btnWimRemount
            // 
            this.btnWimRemount.Location = new System.Drawing.Point(320, 29);
            this.btnWimRemount.Name = "btnWimRemount";
            this.btnWimRemount.Size = new System.Drawing.Size(105, 23);
            this.btnWimRemount.TabIndex = 9;
            this.btnWimRemount.Text = "Remount WIM";
            this.btnWimRemount.UseVisualStyleBackColor = true;
            this.btnWimRemount.Click += new System.EventHandler(this.btnWimRemount_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 489);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.richTextBoxOutput);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDismCommand;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnWimMount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnWimDismount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnWimRemount;
    }
}

