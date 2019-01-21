namespace GJ3Editor
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnNew = new System.Windows.Forms.Button();
            this.btnA = new System.Windows.Forms.Button();
            this.btnB = new System.Windows.Forms.Button();
            this.RotationTimer = new System.Windows.Forms.Timer(this.components);
            this.lblRotationInterval = new System.Windows.Forms.Label();
            this.btnAutorotate = new System.Windows.Forms.Button();
            this.chbRotationX = new System.Windows.Forms.CheckBox();
            this.chbRotationY = new System.Windows.Forms.CheckBox();
            this.chbRotationZ = new System.Windows.Forms.CheckBox();
            this.numRotationInterval = new System.Windows.Forms.NumericUpDown();
            this.btnReset = new System.Windows.Forms.Button();
            this.chbEditMode = new System.Windows.Forms.CheckBox();
            this.NumEditInterval = new System.Windows.Forms.NumericUpDown();
            this.lblEditInterval = new System.Windows.Forms.Label();
            this.lblInstrictions = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numRotationInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumEditInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnNew.Location = new System.Drawing.Point(0, 0);
            this.btnNew.Margin = new System.Windows.Forms.Padding(0);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 40);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnA
            // 
            this.btnA.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnA.FlatAppearance.BorderSize = 0;
            this.btnA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnA.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnA.Location = new System.Drawing.Point(100, 0);
            this.btnA.Margin = new System.Windows.Forms.Padding(0);
            this.btnA.Name = "btnA";
            this.btnA.Size = new System.Drawing.Size(100, 40);
            this.btnA.TabIndex = 2;
            this.btnA.Text = "A";
            this.btnA.UseVisualStyleBackColor = false;
            this.btnA.Click += new System.EventHandler(this.btnA_Click);
            // 
            // btnB
            // 
            this.btnB.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnB.FlatAppearance.BorderSize = 0;
            this.btnB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnB.Location = new System.Drawing.Point(200, 0);
            this.btnB.Margin = new System.Windows.Forms.Padding(0);
            this.btnB.Name = "btnB";
            this.btnB.Size = new System.Drawing.Size(100, 40);
            this.btnB.TabIndex = 3;
            this.btnB.Text = "B";
            this.btnB.UseVisualStyleBackColor = false;
            this.btnB.Click += new System.EventHandler(this.btnB_Click);
            // 
            // RotationTimer
            // 
            this.RotationTimer.Tick += new System.EventHandler(this.RotationTimer_Tick);
            // 
            // lblRotationInterval
            // 
            this.lblRotationInterval.AutoSize = true;
            this.lblRotationInterval.Location = new System.Drawing.Point(1099, 48);
            this.lblRotationInterval.Name = "lblRotationInterval";
            this.lblRotationInterval.Size = new System.Drawing.Size(77, 13);
            this.lblRotationInterval.TabIndex = 5;
            this.lblRotationInterval.Text = "Rotation Scale";
            // 
            // btnAutorotate
            // 
            this.btnAutorotate.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnAutorotate.FlatAppearance.BorderSize = 0;
            this.btnAutorotate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutorotate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnAutorotate.Location = new System.Drawing.Point(1102, 69);
            this.btnAutorotate.Margin = new System.Windows.Forms.Padding(0);
            this.btnAutorotate.Name = "btnAutorotate";
            this.btnAutorotate.Size = new System.Drawing.Size(73, 76);
            this.btnAutorotate.TabIndex = 6;
            this.btnAutorotate.Text = "Autorotate";
            this.btnAutorotate.UseVisualStyleBackColor = false;
            this.btnAutorotate.Click += new System.EventHandler(this.btnAutorotate_Click);
            // 
            // chbRotationX
            // 
            this.chbRotationX.AutoSize = true;
            this.chbRotationX.Location = new System.Drawing.Point(1043, 82);
            this.chbRotationX.Name = "chbRotationX";
            this.chbRotationX.Size = new System.Drawing.Size(33, 17);
            this.chbRotationX.TabIndex = 7;
            this.chbRotationX.Text = "X";
            this.chbRotationX.UseVisualStyleBackColor = true;
            // 
            // chbRotationY
            // 
            this.chbRotationY.AutoSize = true;
            this.chbRotationY.Location = new System.Drawing.Point(1043, 105);
            this.chbRotationY.Name = "chbRotationY";
            this.chbRotationY.Size = new System.Drawing.Size(33, 17);
            this.chbRotationY.TabIndex = 8;
            this.chbRotationY.Text = "Y";
            this.chbRotationY.UseVisualStyleBackColor = true;
            // 
            // chbRotationZ
            // 
            this.chbRotationZ.AutoSize = true;
            this.chbRotationZ.Location = new System.Drawing.Point(1043, 128);
            this.chbRotationZ.Name = "chbRotationZ";
            this.chbRotationZ.Size = new System.Drawing.Size(33, 17);
            this.chbRotationZ.TabIndex = 9;
            this.chbRotationZ.Text = "Z";
            this.chbRotationZ.UseVisualStyleBackColor = true;
            // 
            // numRotationInterval
            // 
            this.numRotationInterval.DecimalPlaces = 1;
            this.numRotationInterval.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numRotationInterval.Location = new System.Drawing.Point(1043, 46);
            this.numRotationInterval.Name = "numRotationInterval";
            this.numRotationInterval.Size = new System.Drawing.Size(50, 20);
            this.numRotationInterval.TabIndex = 4;
            this.numRotationInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnReset.Location = new System.Drawing.Point(1102, 145);
            this.btnReset.Margin = new System.Windows.Forms.Padding(0);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(74, 40);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // chbEditMode
            // 
            this.chbEditMode.AutoSize = true;
            this.chbEditMode.Location = new System.Drawing.Point(1043, 215);
            this.chbEditMode.Name = "chbEditMode";
            this.chbEditMode.Size = new System.Drawing.Size(74, 17);
            this.chbEditMode.TabIndex = 11;
            this.chbEditMode.Text = "Edit Mode";
            this.chbEditMode.UseVisualStyleBackColor = true;
            // 
            // NumEditInterval
            // 
            this.NumEditInterval.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumEditInterval.Location = new System.Drawing.Point(1043, 238);
            this.NumEditInterval.Name = "NumEditInterval";
            this.NumEditInterval.Size = new System.Drawing.Size(50, 20);
            this.NumEditInterval.TabIndex = 12;
            this.NumEditInterval.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // lblEditInterval
            // 
            this.lblEditInterval.AutoSize = true;
            this.lblEditInterval.Location = new System.Drawing.Point(1099, 242);
            this.lblEditInterval.Name = "lblEditInterval";
            this.lblEditInterval.Size = new System.Drawing.Size(77, 13);
            this.lblEditInterval.TabIndex = 13;
            this.lblEditInterval.Text = "Rotation Scale";
            // 
            // lblInstrictions
            // 
            this.lblInstrictions.AutoSize = true;
            this.lblInstrictions.Location = new System.Drawing.Point(1003, 261);
            this.lblInstrictions.Name = "lblInstrictions";
            this.lblInstrictions.Size = new System.Drawing.Size(207, 143);
            this.lblInstrictions.TabIndex = 14;
            this.lblInstrictions.Text = resources.GetString("lblInstrictions.Text");
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.lblInstrictions);
            this.Controls.Add(this.lblEditInterval);
            this.Controls.Add(this.NumEditInterval);
            this.Controls.Add(this.chbEditMode);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.chbRotationZ);
            this.Controls.Add(this.chbRotationY);
            this.Controls.Add(this.chbRotationX);
            this.Controls.Add(this.btnAutorotate);
            this.Controls.Add(this.lblRotationInterval);
            this.Controls.Add(this.numRotationInterval);
            this.Controls.Add(this.btnB);
            this.Controls.Add(this.btnA);
            this.Controls.Add(this.btnNew);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GJ3 Editor";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numRotationInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumEditInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnA;
        private System.Windows.Forms.Button btnB;
        private System.Windows.Forms.Timer RotationTimer;
        private System.Windows.Forms.Label lblRotationInterval;
        private System.Windows.Forms.Button btnAutorotate;
        private System.Windows.Forms.CheckBox chbRotationX;
        private System.Windows.Forms.CheckBox chbRotationY;
        private System.Windows.Forms.CheckBox chbRotationZ;
        private System.Windows.Forms.NumericUpDown numRotationInterval;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox chbEditMode;
        private System.Windows.Forms.NumericUpDown NumEditInterval;
        private System.Windows.Forms.Label lblEditInterval;
        private System.Windows.Forms.Label lblInstrictions;
    }
}

