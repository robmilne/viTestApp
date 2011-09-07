namespace viTestApp
{
  partial class StartForm
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
      this.cboPorts = new System.Windows.Forms.ComboBox();
      this.btnPort = new System.Windows.Forms.Button();
      this.cbxStartSmallNetwork = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // cboPorts
      // 
      this.cboPorts.FormattingEnabled = true;
      this.cboPorts.Location = new System.Drawing.Point(28, 8);
      this.cboPorts.Name = "cboPorts";
      this.cboPorts.Size = new System.Drawing.Size(120, 21);
      this.cboPorts.TabIndex = 13;
      // 
      // btnPort
      // 
      this.btnPort.Location = new System.Drawing.Point(28, 35);
      this.btnPort.Name = "btnPort";
      this.btnPort.Size = new System.Drawing.Size(120, 25);
      this.btnPort.TabIndex = 14;
      this.btnPort.Text = "Open FTDI Device";
      this.btnPort.UseVisualStyleBackColor = true;
      this.btnPort.Click += new System.EventHandler(this.btnPort_Click);
      // 
      // cbxStartSmallNetwork
      // 
      this.cbxStartSmallNetwork.AutoSize = true;
      this.cbxStartSmallNetwork.Checked = true;
      this.cbxStartSmallNetwork.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbxStartSmallNetwork.Location = new System.Drawing.Point(28, 67);
      this.cbxStartSmallNetwork.Name = "cbxStartSmallNetwork";
      this.cbxStartSmallNetwork.Size = new System.Drawing.Size(123, 17);
      this.cbxStartSmallNetwork.TabIndex = 15;
      this.cbxStartSmallNetwork.Text = "Small Network (id<5)";
      this.cbxStartSmallNetwork.UseVisualStyleBackColor = true;
      // 
      // StartForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(174, 92);
      this.Controls.Add(this.cbxStartSmallNetwork);
      this.Controls.Add(this.cboPorts);
      this.Controls.Add(this.btnPort);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "StartForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Select Gateway";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ComboBox cboPorts;
    private System.Windows.Forms.Button btnPort;
    private System.Windows.Forms.CheckBox cbxStartSmallNetwork;

  }
}