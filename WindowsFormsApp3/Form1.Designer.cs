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
            this.help_button = new System.Windows.Forms.Button();
            this.preset_size_up_down = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.preset_size_up_down)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.clear_button.Location = new System.Drawing.Point(448, 194);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(100, 40);
            this.clear_button.TabIndex = 1;
            this.clear_button.Text = "CLEAR";
            this.clear_button.UseVisualStyleBackColor = false;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // node_mode_rb
            // 
            this.node_mode_rb.AutoSize = true;
            this.node_mode_rb.Location = new System.Drawing.Point(17, 75);
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
            this.edge_mode_rb.Location = new System.Drawing.Point(17, 98);
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
            this.reset_button.Location = new System.Drawing.Point(448, 240);
            this.reset_button.Name = "reset_button";
            this.reset_button.Size = new System.Drawing.Size(100, 40);
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
            this.preset_button.Location = new System.Drawing.Point(448, 351);
            this.preset_button.Name = "preset_button";
            this.preset_button.Size = new System.Drawing.Size(100, 40);
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
            this.find_path_button.Location = new System.Drawing.Point(17, 19);
            this.find_path_button.Name = "find_path_button";
            this.find_path_button.Size = new System.Drawing.Size(100, 40);
            this.find_path_button.TabIndex = 5;
            this.find_path_button.Text = "FIND PATH";
            this.find_path_button.UseVisualStyleBackColor = false;
            this.find_path_button.Click += new System.EventHandler(this.find_path_button_Click);
            // 
            // help_button
            // 
            this.help_button.BackColor = System.Drawing.Color.Coral;
            this.help_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.help_button.Location = new System.Drawing.Point(449, 397);
            this.help_button.Name = "help_button";
            this.help_button.Size = new System.Drawing.Size(100, 40);
            this.help_button.TabIndex = 6;
            this.help_button.Text = "HELP";
            this.help_button.UseVisualStyleBackColor = false;
            this.help_button.Click += new System.EventHandler(this.help_button_Click);
            // 
            // preset_size_up_down
            // 
            this.preset_size_up_down.BackColor = System.Drawing.SystemColors.Control;
            this.preset_size_up_down.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.preset_size_up_down.Location = new System.Drawing.Point(514, 329);
            this.preset_size_up_down.Maximum = new decimal(new int[] {
            21,
            0,
            0,
            0});
            this.preset_size_up_down.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.preset_size_up_down.Name = "preset_size_up_down";
            this.preset_size_up_down.Size = new System.Drawing.Size(34, 16);
            this.preset_size_up_down.TabIndex = 7;
            this.preset_size_up_down.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.preset_size_up_down.ValueChanged += new System.EventHandler(this.preset_size_up_down_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(445, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "SIZE";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.find_path_button);
            this.groupBox1.Controls.Add(this.edge_mode_rb);
            this.groupBox1.Controls.Add(this.node_mode_rb);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(431, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 133);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(565, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.preset_size_up_down);
            this.Controls.Add(this.help_button);
            this.Controls.Add(this.preset_button);
            this.Controls.Add(this.reset_button);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Graph Stuff v0.1";
            ((System.ComponentModel.ISupportInitialize)(this.preset_size_up_down)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button help_button;
        private System.Windows.Forms.NumericUpDown preset_size_up_down;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

