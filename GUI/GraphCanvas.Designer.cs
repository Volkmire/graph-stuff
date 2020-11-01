namespace GUI
{
    partial class GraphGUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.drawPanel = new System.Windows.Forms.Panel();
            this.findPathButton = new System.Windows.Forms.Button();
            this.resetEdgesButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.drawRadioButton = new System.Windows.Forms.RadioButton();
            this.selectRadioButton = new System.Windows.Forms.RadioButton();
            this.modeGroup = new System.Windows.Forms.GroupBox();
            this.debugOutput = new System.Windows.Forms.TextBox();
            this.modeGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawPanel
            // 
            this.drawPanel.BackColor = System.Drawing.SystemColors.Window;
            this.drawPanel.Location = new System.Drawing.Point(12, 12);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(476, 426);
            this.drawPanel.TabIndex = 2;
            this.drawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawPanel_MouseDown);
            // 
            // findPathButton
            // 
            this.findPathButton.Location = new System.Drawing.Point(503, 114);
            this.findPathButton.Name = "findPathButton";
            this.findPathButton.Size = new System.Drawing.Size(168, 26);
            this.findPathButton.TabIndex = 3;
            this.findPathButton.Text = "Find Path";
            this.findPathButton.UseVisualStyleBackColor = true;
            this.findPathButton.Click += new System.EventHandler(this.FindPathButton_ClickAsync);
            // 
            // resetEdgesButton
            // 
            this.resetEdgesButton.Location = new System.Drawing.Point(503, 146);
            this.resetEdgesButton.Name = "resetEdgesButton";
            this.resetEdgesButton.Size = new System.Drawing.Size(168, 26);
            this.resetEdgesButton.TabIndex = 3;
            this.resetEdgesButton.Text = "Reset Edges";
            this.resetEdgesButton.UseVisualStyleBackColor = true;
            this.resetEdgesButton.Click += new System.EventHandler(this.ResetEdgesButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(503, 178);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(168, 26);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // drawRadioButton
            // 
            this.drawRadioButton.AutoSize = true;
            this.drawRadioButton.Checked = true;
            this.drawRadioButton.Location = new System.Drawing.Point(6, 18);
            this.drawRadioButton.Name = "drawRadioButton";
            this.drawRadioButton.Size = new System.Drawing.Size(52, 19);
            this.drawRadioButton.TabIndex = 0;
            this.drawRadioButton.TabStop = true;
            this.drawRadioButton.Text = "Draw";
            this.drawRadioButton.UseVisualStyleBackColor = true;
            this.drawRadioButton.CheckedChanged += new System.EventHandler(this.DrawRadioButton_CheckedChanged);
            // 
            // selectRadioButton
            // 
            this.selectRadioButton.AutoSize = true;
            this.selectRadioButton.Location = new System.Drawing.Point(6, 44);
            this.selectRadioButton.Name = "selectRadioButton";
            this.selectRadioButton.Size = new System.Drawing.Size(56, 19);
            this.selectRadioButton.TabIndex = 1;
            this.selectRadioButton.Text = "Select";
            this.selectRadioButton.UseVisualStyleBackColor = true;
            // 
            // modeGroup
            // 
            this.modeGroup.Controls.Add(this.selectRadioButton);
            this.modeGroup.Controls.Add(this.drawRadioButton);
            this.modeGroup.Location = new System.Drawing.Point(503, 12);
            this.modeGroup.Name = "modeGroup";
            this.modeGroup.Size = new System.Drawing.Size(169, 74);
            this.modeGroup.TabIndex = 1;
            this.modeGroup.TabStop = false;
            this.modeGroup.Text = "Modes";
            // 
            // debugOutput
            // 
            this.debugOutput.Location = new System.Drawing.Point(503, 220);
            this.debugOutput.Multiline = true;
            this.debugOutput.Name = "debugOutput";
            this.debugOutput.ReadOnly = true;
            this.debugOutput.Size = new System.Drawing.Size(167, 217);
            this.debugOutput.TabIndex = 4;
            // 
            // GraphGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(684, 450);
            this.Controls.Add(this.debugOutput);
            this.Controls.Add(this.modeGroup);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.resetEdgesButton);
            this.Controls.Add(this.findPathButton);
            this.Controls.Add(this.drawPanel);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GraphGUI";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "GraphGUI";
            this.Shown += new System.EventHandler(this.GraphGUI_Load);
            this.modeGroup.ResumeLayout(false);
            this.modeGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel drawPanel;
        private System.Windows.Forms.Button findPathButton;
        private System.Windows.Forms.RadioButton drawRadioButton;
        private System.Windows.Forms.RadioButton selectRadioButton;
        private System.Windows.Forms.GroupBox modeGroup;
        private System.Windows.Forms.Button resetEdgesButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.TextBox debugOutput;
    }
}