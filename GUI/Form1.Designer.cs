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
            this.modeGroup = new System.Windows.Forms.GroupBox();
            this.drawRadioButton = new System.Windows.Forms.RadioButton();
            this.selectRadioButton = new System.Windows.Forms.RadioButton();
            this.modeGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // modeGroup
            // 
            this.modeGroup.Controls.Add(this.selectRadioButton);
            this.modeGroup.Controls.Add(this.drawRadioButton);
            this.modeGroup.Location = new System.Drawing.Point(503, 17);
            this.modeGroup.Name = "modeGroup";
            this.modeGroup.Size = new System.Drawing.Size(169, 79);
            this.modeGroup.TabIndex = 1;
            this.modeGroup.TabStop = false;
            this.modeGroup.Text = "Modes";
            // 
            // drawRadioButton
            // 
            this.drawRadioButton.AutoSize = true;
            this.drawRadioButton.Location = new System.Drawing.Point(7, 23);
            this.drawRadioButton.Name = "drawRadioButton";
            this.drawRadioButton.Size = new System.Drawing.Size(52, 19);
            this.drawRadioButton.TabIndex = 0;
            this.drawRadioButton.TabStop = true;
            this.drawRadioButton.Text = "Draw";
            this.drawRadioButton.UseVisualStyleBackColor = true;
            // 
            // selectRadioButton
            // 
            this.selectRadioButton.AutoSize = true;
            this.selectRadioButton.Location = new System.Drawing.Point(7, 49);
            this.selectRadioButton.Name = "selectRadioButton";
            this.selectRadioButton.Size = new System.Drawing.Size(56, 19);
            this.selectRadioButton.TabIndex = 1;
            this.selectRadioButton.TabStop = true;
            this.selectRadioButton.Text = "Select";
            this.selectRadioButton.UseVisualStyleBackColor = true;
            // 
            // GraphGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(684, 450);
            this.Controls.Add(this.modeGroup);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GraphGUI";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "GraphGUI";
            this.modeGroup.ResumeLayout(false);
            this.modeGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox modeGroup;
        private System.Windows.Forms.RadioButton selectRadioButton;
        private System.Windows.Forms.RadioButton drawRadioButton;
    }
}

