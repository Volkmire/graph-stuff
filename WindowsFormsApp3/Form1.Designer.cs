namespace WindowsFormsApp3
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.clear_button = new System.Windows.Forms.Button();
            this.node_mode_rb = new System.Windows.Forms.RadioButton();
            this.edge_mode_rb = new System.Windows.Forms.RadioButton();
            this.reset_button = new System.Windows.Forms.Button();
            this.preset_button = new System.Windows.Forms.Button();
            this.find_path_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 426);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            // 
            // clear_button
            // 
            this.clear_button.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.clear_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clear_button.Location = new System.Drawing.Point(447, 12);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(102, 38);
            this.clear_button.TabIndex = 1;
            this.clear_button.Text = "CLEAR";
            this.clear_button.UseVisualStyleBackColor = false;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // node_mode_rb
            // 
            this.node_mode_rb.AutoSize = true;
            this.node_mode_rb.Location = new System.Drawing.Point(447, 150);
            this.node_mode_rb.Name = "node_mode_rb";
            this.node_mode_rb.Size = new System.Drawing.Size(91, 17);
            this.node_mode_rb.TabIndex = 2;
            this.node_mode_rb.TabStop = true;
            this.node_mode_rb.Text = "NODE MODE";
            this.node_mode_rb.UseVisualStyleBackColor = true;
            // 
            // edge_mode_rb
            // 
            this.edge_mode_rb.AutoSize = true;
            this.edge_mode_rb.Location = new System.Drawing.Point(447, 173);
            this.edge_mode_rb.Name = "edge_mode_rb";
            this.edge_mode_rb.Size = new System.Drawing.Size(90, 17);
            this.edge_mode_rb.TabIndex = 3;
            this.edge_mode_rb.TabStop = true;
            this.edge_mode_rb.Text = "EDGE MODE";
            this.edge_mode_rb.UseVisualStyleBackColor = true;
            // 
            // reset_button
            // 
            this.reset_button.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.reset_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reset_button.Location = new System.Drawing.Point(447, 56);
            this.reset_button.Name = "reset_button";
            this.reset_button.Size = new System.Drawing.Size(102, 37);
            this.reset_button.TabIndex = 4;
            this.reset_button.Text = "RESET EDGES";
            this.reset_button.UseVisualStyleBackColor = false;
            this.reset_button.Click += new System.EventHandler(this.reset_button_Click);
            // 
            // preset_button
            // 
            this.preset_button.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.preset_button.Cursor = System.Windows.Forms.Cursors.Default;
            this.preset_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.preset_button.Location = new System.Drawing.Point(448, 398);
            this.preset_button.Name = "preset_button";
            this.preset_button.Size = new System.Drawing.Size(101, 40);
            this.preset_button.TabIndex = 5;
            this.preset_button.Text = "USE PRESET";
            this.preset_button.UseVisualStyleBackColor = false;
            this.preset_button.Click += new System.EventHandler(this.preset_button_Click);
            // 
            // find_path_button
            // 
            this.find_path_button.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.find_path_button.Cursor = System.Windows.Forms.Cursors.Default;
            this.find_path_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.find_path_button.Location = new System.Drawing.Point(448, 225);
            this.find_path_button.Name = "find_path_button";
            this.find_path_button.Size = new System.Drawing.Size(101, 40);
            this.find_path_button.TabIndex = 5;
            this.find_path_button.Text = "FIND PATH";
            this.find_path_button.UseVisualStyleBackColor = false;
            this.find_path_button.Click += new System.EventHandler(this.find_path_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(565, 450);
            this.Controls.Add(this.find_path_button);
            this.Controls.Add(this.preset_button);
            this.Controls.Add(this.reset_button);
            this.Controls.Add(this.edge_mode_rb);
            this.Controls.Add(this.node_mode_rb);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Graph Stuff";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.RadioButton node_mode_rb;
        private System.Windows.Forms.RadioButton edge_mode_rb;
        private System.Windows.Forms.Button reset_button;
        private System.Windows.Forms.Button preset_button;
        private System.Windows.Forms.Button find_path_button;
    }
}

