namespace IndustrialRobots;

partial class Form1
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
        addToolM_btn = new Button();
        removeToolM_btn = new Button();
        createRobotM_btn = new Button();
        createToolM_btn = new Button();
        label1 = new Label();
        choseRobotM_cobo = new ComboBox();
        addToolM_cobo = new ComboBox();
        removeTool_cobo = new ComboBox();
        robo_lbl = new Label();
        label3 = new Label();
        label4 = new Label();
        label5 = new Label();
        currentRobotM_tbx = new TextBox();
        currentLoad_tbx = new TextBox();
        currentToolsM_cobo = new ComboBox();
        slotsM_tbx = new TextBox();
        label2 = new Label();
        slotsBlocked_tbx = new TextBox();
        protocolM_btn = new Button();
        label6 = new Label();
        label7 = new Label();
        label8 = new Label();
        CurToolStats_grpbx = new GroupBox();
        ctFlops_lbl = new Label();
        ctLength_lbl = new Label();
        ctLumen_lbl = new Label();
        ctHeat_lbl = new Label();
        ctWatts_lbl = new Label();
        ctsnr_lbl = new Label();
        ctCat_lbl = new Label();
        ctType_lbl = new Label();
        ctweight_lbl = new Label();
        ctname_lbl = new Label();
        label18 = new Label();
        label17 = new Label();
        label16 = new Label();
        label15 = new Label();
        label14 = new Label();
        label13 = new Label();
        label12 = new Label();
        label11 = new Label();
        label10 = new Label();
        label9 = new Label();
        CurToolStats_grpbx.SuspendLayout();
        SuspendLayout();
        // 
        // addToolM_btn
        // 
        addToolM_btn.Enabled = false;
        addToolM_btn.Location = new Point(26, 192);
        addToolM_btn.Name = "addToolM_btn";
        addToolM_btn.Size = new Size(101, 23);
        addToolM_btn.TabIndex = 0;
        addToolM_btn.Text = "Add Tool";
        addToolM_btn.UseVisualStyleBackColor = true;
        addToolM_btn.Click += addToolM_btn_Click;
        // 
        // removeToolM_btn
        // 
        removeToolM_btn.Location = new Point(26, 239);
        removeToolM_btn.Name = "removeToolM_btn";
        removeToolM_btn.Size = new Size(101, 23);
        removeToolM_btn.TabIndex = 1;
        removeToolM_btn.Text = "Remove Tool";
        removeToolM_btn.UseVisualStyleBackColor = true;
        removeToolM_btn.Click += removeToolM_btn_Click;
        // 
        // createRobotM_btn
        // 
        createRobotM_btn.Location = new Point(26, 60);
        createRobotM_btn.Name = "createRobotM_btn";
        createRobotM_btn.Size = new Size(101, 23);
        createRobotM_btn.TabIndex = 2;
        createRobotM_btn.Text = "Create Robot";
        createRobotM_btn.UseVisualStyleBackColor = true;
        createRobotM_btn.Click += createRobotM_btn_Click;
        // 
        // createToolM_btn
        // 
        createToolM_btn.Location = new Point(148, 60);
        createToolM_btn.Name = "createToolM_btn";
        createToolM_btn.Size = new Size(121, 23);
        createToolM_btn.TabIndex = 3;
        createToolM_btn.Text = "Create Tool";
        createToolM_btn.UseVisualStyleBackColor = true;
        createToolM_btn.Click += createToolM_btn_Click;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Stencil", 12F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point);
        label1.Location = new Point(26, 9);
        label1.Name = "label1";
        label1.Size = new Size(226, 19);
        label1.TabIndex = 4;
        label1.Text = "Robotniki Industrializcy";
        // 
        // choseRobotM_cobo
        // 
        choseRobotM_cobo.DisplayMember = "Form1";
        choseRobotM_cobo.FormattingEnabled = true;
        choseRobotM_cobo.Location = new Point(148, 151);
        choseRobotM_cobo.Name = "choseRobotM_cobo";
        choseRobotM_cobo.Size = new Size(121, 23);
        choseRobotM_cobo.TabIndex = 6;
        choseRobotM_cobo.SelectedIndexChanged += choseRobotM_cobo_SelectedIndexChanged;
        // 
        // addToolM_cobo
        // 
        addToolM_cobo.DisplayMember = "Form1";
        addToolM_cobo.FormattingEnabled = true;
        addToolM_cobo.Location = new Point(148, 193);
        addToolM_cobo.Name = "addToolM_cobo";
        addToolM_cobo.Size = new Size(121, 23);
        addToolM_cobo.TabIndex = 7;
        addToolM_cobo.SelectedIndexChanged += addToolM_cobo_SelectedIndexChanged;
        // 
        // removeTool_cobo
        // 
        removeTool_cobo.DisplayMember = "Form1";
        removeTool_cobo.FormattingEnabled = true;
        removeTool_cobo.Location = new Point(148, 240);
        removeTool_cobo.Name = "removeTool_cobo";
        removeTool_cobo.Size = new Size(121, 23);
        removeTool_cobo.TabIndex = 8;
        removeTool_cobo.SelectedIndexChanged += removeTool_cobo_SelectedIndexChanged;
        // 
        // robo_lbl
        // 
        robo_lbl.AutoSize = true;
        robo_lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        robo_lbl.Location = new Point(33, 327);
        robo_lbl.Name = "robo_lbl";
        robo_lbl.Size = new Size(87, 15);
        robo_lbl.TabIndex = 9;
        robo_lbl.Text = "Current Robot";
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label3.Location = new Point(33, 367);
        label3.Name = "label3";
        label3.Size = new Size(81, 15);
        label3.TabIndex = 10;
        label3.Text = "Current Tools";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label4.Location = new Point(33, 414);
        label4.Name = "label4";
        label4.Size = new Size(79, 15);
        label4.TabIndex = 11;
        label4.Text = "Current Load";
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label5.Location = new Point(33, 458);
        label5.Name = "label5";
        label5.Size = new Size(82, 15);
        label5.TabIndex = 12;
        label5.Text = "ToolBox Slots";
        // 
        // currentRobotM_tbx
        // 
        currentRobotM_tbx.Location = new Point(148, 324);
        currentRobotM_tbx.Name = "currentRobotM_tbx";
        currentRobotM_tbx.ReadOnly = true;
        currentRobotM_tbx.Size = new Size(121, 23);
        currentRobotM_tbx.TabIndex = 13;
        // 
        // currentLoad_tbx
        // 
        currentLoad_tbx.Location = new Point(148, 411);
        currentLoad_tbx.Name = "currentLoad_tbx";
        currentLoad_tbx.ReadOnly = true;
        currentLoad_tbx.Size = new Size(121, 23);
        currentLoad_tbx.TabIndex = 15;
        // 
        // currentToolsM_cobo
        // 
        currentToolsM_cobo.DisplayMember = "Form1";
        currentToolsM_cobo.FormattingEnabled = true;
        currentToolsM_cobo.Location = new Point(148, 364);
        currentToolsM_cobo.Name = "currentToolsM_cobo";
        currentToolsM_cobo.Size = new Size(121, 23);
        currentToolsM_cobo.TabIndex = 17;
        currentToolsM_cobo.SelectedIndexChanged += currentToolsM_cobo_SelectedIndexChanged;
        // 
        // slotsM_tbx
        // 
        slotsM_tbx.Location = new Point(151, 456);
        slotsM_tbx.Name = "slotsM_tbx";
        slotsM_tbx.Size = new Size(118, 23);
        slotsM_tbx.TabIndex = 20;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        label2.Location = new Point(33, 284);
        label2.Name = "label2";
        label2.Size = new Size(63, 15);
        label2.TabIndex = 21;
        label2.Text = "Slots used";
        // 
        // slotsBlocked_tbx
        // 
        slotsBlocked_tbx.Location = new Point(148, 281);
        slotsBlocked_tbx.Name = "slotsBlocked_tbx";
        slotsBlocked_tbx.ReadOnly = true;
        slotsBlocked_tbx.Size = new Size(121, 23);
        slotsBlocked_tbx.TabIndex = 22;
        // 
        // protocolM_btn
        // 
        protocolM_btn.Location = new Point(26, 535);
        protocolM_btn.Name = "protocolM_btn";
        protocolM_btn.Size = new Size(101, 23);
        protocolM_btn.TabIndex = 23;
        protocolM_btn.Text = "Protocol";
        protocolM_btn.UseVisualStyleBackColor = true;
        protocolM_btn.Click += protocolM_btn_Click;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(32, 497);
        label6.Name = "label6";
        label6.Size = new Size(89, 15);
        label6.TabIndex = 24;
        label6.Text = "Open Protocols";
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Location = new Point(95, 574);
        label7.Name = "label7";
        label7.Size = new Size(105, 15);
        label7.TabIndex = 25;
        label7.Text = "Current Tools Stats";
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(34, 151);
        label8.Name = "label8";
        label8.Size = new Size(82, 15);
        label8.TabIndex = 27;
        label8.Text = "Choose Robot";
        // 
        // CurToolStats_grpbx
        // 
        CurToolStats_grpbx.Controls.Add(ctFlops_lbl);
        CurToolStats_grpbx.Controls.Add(ctLength_lbl);
        CurToolStats_grpbx.Controls.Add(ctLumen_lbl);
        CurToolStats_grpbx.Controls.Add(ctHeat_lbl);
        CurToolStats_grpbx.Controls.Add(ctWatts_lbl);
        CurToolStats_grpbx.Controls.Add(ctsnr_lbl);
        CurToolStats_grpbx.Controls.Add(ctCat_lbl);
        CurToolStats_grpbx.Controls.Add(ctType_lbl);
        CurToolStats_grpbx.Controls.Add(ctweight_lbl);
        CurToolStats_grpbx.Controls.Add(ctname_lbl);
        CurToolStats_grpbx.Controls.Add(label18);
        CurToolStats_grpbx.Controls.Add(label17);
        CurToolStats_grpbx.Controls.Add(label16);
        CurToolStats_grpbx.Controls.Add(label15);
        CurToolStats_grpbx.Controls.Add(label14);
        CurToolStats_grpbx.Controls.Add(label13);
        CurToolStats_grpbx.Controls.Add(label12);
        CurToolStats_grpbx.Controls.Add(label11);
        CurToolStats_grpbx.Controls.Add(label10);
        CurToolStats_grpbx.Controls.Add(label9);
        CurToolStats_grpbx.Location = new Point(-3, 604);
        CurToolStats_grpbx.Name = "CurToolStats_grpbx";
        CurToolStats_grpbx.Size = new Size(291, 203);
        CurToolStats_grpbx.TabIndex = 28;
        CurToolStats_grpbx.TabStop = false;
        // 
        // ctFlops_lbl
        // 
        ctFlops_lbl.AutoSize = true;
        ctFlops_lbl.Location = new Point(216, 125);
        ctFlops_lbl.Name = "ctFlops_lbl";
        ctFlops_lbl.Size = new Size(0, 15);
        ctFlops_lbl.TabIndex = 19;
        ctFlops_lbl.TextAlign = ContentAlignment.BottomRight;
        // 
        // ctLength_lbl
        // 
        ctLength_lbl.AutoSize = true;
        ctLength_lbl.Location = new Point(216, 96);
        ctLength_lbl.Name = "ctLength_lbl";
        ctLength_lbl.Size = new Size(0, 15);
        ctLength_lbl.TabIndex = 18;
        ctLength_lbl.TextAlign = ContentAlignment.BottomRight;
        // 
        // ctLumen_lbl
        // 
        ctLumen_lbl.AutoSize = true;
        ctLumen_lbl.Location = new Point(216, 67);
        ctLumen_lbl.Name = "ctLumen_lbl";
        ctLumen_lbl.Size = new Size(0, 15);
        ctLumen_lbl.TabIndex = 17;
        ctLumen_lbl.TextAlign = ContentAlignment.BottomRight;
        // 
        // ctHeat_lbl
        // 
        ctHeat_lbl.AutoSize = true;
        ctHeat_lbl.Location = new Point(216, 40);
        ctHeat_lbl.Name = "ctHeat_lbl";
        ctHeat_lbl.Size = new Size(0, 15);
        ctHeat_lbl.TabIndex = 16;
        ctHeat_lbl.TextAlign = ContentAlignment.BottomRight;
        // 
        // ctWatts_lbl
        // 
        ctWatts_lbl.AutoSize = true;
        ctWatts_lbl.Location = new Point(216, 11);
        ctWatts_lbl.Name = "ctWatts_lbl";
        ctWatts_lbl.Size = new Size(0, 15);
        ctWatts_lbl.TabIndex = 15;
        ctWatts_lbl.TextAlign = ContentAlignment.BottomRight;
        // 
        // ctsnr_lbl
        // 
        ctsnr_lbl.AutoSize = true;
        ctsnr_lbl.Location = new Point(97, 123);
        ctsnr_lbl.Name = "ctsnr_lbl";
        ctsnr_lbl.Size = new Size(0, 15);
        ctsnr_lbl.TabIndex = 14;
        ctsnr_lbl.TextAlign = ContentAlignment.BottomRight;
        // 
        // ctCat_lbl
        // 
        ctCat_lbl.AutoSize = true;
        ctCat_lbl.Location = new Point(97, 96);
        ctCat_lbl.Name = "ctCat_lbl";
        ctCat_lbl.Size = new Size(0, 15);
        ctCat_lbl.TabIndex = 13;
        ctCat_lbl.TextAlign = ContentAlignment.BottomRight;
        // 
        // ctType_lbl
        // 
        ctType_lbl.AutoSize = true;
        ctType_lbl.Location = new Point(97, 67);
        ctType_lbl.Name = "ctType_lbl";
        ctType_lbl.Size = new Size(0, 15);
        ctType_lbl.TabIndex = 12;
        ctType_lbl.TextAlign = ContentAlignment.BottomRight;
        // 
        // ctweight_lbl
        // 
        ctweight_lbl.AutoSize = true;
        ctweight_lbl.Location = new Point(97, 40);
        ctweight_lbl.Name = "ctweight_lbl";
        ctweight_lbl.Size = new Size(0, 15);
        ctweight_lbl.TabIndex = 11;
        ctweight_lbl.TextAlign = ContentAlignment.BottomRight;
        // 
        // ctname_lbl
        // 
        ctname_lbl.AutoSize = true;
        ctname_lbl.Location = new Point(97, 11);
        ctname_lbl.Name = "ctname_lbl";
        ctname_lbl.Size = new Size(0, 15);
        ctname_lbl.TabIndex = 10;
        ctname_lbl.TextAlign = ContentAlignment.BottomRight;
        // 
        // label18
        // 
        label18.AutoSize = true;
        label18.Location = new Point(15, 11);
        label18.Name = "label18";
        label18.Size = new Size(39, 15);
        label18.TabIndex = 9;
        label18.Text = "Name";
        // 
        // label17
        // 
        label17.AutoSize = true;
        label17.Location = new Point(15, 67);
        label17.Name = "label17";
        label17.Size = new Size(61, 15);
        label17.TabIndex = 8;
        label17.Text = "Class Type";
        // 
        // label16
        // 
        label16.AutoSize = true;
        label16.Location = new Point(15, 96);
        label16.Name = "label16";
        label16.Size = new Size(55, 15);
        label16.TabIndex = 7;
        label16.Text = "Category";
        // 
        // label15
        // 
        label15.AutoSize = true;
        label15.Location = new Point(154, 125);
        label15.Name = "label15";
        label15.Size = new Size(35, 15);
        label15.TabIndex = 6;
        label15.Text = "Flops";
        // 
        // label14
        // 
        label14.AutoSize = true;
        label14.Location = new Point(154, 96);
        label14.Name = "label14";
        label14.Size = new Size(44, 15);
        label14.TabIndex = 5;
        label14.Text = "Length";
        // 
        // label13
        // 
        label13.AutoSize = true;
        label13.Location = new Point(154, 40);
        label13.Name = "label13";
        label13.Size = new Size(32, 15);
        label13.TabIndex = 4;
        label13.Text = "Heat";
        // 
        // label12
        // 
        label12.AutoSize = true;
        label12.Location = new Point(154, 67);
        label12.Name = "label12";
        label12.Size = new Size(44, 15);
        label12.TabIndex = 3;
        label12.Text = "Lumen";
        // 
        // label11
        // 
        label11.AutoSize = true;
        label11.Location = new Point(154, 11);
        label11.Name = "label11";
        label11.Size = new Size(37, 15);
        label11.TabIndex = 2;
        label11.Text = "Watts";
        // 
        // label10
        // 
        label10.AutoSize = true;
        label10.Location = new Point(15, 40);
        label10.Name = "label10";
        label10.Size = new Size(45, 15);
        label10.TabIndex = 1;
        label10.Text = "Weight";
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new Point(15, 125);
        label9.Name = "label9";
        label9.Size = new Size(79, 15);
        label9.TabIndex = 0;
        label9.Text = "SerialNumber";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(300, 819);
        Controls.Add(CurToolStats_grpbx);
        Controls.Add(label8);
        Controls.Add(label7);
        Controls.Add(label6);
        Controls.Add(protocolM_btn);
        Controls.Add(slotsBlocked_tbx);
        Controls.Add(label2);
        Controls.Add(slotsM_tbx);
        Controls.Add(currentToolsM_cobo);
        Controls.Add(currentLoad_tbx);
        Controls.Add(currentRobotM_tbx);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(robo_lbl);
        Controls.Add(removeTool_cobo);
        Controls.Add(addToolM_cobo);
        Controls.Add(choseRobotM_cobo);
        Controls.Add(label1);
        Controls.Add(createToolM_btn);
        Controls.Add(createRobotM_btn);
        Controls.Add(removeToolM_btn);
        Controls.Add(addToolM_btn);
        Name = "Form1";
        Load += Form1_Load;
        CurToolStats_grpbx.ResumeLayout(false);
        CurToolStats_grpbx.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button addToolM_btn;
    private Button removeToolM_btn;
    private Button createRobotM_btn;
    private Button createToolM_btn;
    private Label label1;
    private ComboBox choseRobotM_cobo;
    private ComboBox addToolM_cobo;
    private ComboBox removeTool_cobo;
    private Label robo_lbl;
    private Label label3;
    private Label label4;
    private Label label5;
    private TextBox currentRobotM_tbx;
    private TextBox currentLoad_tbx;
    private ComboBox currentToolsM_cobo;
    private TextBox slotsM_tbx;
    private Label label2;
    private TextBox slotsBlocked_tbx;
    private Button protocolM_btn;
    private Label label6;
    private Label label7;
    private Label label8;
    private GroupBox CurToolStats_grpbx;
    private Label label18;
    private Label label17;
    private Label label16;
    private Label label15;
    private Label label14;
    private Label label13;
    private Label label12;
    private Label label11;
    private Label label10;
    private Label label9;
    private Label ctFlops_lbl;
    private Label ctLength_lbl;
    private Label ctLumen_lbl;
    private Label ctHeat_lbl;
    private Label ctWatts_lbl;
    private Label ctsnr_lbl;
    private Label ctCat_lbl;
    private Label ctType_lbl;
    private Label ctweight_lbl;
    private Label ctname_lbl;
}
