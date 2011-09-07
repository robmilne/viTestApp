namespace viTestApp
{
  partial class RndForm
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
      if(disposing && (components != null))
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
      this.btnRndStart = new System.Windows.Forms.Button();
      this.nudRndNumExec = new System.Windows.Forms.NumericUpDown();
      this.lblRndNumExec = new System.Windows.Forms.Label();
      this.tbxRndPos = new System.Windows.Forms.TextBox();
      this.lblRndPos = new System.Windows.Forms.Label();
      this.tbxRndMoveNum = new System.Windows.Forms.TextBox();
      this.lblRndMoveNum = new System.Windows.Forms.Label();
      this.lblRndMaxTime = new System.Windows.Forms.Label();
      this.nudRndSecDelay = new System.Windows.Forms.NumericUpDown();
      this.btnRndStop = new System.Windows.Forms.Button();
      this.lblRndNote = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.nudRndNumExec)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudRndSecDelay)).BeginInit();
      this.SuspendLayout();
      // 
      // btnRndStart
      // 
      this.btnRndStart.Location = new System.Drawing.Point(12, 173);
      this.btnRndStart.Name = "btnRndStart";
      this.btnRndStart.Size = new System.Drawing.Size(75, 23);
      this.btnRndStart.TabIndex = 0;
      this.btnRndStart.Text = "Start";
      this.btnRndStart.UseVisualStyleBackColor = true;
      this.btnRndStart.Click += new System.EventHandler(this.btnRndStart_Click);
      // 
      // nudRndNumExec
      // 
      this.nudRndNumExec.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
      this.nudRndNumExec.Location = new System.Drawing.Point(12, 51);
      this.nudRndNumExec.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.nudRndNumExec.Name = "nudRndNumExec";
      this.nudRndNumExec.Size = new System.Drawing.Size(60, 20);
      this.nudRndNumExec.TabIndex = 2;
      this.nudRndNumExec.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
      // 
      // lblRndNumExec
      // 
      this.lblRndNumExec.AutoSize = true;
      this.lblRndNumExec.Location = new System.Drawing.Point(79, 57);
      this.lblRndNumExec.Name = "lblRndNumExec";
      this.lblRndNumExec.Size = new System.Drawing.Size(91, 13);
      this.lblRndNumExec.TabIndex = 3;
      this.lblRndNumExec.Text = "Number of Moves";
      // 
      // tbxRndPos
      // 
      this.tbxRndPos.Location = new System.Drawing.Point(12, 147);
      this.tbxRndPos.Name = "tbxRndPos";
      this.tbxRndPos.Size = new System.Drawing.Size(100, 20);
      this.tbxRndPos.TabIndex = 4;
      // 
      // lblRndPos
      // 
      this.lblRndPos.AutoSize = true;
      this.lblRndPos.Location = new System.Drawing.Point(118, 154);
      this.lblRndPos.Name = "lblRndPos";
      this.lblRndPos.Size = new System.Drawing.Size(81, 13);
      this.lblRndPos.TabIndex = 5;
      this.lblRndPos.Text = "Current Position";
      // 
      // tbxRndMoveNum
      // 
      this.tbxRndMoveNum.Location = new System.Drawing.Point(12, 121);
      this.tbxRndMoveNum.Name = "tbxRndMoveNum";
      this.tbxRndMoveNum.Size = new System.Drawing.Size(60, 20);
      this.tbxRndMoveNum.TabIndex = 6;
      this.tbxRndMoveNum.Text = "0";
      // 
      // lblRndMoveNum
      // 
      this.lblRndMoveNum.AutoSize = true;
      this.lblRndMoveNum.Location = new System.Drawing.Point(79, 124);
      this.lblRndMoveNum.Name = "lblRndMoveNum";
      this.lblRndMoveNum.Size = new System.Drawing.Size(44, 13);
      this.lblRndMoveNum.TabIndex = 7;
      this.lblRndMoveNum.Text = "Move #";
      // 
      // lblRndMaxTime
      // 
      this.lblRndMaxTime.AutoSize = true;
      this.lblRndMaxTime.Location = new System.Drawing.Point(79, 83);
      this.lblRndMaxTime.Name = "lblRndMaxTime";
      this.lblRndMaxTime.Size = new System.Drawing.Size(130, 13);
      this.lblRndMaxTime.TabIndex = 9;
      this.lblRndMaxTime.Text = "Max # Seconds per Move";
      // 
      // nudRndSecDelay
      // 
      this.nudRndSecDelay.Location = new System.Drawing.Point(12, 77);
      this.nudRndSecDelay.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.nudRndSecDelay.Name = "nudRndSecDelay";
      this.nudRndSecDelay.Size = new System.Drawing.Size(60, 20);
      this.nudRndSecDelay.TabIndex = 8;
      this.nudRndSecDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
      // 
      // btnRndStop
      // 
      this.btnRndStop.Location = new System.Drawing.Point(93, 173);
      this.btnRndStop.Name = "btnRndStop";
      this.btnRndStop.Size = new System.Drawing.Size(75, 23);
      this.btnRndStop.TabIndex = 10;
      this.btnRndStop.Text = "Stop/Exit";
      this.btnRndStop.UseVisualStyleBackColor = true;
      this.btnRndStop.Click += new System.EventHandler(this.btnRndStop_Click);
      // 
      // lblRndNote
      // 
      this.lblRndNote.AutoSize = true;
      this.lblRndNote.Location = new System.Drawing.Point(12, 13);
      this.lblRndNote.Name = "lblRndNote";
      this.lblRndNote.Size = new System.Drawing.Size(205, 26);
      this.lblRndNote.TabIndex = 11;
      this.lblRndNote.Text = "Note: Do not start this operation if motor\r\nmotion is constrained by mechanical l" +
          "imits ";
      // 
      // RndForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(232, 206);
      this.ControlBox = false;
      this.Controls.Add(this.lblRndNote);
      this.Controls.Add(this.btnRndStop);
      this.Controls.Add(this.lblRndMaxTime);
      this.Controls.Add(this.nudRndSecDelay);
      this.Controls.Add(this.lblRndMoveNum);
      this.Controls.Add(this.tbxRndMoveNum);
      this.Controls.Add(this.lblRndPos);
      this.Controls.Add(this.tbxRndPos);
      this.Controls.Add(this.lblRndNumExec);
      this.Controls.Add(this.nudRndNumExec);
      this.Controls.Add(this.btnRndStart);
      this.Name = "RndForm";
      this.Text = "Random Move";
      ((System.ComponentModel.ISupportInitialize)(this.nudRndNumExec)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudRndSecDelay)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnRndStart;
    private System.Windows.Forms.NumericUpDown nudRndNumExec;
    private System.Windows.Forms.Label lblRndNumExec;
    private System.Windows.Forms.TextBox tbxRndPos;
    private System.Windows.Forms.Label lblRndPos;
    private System.Windows.Forms.TextBox tbxRndMoveNum;
    private System.Windows.Forms.Label lblRndMoveNum;
    private System.Windows.Forms.Label lblRndMaxTime;
    private System.Windows.Forms.NumericUpDown nudRndSecDelay;
    private System.Windows.Forms.Button btnRndStop;
    private System.Windows.Forms.Label lblRndNote;
  }
}