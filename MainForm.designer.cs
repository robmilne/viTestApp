namespace viTestApp
{
  partial class MainForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPageGateWay = new System.Windows.Forms.TabPage();
      this.gbStatus = new System.Windows.Forms.GroupBox();
      this.lbl_turnaround = new System.Windows.Forms.Label();
      this.tbxGatewayTurnaround = new System.Windows.Forms.TextBox();
      this.gbGatewayBitrate = new System.Windows.Forms.GroupBox();
      this.cboCANBitrate = new System.Windows.Forms.ComboBox();
      this.cbxCanBusOff = new System.Windows.Forms.CheckBox();
      this.btnGatewayClearStatus = new System.Windows.Forms.Button();
      this.tbxGatewayStatus = new System.Windows.Forms.TextBox();
      this.btnGatewayGetStatus = new System.Windows.Forms.Button();
      this.gbGatewayVersion = new System.Windows.Forms.GroupBox();
      this.lblGatewayVer = new System.Windows.Forms.Label();
      this.tabPageSetup = new System.Windows.Forms.TabPage();
      this.lblEnumNodes = new System.Windows.Forms.Label();
      this.cboSlaveNode = new System.Windows.Forms.ComboBox();
      this.tabServoSettings = new System.Windows.Forms.TabControl();
      this.tabPageSetupControl = new System.Windows.Forms.TabPage();
      this.gbRand = new System.Windows.Forms.GroupBox();
      this.btnRand = new System.Windows.Forms.Button();
      this.gbZero = new System.Windows.Forms.GroupBox();
      this.btnSetEncZero = new System.Windows.Forms.Button();
      this.gbxSleep = new System.Windows.Forms.GroupBox();
      this.rbIRQWakeup = new System.Windows.Forms.RadioButton();
      this.rbCommWakeUp = new System.Windows.Forms.RadioButton();
      this.btnSleep = new System.Windows.Forms.Button();
      this.gbxGroup = new System.Windows.Forms.GroupBox();
      this.cbxGroup = new System.Windows.Forms.CheckBox();
      this.gbxCfg = new System.Windows.Forms.GroupBox();
      this.cbxEeErr = new System.Windows.Forms.CheckBox();
      this.tbxEeErr = new System.Windows.Forms.TextBox();
      this.btnRebuildFs = new System.Windows.Forms.Button();
      this.btnLoadCfg = new System.Windows.Forms.Button();
      this.btnStoreCfg = new System.Windows.Forms.Button();
      this.gbTestMotionStop = new System.Windows.Forms.GroupBox();
      this.btnTestMotionStop = new System.Windows.Forms.Button();
      this.rbTestMotionStartSoft = new System.Windows.Forms.RadioButton();
      this.rbTestMotionStopHard = new System.Windows.Forms.RadioButton();
      this.gbSetupStatus = new System.Windows.Forms.GroupBox();
      this.btnStatusRead = new System.Windows.Forms.Button();
      this.lblStatPeakAcc = new System.Windows.Forms.Label();
      this.tbxStatPeakAcc = new System.Windows.Forms.TextBox();
      this.lblStatErrCode = new System.Windows.Forms.Label();
      this.tbxStatErrCode = new System.Windows.Forms.TextBox();
      this.lblStatServoState = new System.Windows.Forms.Label();
      this.tbxStatServoState = new System.Windows.Forms.TextBox();
      this.gbStatErrFlag = new System.Windows.Forms.GroupBox();
      this.btnStatusWrite = new System.Windows.Forms.Button();
      this.cbxStatIrqErr = new System.Windows.Forms.CheckBox();
      this.cbxStatATDErr = new System.Windows.Forms.CheckBox();
      this.cbxStatFuzzyErr = new System.Windows.Forms.CheckBox();
      this.cbxStatPosErr = new System.Windows.Forms.CheckBox();
      this.cbxStatCANErr = new System.Windows.Forms.CheckBox();
      this.cbxStatSysErr = new System.Windows.Forms.CheckBox();
      this.cbxStatLimErr = new System.Windows.Forms.CheckBox();
      this.gbStatLim = new System.Windows.Forms.GroupBox();
      this.lblStatATDVal = new System.Windows.Forms.Label();
      this.tbxStatATDVal = new System.Windows.Forms.TextBox();
      this.cbxStatEncIdx = new System.Windows.Forms.CheckBox();
      this.cbxStatLimB = new System.Windows.Forms.CheckBox();
      this.cbxStatLimA = new System.Windows.Forms.CheckBox();
      this.lblStatEncIdxVal = new System.Windows.Forms.Label();
      this.tbxStatEncIdxVal = new System.Windows.Forms.TextBox();
      this.tbxStatLimAVal = new System.Windows.Forms.TextBox();
      this.lblStatLimAVal = new System.Windows.Forms.Label();
      this.lblStatLimBVal = new System.Windows.Forms.Label();
      this.tbxStatLimBVal = new System.Windows.Forms.TextBox();
      this.lblStatPeakVel = new System.Windows.Forms.Label();
      this.tbxStatPeakVel = new System.Windows.Forms.TextBox();
      this.lblStatCurVel = new System.Windows.Forms.Label();
      this.tbxStatCurVel = new System.Windows.Forms.TextBox();
      this.lblStatCurPos = new System.Windows.Forms.Label();
      this.tbxStatCurPos = new System.Windows.Forms.TextBox();
      this.gbTestMotionStart = new System.Windows.Forms.GroupBox();
      this.btnMotionCtlHalfPos = new System.Windows.Forms.Button();
      this.btnMotionCtlDoublePos = new System.Windows.Forms.Button();
      this.btnMotionCtlRevPos = new System.Windows.Forms.Button();
      this.btnTestMotionStart = new System.Windows.Forms.Button();
      this.rbTestMotionStartPwm = new System.Windows.Forms.RadioButton();
      this.rbTestMotionStartPwmLim = new System.Windows.Forms.RadioButton();
      this.rbTestMotionStartTrapezoidal = new System.Windows.Forms.RadioButton();
      this.rbTestMotionStartVel = new System.Windows.Forms.RadioButton();
      this.rbTestMotionStartPos = new System.Windows.Forms.RadioButton();
      this.gbSetLimit = new System.Windows.Forms.GroupBox();
      this.gbxIRQEnable = new System.Windows.Forms.GroupBox();
      this.rbIRQsoft = new System.Windows.Forms.RadioButton();
      this.rbIRQhard = new System.Windows.Forms.RadioButton();
      this.cbxIRQEn = new System.Windows.Forms.CheckBox();
      this.gbxSetATDLim = new System.Windows.Forms.GroupBox();
      this.nudSetAtdLimDwell = new System.Windows.Forms.NumericUpDown();
      this.nudSetAtdLimVal = new System.Windows.Forms.NumericUpDown();
      this.lblSetATDLimDwell = new System.Windows.Forms.Label();
      this.lblSetATDLimVal = new System.Windows.Forms.Label();
      this.btnLimitCtlLoad = new System.Windows.Forms.Button();
      this.btnLimitCtlSave = new System.Windows.Forms.Button();
      this.gbSetEncIdx = new System.Windows.Forms.GroupBox();
      this.cbxSetEncIdxZero = new System.Windows.Forms.CheckBox();
      this.cbxSetEncIdxEn = new System.Windows.Forms.CheckBox();
      this.gbSetEncIdxHalt = new System.Windows.Forms.GroupBox();
      this.rbSetEncIdxHaltSoft = new System.Windows.Forms.RadioButton();
      this.rbSetEncIdxHaltHard = new System.Windows.Forms.RadioButton();
      this.gbSetEncIdxVal = new System.Windows.Forms.GroupBox();
      this.rbSetEncIdxValLo = new System.Windows.Forms.RadioButton();
      this.rbSetEncIdxValHi = new System.Windows.Forms.RadioButton();
      this.gbSetLimB = new System.Windows.Forms.GroupBox();
      this.cbxSetLimBZero = new System.Windows.Forms.CheckBox();
      this.cbxSetLimBEn = new System.Windows.Forms.CheckBox();
      this.gbSetLimBHalt = new System.Windows.Forms.GroupBox();
      this.rbSetLimBHaltSoft = new System.Windows.Forms.RadioButton();
      this.rbSetLimBHaltHard = new System.Windows.Forms.RadioButton();
      this.gbSetLimBVal = new System.Windows.Forms.GroupBox();
      this.rbSetLimBValLo = new System.Windows.Forms.RadioButton();
      this.rbSetLimBValHi = new System.Windows.Forms.RadioButton();
      this.gbSetLimA = new System.Windows.Forms.GroupBox();
      this.cbxSetLimAZero = new System.Windows.Forms.CheckBox();
      this.cbxSetLimAEn = new System.Windows.Forms.CheckBox();
      this.gbSetLimAHalt = new System.Windows.Forms.GroupBox();
      this.rbSetLimAHaltSoft = new System.Windows.Forms.RadioButton();
      this.rbSetLimAHaltHard = new System.Windows.Forms.RadioButton();
      this.gbSetLimAVal = new System.Windows.Forms.GroupBox();
      this.rbSetLimAValLo = new System.Windows.Forms.RadioButton();
      this.rbSetLimAValHi = new System.Windows.Forms.RadioButton();
      this.gbSetMotionControl = new System.Windows.Forms.GroupBox();
      this.cbxMoveCtlGo = new System.Windows.Forms.CheckBox();
      this.btnMotionCtlLoad = new System.Windows.Forms.Button();
      this.btnMotionCtlSave = new System.Windows.Forms.Button();
      this.gbSetPwmDir = new System.Windows.Forms.GroupBox();
      this.lblSetPwmDir = new System.Windows.Forms.Label();
      this.lblSetPwmDuty = new System.Windows.Forms.Label();
      this.nudSetPWM = new System.Windows.Forms.NumericUpDown();
      this.rbSetPwmCCW = new System.Windows.Forms.RadioButton();
      this.rbSetPwmCW = new System.Windows.Forms.RadioButton();
      this.rbSetPwmOff = new System.Windows.Forms.RadioButton();
      this.lblSetAcc = new System.Windows.Forms.Label();
      this.lblSetVel = new System.Windows.Forms.Label();
      this.lblSetPos = new System.Windows.Forms.Label();
      this.nudSetVel = new System.Windows.Forms.NumericUpDown();
      this.nudSetPos = new System.Windows.Forms.NumericUpDown();
      this.nudSetAcc = new System.Windows.Forms.NumericUpDown();
      this.gbSetServoControl = new System.Windows.Forms.GroupBox();
      this.lblEncDiv = new System.Windows.Forms.Label();
      this.cboSetEncDiv = new System.Windows.Forms.ComboBox();
      this.btnServoCtlLoad = new System.Windows.Forms.Button();
      this.gbSetMotorDone = new System.Windows.Forms.GroupBox();
      this.rbSetPowerOff = new System.Windows.Forms.RadioButton();
      this.rbSetPowerOn = new System.Windows.Forms.RadioButton();
      this.btnServoCtlSave = new System.Windows.Forms.Button();
      this.gbSetGPIO = new System.Windows.Forms.GroupBox();
      this.cbxGpioSuspendToggle = new System.Windows.Forms.CheckBox();
      this.cbxGpioEnOut = new System.Windows.Forms.CheckBox();
      this.rbSetGPIOLo = new System.Windows.Forms.RadioButton();
      this.rbSetGPIOHi = new System.Windows.Forms.RadioButton();
      this.gbSetKick = new System.Windows.Forms.GroupBox();
      this.rbSetKickOff = new System.Windows.Forms.RadioButton();
      this.rbSetKickOn = new System.Windows.Forms.RadioButton();
      this.lblPWMRate = new System.Windows.Forms.Label();
      this.lblHBridge = new System.Windows.Forms.Label();
      this.lblServoRate = new System.Windows.Forms.Label();
      this.cboSetPWMRate = new System.Windows.Forms.ComboBox();
      this.cboSetHBridge = new System.Windows.Forms.ComboBox();
      this.cboSetServoRate = new System.Windows.Forms.ComboBox();
      this.tabPageSetupFuzzy = new System.Windows.Forms.TabPage();
      this.gbSetFuzzyRules = new System.Windows.Forms.GroupBox();
      this.pnlFuzzyRules = new System.Windows.Forms.Panel();
      this.lblRulesOutHeader = new System.Windows.Forms.Label();
      this.lblRulesSpdHeader = new System.Windows.Forms.Label();
      this.lblRulesPosHeader = new System.Windows.Forms.Label();
      this.lblFuzzyRule2 = new System.Windows.Forms.Label();
      this.lblFuzzyRule1 = new System.Windows.Forms.Label();
      this.lblFuzzyRule0 = new System.Windows.Forms.Label();
      this.cbxFuzzyRule2 = new System.Windows.Forms.ComboBox();
      this.cbxFuzzyRule1 = new System.Windows.Forms.ComboBox();
      this.cbxFuzzyRule0 = new System.Windows.Forms.ComboBox();
      this.btnGetRules = new System.Windows.Forms.Button();
      this.btnSetRules = new System.Windows.Forms.Button();
      this.lblUnfocus = new System.Windows.Forms.Label();
      this.gbSetFuzzyMF = new System.Windows.Forms.GroupBox();
      this.cbxMemFuncCtlPts = new System.Windows.Forms.CheckBox();
      this.lblMemPos0 = new System.Windows.Forms.Label();
      this.tbxPosMem_0_0 = new System.Windows.Forms.TextBox();
      this.lblPosErrMF = new System.Windows.Forms.Label();
      this.btnGetMF = new System.Windows.Forms.Button();
      this.lblSpdMF = new System.Windows.Forms.Label();
      this.btnSetMF = new System.Windows.Forms.Button();
      this.lblPosOutSing = new System.Windows.Forms.Label();
      this.gbPosCtlPts = new System.Windows.Forms.GroupBox();
      this.lblPosOutCtlPtB = new System.Windows.Forms.Label();
      this.tbxPosOutCtlPtB = new System.Windows.Forms.TextBox();
      this.lblPosOutCtlPtA = new System.Windows.Forms.Label();
      this.tbxPosOutCtlPtA = new System.Windows.Forms.TextBox();
      this.lblSpdCtlPtB = new System.Windows.Forms.Label();
      this.tbxSpdCtlPtB = new System.Windows.Forms.TextBox();
      this.lblSpdCtlPtA = new System.Windows.Forms.Label();
      this.tbxSpdCtlPtA = new System.Windows.Forms.TextBox();
      this.lblPosErrCtlPtB = new System.Windows.Forms.Label();
      this.tbxPosErrCtlPtB = new System.Windows.Forms.TextBox();
      this.lblPosErrCtlPtA = new System.Windows.Forms.Label();
      this.tbxPosErrCtlPtA = new System.Windows.Forms.TextBox();
      this.tabPageServoStats = new System.Windows.Forms.TabPage();
      this.gbStatCtlPts = new System.Windows.Forms.GroupBox();
      this.label8 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.lblStatPosCtlPt = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.tbxStatOutCtlPtB = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.tbxStatOutCtlPtA = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.tbxStatSpdCtlPtB = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.tbxStatSpdCtlPtA = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.tbxStatPosCtlPtB = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.tbxStatPosCtlPtA = new System.Windows.Forms.TextBox();
      this.gbStatTypes = new System.Windows.Forms.GroupBox();
      this.cbxStatInfoDuty = new System.Windows.Forms.CheckBox();
      this.cbxStatInfoChange = new System.Windows.Forms.CheckBox();
      this.cbxStatInfoErr = new System.Windows.Forms.CheckBox();
      this.cbxShowStatsPrev = new System.Windows.Forms.CheckBox();
      this.btnStoreStats = new System.Windows.Forms.Button();
      this.pnlStats = new System.Windows.Forms.Panel();
      this.picbxStats = new System.Windows.Forms.PictureBox();
      this.btnGetStats = new System.Windows.Forms.Button();
      this.tbxStats = new System.Windows.Forms.TextBox();
      this.tabPageLog = new System.Windows.Forms.TabPage();
      this.rtbMessageLog = new System.Windows.Forms.RichTextBox();
      this.btnMessageLogClear = new System.Windows.Forms.Button();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.openMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tabControl1.SuspendLayout();
      this.tabPageGateWay.SuspendLayout();
      this.gbStatus.SuspendLayout();
      this.gbGatewayBitrate.SuspendLayout();
      this.gbGatewayVersion.SuspendLayout();
      this.tabPageSetup.SuspendLayout();
      this.tabServoSettings.SuspendLayout();
      this.tabPageSetupControl.SuspendLayout();
      this.gbRand.SuspendLayout();
      this.gbZero.SuspendLayout();
      this.gbxSleep.SuspendLayout();
      this.gbxGroup.SuspendLayout();
      this.gbxCfg.SuspendLayout();
      this.gbTestMotionStop.SuspendLayout();
      this.gbSetupStatus.SuspendLayout();
      this.gbStatErrFlag.SuspendLayout();
      this.gbStatLim.SuspendLayout();
      this.gbTestMotionStart.SuspendLayout();
      this.gbSetLimit.SuspendLayout();
      this.gbxIRQEnable.SuspendLayout();
      this.gbxSetATDLim.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudSetAtdLimDwell)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudSetAtdLimVal)).BeginInit();
      this.gbSetEncIdx.SuspendLayout();
      this.gbSetEncIdxHalt.SuspendLayout();
      this.gbSetEncIdxVal.SuspendLayout();
      this.gbSetLimB.SuspendLayout();
      this.gbSetLimBHalt.SuspendLayout();
      this.gbSetLimBVal.SuspendLayout();
      this.gbSetLimA.SuspendLayout();
      this.gbSetLimAHalt.SuspendLayout();
      this.gbSetLimAVal.SuspendLayout();
      this.gbSetMotionControl.SuspendLayout();
      this.gbSetPwmDir.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudSetPWM)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudSetVel)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudSetPos)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudSetAcc)).BeginInit();
      this.gbSetServoControl.SuspendLayout();
      this.gbSetMotorDone.SuspendLayout();
      this.gbSetGPIO.SuspendLayout();
      this.gbSetKick.SuspendLayout();
      this.tabPageSetupFuzzy.SuspendLayout();
      this.gbSetFuzzyRules.SuspendLayout();
      this.pnlFuzzyRules.SuspendLayout();
      this.gbSetFuzzyMF.SuspendLayout();
      this.gbPosCtlPts.SuspendLayout();
      this.tabPageServoStats.SuspendLayout();
      this.gbStatCtlPts.SuspendLayout();
      this.gbStatTypes.SuspendLayout();
      this.pnlStats.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picbxStats)).BeginInit();
      this.tabPageLog.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPageGateWay);
      this.tabControl1.Controls.Add(this.tabPageSetup);
      this.tabControl1.Controls.Add(this.tabPageLog);
      this.tabControl1.Location = new System.Drawing.Point(6, 27);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(720, 576);
      this.tabControl1.TabIndex = 0;
      // 
      // tabPageGateWay
      // 
      this.tabPageGateWay.Controls.Add(this.gbStatus);
      this.tabPageGateWay.Controls.Add(this.gbGatewayVersion);
      this.tabPageGateWay.Location = new System.Drawing.Point(4, 22);
      this.tabPageGateWay.Name = "tabPageGateWay";
      this.tabPageGateWay.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageGateWay.Size = new System.Drawing.Size(712, 550);
      this.tabPageGateWay.TabIndex = 3;
      this.tabPageGateWay.Text = "Gateway";
      this.tabPageGateWay.UseVisualStyleBackColor = true;
      // 
      // gbStatus
      // 
      this.gbStatus.Controls.Add(this.lbl_turnaround);
      this.gbStatus.Controls.Add(this.tbxGatewayTurnaround);
      this.gbStatus.Controls.Add(this.gbGatewayBitrate);
      this.gbStatus.Controls.Add(this.cbxCanBusOff);
      this.gbStatus.Controls.Add(this.btnGatewayClearStatus);
      this.gbStatus.Controls.Add(this.tbxGatewayStatus);
      this.gbStatus.Controls.Add(this.btnGatewayGetStatus);
      this.gbStatus.Location = new System.Drawing.Point(6, 50);
      this.gbStatus.Name = "gbStatus";
      this.gbStatus.Size = new System.Drawing.Size(203, 225);
      this.gbStatus.TabIndex = 13;
      this.gbStatus.TabStop = false;
      this.gbStatus.Text = "Status";
      // 
      // lbl_turnaround
      // 
      this.lbl_turnaround.AutoSize = true;
      this.lbl_turnaround.Location = new System.Drawing.Point(9, 189);
      this.lbl_turnaround.Name = "lbl_turnaround";
      this.lbl_turnaround.Size = new System.Drawing.Size(177, 26);
      this.lbl_turnaround.TabIndex = 18;
      this.lbl_turnaround.Text = "millisec turnaround for last command\r\n(.125 millisec precision)\r\n";
      // 
      // tbxGatewayTurnaround
      // 
      this.tbxGatewayTurnaround.Location = new System.Drawing.Point(9, 162);
      this.tbxGatewayTurnaround.Name = "tbxGatewayTurnaround";
      this.tbxGatewayTurnaround.Size = new System.Drawing.Size(100, 20);
      this.tbxGatewayTurnaround.TabIndex = 17;
      // 
      // gbGatewayBitrate
      // 
      this.gbGatewayBitrate.Controls.Add(this.cboCANBitrate);
      this.gbGatewayBitrate.Location = new System.Drawing.Point(9, 100);
      this.gbGatewayBitrate.Name = "gbGatewayBitrate";
      this.gbGatewayBitrate.Size = new System.Drawing.Size(185, 56);
      this.gbGatewayBitrate.TabIndex = 16;
      this.gbGatewayBitrate.TabStop = false;
      this.gbGatewayBitrate.Text = "CAN Network Bitrate";
      // 
      // cboCANBitrate
      // 
      this.cboCANBitrate.FormattingEnabled = true;
      this.cboCANBitrate.Location = new System.Drawing.Point(8, 19);
      this.cboCANBitrate.Name = "cboCANBitrate";
      this.cboCANBitrate.Size = new System.Drawing.Size(100, 21);
      this.cboCANBitrate.TabIndex = 10;
      this.cboCANBitrate.SelectedIndexChanged += new System.EventHandler(this.cboCANBitrate_SelectedIndexChanged);
      // 
      // cbxCanBusOff
      // 
      this.cbxCanBusOff.AutoSize = true;
      this.cbxCanBusOff.Location = new System.Drawing.Point(9, 46);
      this.cbxCanBusOff.Name = "cbxCanBusOff";
      this.cbxCanBusOff.Size = new System.Drawing.Size(92, 17);
      this.cbxCanBusOff.TabIndex = 15;
      this.cbxCanBusOff.Text = "CAN bus error";
      this.cbxCanBusOff.UseVisualStyleBackColor = true;
      // 
      // btnGatewayClearStatus
      // 
      this.btnGatewayClearStatus.Enabled = false;
      this.btnGatewayClearStatus.Location = new System.Drawing.Point(104, 71);
      this.btnGatewayClearStatus.Name = "btnGatewayClearStatus";
      this.btnGatewayClearStatus.Size = new System.Drawing.Size(90, 23);
      this.btnGatewayClearStatus.TabIndex = 14;
      this.btnGatewayClearStatus.Text = "Clear Error";
      this.btnGatewayClearStatus.UseVisualStyleBackColor = true;
      this.btnGatewayClearStatus.Click += new System.EventHandler(this.btnGatewayClearStatus_Click);
      // 
      // tbxGatewayStatus
      // 
      this.tbxGatewayStatus.Location = new System.Drawing.Point(9, 19);
      this.tbxGatewayStatus.Name = "tbxGatewayStatus";
      this.tbxGatewayStatus.Size = new System.Drawing.Size(100, 20);
      this.tbxGatewayStatus.TabIndex = 13;
      // 
      // btnGatewayGetStatus
      // 
      this.btnGatewayGetStatus.Location = new System.Drawing.Point(9, 71);
      this.btnGatewayGetStatus.Name = "btnGatewayGetStatus";
      this.btnGatewayGetStatus.Size = new System.Drawing.Size(90, 23);
      this.btnGatewayGetStatus.TabIndex = 12;
      this.btnGatewayGetStatus.Text = "Get Status";
      this.btnGatewayGetStatus.UseVisualStyleBackColor = true;
      this.btnGatewayGetStatus.Click += new System.EventHandler(this.btnGatewayGetStatus_Click);
      // 
      // gbGatewayVersion
      // 
      this.gbGatewayVersion.Controls.Add(this.lblGatewayVer);
      this.gbGatewayVersion.Location = new System.Drawing.Point(6, 6);
      this.gbGatewayVersion.Name = "gbGatewayVersion";
      this.gbGatewayVersion.Size = new System.Drawing.Size(203, 38);
      this.gbGatewayVersion.TabIndex = 12;
      this.gbGatewayVersion.TabStop = false;
      this.gbGatewayVersion.Text = "Version";
      // 
      // lblGatewayVer
      // 
      this.lblGatewayVer.AutoSize = true;
      this.lblGatewayVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblGatewayVer.Location = new System.Drawing.Point(6, 16);
      this.lblGatewayVer.Name = "lblGatewayVer";
      this.lblGatewayVer.Size = new System.Drawing.Size(60, 13);
      this.lblGatewayVer.TabIndex = 9;
      this.lblGatewayVer.Text = "Unknown";
      // 
      // tabPageSetup
      // 
      this.tabPageSetup.Controls.Add(this.lblEnumNodes);
      this.tabPageSetup.Controls.Add(this.cboSlaveNode);
      this.tabPageSetup.Controls.Add(this.tabServoSettings);
      this.tabPageSetup.Location = new System.Drawing.Point(4, 22);
      this.tabPageSetup.Name = "tabPageSetup";
      this.tabPageSetup.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageSetup.Size = new System.Drawing.Size(712, 550);
      this.tabPageSetup.TabIndex = 2;
      this.tabPageSetup.Text = "Servo";
      this.tabPageSetup.UseVisualStyleBackColor = true;
      // 
      // lblEnumNodes
      // 
      this.lblEnumNodes.AutoSize = true;
      this.lblEnumNodes.Location = new System.Drawing.Point(559, 9);
      this.lblEnumNodes.Name = "lblEnumNodes";
      this.lblEnumNodes.Size = new System.Drawing.Size(53, 13);
      this.lblEnumNodes.TabIndex = 24;
      this.lblEnumNodes.Text = "Slave List";
      // 
      // cboSlaveNode
      // 
      this.cboSlaveNode.FormattingEnabled = true;
      this.cboSlaveNode.Location = new System.Drawing.Point(621, 6);
      this.cboSlaveNode.Name = "cboSlaveNode";
      this.cboSlaveNode.Size = new System.Drawing.Size(80, 21);
      this.cboSlaveNode.TabIndex = 23;
      this.cboSlaveNode.Visible = false;
      this.cboSlaveNode.SelectedIndexChanged += new System.EventHandler(this.cboSlaveNode_SelectedIndexChanged);
      // 
      // tabServoSettings
      // 
      this.tabServoSettings.Controls.Add(this.tabPageSetupControl);
      this.tabServoSettings.Controls.Add(this.tabPageSetupFuzzy);
      this.tabServoSettings.Controls.Add(this.tabPageServoStats);
      this.tabServoSettings.Location = new System.Drawing.Point(6, 25);
      this.tabServoSettings.Name = "tabServoSettings";
      this.tabServoSettings.SelectedIndex = 0;
      this.tabServoSettings.Size = new System.Drawing.Size(700, 519);
      this.tabServoSettings.TabIndex = 15;
      this.tabServoSettings.Visible = false;
      // 
      // tabPageSetupControl
      // 
      this.tabPageSetupControl.Controls.Add(this.gbRand);
      this.tabPageSetupControl.Controls.Add(this.gbZero);
      this.tabPageSetupControl.Controls.Add(this.gbxSleep);
      this.tabPageSetupControl.Controls.Add(this.gbxGroup);
      this.tabPageSetupControl.Controls.Add(this.gbxCfg);
      this.tabPageSetupControl.Controls.Add(this.gbTestMotionStop);
      this.tabPageSetupControl.Controls.Add(this.gbSetupStatus);
      this.tabPageSetupControl.Controls.Add(this.gbTestMotionStart);
      this.tabPageSetupControl.Controls.Add(this.gbSetLimit);
      this.tabPageSetupControl.Controls.Add(this.gbSetMotionControl);
      this.tabPageSetupControl.Controls.Add(this.gbSetServoControl);
      this.tabPageSetupControl.Location = new System.Drawing.Point(4, 22);
      this.tabPageSetupControl.Name = "tabPageSetupControl";
      this.tabPageSetupControl.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageSetupControl.Size = new System.Drawing.Size(692, 493);
      this.tabPageSetupControl.TabIndex = 0;
      this.tabPageSetupControl.Text = "Servo Control";
      this.tabPageSetupControl.UseVisualStyleBackColor = true;
      // 
      // gbRand
      // 
      this.gbRand.Controls.Add(this.btnRand);
      this.gbRand.Location = new System.Drawing.Point(577, 6);
      this.gbRand.Name = "gbRand";
      this.gbRand.Size = new System.Drawing.Size(110, 52);
      this.gbRand.TabIndex = 23;
      this.gbRand.TabStop = false;
      this.gbRand.Text = "Random Test";
      // 
      // btnRand
      // 
      this.btnRand.Location = new System.Drawing.Point(7, 20);
      this.btnRand.Name = "btnRand";
      this.btnRand.Size = new System.Drawing.Size(96, 22);
      this.btnRand.TabIndex = 22;
      this.btnRand.Text = "Random Motion";
      this.btnRand.UseVisualStyleBackColor = true;
      this.btnRand.Click += new System.EventHandler(this.btnRand_Click);
      // 
      // gbZero
      // 
      this.gbZero.Controls.Add(this.btnSetEncZero);
      this.gbZero.Location = new System.Drawing.Point(461, 6);
      this.gbZero.Name = "gbZero";
      this.gbZero.Size = new System.Drawing.Size(110, 52);
      this.gbZero.TabIndex = 22;
      this.gbZero.TabStop = false;
      this.gbZero.Text = "Zero";
      // 
      // btnSetEncZero
      // 
      this.btnSetEncZero.Location = new System.Drawing.Point(7, 20);
      this.btnSetEncZero.Name = "btnSetEncZero";
      this.btnSetEncZero.Size = new System.Drawing.Size(96, 22);
      this.btnSetEncZero.TabIndex = 4;
      this.btnSetEncZero.Text = "Zero Encoder";
      this.btnSetEncZero.UseVisualStyleBackColor = true;
      this.btnSetEncZero.Click += new System.EventHandler(this.btnSetEncZero_Click);
      // 
      // gbxSleep
      // 
      this.gbxSleep.Controls.Add(this.rbIRQWakeup);
      this.gbxSleep.Controls.Add(this.rbCommWakeUp);
      this.gbxSleep.Controls.Add(this.btnSleep);
      this.gbxSleep.Location = new System.Drawing.Point(460, 435);
      this.gbxSleep.Name = "gbxSleep";
      this.gbxSleep.Size = new System.Drawing.Size(226, 52);
      this.gbxSleep.TabIndex = 21;
      this.gbxSleep.TabStop = false;
      this.gbxSleep.Text = "Network Suspend";
      // 
      // rbIRQWakeup
      // 
      this.rbIRQWakeup.AutoSize = true;
      this.rbIRQWakeup.Checked = true;
      this.rbIRQWakeup.Location = new System.Drawing.Point(117, 9);
      this.rbIRQWakeup.Name = "rbIRQWakeup";
      this.rbIRQWakeup.Size = new System.Drawing.Size(88, 17);
      this.rbIRQWakeup.TabIndex = 5;
      this.rbIRQWakeup.TabStop = true;
      this.rbIRQWakeup.Text = "IRQ Wakeup";
      this.rbIRQWakeup.UseVisualStyleBackColor = true;
      // 
      // rbCommWakeUp
      // 
      this.rbCommWakeUp.AutoSize = true;
      this.rbCommWakeUp.Location = new System.Drawing.Point(117, 25);
      this.rbCommWakeUp.Name = "rbCommWakeUp";
      this.rbCommWakeUp.Size = new System.Drawing.Size(103, 17);
      this.rbCommWakeUp.TabIndex = 4;
      this.rbCommWakeUp.Text = "Comms Wakeup";
      this.rbCommWakeUp.UseVisualStyleBackColor = true;
      // 
      // btnSleep
      // 
      this.btnSleep.Location = new System.Drawing.Point(6, 19);
      this.btnSleep.Name = "btnSleep";
      this.btnSleep.Size = new System.Drawing.Size(100, 23);
      this.btnSleep.TabIndex = 0;
      this.btnSleep.Text = "Suspend";
      this.btnSleep.UseVisualStyleBackColor = true;
      this.btnSleep.Click += new System.EventHandler(this.btnSleep_Click);
      // 
      // gbxGroup
      // 
      this.gbxGroup.Controls.Add(this.cbxGroup);
      this.gbxGroup.Location = new System.Drawing.Point(394, 6);
      this.gbxGroup.Name = "gbxGroup";
      this.gbxGroup.Size = new System.Drawing.Size(60, 52);
      this.gbxGroup.TabIndex = 20;
      this.gbxGroup.TabStop = false;
      this.gbxGroup.Text = "Group";
      // 
      // cbxGroup
      // 
      this.cbxGroup.AutoSize = true;
      this.cbxGroup.Location = new System.Drawing.Point(24, 23);
      this.cbxGroup.Name = "cbxGroup";
      this.cbxGroup.Size = new System.Drawing.Size(15, 14);
      this.cbxGroup.TabIndex = 18;
      this.cbxGroup.UseVisualStyleBackColor = true;
      // 
      // gbxCfg
      // 
      this.gbxCfg.Controls.Add(this.cbxEeErr);
      this.gbxCfg.Controls.Add(this.tbxEeErr);
      this.gbxCfg.Controls.Add(this.btnRebuildFs);
      this.gbxCfg.Controls.Add(this.btnLoadCfg);
      this.gbxCfg.Controls.Add(this.btnStoreCfg);
      this.gbxCfg.Location = new System.Drawing.Point(127, 357);
      this.gbxCfg.Name = "gbxCfg";
      this.gbxCfg.Size = new System.Drawing.Size(118, 130);
      this.gbxCfg.TabIndex = 19;
      this.gbxCfg.TabStop = false;
      this.gbxCfg.Text = "Servo EEPROM Configuration";
      // 
      // cbxEeErr
      // 
      this.cbxEeErr.AutoSize = true;
      this.cbxEeErr.Location = new System.Drawing.Point(9, 109);
      this.cbxEeErr.Name = "cbxEeErr";
      this.cbxEeErr.Size = new System.Drawing.Size(39, 17);
      this.cbxEeErr.TabIndex = 27;
      this.cbxEeErr.Text = "Err";
      this.cbxEeErr.UseVisualStyleBackColor = true;
      this.cbxEeErr.Visible = false;
      this.cbxEeErr.CheckedChanged += new System.EventHandler(this.cbxEeErr_CheckedChanged);
      // 
      // tbxEeErr
      // 
      this.tbxEeErr.BackColor = System.Drawing.SystemColors.Info;
      this.tbxEeErr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxEeErr.Location = new System.Drawing.Point(50, 106);
      this.tbxEeErr.Name = "tbxEeErr";
      this.tbxEeErr.ReadOnly = true;
      this.tbxEeErr.Size = new System.Drawing.Size(62, 20);
      this.tbxEeErr.TabIndex = 26;
      this.tbxEeErr.Visible = false;
      // 
      // btnRebuildFs
      // 
      this.btnRebuildFs.Location = new System.Drawing.Point(6, 82);
      this.btnRebuildFs.Name = "btnRebuildFs";
      this.btnRebuildFs.Size = new System.Drawing.Size(106, 21);
      this.btnRebuildFs.TabIndex = 20;
      this.btnRebuildFs.Text = "Delete All";
      this.btnRebuildFs.UseVisualStyleBackColor = true;
      this.btnRebuildFs.Click += new System.EventHandler(this.btnRebuildFs_Click);
      // 
      // btnLoadCfg
      // 
      this.btnLoadCfg.Location = new System.Drawing.Point(6, 58);
      this.btnLoadCfg.Name = "btnLoadCfg";
      this.btnLoadCfg.Size = new System.Drawing.Size(106, 21);
      this.btnLoadCfg.TabIndex = 19;
      this.btnLoadCfg.Text = "Read All";
      this.btnLoadCfg.UseVisualStyleBackColor = true;
      this.btnLoadCfg.Click += new System.EventHandler(this.btnLoadCfg_Click);
      // 
      // btnStoreCfg
      // 
      this.btnStoreCfg.Location = new System.Drawing.Point(6, 34);
      this.btnStoreCfg.Name = "btnStoreCfg";
      this.btnStoreCfg.Size = new System.Drawing.Size(106, 21);
      this.btnStoreCfg.TabIndex = 18;
      this.btnStoreCfg.Text = "Write All";
      this.btnStoreCfg.UseVisualStyleBackColor = true;
      this.btnStoreCfg.Click += new System.EventHandler(this.btnStoreCfg_Click);
      // 
      // gbTestMotionStop
      // 
      this.gbTestMotionStop.Controls.Add(this.btnTestMotionStop);
      this.gbTestMotionStop.Controls.Add(this.rbTestMotionStartSoft);
      this.gbTestMotionStop.Controls.Add(this.rbTestMotionStopHard);
      this.gbTestMotionStop.Location = new System.Drawing.Point(251, 6);
      this.gbTestMotionStop.Name = "gbTestMotionStop";
      this.gbTestMotionStop.Size = new System.Drawing.Size(137, 52);
      this.gbTestMotionStop.TabIndex = 2;
      this.gbTestMotionStop.TabStop = false;
      this.gbTestMotionStop.Text = "Stop Motion";
      // 
      // btnTestMotionStop
      // 
      this.btnTestMotionStop.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnTestMotionStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnTestMotionStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
      this.btnTestMotionStop.Location = new System.Drawing.Point(6, 19);
      this.btnTestMotionStop.Name = "btnTestMotionStop";
      this.btnTestMotionStop.Size = new System.Drawing.Size(76, 26);
      this.btnTestMotionStop.TabIndex = 19;
      this.btnTestMotionStop.Text = "Stop (Esc)";
      this.btnTestMotionStop.UseVisualStyleBackColor = true;
      this.btnTestMotionStop.Click += new System.EventHandler(this.btnTestMotionStop_Click);
      // 
      // rbTestMotionStartSoft
      // 
      this.rbTestMotionStartSoft.AutoSize = true;
      this.rbTestMotionStartSoft.Checked = true;
      this.rbTestMotionStartSoft.Location = new System.Drawing.Point(89, 28);
      this.rbTestMotionStartSoft.Name = "rbTestMotionStartSoft";
      this.rbTestMotionStartSoft.Size = new System.Drawing.Size(44, 17);
      this.rbTestMotionStartSoft.TabIndex = 3;
      this.rbTestMotionStartSoft.TabStop = true;
      this.rbTestMotionStartSoft.Text = "Soft";
      this.rbTestMotionStartSoft.UseVisualStyleBackColor = true;
      // 
      // rbTestMotionStopHard
      // 
      this.rbTestMotionStopHard.AutoSize = true;
      this.rbTestMotionStopHard.Location = new System.Drawing.Point(89, 12);
      this.rbTestMotionStopHard.Name = "rbTestMotionStopHard";
      this.rbTestMotionStopHard.Size = new System.Drawing.Size(48, 17);
      this.rbTestMotionStopHard.TabIndex = 2;
      this.rbTestMotionStopHard.Text = "Hard";
      this.rbTestMotionStopHard.UseVisualStyleBackColor = true;
      // 
      // gbSetupStatus
      // 
      this.gbSetupStatus.Controls.Add(this.btnStatusRead);
      this.gbSetupStatus.Controls.Add(this.lblStatPeakAcc);
      this.gbSetupStatus.Controls.Add(this.tbxStatPeakAcc);
      this.gbSetupStatus.Controls.Add(this.lblStatErrCode);
      this.gbSetupStatus.Controls.Add(this.tbxStatErrCode);
      this.gbSetupStatus.Controls.Add(this.lblStatServoState);
      this.gbSetupStatus.Controls.Add(this.tbxStatServoState);
      this.gbSetupStatus.Controls.Add(this.gbStatErrFlag);
      this.gbSetupStatus.Controls.Add(this.gbStatLim);
      this.gbSetupStatus.Controls.Add(this.lblStatPeakVel);
      this.gbSetupStatus.Controls.Add(this.tbxStatPeakVel);
      this.gbSetupStatus.Controls.Add(this.lblStatCurVel);
      this.gbSetupStatus.Controls.Add(this.tbxStatCurVel);
      this.gbSetupStatus.Controls.Add(this.lblStatCurPos);
      this.gbSetupStatus.Controls.Add(this.tbxStatCurPos);
      this.gbSetupStatus.Location = new System.Drawing.Point(461, 64);
      this.gbSetupStatus.Name = "gbSetupStatus";
      this.gbSetupStatus.Size = new System.Drawing.Size(227, 365);
      this.gbSetupStatus.TabIndex = 16;
      this.gbSetupStatus.TabStop = false;
      this.gbSetupStatus.Text = "Status";
      // 
      // btnStatusRead
      // 
      this.btnStatusRead.Location = new System.Drawing.Point(176, 19);
      this.btnStatusRead.Name = "btnStatusRead";
      this.btnStatusRead.Size = new System.Drawing.Size(45, 21);
      this.btnStatusRead.TabIndex = 34;
      this.btnStatusRead.Text = "Read";
      this.btnStatusRead.UseVisualStyleBackColor = true;
      this.btnStatusRead.Click += new System.EventHandler(this.btnStatusRead_Click);
      // 
      // lblStatPeakAcc
      // 
      this.lblStatPeakAcc.AutoSize = true;
      this.lblStatPeakAcc.Location = new System.Drawing.Point(89, 83);
      this.lblStatPeakAcc.Name = "lblStatPeakAcc";
      this.lblStatPeakAcc.Size = new System.Drawing.Size(112, 13);
      this.lblStatPeakAcc.TabIndex = 33;
      this.lblStatPeakAcc.Text = "Peak Change Change";
      // 
      // tbxStatPeakAcc
      // 
      this.tbxStatPeakAcc.BackColor = System.Drawing.SystemColors.Info;
      this.tbxStatPeakAcc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxStatPeakAcc.Location = new System.Drawing.Point(6, 80);
      this.tbxStatPeakAcc.Name = "tbxStatPeakAcc";
      this.tbxStatPeakAcc.ReadOnly = true;
      this.tbxStatPeakAcc.Size = new System.Drawing.Size(80, 20);
      this.tbxStatPeakAcc.TabIndex = 32;
      // 
      // lblStatErrCode
      // 
      this.lblStatErrCode.AutoSize = true;
      this.lblStatErrCode.Location = new System.Drawing.Point(89, 126);
      this.lblStatErrCode.Name = "lblStatErrCode";
      this.lblStatErrCode.Size = new System.Drawing.Size(94, 13);
      this.lblStatErrCode.TabIndex = 28;
      this.lblStatErrCode.Text = "System Error Code";
      // 
      // tbxStatErrCode
      // 
      this.tbxStatErrCode.BackColor = System.Drawing.SystemColors.Info;
      this.tbxStatErrCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxStatErrCode.Location = new System.Drawing.Point(6, 123);
      this.tbxStatErrCode.Name = "tbxStatErrCode";
      this.tbxStatErrCode.ReadOnly = true;
      this.tbxStatErrCode.Size = new System.Drawing.Size(80, 20);
      this.tbxStatErrCode.TabIndex = 27;
      // 
      // lblStatServoState
      // 
      this.lblStatServoState.AutoSize = true;
      this.lblStatServoState.Location = new System.Drawing.Point(89, 106);
      this.lblStatServoState.Name = "lblStatServoState";
      this.lblStatServoState.Size = new System.Drawing.Size(63, 13);
      this.lblStatServoState.TabIndex = 26;
      this.lblStatServoState.Text = "Servo State";
      // 
      // tbxStatServoState
      // 
      this.tbxStatServoState.BackColor = System.Drawing.SystemColors.Info;
      this.tbxStatServoState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxStatServoState.Location = new System.Drawing.Point(6, 103);
      this.tbxStatServoState.Name = "tbxStatServoState";
      this.tbxStatServoState.ReadOnly = true;
      this.tbxStatServoState.Size = new System.Drawing.Size(80, 20);
      this.tbxStatServoState.TabIndex = 25;
      // 
      // gbStatErrFlag
      // 
      this.gbStatErrFlag.Controls.Add(this.btnStatusWrite);
      this.gbStatErrFlag.Controls.Add(this.cbxStatIrqErr);
      this.gbStatErrFlag.Controls.Add(this.cbxStatATDErr);
      this.gbStatErrFlag.Controls.Add(this.cbxStatFuzzyErr);
      this.gbStatErrFlag.Controls.Add(this.cbxStatPosErr);
      this.gbStatErrFlag.Controls.Add(this.cbxStatCANErr);
      this.gbStatErrFlag.Controls.Add(this.cbxStatSysErr);
      this.gbStatErrFlag.Controls.Add(this.cbxStatLimErr);
      this.gbStatErrFlag.Location = new System.Drawing.Point(6, 261);
      this.gbStatErrFlag.Name = "gbStatErrFlag";
      this.gbStatErrFlag.Size = new System.Drawing.Size(215, 98);
      this.gbStatErrFlag.TabIndex = 24;
      this.gbStatErrFlag.TabStop = false;
      this.gbStatErrFlag.Text = "Sticky Error Flags";
      // 
      // btnStatusWrite
      // 
      this.btnStatusWrite.Location = new System.Drawing.Point(111, 71);
      this.btnStatusWrite.Name = "btnStatusWrite";
      this.btnStatusWrite.Size = new System.Drawing.Size(98, 21);
      this.btnStatusWrite.TabIndex = 35;
      this.btnStatusWrite.Text = "Clear Error Flags";
      this.btnStatusWrite.UseVisualStyleBackColor = true;
      this.btnStatusWrite.Click += new System.EventHandler(this.btnStatusWrite_Click);
      // 
      // cbxStatIrqErr
      // 
      this.cbxStatIrqErr.AutoSize = true;
      this.cbxStatIrqErr.Enabled = false;
      this.cbxStatIrqErr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbxStatIrqErr.Location = new System.Drawing.Point(6, 18);
      this.cbxStatIrqErr.Margin = new System.Windows.Forms.Padding(2);
      this.cbxStatIrqErr.Name = "cbxStatIrqErr";
      this.cbxStatIrqErr.Size = new System.Drawing.Size(67, 17);
      this.cbxStatIrqErr.TabIndex = 6;
      this.cbxStatIrqErr.Text = "IRQ Error";
      this.cbxStatIrqErr.UseVisualStyleBackColor = true;
      // 
      // cbxStatATDErr
      // 
      this.cbxStatATDErr.AutoSize = true;
      this.cbxStatATDErr.Enabled = false;
      this.cbxStatATDErr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbxStatATDErr.Location = new System.Drawing.Point(117, 51);
      this.cbxStatATDErr.Margin = new System.Windows.Forms.Padding(2);
      this.cbxStatATDErr.Name = "cbxStatATDErr";
      this.cbxStatATDErr.Size = new System.Drawing.Size(70, 17);
      this.cbxStatATDErr.TabIndex = 5;
      this.cbxStatATDErr.Text = "ATD Error";
      this.cbxStatATDErr.UseVisualStyleBackColor = true;
      // 
      // cbxStatFuzzyErr
      // 
      this.cbxStatFuzzyErr.AutoSize = true;
      this.cbxStatFuzzyErr.Enabled = false;
      this.cbxStatFuzzyErr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbxStatFuzzyErr.Location = new System.Drawing.Point(117, 34);
      this.cbxStatFuzzyErr.Margin = new System.Windows.Forms.Padding(2);
      this.cbxStatFuzzyErr.Name = "cbxStatFuzzyErr";
      this.cbxStatFuzzyErr.Size = new System.Drawing.Size(91, 17);
      this.cbxStatFuzzyErr.TabIndex = 4;
      this.cbxStatFuzzyErr.Text = "Fuzzy ISR Ovf";
      this.cbxStatFuzzyErr.UseVisualStyleBackColor = true;
      // 
      // cbxStatPosErr
      // 
      this.cbxStatPosErr.AutoSize = true;
      this.cbxStatPosErr.Enabled = false;
      this.cbxStatPosErr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbxStatPosErr.Location = new System.Drawing.Point(117, 17);
      this.cbxStatPosErr.Margin = new System.Windows.Forms.Padding(2);
      this.cbxStatPosErr.Name = "cbxStatPosErr";
      this.cbxStatPosErr.Size = new System.Drawing.Size(85, 17);
      this.cbxStatPosErr.TabIndex = 3;
      this.cbxStatPosErr.Text = "Position Error";
      this.cbxStatPosErr.UseVisualStyleBackColor = true;
      // 
      // cbxStatCANErr
      // 
      this.cbxStatCANErr.AutoSize = true;
      this.cbxStatCANErr.Enabled = false;
      this.cbxStatCANErr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbxStatCANErr.Location = new System.Drawing.Point(6, 69);
      this.cbxStatCANErr.Margin = new System.Windows.Forms.Padding(2);
      this.cbxStatCANErr.Name = "cbxStatCANErr";
      this.cbxStatCANErr.Size = new System.Drawing.Size(70, 17);
      this.cbxStatCANErr.TabIndex = 2;
      this.cbxStatCANErr.Text = "CAN Error";
      this.cbxStatCANErr.UseVisualStyleBackColor = true;
      // 
      // cbxStatSysErr
      // 
      this.cbxStatSysErr.AutoSize = true;
      this.cbxStatSysErr.Enabled = false;
      this.cbxStatSysErr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbxStatSysErr.Location = new System.Drawing.Point(6, 52);
      this.cbxStatSysErr.Margin = new System.Windows.Forms.Padding(2);
      this.cbxStatSysErr.Name = "cbxStatSysErr";
      this.cbxStatSysErr.Size = new System.Drawing.Size(82, 17);
      this.cbxStatSysErr.TabIndex = 1;
      this.cbxStatSysErr.Text = "System Error";
      this.cbxStatSysErr.UseVisualStyleBackColor = true;
      // 
      // cbxStatLimErr
      // 
      this.cbxStatLimErr.AutoSize = true;
      this.cbxStatLimErr.Enabled = false;
      this.cbxStatLimErr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbxStatLimErr.Location = new System.Drawing.Point(6, 35);
      this.cbxStatLimErr.Margin = new System.Windows.Forms.Padding(2);
      this.cbxStatLimErr.Name = "cbxStatLimErr";
      this.cbxStatLimErr.Size = new System.Drawing.Size(69, 17);
      this.cbxStatLimErr.TabIndex = 0;
      this.cbxStatLimErr.Text = "Limit Error";
      this.cbxStatLimErr.UseVisualStyleBackColor = true;
      // 
      // gbStatLim
      // 
      this.gbStatLim.Controls.Add(this.lblStatATDVal);
      this.gbStatLim.Controls.Add(this.tbxStatATDVal);
      this.gbStatLim.Controls.Add(this.cbxStatEncIdx);
      this.gbStatLim.Controls.Add(this.cbxStatLimB);
      this.gbStatLim.Controls.Add(this.cbxStatLimA);
      this.gbStatLim.Controls.Add(this.lblStatEncIdxVal);
      this.gbStatLim.Controls.Add(this.tbxStatEncIdxVal);
      this.gbStatLim.Controls.Add(this.tbxStatLimAVal);
      this.gbStatLim.Controls.Add(this.lblStatLimAVal);
      this.gbStatLim.Controls.Add(this.lblStatLimBVal);
      this.gbStatLim.Controls.Add(this.tbxStatLimBVal);
      this.gbStatLim.Location = new System.Drawing.Point(6, 149);
      this.gbStatLim.Name = "gbStatLim";
      this.gbStatLim.Size = new System.Drawing.Size(215, 106);
      this.gbStatLim.TabIndex = 19;
      this.gbStatLim.TabStop = false;
      this.gbStatLim.Text = "Limit";
      // 
      // lblStatATDVal
      // 
      this.lblStatATDVal.AutoSize = true;
      this.lblStatATDVal.Location = new System.Drawing.Point(36, 81);
      this.lblStatATDVal.Name = "lblStatATDVal";
      this.lblStatATDVal.Size = new System.Drawing.Size(59, 13);
      this.lblStatATDVal.TabIndex = 28;
      this.lblStatATDVal.Text = "ATD Value";
      // 
      // tbxStatATDVal
      // 
      this.tbxStatATDVal.BackColor = System.Drawing.SystemColors.Info;
      this.tbxStatATDVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxStatATDVal.Location = new System.Drawing.Point(6, 79);
      this.tbxStatATDVal.Name = "tbxStatATDVal";
      this.tbxStatATDVal.ReadOnly = true;
      this.tbxStatATDVal.Size = new System.Drawing.Size(30, 20);
      this.tbxStatATDVal.TabIndex = 27;
      // 
      // cbxStatEncIdx
      // 
      this.cbxStatEncIdx.AutoSize = true;
      this.cbxStatEncIdx.Enabled = false;
      this.cbxStatEncIdx.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbxStatEncIdx.Location = new System.Drawing.Point(117, 61);
      this.cbxStatEncIdx.Name = "cbxStatEncIdx";
      this.cbxStatEncIdx.Size = new System.Drawing.Size(87, 17);
      this.cbxStatEncIdx.TabIndex = 26;
      this.cbxStatEncIdx.Text = "Enc Idx State";
      this.cbxStatEncIdx.UseVisualStyleBackColor = true;
      // 
      // cbxStatLimB
      // 
      this.cbxStatLimB.AutoSize = true;
      this.cbxStatLimB.Enabled = false;
      this.cbxStatLimB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbxStatLimB.Location = new System.Drawing.Point(117, 42);
      this.cbxStatLimB.Name = "cbxStatLimB";
      this.cbxStatLimB.Size = new System.Drawing.Size(77, 17);
      this.cbxStatLimB.TabIndex = 25;
      this.cbxStatLimB.Text = "Lim B State";
      this.cbxStatLimB.UseVisualStyleBackColor = true;
      // 
      // cbxStatLimA
      // 
      this.cbxStatLimA.AutoSize = true;
      this.cbxStatLimA.BackColor = System.Drawing.Color.Transparent;
      this.cbxStatLimA.Enabled = false;
      this.cbxStatLimA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.cbxStatLimA.ForeColor = System.Drawing.SystemColors.ControlText;
      this.cbxStatLimA.Location = new System.Drawing.Point(117, 21);
      this.cbxStatLimA.Name = "cbxStatLimA";
      this.cbxStatLimA.Size = new System.Drawing.Size(77, 17);
      this.cbxStatLimA.TabIndex = 24;
      this.cbxStatLimA.Text = "Lim A State";
      this.cbxStatLimA.UseVisualStyleBackColor = false;
      // 
      // lblStatEncIdxVal
      // 
      this.lblStatEncIdxVal.AutoSize = true;
      this.lblStatEncIdxVal.Location = new System.Drawing.Point(36, 63);
      this.lblStatEncIdxVal.Name = "lblStatEncIdxVal";
      this.lblStatEncIdxVal.Size = new System.Drawing.Size(73, 13);
      this.lblStatEncIdxVal.TabIndex = 23;
      this.lblStatEncIdxVal.Text = "Enc Idx Value";
      // 
      // tbxStatEncIdxVal
      // 
      this.tbxStatEncIdxVal.BackColor = System.Drawing.SystemColors.Info;
      this.tbxStatEncIdxVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxStatEncIdxVal.Location = new System.Drawing.Point(6, 59);
      this.tbxStatEncIdxVal.Name = "tbxStatEncIdxVal";
      this.tbxStatEncIdxVal.ReadOnly = true;
      this.tbxStatEncIdxVal.Size = new System.Drawing.Size(30, 20);
      this.tbxStatEncIdxVal.TabIndex = 22;
      // 
      // tbxStatLimAVal
      // 
      this.tbxStatLimAVal.BackColor = System.Drawing.SystemColors.Info;
      this.tbxStatLimAVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxStatLimAVal.Location = new System.Drawing.Point(6, 19);
      this.tbxStatLimAVal.Name = "tbxStatLimAVal";
      this.tbxStatLimAVal.ReadOnly = true;
      this.tbxStatLimAVal.Size = new System.Drawing.Size(30, 20);
      this.tbxStatLimAVal.TabIndex = 15;
      // 
      // lblStatLimAVal
      // 
      this.lblStatLimAVal.AutoSize = true;
      this.lblStatLimAVal.Location = new System.Drawing.Point(36, 23);
      this.lblStatLimAVal.Name = "lblStatLimAVal";
      this.lblStatLimAVal.Size = new System.Drawing.Size(68, 13);
      this.lblStatLimAVal.TabIndex = 16;
      this.lblStatLimAVal.Text = "Limit A Value";
      // 
      // lblStatLimBVal
      // 
      this.lblStatLimBVal.AutoSize = true;
      this.lblStatLimBVal.Location = new System.Drawing.Point(36, 43);
      this.lblStatLimBVal.Name = "lblStatLimBVal";
      this.lblStatLimBVal.Size = new System.Drawing.Size(68, 13);
      this.lblStatLimBVal.TabIndex = 18;
      this.lblStatLimBVal.Text = "Limit B Value";
      // 
      // tbxStatLimBVal
      // 
      this.tbxStatLimBVal.BackColor = System.Drawing.SystemColors.Info;
      this.tbxStatLimBVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxStatLimBVal.Location = new System.Drawing.Point(6, 39);
      this.tbxStatLimBVal.Name = "tbxStatLimBVal";
      this.tbxStatLimBVal.ReadOnly = true;
      this.tbxStatLimBVal.Size = new System.Drawing.Size(30, 20);
      this.tbxStatLimBVal.TabIndex = 17;
      // 
      // lblStatPeakVel
      // 
      this.lblStatPeakVel.AutoSize = true;
      this.lblStatPeakVel.Location = new System.Drawing.Point(89, 63);
      this.lblStatPeakVel.Name = "lblStatPeakVel";
      this.lblStatPeakVel.Size = new System.Drawing.Size(115, 13);
      this.lblStatPeakVel.TabIndex = 8;
      this.lblStatPeakVel.Text = "Peak Encoder Change";
      // 
      // tbxStatPeakVel
      // 
      this.tbxStatPeakVel.BackColor = System.Drawing.SystemColors.Info;
      this.tbxStatPeakVel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxStatPeakVel.Location = new System.Drawing.Point(6, 60);
      this.tbxStatPeakVel.Name = "tbxStatPeakVel";
      this.tbxStatPeakVel.ReadOnly = true;
      this.tbxStatPeakVel.Size = new System.Drawing.Size(80, 20);
      this.tbxStatPeakVel.TabIndex = 7;
      // 
      // lblStatCurVel
      // 
      this.lblStatCurVel.AutoSize = true;
      this.lblStatCurVel.Location = new System.Drawing.Point(89, 43);
      this.lblStatCurVel.Name = "lblStatCurVel";
      this.lblStatCurVel.Size = new System.Drawing.Size(81, 13);
      this.lblStatCurVel.TabIndex = 6;
      this.lblStatCurVel.Text = "Current Velocity";
      // 
      // tbxStatCurVel
      // 
      this.tbxStatCurVel.BackColor = System.Drawing.SystemColors.Info;
      this.tbxStatCurVel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxStatCurVel.Location = new System.Drawing.Point(6, 40);
      this.tbxStatCurVel.Name = "tbxStatCurVel";
      this.tbxStatCurVel.ReadOnly = true;
      this.tbxStatCurVel.Size = new System.Drawing.Size(80, 20);
      this.tbxStatCurVel.TabIndex = 5;
      // 
      // lblStatCurPos
      // 
      this.lblStatCurPos.AutoSize = true;
      this.lblStatCurPos.Location = new System.Drawing.Point(89, 23);
      this.lblStatCurPos.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
      this.lblStatCurPos.Name = "lblStatCurPos";
      this.lblStatCurPos.Size = new System.Drawing.Size(81, 13);
      this.lblStatCurPos.TabIndex = 4;
      this.lblStatCurPos.Text = "Current Position";
      // 
      // tbxStatCurPos
      // 
      this.tbxStatCurPos.BackColor = System.Drawing.SystemColors.Info;
      this.tbxStatCurPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tbxStatCurPos.Location = new System.Drawing.Point(6, 20);
      this.tbxStatCurPos.Name = "tbxStatCurPos";
      this.tbxStatCurPos.ReadOnly = true;
      this.tbxStatCurPos.Size = new System.Drawing.Size(80, 20);
      this.tbxStatCurPos.TabIndex = 3;
      // 
      // gbTestMotionStart
      // 
      this.gbTestMotionStart.Controls.Add(this.btnMotionCtlHalfPos);
      this.gbTestMotionStart.Controls.Add(this.btnMotionCtlDoublePos);
      this.gbTestMotionStart.Controls.Add(this.btnMotionCtlRevPos);
      this.gbTestMotionStart.Controls.Add(this.btnTestMotionStart);
      this.gbTestMotionStart.Controls.Add(this.rbTestMotionStartPwm);
      this.gbTestMotionStart.Controls.Add(this.rbTestMotionStartPwmLim);
      this.gbTestMotionStart.Controls.Add(this.rbTestMotionStartTrapezoidal);
      this.gbTestMotionStart.Controls.Add(this.rbTestMotionStartVel);
      this.gbTestMotionStart.Controls.Add(this.rbTestMotionStartPos);
      this.gbTestMotionStart.Location = new System.Drawing.Point(251, 64);
      this.gbTestMotionStart.Name = "gbTestMotionStart";
      this.gbTestMotionStart.Size = new System.Drawing.Size(203, 96);
      this.gbTestMotionStart.TabIndex = 1;
      this.gbTestMotionStart.TabStop = false;
      this.gbTestMotionStart.Text = "Start Motion";
      // 
      // btnMotionCtlHalfPos
      // 
      this.btnMotionCtlHalfPos.Location = new System.Drawing.Point(150, 15);
      this.btnMotionCtlHalfPos.Name = "btnMotionCtlHalfPos";
      this.btnMotionCtlHalfPos.Size = new System.Drawing.Size(50, 22);
      this.btnMotionCtlHalfPos.TabIndex = 20;
      this.btnMotionCtlHalfPos.Text = "Half+St";
      this.btnMotionCtlHalfPos.UseVisualStyleBackColor = true;
      this.btnMotionCtlHalfPos.Click += new System.EventHandler(this.btnMotionCtlHalfPos_Click);
      // 
      // btnMotionCtlDoublePos
      // 
      this.btnMotionCtlDoublePos.Location = new System.Drawing.Point(98, 15);
      this.btnMotionCtlDoublePos.Name = "btnMotionCtlDoublePos";
      this.btnMotionCtlDoublePos.Size = new System.Drawing.Size(48, 22);
      this.btnMotionCtlDoublePos.TabIndex = 19;
      this.btnMotionCtlDoublePos.Text = "Dbl+St";
      this.btnMotionCtlDoublePos.UseCompatibleTextRendering = true;
      this.btnMotionCtlDoublePos.UseVisualStyleBackColor = true;
      this.btnMotionCtlDoublePos.Click += new System.EventHandler(this.btnMotionCtlDoublePos_Click);
      // 
      // btnMotionCtlRevPos
      // 
      this.btnMotionCtlRevPos.Location = new System.Drawing.Point(48, 15);
      this.btnMotionCtlRevPos.Name = "btnMotionCtlRevPos";
      this.btnMotionCtlRevPos.Size = new System.Drawing.Size(46, 22);
      this.btnMotionCtlRevPos.TabIndex = 16;
      this.btnMotionCtlRevPos.Text = "Inv+St";
      this.btnMotionCtlRevPos.UseVisualStyleBackColor = true;
      this.btnMotionCtlRevPos.Click += new System.EventHandler(this.btnMotionCtlRevPos_Click);
      // 
      // btnTestMotionStart
      // 
      this.btnTestMotionStart.Location = new System.Drawing.Point(4, 15);
      this.btnTestMotionStart.Name = "btnTestMotionStart";
      this.btnTestMotionStart.Size = new System.Drawing.Size(40, 22);
      this.btnTestMotionStart.TabIndex = 5;
      this.btnTestMotionStart.Text = "Start";
      this.btnTestMotionStart.UseVisualStyleBackColor = true;
      this.btnTestMotionStart.Click += new System.EventHandler(this.btnTestMotionStart_Click);
      // 
      // rbTestMotionStartPwm
      // 
      this.rbTestMotionStartPwm.AutoSize = true;
      this.rbTestMotionStartPwm.Location = new System.Drawing.Point(89, 43);
      this.rbTestMotionStartPwm.Name = "rbTestMotionStartPwm";
      this.rbTestMotionStartPwm.Size = new System.Drawing.Size(52, 17);
      this.rbTestMotionStartPwm.TabIndex = 4;
      this.rbTestMotionStartPwm.Text = "PWM";
      this.rbTestMotionStartPwm.UseVisualStyleBackColor = true;
      this.rbTestMotionStartPwm.CheckedChanged += new System.EventHandler(this.rbMotionStart_CheckedChanged);
      // 
      // rbTestMotionStartPwmLim
      // 
      this.rbTestMotionStartPwmLim.AutoSize = true;
      this.rbTestMotionStartPwmLim.Location = new System.Drawing.Point(89, 59);
      this.rbTestMotionStartPwmLim.Name = "rbTestMotionStartPwmLim";
      this.rbTestMotionStartPwmLim.Size = new System.Drawing.Size(110, 17);
      this.rbTestMotionStartPwmLim.TabIndex = 3;
      this.rbTestMotionStartPwmLim.Text = "PWM (pos limited)";
      this.rbTestMotionStartPwmLim.UseVisualStyleBackColor = true;
      this.rbTestMotionStartPwmLim.CheckedChanged += new System.EventHandler(this.rbMotionStart_CheckedChanged);
      // 
      // rbTestMotionStartTrapezoidal
      // 
      this.rbTestMotionStartTrapezoidal.AutoSize = true;
      this.rbTestMotionStartTrapezoidal.Checked = true;
      this.rbTestMotionStartTrapezoidal.Location = new System.Drawing.Point(7, 75);
      this.rbTestMotionStartTrapezoidal.Name = "rbTestMotionStartTrapezoidal";
      this.rbTestMotionStartTrapezoidal.Size = new System.Drawing.Size(80, 17);
      this.rbTestMotionStartTrapezoidal.TabIndex = 2;
      this.rbTestMotionStartTrapezoidal.TabStop = true;
      this.rbTestMotionStartTrapezoidal.Text = "Trapezoidal";
      this.rbTestMotionStartTrapezoidal.UseVisualStyleBackColor = true;
      this.rbTestMotionStartTrapezoidal.CheckedChanged += new System.EventHandler(this.rbMotionStart_CheckedChanged);
      // 
      // rbTestMotionStartVel
      // 
      this.rbTestMotionStartVel.AutoSize = true;
      this.rbTestMotionStartVel.Location = new System.Drawing.Point(7, 59);
      this.rbTestMotionStartVel.Name = "rbTestMotionStartVel";
      this.rbTestMotionStartVel.Size = new System.Drawing.Size(62, 17);
      this.rbTestMotionStartVel.TabIndex = 1;
      this.rbTestMotionStartVel.Text = "Velocity";
      this.rbTestMotionStartVel.UseVisualStyleBackColor = true;
      this.rbTestMotionStartVel.CheckedChanged += new System.EventHandler(this.rbMotionStart_CheckedChanged);
      // 
      // rbTestMotionStartPos
      // 
      this.rbTestMotionStartPos.AutoSize = true;
      this.rbTestMotionStartPos.Location = new System.Drawing.Point(7, 43);
      this.rbTestMotionStartPos.Name = "rbTestMotionStartPos";
      this.rbTestMotionStartPos.Size = new System.Drawing.Size(62, 17);
      this.rbTestMotionStartPos.TabIndex = 0;
      this.rbTestMotionStartPos.Text = "Position";
      this.rbTestMotionStartPos.UseVisualStyleBackColor = true;
      this.rbTestMotionStartPos.CheckedChanged += new System.EventHandler(this.rbMotionStart_CheckedChanged);
      // 
      // gbSetLimit
      // 
      this.gbSetLimit.Controls.Add(this.gbxIRQEnable);
      this.gbSetLimit.Controls.Add(this.gbxSetATDLim);
      this.gbSetLimit.Controls.Add(this.btnLimitCtlLoad);
      this.gbSetLimit.Controls.Add(this.btnLimitCtlSave);
      this.gbSetLimit.Controls.Add(this.gbSetEncIdx);
      this.gbSetLimit.Controls.Add(this.gbSetLimB);
      this.gbSetLimit.Controls.Add(this.gbSetLimA);
      this.gbSetLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.gbSetLimit.Location = new System.Drawing.Point(251, 169);
      this.gbSetLimit.Name = "gbSetLimit";
      this.gbSetLimit.Size = new System.Drawing.Size(203, 318);
      this.gbSetLimit.TabIndex = 14;
      this.gbSetLimit.TabStop = false;
      this.gbSetLimit.Text = "Limit Control";
      // 
      // gbxIRQEnable
      // 
      this.gbxIRQEnable.Controls.Add(this.rbIRQsoft);
      this.gbxIRQEnable.Controls.Add(this.rbIRQhard);
      this.gbxIRQEnable.Controls.Add(this.cbxIRQEn);
      this.gbxIRQEnable.Location = new System.Drawing.Point(6, 265);
      this.gbxIRQEnable.Name = "gbxIRQEnable";
      this.gbxIRQEnable.Size = new System.Drawing.Size(131, 46);
      this.gbxIRQEnable.TabIndex = 17;
      this.gbxIRQEnable.TabStop = false;
      this.gbxIRQEnable.Text = "IRQ Stop";
      // 
      // rbIRQsoft
      // 
      this.rbIRQsoft.AutoSize = true;
      this.rbIRQsoft.Checked = true;
      this.rbIRQsoft.Location = new System.Drawing.Point(76, 25);
      this.rbIRQsoft.Name = "rbIRQsoft";
      this.rbIRQsoft.Size = new System.Drawing.Size(44, 17);
      this.rbIRQsoft.TabIndex = 18;
      this.rbIRQsoft.TabStop = true;
      this.rbIRQsoft.Text = "Soft";
      this.rbIRQsoft.UseVisualStyleBackColor = true;
      // 
      // rbIRQhard
      // 
      this.rbIRQhard.AutoSize = true;
      this.rbIRQhard.Location = new System.Drawing.Point(76, 9);
      this.rbIRQhard.Name = "rbIRQhard";
      this.rbIRQhard.Size = new System.Drawing.Size(48, 17);
      this.rbIRQhard.TabIndex = 17;
      this.rbIRQhard.Text = "Hard";
      this.rbIRQhard.UseVisualStyleBackColor = true;
      // 
      // cbxIRQEn
      // 
      this.cbxIRQEn.AutoSize = true;
      this.cbxIRQEn.Location = new System.Drawing.Point(7, 19);
      this.cbxIRQEn.Name = "cbxIRQEn";
      this.cbxIRQEn.Size = new System.Drawing.Size(59, 17);
      this.cbxIRQEn.TabIndex = 16;
      this.cbxIRQEn.Text = "Enable";
      this.cbxIRQEn.UseVisualStyleBackColor = true;
      // 
      // gbxSetATDLim
      // 
      this.gbxSetATDLim.Controls.Add(this.nudSetAtdLimDwell);
      this.gbxSetATDLim.Controls.Add(this.nudSetAtdLimVal);
      this.gbxSetATDLim.Controls.Add(this.lblSetATDLimDwell);
      this.gbxSetATDLim.Controls.Add(this.lblSetATDLimVal);
      this.gbxSetATDLim.Location = new System.Drawing.Point(6, 198);
      this.gbxSetATDLim.Name = "gbxSetATDLim";
      this.gbxSetATDLim.Size = new System.Drawing.Size(190, 65);
      this.gbxSetATDLim.TabIndex = 16;
      this.gbxSetATDLim.TabStop = false;
      this.gbxSetATDLim.Text = "ATD Limit";
      // 
      // nudSetAtdLimDwell
      // 
      this.nudSetAtdLimDwell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.nudSetAtdLimDwell.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.nudSetAtdLimDwell.Location = new System.Drawing.Point(6, 39);
      this.nudSetAtdLimDwell.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.nudSetAtdLimDwell.Name = "nudSetAtdLimDwell";
      this.nudSetAtdLimDwell.Size = new System.Drawing.Size(60, 20);
      this.nudSetAtdLimDwell.TabIndex = 21;
      // 
      // nudSetAtdLimVal
      // 
      this.nudSetAtdLimVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.nudSetAtdLimVal.Location = new System.Drawing.Point(6, 16);
      this.nudSetAtdLimVal.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.nudSetAtdLimVal.Name = "nudSetAtdLimVal";
      this.nudSetAtdLimVal.Size = new System.Drawing.Size(60, 20);
      this.nudSetAtdLimVal.TabIndex = 20;
      // 
      // lblSetATDLimDwell
      // 
      this.lblSetATDLimDwell.AutoSize = true;
      this.lblSetATDLimDwell.Location = new System.Drawing.Point(67, 42);
      this.lblSetATDLimDwell.Name = "lblSetATDLimDwell";
      this.lblSetATDLimDwell.Size = new System.Drawing.Size(101, 13);
      this.lblSetATDLimDwell.TabIndex = 19;
      this.lblSetATDLimDwell.Text = "Dwell (servo cycles)";
      // 
      // lblSetATDLimVal
      // 
      this.lblSetATDLimVal.AutoSize = true;
      this.lblSetATDLimVal.Location = new System.Drawing.Point(66, 19);
      this.lblSetATDLimVal.Name = "lblSetATDLimVal";
      this.lblSetATDLimVal.Size = new System.Drawing.Size(118, 13);
      this.lblSetATDLimVal.TabIndex = 17;
      this.lblSetATDLimVal.Text = "Limit Value (0 = disable)";
      // 
      // btnLimitCtlLoad
      // 
      this.btnLimitCtlLoad.Location = new System.Drawing.Point(143, 290);
      this.btnLimitCtlLoad.Name = "btnLimitCtlLoad";
      this.btnLimitCtlLoad.Size = new System.Drawing.Size(53, 21);
      this.btnLimitCtlLoad.TabIndex = 12;
      this.btnLimitCtlLoad.Text = "Get";
      this.btnLimitCtlLoad.UseVisualStyleBackColor = true;
      this.btnLimitCtlLoad.Click += new System.EventHandler(this.btnLimitCtlLoad_Click);
      // 
      // btnLimitCtlSave
      // 
      this.btnLimitCtlSave.Location = new System.Drawing.Point(143, 266);
      this.btnLimitCtlSave.Name = "btnLimitCtlSave";
      this.btnLimitCtlSave.Size = new System.Drawing.Size(53, 21);
      this.btnLimitCtlSave.TabIndex = 13;
      this.btnLimitCtlSave.Text = "Set";
      this.btnLimitCtlSave.UseVisualStyleBackColor = true;
      this.btnLimitCtlSave.Click += new System.EventHandler(this.btnLimitCtlSave_Click);
      // 
      // gbSetEncIdx
      // 
      this.gbSetEncIdx.Controls.Add(this.cbxSetEncIdxZero);
      this.gbSetEncIdx.Controls.Add(this.cbxSetEncIdxEn);
      this.gbSetEncIdx.Controls.Add(this.gbSetEncIdxHalt);
      this.gbSetEncIdx.Controls.Add(this.gbSetEncIdxVal);
      this.gbSetEncIdx.Location = new System.Drawing.Point(6, 136);
      this.gbSetEncIdx.Name = "gbSetEncIdx";
      this.gbSetEncIdx.Size = new System.Drawing.Size(190, 60);
      this.gbSetEncIdx.TabIndex = 2;
      this.gbSetEncIdx.TabStop = false;
      this.gbSetEncIdx.Text = "Enc Index";
      // 
      // cbxSetEncIdxZero
      // 
      this.cbxSetEncIdxZero.AutoSize = true;
      this.cbxSetEncIdxZero.Location = new System.Drawing.Point(6, 39);
      this.cbxSetEncIdxZero.Name = "cbxSetEncIdxZero";
      this.cbxSetEncIdxZero.Size = new System.Drawing.Size(48, 17);
      this.cbxSetEncIdxZero.TabIndex = 16;
      this.cbxSetEncIdxZero.Text = "Zero";
      this.cbxSetEncIdxZero.UseVisualStyleBackColor = true;
      // 
      // cbxSetEncIdxEn
      // 
      this.cbxSetEncIdxEn.AutoSize = true;
      this.cbxSetEncIdxEn.Location = new System.Drawing.Point(6, 20);
      this.cbxSetEncIdxEn.Name = "cbxSetEncIdxEn";
      this.cbxSetEncIdxEn.Size = new System.Drawing.Size(59, 17);
      this.cbxSetEncIdxEn.TabIndex = 15;
      this.cbxSetEncIdxEn.Text = "Enable";
      this.cbxSetEncIdxEn.UseVisualStyleBackColor = true;
      // 
      // gbSetEncIdxHalt
      // 
      this.gbSetEncIdxHalt.Controls.Add(this.rbSetEncIdxHaltSoft);
      this.gbSetEncIdxHalt.Controls.Add(this.rbSetEncIdxHaltHard);
      this.gbSetEncIdxHalt.Location = new System.Drawing.Point(130, 8);
      this.gbSetEncIdxHalt.Name = "gbSetEncIdxHalt";
      this.gbSetEncIdxHalt.Size = new System.Drawing.Size(56, 50);
      this.gbSetEncIdxHalt.TabIndex = 14;
      this.gbSetEncIdxHalt.TabStop = false;
      this.gbSetEncIdxHalt.Text = "Halt";
      // 
      // rbSetEncIdxHaltSoft
      // 
      this.rbSetEncIdxHaltSoft.AutoSize = true;
      this.rbSetEncIdxHaltSoft.Checked = true;
      this.rbSetEncIdxHaltSoft.Location = new System.Drawing.Point(6, 28);
      this.rbSetEncIdxHaltSoft.Name = "rbSetEncIdxHaltSoft";
      this.rbSetEncIdxHaltSoft.Size = new System.Drawing.Size(44, 17);
      this.rbSetEncIdxHaltSoft.TabIndex = 1;
      this.rbSetEncIdxHaltSoft.TabStop = true;
      this.rbSetEncIdxHaltSoft.Text = "Soft";
      this.rbSetEncIdxHaltSoft.UseVisualStyleBackColor = true;
      // 
      // rbSetEncIdxHaltHard
      // 
      this.rbSetEncIdxHaltHard.AutoSize = true;
      this.rbSetEncIdxHaltHard.Location = new System.Drawing.Point(6, 12);
      this.rbSetEncIdxHaltHard.Name = "rbSetEncIdxHaltHard";
      this.rbSetEncIdxHaltHard.Size = new System.Drawing.Size(48, 17);
      this.rbSetEncIdxHaltHard.TabIndex = 0;
      this.rbSetEncIdxHaltHard.Text = "Hard";
      this.rbSetEncIdxHaltHard.UseVisualStyleBackColor = true;
      // 
      // gbSetEncIdxVal
      // 
      this.gbSetEncIdxVal.Controls.Add(this.rbSetEncIdxValLo);
      this.gbSetEncIdxVal.Controls.Add(this.rbSetEncIdxValHi);
      this.gbSetEncIdxVal.Location = new System.Drawing.Point(70, 8);
      this.gbSetEncIdxVal.Name = "gbSetEncIdxVal";
      this.gbSetEncIdxVal.Size = new System.Drawing.Size(56, 50);
      this.gbSetEncIdxVal.TabIndex = 13;
      this.gbSetEncIdxVal.TabStop = false;
      this.gbSetEncIdxVal.Text = "Value";
      // 
      // rbSetEncIdxValLo
      // 
      this.rbSetEncIdxValLo.AutoSize = true;
      this.rbSetEncIdxValLo.Checked = true;
      this.rbSetEncIdxValLo.Location = new System.Drawing.Point(6, 28);
      this.rbSetEncIdxValLo.Name = "rbSetEncIdxValLo";
      this.rbSetEncIdxValLo.Size = new System.Drawing.Size(45, 17);
      this.rbSetEncIdxValLo.TabIndex = 1;
      this.rbSetEncIdxValLo.TabStop = true;
      this.rbSetEncIdxValLo.Text = "Low";
      this.rbSetEncIdxValLo.UseVisualStyleBackColor = true;
      // 
      // rbSetEncIdxValHi
      // 
      this.rbSetEncIdxValHi.AutoSize = true;
      this.rbSetEncIdxValHi.Location = new System.Drawing.Point(6, 12);
      this.rbSetEncIdxValHi.Name = "rbSetEncIdxValHi";
      this.rbSetEncIdxValHi.Size = new System.Drawing.Size(47, 17);
      this.rbSetEncIdxValHi.TabIndex = 0;
      this.rbSetEncIdxValHi.Text = "High";
      this.rbSetEncIdxValHi.UseVisualStyleBackColor = true;
      // 
      // gbSetLimB
      // 
      this.gbSetLimB.Controls.Add(this.cbxSetLimBZero);
      this.gbSetLimB.Controls.Add(this.cbxSetLimBEn);
      this.gbSetLimB.Controls.Add(this.gbSetLimBHalt);
      this.gbSetLimB.Controls.Add(this.gbSetLimBVal);
      this.gbSetLimB.Location = new System.Drawing.Point(7, 74);
      this.gbSetLimB.Name = "gbSetLimB";
      this.gbSetLimB.Size = new System.Drawing.Size(190, 60);
      this.gbSetLimB.TabIndex = 1;
      this.gbSetLimB.TabStop = false;
      this.gbSetLimB.Text = "Limit B";
      // 
      // cbxSetLimBZero
      // 
      this.cbxSetLimBZero.AutoSize = true;
      this.cbxSetLimBZero.Location = new System.Drawing.Point(6, 39);
      this.cbxSetLimBZero.Name = "cbxSetLimBZero";
      this.cbxSetLimBZero.Size = new System.Drawing.Size(48, 17);
      this.cbxSetLimBZero.TabIndex = 16;
      this.cbxSetLimBZero.Text = "Zero";
      this.cbxSetLimBZero.UseVisualStyleBackColor = true;
      // 
      // cbxSetLimBEn
      // 
      this.cbxSetLimBEn.AutoSize = true;
      this.cbxSetLimBEn.Location = new System.Drawing.Point(6, 20);
      this.cbxSetLimBEn.Name = "cbxSetLimBEn";
      this.cbxSetLimBEn.Size = new System.Drawing.Size(59, 17);
      this.cbxSetLimBEn.TabIndex = 15;
      this.cbxSetLimBEn.Text = "Enable";
      this.cbxSetLimBEn.UseVisualStyleBackColor = true;
      // 
      // gbSetLimBHalt
      // 
      this.gbSetLimBHalt.Controls.Add(this.rbSetLimBHaltSoft);
      this.gbSetLimBHalt.Controls.Add(this.rbSetLimBHaltHard);
      this.gbSetLimBHalt.Location = new System.Drawing.Point(130, 8);
      this.gbSetLimBHalt.Name = "gbSetLimBHalt";
      this.gbSetLimBHalt.Size = new System.Drawing.Size(56, 50);
      this.gbSetLimBHalt.TabIndex = 14;
      this.gbSetLimBHalt.TabStop = false;
      this.gbSetLimBHalt.Text = "Halt";
      // 
      // rbSetLimBHaltSoft
      // 
      this.rbSetLimBHaltSoft.AutoSize = true;
      this.rbSetLimBHaltSoft.Checked = true;
      this.rbSetLimBHaltSoft.Location = new System.Drawing.Point(6, 28);
      this.rbSetLimBHaltSoft.Name = "rbSetLimBHaltSoft";
      this.rbSetLimBHaltSoft.Size = new System.Drawing.Size(44, 17);
      this.rbSetLimBHaltSoft.TabIndex = 1;
      this.rbSetLimBHaltSoft.TabStop = true;
      this.rbSetLimBHaltSoft.Text = "Soft";
      this.rbSetLimBHaltSoft.UseVisualStyleBackColor = true;
      // 
      // rbSetLimBHaltHard
      // 
      this.rbSetLimBHaltHard.AutoSize = true;
      this.rbSetLimBHaltHard.Location = new System.Drawing.Point(6, 12);
      this.rbSetLimBHaltHard.Name = "rbSetLimBHaltHard";
      this.rbSetLimBHaltHard.Size = new System.Drawing.Size(48, 17);
      this.rbSetLimBHaltHard.TabIndex = 0;
      this.rbSetLimBHaltHard.Text = "Hard";
      this.rbSetLimBHaltHard.UseVisualStyleBackColor = true;
      // 
      // gbSetLimBVal
      // 
      this.gbSetLimBVal.Controls.Add(this.rbSetLimBValLo);
      this.gbSetLimBVal.Controls.Add(this.rbSetLimBValHi);
      this.gbSetLimBVal.Location = new System.Drawing.Point(70, 8);
      this.gbSetLimBVal.Name = "gbSetLimBVal";
      this.gbSetLimBVal.Size = new System.Drawing.Size(56, 50);
      this.gbSetLimBVal.TabIndex = 13;
      this.gbSetLimBVal.TabStop = false;
      this.gbSetLimBVal.Text = "Value";
      // 
      // rbSetLimBValLo
      // 
      this.rbSetLimBValLo.AutoSize = true;
      this.rbSetLimBValLo.Checked = true;
      this.rbSetLimBValLo.Location = new System.Drawing.Point(6, 28);
      this.rbSetLimBValLo.Name = "rbSetLimBValLo";
      this.rbSetLimBValLo.Size = new System.Drawing.Size(45, 17);
      this.rbSetLimBValLo.TabIndex = 1;
      this.rbSetLimBValLo.TabStop = true;
      this.rbSetLimBValLo.Text = "Low";
      this.rbSetLimBValLo.UseVisualStyleBackColor = true;
      // 
      // rbSetLimBValHi
      // 
      this.rbSetLimBValHi.AutoSize = true;
      this.rbSetLimBValHi.Location = new System.Drawing.Point(6, 12);
      this.rbSetLimBValHi.Name = "rbSetLimBValHi";
      this.rbSetLimBValHi.Size = new System.Drawing.Size(47, 17);
      this.rbSetLimBValHi.TabIndex = 0;
      this.rbSetLimBValHi.Text = "High";
      this.rbSetLimBValHi.UseVisualStyleBackColor = true;
      // 
      // gbSetLimA
      // 
      this.gbSetLimA.Controls.Add(this.cbxSetLimAZero);
      this.gbSetLimA.Controls.Add(this.cbxSetLimAEn);
      this.gbSetLimA.Controls.Add(this.gbSetLimAHalt);
      this.gbSetLimA.Controls.Add(this.gbSetLimAVal);
      this.gbSetLimA.Location = new System.Drawing.Point(6, 13);
      this.gbSetLimA.Name = "gbSetLimA";
      this.gbSetLimA.Size = new System.Drawing.Size(190, 60);
      this.gbSetLimA.TabIndex = 0;
      this.gbSetLimA.TabStop = false;
      this.gbSetLimA.Text = "Limit A";
      // 
      // cbxSetLimAZero
      // 
      this.cbxSetLimAZero.AutoSize = true;
      this.cbxSetLimAZero.Location = new System.Drawing.Point(6, 39);
      this.cbxSetLimAZero.Name = "cbxSetLimAZero";
      this.cbxSetLimAZero.Size = new System.Drawing.Size(48, 17);
      this.cbxSetLimAZero.TabIndex = 16;
      this.cbxSetLimAZero.Text = "Zero";
      this.cbxSetLimAZero.UseVisualStyleBackColor = true;
      // 
      // cbxSetLimAEn
      // 
      this.cbxSetLimAEn.AutoSize = true;
      this.cbxSetLimAEn.Location = new System.Drawing.Point(6, 20);
      this.cbxSetLimAEn.Name = "cbxSetLimAEn";
      this.cbxSetLimAEn.Size = new System.Drawing.Size(59, 17);
      this.cbxSetLimAEn.TabIndex = 15;
      this.cbxSetLimAEn.Text = "Enable";
      this.cbxSetLimAEn.UseVisualStyleBackColor = true;
      // 
      // gbSetLimAHalt
      // 
      this.gbSetLimAHalt.Controls.Add(this.rbSetLimAHaltSoft);
      this.gbSetLimAHalt.Controls.Add(this.rbSetLimAHaltHard);
      this.gbSetLimAHalt.Location = new System.Drawing.Point(130, 8);
      this.gbSetLimAHalt.Name = "gbSetLimAHalt";
      this.gbSetLimAHalt.Size = new System.Drawing.Size(56, 50);
      this.gbSetLimAHalt.TabIndex = 14;
      this.gbSetLimAHalt.TabStop = false;
      this.gbSetLimAHalt.Text = "Halt";
      // 
      // rbSetLimAHaltSoft
      // 
      this.rbSetLimAHaltSoft.AutoSize = true;
      this.rbSetLimAHaltSoft.Checked = true;
      this.rbSetLimAHaltSoft.Location = new System.Drawing.Point(6, 28);
      this.rbSetLimAHaltSoft.Name = "rbSetLimAHaltSoft";
      this.rbSetLimAHaltSoft.Size = new System.Drawing.Size(44, 17);
      this.rbSetLimAHaltSoft.TabIndex = 1;
      this.rbSetLimAHaltSoft.TabStop = true;
      this.rbSetLimAHaltSoft.Text = "Soft";
      this.rbSetLimAHaltSoft.UseVisualStyleBackColor = true;
      // 
      // rbSetLimAHaltHard
      // 
      this.rbSetLimAHaltHard.AutoSize = true;
      this.rbSetLimAHaltHard.Location = new System.Drawing.Point(6, 12);
      this.rbSetLimAHaltHard.Name = "rbSetLimAHaltHard";
      this.rbSetLimAHaltHard.Size = new System.Drawing.Size(48, 17);
      this.rbSetLimAHaltHard.TabIndex = 0;
      this.rbSetLimAHaltHard.Text = "Hard";
      this.rbSetLimAHaltHard.UseVisualStyleBackColor = true;
      // 
      // gbSetLimAVal
      // 
      this.gbSetLimAVal.Controls.Add(this.rbSetLimAValLo);
      this.gbSetLimAVal.Controls.Add(this.rbSetLimAValHi);
      this.gbSetLimAVal.Location = new System.Drawing.Point(70, 8);
      this.gbSetLimAVal.Name = "gbSetLimAVal";
      this.gbSetLimAVal.Size = new System.Drawing.Size(56, 50);
      this.gbSetLimAVal.TabIndex = 13;
      this.gbSetLimAVal.TabStop = false;
      this.gbSetLimAVal.Text = "Value";
      // 
      // rbSetLimAValLo
      // 
      this.rbSetLimAValLo.AutoSize = true;
      this.rbSetLimAValLo.Checked = true;
      this.rbSetLimAValLo.Location = new System.Drawing.Point(6, 28);
      this.rbSetLimAValLo.Name = "rbSetLimAValLo";
      this.rbSetLimAValLo.Size = new System.Drawing.Size(45, 17);
      this.rbSetLimAValLo.TabIndex = 1;
      this.rbSetLimAValLo.TabStop = true;
      this.rbSetLimAValLo.Text = "Low";
      this.rbSetLimAValLo.UseVisualStyleBackColor = true;
      // 
      // rbSetLimAValHi
      // 
      this.rbSetLimAValHi.AutoSize = true;
      this.rbSetLimAValHi.Location = new System.Drawing.Point(6, 12);
      this.rbSetLimAValHi.Name = "rbSetLimAValHi";
      this.rbSetLimAValHi.Size = new System.Drawing.Size(47, 17);
      this.rbSetLimAValHi.TabIndex = 0;
      this.rbSetLimAValHi.Text = "High";
      this.rbSetLimAValHi.UseVisualStyleBackColor = true;
      // 
      // gbSetMotionControl
      // 
      this.gbSetMotionControl.Controls.Add(this.cbxMoveCtlGo);
      this.gbSetMotionControl.Controls.Add(this.btnMotionCtlLoad);
      this.gbSetMotionControl.Controls.Add(this.btnMotionCtlSave);
      this.gbSetMotionControl.Controls.Add(this.gbSetPwmDir);
      this.gbSetMotionControl.Controls.Add(this.lblSetAcc);
      this.gbSetMotionControl.Controls.Add(this.lblSetVel);
      this.gbSetMotionControl.Controls.Add(this.lblSetPos);
      this.gbSetMotionControl.Controls.Add(this.nudSetVel);
      this.gbSetMotionControl.Controls.Add(this.nudSetPos);
      this.gbSetMotionControl.Controls.Add(this.nudSetAcc);
      this.gbSetMotionControl.Location = new System.Drawing.Point(127, 6);
      this.gbSetMotionControl.Name = "gbSetMotionControl";
      this.gbSetMotionControl.Size = new System.Drawing.Size(118, 308);
      this.gbSetMotionControl.TabIndex = 13;
      this.gbSetMotionControl.TabStop = false;
      this.gbSetMotionControl.Text = "Motion Control";
      // 
      // cbxMoveCtlGo
      // 
      this.cbxMoveCtlGo.AutoSize = true;
      this.cbxMoveCtlGo.Location = new System.Drawing.Point(6, 231);
      this.cbxMoveCtlGo.Name = "cbxMoveCtlGo";
      this.cbxMoveCtlGo.Size = new System.Drawing.Size(78, 17);
      this.cbxMoveCtlGo.TabIndex = 18;
      this.cbxMoveCtlGo.Text = "Go on \'Set\'";
      this.cbxMoveCtlGo.UseVisualStyleBackColor = true;
      // 
      // btnMotionCtlLoad
      // 
      this.btnMotionCtlLoad.Location = new System.Drawing.Point(6, 278);
      this.btnMotionCtlLoad.Name = "btnMotionCtlLoad";
      this.btnMotionCtlLoad.Size = new System.Drawing.Size(106, 21);
      this.btnMotionCtlLoad.TabIndex = 14;
      this.btnMotionCtlLoad.Text = "Get";
      this.btnMotionCtlLoad.UseVisualStyleBackColor = true;
      this.btnMotionCtlLoad.Click += new System.EventHandler(this.btnMotionCtlLoad_Click);
      // 
      // btnMotionCtlSave
      // 
      this.btnMotionCtlSave.Location = new System.Drawing.Point(6, 254);
      this.btnMotionCtlSave.Name = "btnMotionCtlSave";
      this.btnMotionCtlSave.Size = new System.Drawing.Size(106, 21);
      this.btnMotionCtlSave.TabIndex = 15;
      this.btnMotionCtlSave.Text = "Set";
      this.btnMotionCtlSave.UseVisualStyleBackColor = true;
      this.btnMotionCtlSave.Click += new System.EventHandler(this.btnMotionCtlSave_Click);
      // 
      // gbSetPwmDir
      // 
      this.gbSetPwmDir.Controls.Add(this.lblSetPwmDir);
      this.gbSetPwmDir.Controls.Add(this.lblSetPwmDuty);
      this.gbSetPwmDir.Controls.Add(this.nudSetPWM);
      this.gbSetPwmDir.Controls.Add(this.rbSetPwmCCW);
      this.gbSetPwmDir.Controls.Add(this.rbSetPwmCW);
      this.gbSetPwmDir.Controls.Add(this.rbSetPwmOff);
      this.gbSetPwmDir.Location = new System.Drawing.Point(6, 140);
      this.gbSetPwmDir.Name = "gbSetPwmDir";
      this.gbSetPwmDir.Size = new System.Drawing.Size(106, 85);
      this.gbSetPwmDir.TabIndex = 13;
      this.gbSetPwmDir.TabStop = false;
      this.gbSetPwmDir.Text = "PWM";
      // 
      // lblSetPwmDir
      // 
      this.lblSetPwmDir.AutoSize = true;
      this.lblSetPwmDir.Location = new System.Drawing.Point(11, 14);
      this.lblSetPwmDir.Name = "lblSetPwmDir";
      this.lblSetPwmDir.Size = new System.Drawing.Size(23, 13);
      this.lblSetPwmDir.TabIndex = 15;
      this.lblSetPwmDir.Text = "Dir:";
      // 
      // lblSetPwmDuty
      // 
      this.lblSetPwmDuty.AutoSize = true;
      this.lblSetPwmDuty.Location = new System.Drawing.Point(60, 14);
      this.lblSetPwmDuty.Name = "lblSetPwmDuty";
      this.lblSetPwmDuty.Size = new System.Drawing.Size(32, 13);
      this.lblSetPwmDuty.TabIndex = 14;
      this.lblSetPwmDuty.Text = "Duty:";
      // 
      // nudSetPWM
      // 
      this.nudSetPWM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.nudSetPWM.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.nudSetPWM.Location = new System.Drawing.Point(55, 30);
      this.nudSetPWM.Name = "nudSetPWM";
      this.nudSetPWM.Size = new System.Drawing.Size(45, 20);
      this.nudSetPWM.TabIndex = 13;
      // 
      // rbSetPwmCCW
      // 
      this.rbSetPwmCCW.AutoSize = true;
      this.rbSetPwmCCW.Location = new System.Drawing.Point(6, 62);
      this.rbSetPwmCCW.Name = "rbSetPwmCCW";
      this.rbSetPwmCCW.Size = new System.Drawing.Size(47, 17);
      this.rbSetPwmCCW.TabIndex = 2;
      this.rbSetPwmCCW.Text = "DEC";
      this.rbSetPwmCCW.UseVisualStyleBackColor = true;
      // 
      // rbSetPwmCW
      // 
      this.rbSetPwmCW.AutoSize = true;
      this.rbSetPwmCW.Location = new System.Drawing.Point(6, 46);
      this.rbSetPwmCW.Name = "rbSetPwmCW";
      this.rbSetPwmCW.Size = new System.Drawing.Size(43, 17);
      this.rbSetPwmCW.TabIndex = 1;
      this.rbSetPwmCW.Text = "INC";
      this.rbSetPwmCW.UseVisualStyleBackColor = true;
      // 
      // rbSetPwmOff
      // 
      this.rbSetPwmOff.AutoSize = true;
      this.rbSetPwmOff.Checked = true;
      this.rbSetPwmOff.Location = new System.Drawing.Point(6, 30);
      this.rbSetPwmOff.Name = "rbSetPwmOff";
      this.rbSetPwmOff.Size = new System.Drawing.Size(39, 17);
      this.rbSetPwmOff.TabIndex = 0;
      this.rbSetPwmOff.TabStop = true;
      this.rbSetPwmOff.Text = "Off";
      this.rbSetPwmOff.UseVisualStyleBackColor = true;
      // 
      // lblSetAcc
      // 
      this.lblSetAcc.AutoSize = true;
      this.lblSetAcc.Location = new System.Drawing.Point(6, 100);
      this.lblSetAcc.Name = "lblSetAcc";
      this.lblSetAcc.Size = new System.Drawing.Size(92, 13);
      this.lblSetAcc.TabIndex = 11;
      this.lblSetAcc.Text = "Acc (enc/secsec)";
      // 
      // lblSetVel
      // 
      this.lblSetVel.AutoSize = true;
      this.lblSetVel.Location = new System.Drawing.Point(6, 60);
      this.lblSetVel.Name = "lblSetVel";
      this.lblSetVel.Size = new System.Drawing.Size(71, 13);
      this.lblSetVel.TabIndex = 10;
      this.lblSetVel.Text = "Vel (enc/sec)";
      // 
      // lblSetPos
      // 
      this.lblSetPos.AutoSize = true;
      this.lblSetPos.Location = new System.Drawing.Point(6, 20);
      this.lblSetPos.Name = "lblSetPos";
      this.lblSetPos.Size = new System.Drawing.Size(89, 13);
      this.lblSetPos.TabIndex = 9;
      this.lblSetPos.Text = "Position (enc cnt)";
      // 
      // nudSetVel
      // 
      this.nudSetVel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.nudSetVel.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.nudSetVel.Location = new System.Drawing.Point(8, 75);
      this.nudSetVel.Maximum = new decimal(new int[] {
            524287,
            0,
            0,
            0});
      this.nudSetVel.Minimum = new decimal(new int[] {
            524288,
            0,
            0,
            -2147483648});
      this.nudSetVel.Name = "nudSetVel";
      this.nudSetVel.Size = new System.Drawing.Size(100, 20);
      this.nudSetVel.TabIndex = 5;
      // 
      // nudSetPos
      // 
      this.nudSetPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.nudSetPos.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.nudSetPos.Location = new System.Drawing.Point(8, 35);
      this.nudSetPos.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
      this.nudSetPos.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
      this.nudSetPos.Name = "nudSetPos";
      this.nudSetPos.Size = new System.Drawing.Size(100, 20);
      this.nudSetPos.TabIndex = 4;
      // 
      // nudSetAcc
      // 
      this.nudSetAcc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.nudSetAcc.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
      this.nudSetAcc.Location = new System.Drawing.Point(8, 115);
      this.nudSetAcc.Maximum = new decimal(new int[] {
            16777216,
            0,
            0,
            0});
      this.nudSetAcc.Name = "nudSetAcc";
      this.nudSetAcc.Size = new System.Drawing.Size(100, 20);
      this.nudSetAcc.TabIndex = 6;
      // 
      // gbSetServoControl
      // 
      this.gbSetServoControl.Controls.Add(this.lblEncDiv);
      this.gbSetServoControl.Controls.Add(this.cboSetEncDiv);
      this.gbSetServoControl.Controls.Add(this.btnServoCtlLoad);
      this.gbSetServoControl.Controls.Add(this.gbSetMotorDone);
      this.gbSetServoControl.Controls.Add(this.btnServoCtlSave);
      this.gbSetServoControl.Controls.Add(this.gbSetGPIO);
      this.gbSetServoControl.Controls.Add(this.gbSetKick);
      this.gbSetServoControl.Controls.Add(this.lblPWMRate);
      this.gbSetServoControl.Controls.Add(this.lblHBridge);
      this.gbSetServoControl.Controls.Add(this.lblServoRate);
      this.gbSetServoControl.Controls.Add(this.cboSetPWMRate);
      this.gbSetServoControl.Controls.Add(this.cboSetHBridge);
      this.gbSetServoControl.Controls.Add(this.cboSetServoRate);
      this.gbSetServoControl.Location = new System.Drawing.Point(3, 6);
      this.gbSetServoControl.Name = "gbSetServoControl";
      this.gbSetServoControl.Size = new System.Drawing.Size(118, 481);
      this.gbSetServoControl.TabIndex = 10;
      this.gbSetServoControl.TabStop = false;
      this.gbSetServoControl.Text = "Servo Control";
      // 
      // lblEncDiv
      // 
      this.lblEncDiv.AutoSize = true;
      this.lblEncDiv.Location = new System.Drawing.Point(6, 139);
      this.lblEncDiv.Name = "lblEncDiv";
      this.lblEncDiv.Size = new System.Drawing.Size(83, 13);
      this.lblEncDiv.TabIndex = 16;
      this.lblEncDiv.Text = "Encoder Divider";
      // 
      // cboSetEncDiv
      // 
      this.cboSetEncDiv.FormattingEnabled = true;
      this.cboSetEncDiv.Location = new System.Drawing.Point(8, 154);
      this.cboSetEncDiv.Name = "cboSetEncDiv";
      this.cboSetEncDiv.Size = new System.Drawing.Size(100, 21);
      this.cboSetEncDiv.TabIndex = 15;
      this.cboSetEncDiv.Text = "cboSetEncDiv";
      // 
      // btnServoCtlLoad
      // 
      this.btnServoCtlLoad.Location = new System.Drawing.Point(6, 454);
      this.btnServoCtlLoad.Name = "btnServoCtlLoad";
      this.btnServoCtlLoad.Size = new System.Drawing.Size(106, 21);
      this.btnServoCtlLoad.TabIndex = 10;
      this.btnServoCtlLoad.Text = "Get";
      this.btnServoCtlLoad.UseVisualStyleBackColor = true;
      this.btnServoCtlLoad.Click += new System.EventHandler(this.btnServoCtlLoad_Click);
      // 
      // gbSetMotorDone
      // 
      this.gbSetMotorDone.Controls.Add(this.rbSetPowerOff);
      this.gbSetMotorDone.Controls.Add(this.rbSetPowerOn);
      this.gbSetMotorDone.Location = new System.Drawing.Point(6, 181);
      this.gbSetMotorDone.Name = "gbSetMotorDone";
      this.gbSetMotorDone.Size = new System.Drawing.Size(106, 58);
      this.gbSetMotorDone.TabIndex = 14;
      this.gbSetMotorDone.TabStop = false;
      this.gbSetMotorDone.Text = "\'Move Done\'";
      // 
      // rbSetPowerOff
      // 
      this.rbSetPowerOff.AutoSize = true;
      this.rbSetPowerOff.Checked = true;
      this.rbSetPowerOff.Location = new System.Drawing.Point(19, 35);
      this.rbSetPowerOff.Name = "rbSetPowerOff";
      this.rbSetPowerOff.Size = new System.Drawing.Size(72, 17);
      this.rbSetPowerOff.TabIndex = 1;
      this.rbSetPowerOff.TabStop = true;
      this.rbSetPowerOff.Text = "Power Off";
      this.rbSetPowerOff.UseVisualStyleBackColor = true;
      // 
      // rbSetPowerOn
      // 
      this.rbSetPowerOn.AutoSize = true;
      this.rbSetPowerOn.Location = new System.Drawing.Point(19, 19);
      this.rbSetPowerOn.Name = "rbSetPowerOn";
      this.rbSetPowerOn.Size = new System.Drawing.Size(72, 17);
      this.rbSetPowerOn.TabIndex = 0;
      this.rbSetPowerOn.Text = "Power On";
      this.rbSetPowerOn.UseVisualStyleBackColor = true;
      // 
      // btnServoCtlSave
      // 
      this.btnServoCtlSave.Location = new System.Drawing.Point(6, 430);
      this.btnServoCtlSave.Name = "btnServoCtlSave";
      this.btnServoCtlSave.Size = new System.Drawing.Size(106, 21);
      this.btnServoCtlSave.TabIndex = 11;
      this.btnServoCtlSave.Text = "Set";
      this.btnServoCtlSave.UseVisualStyleBackColor = true;
      this.btnServoCtlSave.Click += new System.EventHandler(this.btnServoCtlSave_Click);
      // 
      // gbSetGPIO
      // 
      this.gbSetGPIO.Controls.Add(this.cbxGpioSuspendToggle);
      this.gbSetGPIO.Controls.Add(this.cbxGpioEnOut);
      this.gbSetGPIO.Controls.Add(this.rbSetGPIOLo);
      this.gbSetGPIO.Controls.Add(this.rbSetGPIOHi);
      this.gbSetGPIO.Location = new System.Drawing.Point(6, 318);
      this.gbSetGPIO.Name = "gbSetGPIO";
      this.gbSetGPIO.Size = new System.Drawing.Size(106, 106);
      this.gbSetGPIO.TabIndex = 13;
      this.gbSetGPIO.TabStop = false;
      this.gbSetGPIO.Text = "GPIO pin";
      // 
      // cbxGpioSuspendToggle
      // 
      this.cbxGpioSuspendToggle.AutoSize = true;
      this.cbxGpioSuspendToggle.Location = new System.Drawing.Point(6, 82);
      this.cbxGpioSuspendToggle.Name = "cbxGpioSuspendToggle";
      this.cbxGpioSuspendToggle.Size = new System.Drawing.Size(104, 17);
      this.cbxGpioSuspendToggle.TabIndex = 20;
      this.cbxGpioSuspendToggle.Text = "Suspend Toggle";
      this.cbxGpioSuspendToggle.UseVisualStyleBackColor = true;
      this.cbxGpioSuspendToggle.Visible = false;
      // 
      // cbxGpioEnOut
      // 
      this.cbxGpioEnOut.AutoSize = true;
      this.cbxGpioEnOut.Location = new System.Drawing.Point(19, 19);
      this.cbxGpioEnOut.Name = "cbxGpioEnOut";
      this.cbxGpioEnOut.Size = new System.Drawing.Size(58, 17);
      this.cbxGpioEnOut.TabIndex = 19;
      this.cbxGpioEnOut.Text = "Output";
      this.cbxGpioEnOut.UseVisualStyleBackColor = true;
      this.cbxGpioEnOut.CheckedChanged += new System.EventHandler(this.cbxGpioEnOut_CheckedChanged);
      // 
      // rbSetGPIOLo
      // 
      this.rbSetGPIOLo.AutoSize = true;
      this.rbSetGPIOLo.Checked = true;
      this.rbSetGPIOLo.Location = new System.Drawing.Point(19, 59);
      this.rbSetGPIOLo.Name = "rbSetGPIOLo";
      this.rbSetGPIOLo.Size = new System.Drawing.Size(45, 17);
      this.rbSetGPIOLo.TabIndex = 1;
      this.rbSetGPIOLo.TabStop = true;
      this.rbSetGPIOLo.Text = "Low";
      this.rbSetGPIOLo.UseVisualStyleBackColor = true;
      // 
      // rbSetGPIOHi
      // 
      this.rbSetGPIOHi.AutoSize = true;
      this.rbSetGPIOHi.Location = new System.Drawing.Point(19, 42);
      this.rbSetGPIOHi.Name = "rbSetGPIOHi";
      this.rbSetGPIOHi.Size = new System.Drawing.Size(47, 17);
      this.rbSetGPIOHi.TabIndex = 0;
      this.rbSetGPIOHi.Text = "High";
      this.rbSetGPIOHi.UseVisualStyleBackColor = true;
      // 
      // gbSetKick
      // 
      this.gbSetKick.Controls.Add(this.rbSetKickOff);
      this.gbSetKick.Controls.Add(this.rbSetKickOn);
      this.gbSetKick.Location = new System.Drawing.Point(6, 245);
      this.gbSetKick.Name = "gbSetKick";
      this.gbSetKick.Size = new System.Drawing.Size(106, 68);
      this.gbSetKick.TabIndex = 12;
      this.gbSetKick.TabStop = false;
      this.gbSetKick.Text = "\'Move Done\' Kick (Trapezoidal only)";
      // 
      // rbSetKickOff
      // 
      this.rbSetKickOff.AutoSize = true;
      this.rbSetKickOff.Checked = true;
      this.rbSetKickOff.Location = new System.Drawing.Point(19, 46);
      this.rbSetKickOff.Name = "rbSetKickOff";
      this.rbSetKickOff.Size = new System.Drawing.Size(39, 17);
      this.rbSetKickOff.TabIndex = 1;
      this.rbSetKickOff.TabStop = true;
      this.rbSetKickOff.Text = "Off";
      this.rbSetKickOff.UseVisualStyleBackColor = true;
      // 
      // rbSetKickOn
      // 
      this.rbSetKickOn.AutoSize = true;
      this.rbSetKickOn.Location = new System.Drawing.Point(19, 29);
      this.rbSetKickOn.Name = "rbSetKickOn";
      this.rbSetKickOn.Size = new System.Drawing.Size(39, 17);
      this.rbSetKickOn.TabIndex = 0;
      this.rbSetKickOn.Text = "On";
      this.rbSetKickOn.UseVisualStyleBackColor = true;
      // 
      // lblPWMRate
      // 
      this.lblPWMRate.AutoSize = true;
      this.lblPWMRate.Location = new System.Drawing.Point(6, 99);
      this.lblPWMRate.Name = "lblPWMRate";
      this.lblPWMRate.Size = new System.Drawing.Size(100, 13);
      this.lblPWMRate.TabIndex = 11;
      this.lblPWMRate.Text = "Hbridge PWM Rate";
      // 
      // lblHBridge
      // 
      this.lblHBridge.AutoSize = true;
      this.lblHBridge.Location = new System.Drawing.Point(6, 59);
      this.lblHBridge.Name = "lblHBridge";
      this.lblHBridge.Size = new System.Drawing.Size(45, 13);
      this.lblHBridge.TabIndex = 10;
      this.lblHBridge.Text = "HBridge";
      // 
      // lblServoRate
      // 
      this.lblServoRate.AutoSize = true;
      this.lblServoRate.Location = new System.Drawing.Point(6, 20);
      this.lblServoRate.Name = "lblServoRate";
      this.lblServoRate.Size = new System.Drawing.Size(58, 13);
      this.lblServoRate.TabIndex = 8;
      this.lblServoRate.Text = "ServoRate";
      // 
      // cboSetPWMRate
      // 
      this.cboSetPWMRate.FormattingEnabled = true;
      this.cboSetPWMRate.Location = new System.Drawing.Point(8, 115);
      this.cboSetPWMRate.Name = "cboSetPWMRate";
      this.cboSetPWMRate.Size = new System.Drawing.Size(100, 21);
      this.cboSetPWMRate.TabIndex = 7;
      this.cboSetPWMRate.Text = "cboSetPWMRate";
      // 
      // cboSetHBridge
      // 
      this.cboSetHBridge.FormattingEnabled = true;
      this.cboSetHBridge.Location = new System.Drawing.Point(8, 75);
      this.cboSetHBridge.Name = "cboSetHBridge";
      this.cboSetHBridge.Size = new System.Drawing.Size(100, 21);
      this.cboSetHBridge.TabIndex = 6;
      this.cboSetHBridge.Text = "cboSetHBridge";
      // 
      // cboSetServoRate
      // 
      this.cboSetServoRate.FormattingEnabled = true;
      this.cboSetServoRate.Location = new System.Drawing.Point(8, 35);
      this.cboSetServoRate.Name = "cboSetServoRate";
      this.cboSetServoRate.Size = new System.Drawing.Size(100, 21);
      this.cboSetServoRate.TabIndex = 4;
      this.cboSetServoRate.Text = "cboSetServoRate";
      // 
      // tabPageSetupFuzzy
      // 
      this.tabPageSetupFuzzy.Controls.Add(this.gbSetFuzzyRules);
      this.tabPageSetupFuzzy.Controls.Add(this.gbSetFuzzyMF);
      this.tabPageSetupFuzzy.Location = new System.Drawing.Point(4, 22);
      this.tabPageSetupFuzzy.Name = "tabPageSetupFuzzy";
      this.tabPageSetupFuzzy.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageSetupFuzzy.Size = new System.Drawing.Size(692, 493);
      this.tabPageSetupFuzzy.TabIndex = 1;
      this.tabPageSetupFuzzy.Text = "Fuzzy Tuning";
      this.tabPageSetupFuzzy.UseVisualStyleBackColor = true;
      // 
      // gbSetFuzzyRules
      // 
      this.gbSetFuzzyRules.Controls.Add(this.pnlFuzzyRules);
      this.gbSetFuzzyRules.Controls.Add(this.btnGetRules);
      this.gbSetFuzzyRules.Controls.Add(this.btnSetRules);
      this.gbSetFuzzyRules.Controls.Add(this.lblUnfocus);
      this.gbSetFuzzyRules.Location = new System.Drawing.Point(226, 3);
      this.gbSetFuzzyRules.Margin = new System.Windows.Forms.Padding(0);
      this.gbSetFuzzyRules.Name = "gbSetFuzzyRules";
      this.gbSetFuzzyRules.Padding = new System.Windows.Forms.Padding(0);
      this.gbSetFuzzyRules.Size = new System.Drawing.Size(461, 487);
      this.gbSetFuzzyRules.TabIndex = 16;
      this.gbSetFuzzyRules.TabStop = false;
      this.gbSetFuzzyRules.Text = "Fuzzy Rules";
      // 
      // pnlFuzzyRules
      // 
      this.pnlFuzzyRules.AutoScroll = true;
      this.pnlFuzzyRules.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlFuzzyRules.Controls.Add(this.lblRulesOutHeader);
      this.pnlFuzzyRules.Controls.Add(this.lblRulesSpdHeader);
      this.pnlFuzzyRules.Controls.Add(this.lblRulesPosHeader);
      this.pnlFuzzyRules.Controls.Add(this.lblFuzzyRule2);
      this.pnlFuzzyRules.Controls.Add(this.lblFuzzyRule1);
      this.pnlFuzzyRules.Controls.Add(this.lblFuzzyRule0);
      this.pnlFuzzyRules.Controls.Add(this.cbxFuzzyRule2);
      this.pnlFuzzyRules.Controls.Add(this.cbxFuzzyRule1);
      this.pnlFuzzyRules.Controls.Add(this.cbxFuzzyRule0);
      this.pnlFuzzyRules.Location = new System.Drawing.Point(6, 20);
      this.pnlFuzzyRules.Name = "pnlFuzzyRules";
      this.pnlFuzzyRules.Size = new System.Drawing.Size(380, 460);
      this.pnlFuzzyRules.TabIndex = 19;
      // 
      // lblRulesOutHeader
      // 
      this.lblRulesOutHeader.AutoSize = true;
      this.lblRulesOutHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblRulesOutHeader.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.lblRulesOutHeader.Location = new System.Drawing.Point(267, 3);
      this.lblRulesOutHeader.Name = "lblRulesOutHeader";
      this.lblRulesOutHeader.Size = new System.Drawing.Size(102, 12);
      this.lblRulesOutHeader.TabIndex = 27;
      this.lblRulesOutHeader.Text = "OUTPUT  (PWM DUTY)";
      // 
      // lblRulesSpdHeader
      // 
      this.lblRulesSpdHeader.AutoSize = true;
      this.lblRulesSpdHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblRulesSpdHeader.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.lblRulesSpdHeader.Location = new System.Drawing.Point(145, 3);
      this.lblRulesSpdHeader.Name = "lblRulesSpdHeader";
      this.lblRulesSpdHeader.Size = new System.Drawing.Size(87, 12);
      this.lblRulesSpdHeader.TabIndex = 26;
      this.lblRulesSpdHeader.Text = "SPEED  (CHANGE)";
      // 
      // lblRulesPosHeader
      // 
      this.lblRulesPosHeader.AutoSize = true;
      this.lblRulesPosHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblRulesPosHeader.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.lblRulesPosHeader.Location = new System.Drawing.Point(27, 3);
      this.lblRulesPosHeader.Name = "lblRulesPosHeader";
      this.lblRulesPosHeader.Size = new System.Drawing.Size(93, 12);
      this.lblRulesPosHeader.TabIndex = 25;
      this.lblRulesPosHeader.Text = "POSITION  (ERROR)";
      // 
      // lblFuzzyRule2
      // 
      this.lblFuzzyRule2.AutoSize = true;
      this.lblFuzzyRule2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblFuzzyRule2.Location = new System.Drawing.Point(233, 18);
      this.lblFuzzyRule2.Name = "lblFuzzyRule2";
      this.lblFuzzyRule2.Size = new System.Drawing.Size(30, 12);
      this.lblFuzzyRule2.TabIndex = 24;
      this.lblFuzzyRule2.Text = "THEN";
      this.lblFuzzyRule2.Visible = false;
      // 
      // lblFuzzyRule1
      // 
      this.lblFuzzyRule1.AutoSize = true;
      this.lblFuzzyRule1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblFuzzyRule1.Location = new System.Drawing.Point(115, 18);
      this.lblFuzzyRule1.Name = "lblFuzzyRule1";
      this.lblFuzzyRule1.Size = new System.Drawing.Size(26, 12);
      this.lblFuzzyRule1.TabIndex = 23;
      this.lblFuzzyRule1.Text = "AND";
      this.lblFuzzyRule1.Visible = false;
      // 
      // lblFuzzyRule0
      // 
      this.lblFuzzyRule0.AutoSize = true;
      this.lblFuzzyRule0.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblFuzzyRule0.Location = new System.Drawing.Point(10, 19);
      this.lblFuzzyRule0.Name = "lblFuzzyRule0";
      this.lblFuzzyRule0.Size = new System.Drawing.Size(14, 12);
      this.lblFuzzyRule0.TabIndex = 22;
      this.lblFuzzyRule0.Text = "IF";
      this.lblFuzzyRule0.Visible = false;
      // 
      // cbxFuzzyRule2
      // 
      this.cbxFuzzyRule2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cbxFuzzyRule2.FormattingEnabled = true;
      this.cbxFuzzyRule2.Location = new System.Drawing.Point(269, 15);
      this.cbxFuzzyRule2.Name = "cbxFuzzyRule2";
      this.cbxFuzzyRule2.Size = new System.Drawing.Size(80, 17);
      this.cbxFuzzyRule2.TabIndex = 21;
      this.cbxFuzzyRule2.Visible = false;
      // 
      // cbxFuzzyRule1
      // 
      this.cbxFuzzyRule1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cbxFuzzyRule1.FormattingEnabled = true;
      this.cbxFuzzyRule1.Location = new System.Drawing.Point(147, 15);
      this.cbxFuzzyRule1.Name = "cbxFuzzyRule1";
      this.cbxFuzzyRule1.Size = new System.Drawing.Size(80, 17);
      this.cbxFuzzyRule1.TabIndex = 20;
      this.cbxFuzzyRule1.Visible = false;
      // 
      // cbxFuzzyRule0
      // 
      this.cbxFuzzyRule0.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cbxFuzzyRule0.FormattingEnabled = true;
      this.cbxFuzzyRule0.Location = new System.Drawing.Point(29, 16);
      this.cbxFuzzyRule0.Name = "cbxFuzzyRule0";
      this.cbxFuzzyRule0.Size = new System.Drawing.Size(80, 17);
      this.cbxFuzzyRule0.TabIndex = 19;
      this.cbxFuzzyRule0.Visible = false;
      // 
      // btnGetRules
      // 
      this.btnGetRules.Location = new System.Drawing.Point(392, 98);
      this.btnGetRules.Name = "btnGetRules";
      this.btnGetRules.Size = new System.Drawing.Size(62, 70);
      this.btnGetRules.TabIndex = 2;
      this.btnGetRules.Text = "Load Rules from Target";
      this.btnGetRules.UseVisualStyleBackColor = true;
      this.btnGetRules.Click += new System.EventHandler(this.btnGetRules_Click);
      // 
      // btnSetRules
      // 
      this.btnSetRules.Location = new System.Drawing.Point(392, 20);
      this.btnSetRules.Name = "btnSetRules";
      this.btnSetRules.Size = new System.Drawing.Size(62, 70);
      this.btnSetRules.TabIndex = 1;
      this.btnSetRules.Text = "Store Rules to Target";
      this.btnSetRules.UseVisualStyleBackColor = true;
      this.btnSetRules.Click += new System.EventHandler(this.btnSetRules_Click);
      // 
      // lblUnfocus
      // 
      this.lblUnfocus.AutoSize = true;
      this.lblUnfocus.Location = new System.Drawing.Point(400, 25);
      this.lblUnfocus.Name = "lblUnfocus";
      this.lblUnfocus.Size = new System.Drawing.Size(47, 13);
      this.lblUnfocus.TabIndex = 25;
      this.lblUnfocus.Text = "Unfocus";
      // 
      // gbSetFuzzyMF
      // 
      this.gbSetFuzzyMF.Controls.Add(this.cbxMemFuncCtlPts);
      this.gbSetFuzzyMF.Controls.Add(this.lblMemPos0);
      this.gbSetFuzzyMF.Controls.Add(this.tbxPosMem_0_0);
      this.gbSetFuzzyMF.Controls.Add(this.lblPosErrMF);
      this.gbSetFuzzyMF.Controls.Add(this.btnGetMF);
      this.gbSetFuzzyMF.Controls.Add(this.lblSpdMF);
      this.gbSetFuzzyMF.Controls.Add(this.btnSetMF);
      this.gbSetFuzzyMF.Controls.Add(this.lblPosOutSing);
      this.gbSetFuzzyMF.Controls.Add(this.gbPosCtlPts);
      this.gbSetFuzzyMF.Location = new System.Drawing.Point(6, 3);
      this.gbSetFuzzyMF.Name = "gbSetFuzzyMF";
      this.gbSetFuzzyMF.Size = new System.Drawing.Size(217, 484);
      this.gbSetFuzzyMF.TabIndex = 15;
      this.gbSetFuzzyMF.TabStop = false;
      this.gbSetFuzzyMF.Text = "Fuzzy Membership Functions";
      // 
      // cbxMemFuncCtlPts
      // 
      this.cbxMemFuncCtlPts.AutoSize = true;
      this.cbxMemFuncCtlPts.Location = new System.Drawing.Point(9, 403);
      this.cbxMemFuncCtlPts.Name = "cbxMemFuncCtlPts";
      this.cbxMemFuncCtlPts.Size = new System.Drawing.Size(107, 17);
      this.cbxMemFuncCtlPts.TabIndex = 36;
      this.cbxMemFuncCtlPts.Text = "Symmetric Ctl Pts";
      this.cbxMemFuncCtlPts.UseVisualStyleBackColor = true;
      this.cbxMemFuncCtlPts.CheckedChanged += new System.EventHandler(this.cbxMemFuncCtlPts_CheckedChanged);
      // 
      // lblMemPos0
      // 
      this.lblMemPos0.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblMemPos0.Location = new System.Drawing.Point(2, 40);
      this.lblMemPos0.Name = "lblMemPos0";
      this.lblMemPos0.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.lblMemPos0.Size = new System.Drawing.Size(54, 12);
      this.lblMemPos0.TabIndex = 34;
      this.lblMemPos0.Text = "NEGLRG";
      this.lblMemPos0.Visible = false;
      // 
      // tbxPosMem_0_0
      // 
      this.tbxPosMem_0_0.Location = new System.Drawing.Point(56, 36);
      this.tbxPosMem_0_0.Name = "tbxPosMem_0_0";
      this.tbxPosMem_0_0.Size = new System.Drawing.Size(20, 20);
      this.tbxPosMem_0_0.TabIndex = 13;
      this.tbxPosMem_0_0.Text = "FF";
      this.tbxPosMem_0_0.Visible = false;
      // 
      // lblPosErrMF
      // 
      this.lblPosErrMF.AutoSize = true;
      this.lblPosErrMF.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.lblPosErrMF.Location = new System.Drawing.Point(12, 18);
      this.lblPosErrMF.Name = "lblPosErrMF";
      this.lblPosErrMF.Size = new System.Drawing.Size(123, 13);
      this.lblPosErrMF.TabIndex = 3;
      this.lblPosErrMF.Text = "POSITION FUNCTIONS";
      // 
      // btnGetMF
      // 
      this.btnGetMF.Location = new System.Drawing.Point(5, 454);
      this.btnGetMF.Name = "btnGetMF";
      this.btnGetMF.Size = new System.Drawing.Size(206, 22);
      this.btnGetMF.TabIndex = 8;
      this.btnGetMF.Text = "Load Functions from Target";
      this.btnGetMF.UseVisualStyleBackColor = true;
      this.btnGetMF.Click += new System.EventHandler(this.btnGetMF_Click);
      // 
      // lblSpdMF
      // 
      this.lblSpdMF.AutoSize = true;
      this.lblSpdMF.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.lblSpdMF.Location = new System.Drawing.Point(12, 150);
      this.lblSpdMF.Name = "lblSpdMF";
      this.lblSpdMF.Size = new System.Drawing.Size(108, 13);
      this.lblSpdMF.TabIndex = 4;
      this.lblSpdMF.Text = "SPEED FUNCTIONS";
      // 
      // btnSetMF
      // 
      this.btnSetMF.Location = new System.Drawing.Point(6, 426);
      this.btnSetMF.Name = "btnSetMF";
      this.btnSetMF.Size = new System.Drawing.Size(205, 22);
      this.btnSetMF.TabIndex = 7;
      this.btnSetMF.Text = "Store Functions to Target ";
      this.btnSetMF.UseVisualStyleBackColor = true;
      this.btnSetMF.Click += new System.EventHandler(this.btnSetMF_Click);
      // 
      // lblPosOutSing
      // 
      this.lblPosOutSing.AutoSize = true;
      this.lblPosOutSing.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.lblPosOutSing.Location = new System.Drawing.Point(12, 280);
      this.lblPosOutSing.Name = "lblPosOutSing";
      this.lblPosOutSing.Size = new System.Drawing.Size(117, 13);
      this.lblPosOutSing.TabIndex = 5;
      this.lblPosOutSing.Text = "OUTPUT SINGLETON";
      // 
      // gbPosCtlPts
      // 
      this.gbPosCtlPts.Controls.Add(this.lblPosOutCtlPtB);
      this.gbPosCtlPts.Controls.Add(this.tbxPosOutCtlPtB);
      this.gbPosCtlPts.Controls.Add(this.lblPosOutCtlPtA);
      this.gbPosCtlPts.Controls.Add(this.tbxPosOutCtlPtA);
      this.gbPosCtlPts.Controls.Add(this.lblSpdCtlPtB);
      this.gbPosCtlPts.Controls.Add(this.tbxSpdCtlPtB);
      this.gbPosCtlPts.Controls.Add(this.lblSpdCtlPtA);
      this.gbPosCtlPts.Controls.Add(this.tbxSpdCtlPtA);
      this.gbPosCtlPts.Controls.Add(this.lblPosErrCtlPtB);
      this.gbPosCtlPts.Controls.Add(this.tbxPosErrCtlPtB);
      this.gbPosCtlPts.Controls.Add(this.lblPosErrCtlPtA);
      this.gbPosCtlPts.Controls.Add(this.tbxPosErrCtlPtA);
      this.gbPosCtlPts.Location = new System.Drawing.Point(158, 14);
      this.gbPosCtlPts.Name = "gbPosCtlPts";
      this.gbPosCtlPts.Size = new System.Drawing.Size(53, 406);
      this.gbPosCtlPts.TabIndex = 6;
      this.gbPosCtlPts.TabStop = false;
      this.gbPosCtlPts.Text = "Ctl Pts";
      // 
      // lblPosOutCtlPtB
      // 
      this.lblPosOutCtlPtB.AutoSize = true;
      this.lblPosOutCtlPtB.Location = new System.Drawing.Point(32, 306);
      this.lblPosOutCtlPtB.Name = "lblPosOutCtlPtB";
      this.lblPosOutCtlPtB.Size = new System.Drawing.Size(14, 13);
      this.lblPosOutCtlPtB.TabIndex = 11;
      this.lblPosOutCtlPtB.Text = "B";
      // 
      // tbxPosOutCtlPtB
      // 
      this.tbxPosOutCtlPtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbxPosOutCtlPtB.Location = new System.Drawing.Point(6, 304);
      this.tbxPosOutCtlPtB.Name = "tbxPosOutCtlPtB";
      this.tbxPosOutCtlPtB.Size = new System.Drawing.Size(20, 18);
      this.tbxPosOutCtlPtB.TabIndex = 8;
      this.tbxPosOutCtlPtB.TextChanged += new System.EventHandler(this.tbxPosOutCtlPtB_TextChanged);
      this.tbxPosOutCtlPtB.LostFocus += new System.EventHandler(this.OutCtlPoint_LostFocus);
      // 
      // lblPosOutCtlPtA
      // 
      this.lblPosOutCtlPtA.AutoSize = true;
      this.lblPosOutCtlPtA.Location = new System.Drawing.Point(32, 284);
      this.lblPosOutCtlPtA.Name = "lblPosOutCtlPtA";
      this.lblPosOutCtlPtA.Size = new System.Drawing.Size(14, 13);
      this.lblPosOutCtlPtA.TabIndex = 9;
      this.lblPosOutCtlPtA.Text = "A";
      // 
      // tbxPosOutCtlPtA
      // 
      this.tbxPosOutCtlPtA.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbxPosOutCtlPtA.Location = new System.Drawing.Point(6, 280);
      this.tbxPosOutCtlPtA.Name = "tbxPosOutCtlPtA";
      this.tbxPosOutCtlPtA.Size = new System.Drawing.Size(20, 18);
      this.tbxPosOutCtlPtA.TabIndex = 8;
      this.tbxPosOutCtlPtA.TextChanged += new System.EventHandler(this.tbxPosOutCtlPtA_TextChanged);
      this.tbxPosOutCtlPtA.LostFocus += new System.EventHandler(this.OutCtlPoint_LostFocus);
      // 
      // lblSpdCtlPtB
      // 
      this.lblSpdCtlPtB.AutoSize = true;
      this.lblSpdCtlPtB.Location = new System.Drawing.Point(32, 176);
      this.lblSpdCtlPtB.Name = "lblSpdCtlPtB";
      this.lblSpdCtlPtB.Size = new System.Drawing.Size(14, 13);
      this.lblSpdCtlPtB.TabIndex = 7;
      this.lblSpdCtlPtB.Text = "B";
      // 
      // tbxSpdCtlPtB
      // 
      this.tbxSpdCtlPtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbxSpdCtlPtB.Location = new System.Drawing.Point(6, 174);
      this.tbxSpdCtlPtB.Name = "tbxSpdCtlPtB";
      this.tbxSpdCtlPtB.Size = new System.Drawing.Size(20, 18);
      this.tbxSpdCtlPtB.TabIndex = 6;
      this.tbxSpdCtlPtB.TextChanged += new System.EventHandler(this.tbxSpdCtlPtB_TextChanged);
      this.tbxSpdCtlPtB.LostFocus += new System.EventHandler(this.SpdCtlPoint_LostFocus);
      // 
      // lblSpdCtlPtA
      // 
      this.lblSpdCtlPtA.AutoSize = true;
      this.lblSpdCtlPtA.Location = new System.Drawing.Point(32, 153);
      this.lblSpdCtlPtA.Name = "lblSpdCtlPtA";
      this.lblSpdCtlPtA.Size = new System.Drawing.Size(14, 13);
      this.lblSpdCtlPtA.TabIndex = 5;
      this.lblSpdCtlPtA.Text = "A";
      // 
      // tbxSpdCtlPtA
      // 
      this.tbxSpdCtlPtA.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbxSpdCtlPtA.Location = new System.Drawing.Point(6, 150);
      this.tbxSpdCtlPtA.Name = "tbxSpdCtlPtA";
      this.tbxSpdCtlPtA.Size = new System.Drawing.Size(20, 18);
      this.tbxSpdCtlPtA.TabIndex = 4;
      this.tbxSpdCtlPtA.TextChanged += new System.EventHandler(this.tbxSpdCtlPtA_TextChanged);
      this.tbxSpdCtlPtA.LostFocus += new System.EventHandler(this.SpdCtlPoint_LostFocus);
      // 
      // lblPosErrCtlPtB
      // 
      this.lblPosErrCtlPtB.AutoSize = true;
      this.lblPosErrCtlPtB.Location = new System.Drawing.Point(32, 46);
      this.lblPosErrCtlPtB.Name = "lblPosErrCtlPtB";
      this.lblPosErrCtlPtB.Size = new System.Drawing.Size(14, 13);
      this.lblPosErrCtlPtB.TabIndex = 3;
      this.lblPosErrCtlPtB.Text = "B";
      // 
      // tbxPosErrCtlPtB
      // 
      this.tbxPosErrCtlPtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbxPosErrCtlPtB.Location = new System.Drawing.Point(6, 44);
      this.tbxPosErrCtlPtB.Name = "tbxPosErrCtlPtB";
      this.tbxPosErrCtlPtB.Size = new System.Drawing.Size(20, 18);
      this.tbxPosErrCtlPtB.TabIndex = 2;
      this.tbxPosErrCtlPtB.TextChanged += new System.EventHandler(this.tbxPosErrCtlPtB_TextChanged);
      this.tbxPosErrCtlPtB.LostFocus += new System.EventHandler(this.PosCtlPoint_LostFocus);
      // 
      // lblPosErrCtlPtA
      // 
      this.lblPosErrCtlPtA.AutoSize = true;
      this.lblPosErrCtlPtA.Location = new System.Drawing.Point(32, 24);
      this.lblPosErrCtlPtA.Name = "lblPosErrCtlPtA";
      this.lblPosErrCtlPtA.Size = new System.Drawing.Size(14, 13);
      this.lblPosErrCtlPtA.TabIndex = 1;
      this.lblPosErrCtlPtA.Text = "A";
      // 
      // tbxPosErrCtlPtA
      // 
      this.tbxPosErrCtlPtA.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbxPosErrCtlPtA.Location = new System.Drawing.Point(6, 20);
      this.tbxPosErrCtlPtA.Name = "tbxPosErrCtlPtA";
      this.tbxPosErrCtlPtA.Size = new System.Drawing.Size(20, 18);
      this.tbxPosErrCtlPtA.TabIndex = 0;
      this.tbxPosErrCtlPtA.TextChanged += new System.EventHandler(this.tbxPosErrCtlPtA_TextChanged);
      this.tbxPosErrCtlPtA.LostFocus += new System.EventHandler(this.PosCtlPoint_LostFocus);
      // 
      // tabPageServoStats
      // 
      this.tabPageServoStats.Controls.Add(this.gbStatCtlPts);
      this.tabPageServoStats.Controls.Add(this.gbStatTypes);
      this.tabPageServoStats.Controls.Add(this.cbxShowStatsPrev);
      this.tabPageServoStats.Controls.Add(this.btnStoreStats);
      this.tabPageServoStats.Controls.Add(this.pnlStats);
      this.tabPageServoStats.Controls.Add(this.btnGetStats);
      this.tabPageServoStats.Controls.Add(this.tbxStats);
      this.tabPageServoStats.Location = new System.Drawing.Point(4, 22);
      this.tabPageServoStats.Name = "tabPageServoStats";
      this.tabPageServoStats.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageServoStats.Size = new System.Drawing.Size(692, 493);
      this.tabPageServoStats.TabIndex = 2;
      this.tabPageServoStats.Text = "Statistics";
      this.tabPageServoStats.UseVisualStyleBackColor = true;
      // 
      // gbStatCtlPts
      // 
      this.gbStatCtlPts.Controls.Add(this.label8);
      this.gbStatCtlPts.Controls.Add(this.label7);
      this.gbStatCtlPts.Controls.Add(this.lblStatPosCtlPt);
      this.gbStatCtlPts.Controls.Add(this.label3);
      this.gbStatCtlPts.Controls.Add(this.tbxStatOutCtlPtB);
      this.gbStatCtlPts.Controls.Add(this.label4);
      this.gbStatCtlPts.Controls.Add(this.tbxStatOutCtlPtA);
      this.gbStatCtlPts.Controls.Add(this.label1);
      this.gbStatCtlPts.Controls.Add(this.tbxStatSpdCtlPtB);
      this.gbStatCtlPts.Controls.Add(this.label2);
      this.gbStatCtlPts.Controls.Add(this.tbxStatSpdCtlPtA);
      this.gbStatCtlPts.Controls.Add(this.label5);
      this.gbStatCtlPts.Controls.Add(this.tbxStatPosCtlPtB);
      this.gbStatCtlPts.Controls.Add(this.label6);
      this.gbStatCtlPts.Controls.Add(this.tbxStatPosCtlPtA);
      this.gbStatCtlPts.Location = new System.Drawing.Point(248, 328);
      this.gbStatCtlPts.Name = "gbStatCtlPts";
      this.gbStatCtlPts.Size = new System.Drawing.Size(107, 151);
      this.gbStatCtlPts.TabIndex = 8;
      this.gbStatCtlPts.TabStop = false;
      this.gbStatCtlPts.Text = "Symmetric Ctl Pts";
      this.gbStatCtlPts.Visible = false;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(50, 114);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(39, 13);
      this.label8.TabIndex = 14;
      this.label8.Text = "Output";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(50, 72);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(38, 13);
      this.label7.TabIndex = 13;
      this.label7.Text = "Speed";
      // 
      // lblStatPosCtlPt
      // 
      this.lblStatPosCtlPt.AutoSize = true;
      this.lblStatPosCtlPt.Location = new System.Drawing.Point(50, 30);
      this.lblStatPosCtlPt.Name = "lblStatPosCtlPt";
      this.lblStatPosCtlPt.Size = new System.Drawing.Size(44, 13);
      this.lblStatPosCtlPt.TabIndex = 12;
      this.lblStatPosCtlPt.Text = "Position";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(28, 124);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(14, 13);
      this.label3.TabIndex = 11;
      this.label3.Text = "B";
      // 
      // tbxStatOutCtlPtB
      // 
      this.tbxStatOutCtlPtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbxStatOutCtlPtB.Location = new System.Drawing.Point(6, 122);
      this.tbxStatOutCtlPtB.Name = "tbxStatOutCtlPtB";
      this.tbxStatOutCtlPtB.ReadOnly = true;
      this.tbxStatOutCtlPtB.Size = new System.Drawing.Size(20, 18);
      this.tbxStatOutCtlPtB.TabIndex = 10;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(28, 109);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(14, 13);
      this.label4.TabIndex = 9;
      this.label4.Text = "A";
      // 
      // tbxStatOutCtlPtA
      // 
      this.tbxStatOutCtlPtA.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbxStatOutCtlPtA.Location = new System.Drawing.Point(6, 104);
      this.tbxStatOutCtlPtA.Name = "tbxStatOutCtlPtA";
      this.tbxStatOutCtlPtA.ReadOnly = true;
      this.tbxStatOutCtlPtA.Size = new System.Drawing.Size(20, 18);
      this.tbxStatOutCtlPtA.TabIndex = 8;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(28, 82);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(14, 13);
      this.label1.TabIndex = 7;
      this.label1.Text = "B";
      // 
      // tbxStatSpdCtlPtB
      // 
      this.tbxStatSpdCtlPtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbxStatSpdCtlPtB.Location = new System.Drawing.Point(6, 80);
      this.tbxStatSpdCtlPtB.Name = "tbxStatSpdCtlPtB";
      this.tbxStatSpdCtlPtB.ReadOnly = true;
      this.tbxStatSpdCtlPtB.Size = new System.Drawing.Size(20, 18);
      this.tbxStatSpdCtlPtB.TabIndex = 6;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(28, 67);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(14, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "A";
      // 
      // tbxStatSpdCtlPtA
      // 
      this.tbxStatSpdCtlPtA.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbxStatSpdCtlPtA.Location = new System.Drawing.Point(6, 62);
      this.tbxStatSpdCtlPtA.Name = "tbxStatSpdCtlPtA";
      this.tbxStatSpdCtlPtA.ReadOnly = true;
      this.tbxStatSpdCtlPtA.Size = new System.Drawing.Size(20, 18);
      this.tbxStatSpdCtlPtA.TabIndex = 4;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(28, 40);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(14, 13);
      this.label5.TabIndex = 3;
      this.label5.Text = "B";
      // 
      // tbxStatPosCtlPtB
      // 
      this.tbxStatPosCtlPtB.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbxStatPosCtlPtB.Location = new System.Drawing.Point(6, 38);
      this.tbxStatPosCtlPtB.Name = "tbxStatPosCtlPtB";
      this.tbxStatPosCtlPtB.ReadOnly = true;
      this.tbxStatPosCtlPtB.Size = new System.Drawing.Size(20, 18);
      this.tbxStatPosCtlPtB.TabIndex = 2;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(28, 25);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(14, 13);
      this.label6.TabIndex = 1;
      this.label6.Text = "A";
      // 
      // tbxStatPosCtlPtA
      // 
      this.tbxStatPosCtlPtA.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.tbxStatPosCtlPtA.Location = new System.Drawing.Point(6, 20);
      this.tbxStatPosCtlPtA.Name = "tbxStatPosCtlPtA";
      this.tbxStatPosCtlPtA.ReadOnly = true;
      this.tbxStatPosCtlPtA.Size = new System.Drawing.Size(20, 18);
      this.tbxStatPosCtlPtA.TabIndex = 0;
      // 
      // gbStatTypes
      // 
      this.gbStatTypes.Controls.Add(this.cbxStatInfoDuty);
      this.gbStatTypes.Controls.Add(this.cbxStatInfoChange);
      this.gbStatTypes.Controls.Add(this.cbxStatInfoErr);
      this.gbStatTypes.Location = new System.Drawing.Point(92, 328);
      this.gbStatTypes.Name = "gbStatTypes";
      this.gbStatTypes.Size = new System.Drawing.Size(150, 151);
      this.gbStatTypes.TabIndex = 7;
      this.gbStatTypes.TabStop = false;
      this.gbStatTypes.Text = "Statistic Fields";
      // 
      // cbxStatInfoDuty
      // 
      this.cbxStatInfoDuty.AutoSize = true;
      this.cbxStatInfoDuty.Location = new System.Drawing.Point(7, 104);
      this.cbxStatInfoDuty.Name = "cbxStatInfoDuty";
      this.cbxStatInfoDuty.Size = new System.Drawing.Size(93, 17);
      this.cbxStatInfoDuty.TabIndex = 2;
      this.cbxStatInfoDuty.Text = "Output (black)";
      this.cbxStatInfoDuty.UseVisualStyleBackColor = true;
      this.cbxStatInfoDuty.CheckedChanged += new System.EventHandler(this.cbxStatInfoDuty_CheckedChanged);
      // 
      // cbxStatInfoChange
      // 
      this.cbxStatInfoChange.AutoSize = true;
      this.cbxStatInfoChange.Location = new System.Drawing.Point(7, 62);
      this.cbxStatInfoChange.Name = "cbxStatInfoChange";
      this.cbxStatInfoChange.Size = new System.Drawing.Size(86, 17);
      this.cbxStatInfoChange.TabIndex = 1;
      this.cbxStatInfoChange.Text = "Speed (blue)";
      this.cbxStatInfoChange.UseVisualStyleBackColor = true;
      this.cbxStatInfoChange.CheckedChanged += new System.EventHandler(this.cbxStatInfoChange_CheckedChanged);
      // 
      // cbxStatInfoErr
      // 
      this.cbxStatInfoErr.AutoSize = true;
      this.cbxStatInfoErr.Checked = true;
      this.cbxStatInfoErr.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbxStatInfoErr.Location = new System.Drawing.Point(6, 20);
      this.cbxStatInfoErr.Name = "cbxStatInfoErr";
      this.cbxStatInfoErr.Size = new System.Drawing.Size(112, 17);
      this.cbxStatInfoErr.TabIndex = 0;
      this.cbxStatInfoErr.Text = "Position Error (red)";
      this.cbxStatInfoErr.UseVisualStyleBackColor = true;
      this.cbxStatInfoErr.CheckedChanged += new System.EventHandler(this.cbxStatInfoErr_CheckedChanged);
      // 
      // cbxShowStatsPrev
      // 
      this.cbxShowStatsPrev.AutoSize = true;
      this.cbxShowStatsPrev.Location = new System.Drawing.Point(340, 303);
      this.cbxShowStatsPrev.Name = "cbxShowStatsPrev";
      this.cbxShowStatsPrev.Size = new System.Drawing.Size(132, 17);
      this.cbxShowStatsPrev.TabIndex = 6;
      this.cbxShowStatsPrev.Text = "Show Stored Statistics";
      this.cbxShowStatsPrev.UseVisualStyleBackColor = true;
      this.cbxShowStatsPrev.Visible = false;
      this.cbxShowStatsPrev.CheckedChanged += new System.EventHandler(this.cbxShowStatsPrev_CheckedChanged);
      // 
      // btnStoreStats
      // 
      this.btnStoreStats.Location = new System.Drawing.Point(216, 299);
      this.btnStoreStats.Name = "btnStoreStats";
      this.btnStoreStats.Size = new System.Drawing.Size(118, 23);
      this.btnStoreStats.TabIndex = 5;
      this.btnStoreStats.Text = "Store Current Stats";
      this.btnStoreStats.UseVisualStyleBackColor = true;
      this.btnStoreStats.Click += new System.EventHandler(this.btnStoreStats_Click);
      // 
      // pnlStats
      // 
      this.pnlStats.AutoScroll = true;
      this.pnlStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlStats.Controls.Add(this.picbxStats);
      this.pnlStats.Location = new System.Drawing.Point(92, 6);
      this.pnlStats.Name = "pnlStats";
      this.pnlStats.Size = new System.Drawing.Size(599, 277);
      this.pnlStats.TabIndex = 2;
      this.pnlStats.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlStats_Paint);
      this.pnlStats.Scroll += new System.Windows.Forms.ScrollEventHandler(this.StatsHandleScroll);
      // 
      // picbxStats
      // 
      this.picbxStats.Location = new System.Drawing.Point(-1, 0);
      this.picbxStats.Name = "picbxStats";
      this.picbxStats.Size = new System.Drawing.Size(598, 257);
      this.picbxStats.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.picbxStats.TabIndex = 0;
      this.picbxStats.TabStop = false;
      // 
      // btnGetStats
      // 
      this.btnGetStats.Location = new System.Drawing.Point(92, 299);
      this.btnGetStats.Name = "btnGetStats";
      this.btnGetStats.Size = new System.Drawing.Size(118, 23);
      this.btnGetStats.TabIndex = 1;
      this.btnGetStats.Text = "Get Statistics";
      this.btnGetStats.UseVisualStyleBackColor = true;
      this.btnGetStats.Click += new System.EventHandler(this.btnGetStats_Click);
      // 
      // tbxStats
      // 
      this.tbxStats.Location = new System.Drawing.Point(6, 6);
      this.tbxStats.Multiline = true;
      this.tbxStats.Name = "tbxStats";
      this.tbxStats.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.tbxStats.Size = new System.Drawing.Size(80, 481);
      this.tbxStats.TabIndex = 0;
      this.tbxStats.Text = "tbxStats";
      // 
      // tabPageLog
      // 
      this.tabPageLog.Controls.Add(this.rtbMessageLog);
      this.tabPageLog.Controls.Add(this.btnMessageLogClear);
      this.tabPageLog.Location = new System.Drawing.Point(4, 22);
      this.tabPageLog.Name = "tabPageLog";
      this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
      this.tabPageLog.Size = new System.Drawing.Size(712, 550);
      this.tabPageLog.TabIndex = 1;
      this.tabPageLog.Text = "Log";
      this.tabPageLog.UseVisualStyleBackColor = true;
      // 
      // rtbMessageLog
      // 
      this.rtbMessageLog.Location = new System.Drawing.Point(6, 6);
      this.rtbMessageLog.Name = "rtbMessageLog";
      this.rtbMessageLog.Size = new System.Drawing.Size(700, 394);
      this.rtbMessageLog.TabIndex = 7;
      this.rtbMessageLog.Text = "";
      // 
      // btnMessageLogClear
      // 
      this.btnMessageLogClear.Location = new System.Drawing.Point(6, 406);
      this.btnMessageLogClear.Name = "btnMessageLogClear";
      this.btnMessageLogClear.Size = new System.Drawing.Size(75, 20);
      this.btnMessageLogClear.TabIndex = 8;
      this.btnMessageLogClear.Text = "Clear";
      this.btnMessageLogClear.UseVisualStyleBackColor = true;
      this.btnMessageLogClear.Click += new System.EventHandler(this.btnMessageLogClear_Click);
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenuItem,
            this.aboutToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(732, 24);
      this.menuStrip1.TabIndex = 45;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // openMenuItem
      // 
      this.openMenuItem.Name = "openMenuItem";
      this.openMenuItem.Size = new System.Drawing.Size(119, 20);
      this.openMenuItem.Text = "Open Servo Network";
      this.openMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
      // 
      // aboutToolStripMenuItem
      // 
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
      this.aboutToolStripMenuItem.Text = "About";
      this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.btnTestMotionStop;
      this.ClientSize = new System.Drawing.Size(732, 606);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.menuStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainForm";
      this.Text = "viTestApp";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.tabControl1.ResumeLayout(false);
      this.tabPageGateWay.ResumeLayout(false);
      this.gbStatus.ResumeLayout(false);
      this.gbStatus.PerformLayout();
      this.gbGatewayBitrate.ResumeLayout(false);
      this.gbGatewayVersion.ResumeLayout(false);
      this.gbGatewayVersion.PerformLayout();
      this.tabPageSetup.ResumeLayout(false);
      this.tabPageSetup.PerformLayout();
      this.tabServoSettings.ResumeLayout(false);
      this.tabPageSetupControl.ResumeLayout(false);
      this.gbRand.ResumeLayout(false);
      this.gbZero.ResumeLayout(false);
      this.gbxSleep.ResumeLayout(false);
      this.gbxSleep.PerformLayout();
      this.gbxGroup.ResumeLayout(false);
      this.gbxGroup.PerformLayout();
      this.gbxCfg.ResumeLayout(false);
      this.gbxCfg.PerformLayout();
      this.gbTestMotionStop.ResumeLayout(false);
      this.gbTestMotionStop.PerformLayout();
      this.gbSetupStatus.ResumeLayout(false);
      this.gbSetupStatus.PerformLayout();
      this.gbStatErrFlag.ResumeLayout(false);
      this.gbStatErrFlag.PerformLayout();
      this.gbStatLim.ResumeLayout(false);
      this.gbStatLim.PerformLayout();
      this.gbTestMotionStart.ResumeLayout(false);
      this.gbTestMotionStart.PerformLayout();
      this.gbSetLimit.ResumeLayout(false);
      this.gbxIRQEnable.ResumeLayout(false);
      this.gbxIRQEnable.PerformLayout();
      this.gbxSetATDLim.ResumeLayout(false);
      this.gbxSetATDLim.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudSetAtdLimDwell)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudSetAtdLimVal)).EndInit();
      this.gbSetEncIdx.ResumeLayout(false);
      this.gbSetEncIdx.PerformLayout();
      this.gbSetEncIdxHalt.ResumeLayout(false);
      this.gbSetEncIdxHalt.PerformLayout();
      this.gbSetEncIdxVal.ResumeLayout(false);
      this.gbSetEncIdxVal.PerformLayout();
      this.gbSetLimB.ResumeLayout(false);
      this.gbSetLimB.PerformLayout();
      this.gbSetLimBHalt.ResumeLayout(false);
      this.gbSetLimBHalt.PerformLayout();
      this.gbSetLimBVal.ResumeLayout(false);
      this.gbSetLimBVal.PerformLayout();
      this.gbSetLimA.ResumeLayout(false);
      this.gbSetLimA.PerformLayout();
      this.gbSetLimAHalt.ResumeLayout(false);
      this.gbSetLimAHalt.PerformLayout();
      this.gbSetLimAVal.ResumeLayout(false);
      this.gbSetLimAVal.PerformLayout();
      this.gbSetMotionControl.ResumeLayout(false);
      this.gbSetMotionControl.PerformLayout();
      this.gbSetPwmDir.ResumeLayout(false);
      this.gbSetPwmDir.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.nudSetPWM)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudSetVel)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudSetPos)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.nudSetAcc)).EndInit();
      this.gbSetServoControl.ResumeLayout(false);
      this.gbSetServoControl.PerformLayout();
      this.gbSetMotorDone.ResumeLayout(false);
      this.gbSetMotorDone.PerformLayout();
      this.gbSetGPIO.ResumeLayout(false);
      this.gbSetGPIO.PerformLayout();
      this.gbSetKick.ResumeLayout(false);
      this.gbSetKick.PerformLayout();
      this.tabPageSetupFuzzy.ResumeLayout(false);
      this.gbSetFuzzyRules.ResumeLayout(false);
      this.gbSetFuzzyRules.PerformLayout();
      this.pnlFuzzyRules.ResumeLayout(false);
      this.pnlFuzzyRules.PerformLayout();
      this.gbSetFuzzyMF.ResumeLayout(false);
      this.gbSetFuzzyMF.PerformLayout();
      this.gbPosCtlPts.ResumeLayout(false);
      this.gbPosCtlPts.PerformLayout();
      this.tabPageServoStats.ResumeLayout(false);
      this.tabPageServoStats.PerformLayout();
      this.gbStatCtlPts.ResumeLayout(false);
      this.gbStatCtlPts.PerformLayout();
      this.gbStatTypes.ResumeLayout(false);
      this.gbStatTypes.PerformLayout();
      this.pnlStats.ResumeLayout(false);
      this.pnlStats.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.picbxStats)).EndInit();
      this.tabPageLog.ResumeLayout(false);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem openMenuItem;
    private System.Windows.Forms.TabPage tabPageLog;
    private System.Windows.Forms.RichTextBox rtbMessageLog;
    private System.Windows.Forms.Button btnMessageLogClear;
    private System.Windows.Forms.TabPage tabPageSetup;
    private System.Windows.Forms.Button btnServoCtlSave;
    private System.Windows.Forms.Button btnServoCtlLoad;
    private System.Windows.Forms.TabControl tabServoSettings;
    private System.Windows.Forms.TabPage tabPageSetupFuzzy;
    private System.Windows.Forms.TabPage tabPageSetupControl;
    private System.Windows.Forms.GroupBox gbSetLimit;
    private System.Windows.Forms.GroupBox gbSetEncIdx;
    private System.Windows.Forms.CheckBox cbxSetEncIdxZero;
    private System.Windows.Forms.CheckBox cbxSetEncIdxEn;
    private System.Windows.Forms.GroupBox gbSetEncIdxHalt;
    private System.Windows.Forms.RadioButton rbSetEncIdxHaltSoft;
    private System.Windows.Forms.RadioButton rbSetEncIdxHaltHard;
    private System.Windows.Forms.GroupBox gbSetEncIdxVal;
    private System.Windows.Forms.RadioButton rbSetEncIdxValLo;
    private System.Windows.Forms.RadioButton rbSetEncIdxValHi;
    private System.Windows.Forms.GroupBox gbSetLimB;
    private System.Windows.Forms.CheckBox cbxSetLimBZero;
    private System.Windows.Forms.CheckBox cbxSetLimBEn;
    private System.Windows.Forms.GroupBox gbSetLimBHalt;
    private System.Windows.Forms.RadioButton rbSetLimBHaltSoft;
    private System.Windows.Forms.RadioButton rbSetLimBHaltHard;
    private System.Windows.Forms.GroupBox gbSetLimBVal;
    private System.Windows.Forms.RadioButton rbSetLimBValLo;
    private System.Windows.Forms.RadioButton rbSetLimBValHi;
    private System.Windows.Forms.GroupBox gbSetLimA;
    private System.Windows.Forms.CheckBox cbxSetLimAZero;
    private System.Windows.Forms.CheckBox cbxSetLimAEn;
    private System.Windows.Forms.GroupBox gbSetLimAHalt;
    private System.Windows.Forms.RadioButton rbSetLimAHaltSoft;
    private System.Windows.Forms.RadioButton rbSetLimAHaltHard;
    private System.Windows.Forms.GroupBox gbSetLimAVal;
    private System.Windows.Forms.RadioButton rbSetLimAValLo;
    private System.Windows.Forms.RadioButton rbSetLimAValHi;
    private System.Windows.Forms.GroupBox gbSetMotionControl;
    private System.Windows.Forms.GroupBox gbSetPwmDir;
    private System.Windows.Forms.RadioButton rbSetPwmCCW;
    private System.Windows.Forms.RadioButton rbSetPwmCW;
    private System.Windows.Forms.RadioButton rbSetPwmOff;
    private System.Windows.Forms.Label lblSetAcc;
    private System.Windows.Forms.Label lblSetVel;
    private System.Windows.Forms.Label lblSetPos;
    private System.Windows.Forms.NumericUpDown nudSetVel;
    private System.Windows.Forms.NumericUpDown nudSetPos;
    private System.Windows.Forms.NumericUpDown nudSetAcc;
    private System.Windows.Forms.GroupBox gbSetServoControl;
    private System.Windows.Forms.GroupBox gbSetMotorDone;
    private System.Windows.Forms.RadioButton rbSetPowerOff;
    private System.Windows.Forms.RadioButton rbSetPowerOn;
    private System.Windows.Forms.GroupBox gbSetGPIO;
    private System.Windows.Forms.RadioButton rbSetGPIOLo;
    private System.Windows.Forms.RadioButton rbSetGPIOHi;
    private System.Windows.Forms.GroupBox gbSetKick;
    private System.Windows.Forms.RadioButton rbSetKickOff;
    private System.Windows.Forms.RadioButton rbSetKickOn;
    private System.Windows.Forms.Label lblPWMRate;
    private System.Windows.Forms.Label lblServoRate;
    private System.Windows.Forms.ComboBox cboSetPWMRate;
    private System.Windows.Forms.ComboBox cboSetHBridge;
    private System.Windows.Forms.ComboBox cboSetServoRate;
    private System.Windows.Forms.GroupBox gbSetFuzzyMF;
    private System.Windows.Forms.GroupBox gbSetFuzzyRules;
    private System.Windows.Forms.Label lblSpdMF;
    private System.Windows.Forms.Label lblPosErrMF;
    private System.Windows.Forms.GroupBox gbPosCtlPts;
    private System.Windows.Forms.Label lblPosOutSing;
    private System.Windows.Forms.Label lblSpdCtlPtB;
    private System.Windows.Forms.TextBox tbxSpdCtlPtB;
    private System.Windows.Forms.Label lblSpdCtlPtA;
    private System.Windows.Forms.TextBox tbxSpdCtlPtA;
    private System.Windows.Forms.Label lblPosErrCtlPtB;
    private System.Windows.Forms.TextBox tbxPosErrCtlPtB;
    private System.Windows.Forms.Label lblPosErrCtlPtA;
    private System.Windows.Forms.TextBox tbxPosErrCtlPtA;
    private System.Windows.Forms.Label lblPosOutCtlPtB;
    private System.Windows.Forms.TextBox tbxPosOutCtlPtB;
    private System.Windows.Forms.Label lblPosOutCtlPtA;
    private System.Windows.Forms.TextBox tbxPosOutCtlPtA;
    private System.Windows.Forms.GroupBox gbTestMotionStart;
    private System.Windows.Forms.RadioButton rbTestMotionStartPos;
    private System.Windows.Forms.Button btnTestMotionStart;
    private System.Windows.Forms.RadioButton rbTestMotionStartPwm;
    private System.Windows.Forms.RadioButton rbTestMotionStartPwmLim;
    private System.Windows.Forms.RadioButton rbTestMotionStartTrapezoidal;
    private System.Windows.Forms.RadioButton rbTestMotionStartVel;
    private System.Windows.Forms.Button btnLimitCtlLoad;
    private System.Windows.Forms.Button btnLimitCtlSave;
    private System.Windows.Forms.Button btnMotionCtlLoad;
    private System.Windows.Forms.Button btnMotionCtlSave;
    private System.Windows.Forms.Button btnMotionCtlRevPos;
    private System.Windows.Forms.GroupBox gbSetupStatus;
    private System.Windows.Forms.Button btnGetMF;
    private System.Windows.Forms.Button btnSetMF;
    private System.Windows.Forms.Button btnGetRules;
    private System.Windows.Forms.Button btnSetRules;
    private System.Windows.Forms.TextBox tbxStatCurPos;
    private System.Windows.Forms.Label lblStatCurPos;
    private System.Windows.Forms.Label lblStatLimBVal;
    private System.Windows.Forms.TextBox tbxStatLimBVal;
    private System.Windows.Forms.Label lblStatLimAVal;
    private System.Windows.Forms.TextBox tbxStatLimAVal;
    private System.Windows.Forms.Label lblStatPeakVel;
    private System.Windows.Forms.TextBox tbxStatPeakVel;
    private System.Windows.Forms.Label lblStatCurVel;
    private System.Windows.Forms.TextBox tbxStatCurVel;
    private System.Windows.Forms.GroupBox gbStatLim;
    private System.Windows.Forms.GroupBox gbStatErrFlag;
    private System.Windows.Forms.CheckBox cbxStatFuzzyErr;
    private System.Windows.Forms.CheckBox cbxStatPosErr;
    private System.Windows.Forms.CheckBox cbxStatCANErr;
    private System.Windows.Forms.CheckBox cbxStatSysErr;
    private System.Windows.Forms.CheckBox cbxStatLimErr;
    private System.Windows.Forms.Label lblStatEncIdxVal;
    private System.Windows.Forms.TextBox tbxStatEncIdxVal;
    private System.Windows.Forms.CheckBox cbxStatLimA;
    private System.Windows.Forms.CheckBox cbxStatEncIdx;
    private System.Windows.Forms.CheckBox cbxStatLimB;
    private System.Windows.Forms.TabPage tabPageServoStats;
    private System.Windows.Forms.Panel pnlStats;
    private System.Windows.Forms.Button btnGetStats;
    private System.Windows.Forms.TextBox tbxStats;
    private System.Windows.Forms.Button btnStoreStats;
    private System.Windows.Forms.CheckBox cbxShowStatsPrev;
    private System.Windows.Forms.GroupBox gbStatTypes;
    private System.Windows.Forms.CheckBox cbxStatInfoDuty;
    private System.Windows.Forms.CheckBox cbxStatInfoChange;
    private System.Windows.Forms.CheckBox cbxStatInfoErr;
    private System.Windows.Forms.CheckBox cbxStatATDErr;
    private System.Windows.Forms.Label lblStatATDVal;
    private System.Windows.Forms.TextBox tbxStatATDVal;
    private System.Windows.Forms.Label lblStatErrCode;
    private System.Windows.Forms.TextBox tbxStatErrCode;
    private System.Windows.Forms.Label lblStatServoState;
    private System.Windows.Forms.TextBox tbxStatServoState;
    private System.Windows.Forms.Label lblSetPwmDuty;
    private System.Windows.Forms.NumericUpDown nudSetPWM;
    private System.Windows.Forms.Label lblSetPwmDir;
    private System.Windows.Forms.GroupBox gbxSetATDLim;
    private System.Windows.Forms.Label lblSetATDLimDwell;
    private System.Windows.Forms.Label lblSetATDLimVal;
    private System.Windows.Forms.NumericUpDown nudSetAtdLimDwell;
    private System.Windows.Forms.NumericUpDown nudSetAtdLimVal;
    private System.Windows.Forms.Label lblEnumNodes;
    private System.Windows.Forms.ComboBox cboSlaveNode;
    private System.Windows.Forms.CheckBox cbxMoveCtlGo;
    private System.Windows.Forms.GroupBox gbTestMotionStop;
    private System.Windows.Forms.Button btnTestMotionStop;
    private System.Windows.Forms.RadioButton rbTestMotionStartSoft;
    private System.Windows.Forms.RadioButton rbTestMotionStopHard;
    private System.Windows.Forms.CheckBox cbxStatIrqErr;
    private System.Windows.Forms.GroupBox gbxIRQEnable;
    private System.Windows.Forms.CheckBox cbxIRQEn;
    private System.Windows.Forms.GroupBox gbxCfg;
    private System.Windows.Forms.Button btnLoadCfg;
    private System.Windows.Forms.Button btnStoreCfg;
    private System.Windows.Forms.Panel pnlFuzzyRules;
    private System.Windows.Forms.Label lblFuzzyRule2;
    private System.Windows.Forms.Label lblFuzzyRule1;
    private System.Windows.Forms.Label lblFuzzyRule0;
    private System.Windows.Forms.ComboBox cbxFuzzyRule2;
    private System.Windows.Forms.ComboBox cbxFuzzyRule1;
    private System.Windows.Forms.ComboBox cbxFuzzyRule0;
    private System.Windows.Forms.Label lblUnfocus;
    private System.Windows.Forms.Label lblRulesPosHeader;
    private System.Windows.Forms.Label lblRulesOutHeader;
    private System.Windows.Forms.Label lblRulesSpdHeader;
    private System.Windows.Forms.TextBox tbxPosMem_0_0;
    private System.Windows.Forms.Label lblMemPos0;
    private System.Windows.Forms.CheckBox cbxMemFuncCtlPts;
    private System.Windows.Forms.Button btnMotionCtlDoublePos;
    private System.Windows.Forms.GroupBox gbxGroup;
    private System.Windows.Forms.CheckBox cbxGroup;
    private System.Windows.Forms.Button btnMotionCtlHalfPos;
    private System.Windows.Forms.CheckBox cbxGpioEnOut;
    private System.Windows.Forms.GroupBox gbxSleep;
    private System.Windows.Forms.RadioButton rbIRQWakeup;
    private System.Windows.Forms.RadioButton rbCommWakeUp;
    private System.Windows.Forms.Button btnSleep;
    private System.Windows.Forms.CheckBox cbxGpioSuspendToggle;
    private System.Windows.Forms.TabPage tabPageGateWay;
    private System.Windows.Forms.GroupBox gbStatus;
    private System.Windows.Forms.CheckBox cbxCanBusOff;
    private System.Windows.Forms.Button btnGatewayClearStatus;
    private System.Windows.Forms.TextBox tbxGatewayStatus;
    private System.Windows.Forms.Button btnGatewayGetStatus;
    private System.Windows.Forms.GroupBox gbGatewayVersion;
    private System.Windows.Forms.Label lblGatewayVer;
    private System.Windows.Forms.GroupBox gbGatewayBitrate;
    private System.Windows.Forms.ComboBox cboCANBitrate;
    private System.Windows.Forms.Button btnRebuildFs;
    private System.Windows.Forms.Label lbl_turnaround;
    private System.Windows.Forms.TextBox tbxGatewayTurnaround;
    private System.Windows.Forms.Label lblEncDiv;
    private System.Windows.Forms.ComboBox cboSetEncDiv;
    private System.Windows.Forms.Label lblHBridge;
    private System.Windows.Forms.RadioButton rbIRQhard;
    private System.Windows.Forms.RadioButton rbIRQsoft;
    private System.Windows.Forms.CheckBox cbxEeErr;
    private System.Windows.Forms.TextBox tbxEeErr;
    private System.Windows.Forms.Label lblStatPeakAcc;
    private System.Windows.Forms.TextBox tbxStatPeakAcc;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.GroupBox gbStatCtlPts;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox tbxStatPosCtlPtB;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox tbxStatPosCtlPtA;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox tbxStatOutCtlPtB;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox tbxStatOutCtlPtA;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox tbxStatSpdCtlPtB;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox tbxStatSpdCtlPtA;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label lblStatPosCtlPt;
    private System.Windows.Forms.PictureBox picbxStats;
    private System.Windows.Forms.GroupBox gbZero;
    private System.Windows.Forms.Button btnSetEncZero;
    private System.Windows.Forms.Button btnStatusWrite;
    private System.Windows.Forms.Button btnStatusRead;
    private System.Windows.Forms.GroupBox gbRand;
    private System.Windows.Forms.Button btnRand;
  }
}

