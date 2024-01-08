namespace IndustrialRobots;

partial class RobotCreation
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
        titleRoboCre_lbl = new Label();
        nameRoCre_lbl = new Label();
        toboRoCre_lbl = new Label();
        weightRoCre_lbl = new Label();
        nameRoCre_tbx = new TextBox();
        weightRoCre_tbx = new TextBox();
        smalltbRoCre_rdo = new RadioButton();
        mediumtbRoCre_rdo = new RadioButton();
        largetbRoCre_rdo = new RadioButton();
        createRoCre_btn = new Button();
        toolsRoCre_grobox = new GroupBox();
        toolsRoCre_grobox.SuspendLayout();
        SuspendLayout();
        // 
        // titleRoboCre_lbl
        // 
        titleRoboCre_lbl.AutoSize = true;
        titleRoboCre_lbl.Font = new Font("Stencil", 12F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point);
        titleRoboCre_lbl.ForeColor = Color.Black;
        titleRoboCre_lbl.Location = new Point(16, 9);
        titleRoboCre_lbl.Name = "titleRoboCre_lbl";
        titleRoboCre_lbl.Size = new Size(216, 19);
        titleRoboCre_lbl.TabIndex = 0;
        titleRoboCre_lbl.Text = "Robotniky Creationizky";
        // 
        // nameRoCre_lbl
        // 
        nameRoCre_lbl.AutoSize = true;
        nameRoCre_lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        nameRoCre_lbl.Location = new Point(16, 52);
        nameRoCre_lbl.Name = "nameRoCre_lbl";
        nameRoCre_lbl.Size = new Size(40, 15);
        nameRoCre_lbl.TabIndex = 1;
        nameRoCre_lbl.Text = "Name";
        // 
        // toboRoCre_lbl
        // 
        toboRoCre_lbl.AutoSize = true;
        toboRoCre_lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        toboRoCre_lbl.Location = new Point(16, 117);
        toboRoCre_lbl.Name = "toboRoCre_lbl";
        toboRoCre_lbl.Size = new Size(51, 15);
        toboRoCre_lbl.TabIndex = 2;
        toboRoCre_lbl.Text = "Toolbox";
        // 
        // weightRoCre_lbl
        // 
        weightRoCre_lbl.AutoSize = true;
        weightRoCre_lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        weightRoCre_lbl.Location = new Point(16, 184);
        weightRoCre_lbl.Name = "weightRoCre_lbl";
        weightRoCre_lbl.Size = new Size(75, 15);
        weightRoCre_lbl.TabIndex = 3;
        weightRoCre_lbl.Text = "Max Weight";
        // 
        // nameRoCre_tbx
        // 
        nameRoCre_tbx.Location = new Point(69, 49);
        nameRoCre_tbx.Name = "nameRoCre_tbx";
        nameRoCre_tbx.Size = new Size(139, 23);
        nameRoCre_tbx.TabIndex = 4;
        nameRoCre_tbx.TextChanged += nameRoCre_tbx_TextChanged;
        // 
        // weightRoCre_tbx
        // 
        weightRoCre_tbx.Location = new Point(108, 181);
        weightRoCre_tbx.Name = "weightRoCre_tbx";
        weightRoCre_tbx.Size = new Size(100, 23);
        weightRoCre_tbx.TabIndex = 5;
        weightRoCre_tbx.TextChanged += weightRoCre_tbx_TextChanged;
        // 
        // smalltbRoCre_rdo
        // 
        smalltbRoCre_rdo.AutoSize = true;
        smalltbRoCre_rdo.Location = new Point(6, 18);
        smalltbRoCre_rdo.Name = "smalltbRoCre_rdo";
        smalltbRoCre_rdo.Size = new Size(116, 19);
        smalltbRoCre_rdo.TabIndex = 6;
        smalltbRoCre_rdo.TabStop = true;
        smalltbRoCre_rdo.Text = "Small Toolbox {3)";
        smalltbRoCre_rdo.UseVisualStyleBackColor = true;
        // 
        // mediumtbRoCre_rdo
        // 
        mediumtbRoCre_rdo.AutoSize = true;
        mediumtbRoCre_rdo.Location = new Point(6, 41);
        mediumtbRoCre_rdo.Name = "mediumtbRoCre_rdo";
        mediumtbRoCre_rdo.Size = new Size(132, 19);
        mediumtbRoCre_rdo.TabIndex = 7;
        mediumtbRoCre_rdo.TabStop = true;
        mediumtbRoCre_rdo.Text = "Medium Toolbox {6)";
        mediumtbRoCre_rdo.UseVisualStyleBackColor = true;
        // 
        // largetbRoCre_rdo
        // 
        largetbRoCre_rdo.AutoSize = true;
        largetbRoCre_rdo.Location = new Point(6, 66);
        largetbRoCre_rdo.Name = "largetbRoCre_rdo";
        largetbRoCre_rdo.Size = new Size(116, 19);
        largetbRoCre_rdo.TabIndex = 8;
        largetbRoCre_rdo.TabStop = true;
        largetbRoCre_rdo.Text = "Large Toolbox (9)";
        largetbRoCre_rdo.UseVisualStyleBackColor = true;
        // 
        // createRoCre_btn
        // 
        createRoCre_btn.BackColor = SystemColors.ControlDarkDark;
        createRoCre_btn.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
        createRoCre_btn.Location = new Point(73, 223);
        createRoCre_btn.Name = "createRoCre_btn";
        createRoCre_btn.Size = new Size(88, 42);
        createRoCre_btn.TabIndex = 9;
        createRoCre_btn.Text = "Create!";
        createRoCre_btn.UseVisualStyleBackColor = false;
        createRoCre_btn.Click += createRoCre_btn_Click;
        createRoCre_btn.MouseEnter += createRoCre_btn_MouseEnter;
        createRoCre_btn.MouseLeave += createRoCre_btn_MouseLeave;
        // 
        // toolsRoCre_grobox
        // 
        toolsRoCre_grobox.Controls.Add(smalltbRoCre_rdo);
        toolsRoCre_grobox.Controls.Add(mediumtbRoCre_rdo);
        toolsRoCre_grobox.Controls.Add(largetbRoCre_rdo);
        toolsRoCre_grobox.Location = new Point(73, 78);
        toolsRoCre_grobox.Name = "toolsRoCre_grobox";
        toolsRoCre_grobox.Size = new Size(136, 100);
        toolsRoCre_grobox.TabIndex = 10;
        toolsRoCre_grobox.TabStop = false;
        // 
        // RobotCreation
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(257, 276);
        Controls.Add(toolsRoCre_grobox);
        Controls.Add(createRoCre_btn);
        Controls.Add(weightRoCre_tbx);
        Controls.Add(nameRoCre_tbx);
        Controls.Add(weightRoCre_lbl);
        Controls.Add(toboRoCre_lbl);
        Controls.Add(nameRoCre_lbl);
        Controls.Add(titleRoboCre_lbl);
        Name = "RobotCreation";
        Text = "RobotCreation";
        toolsRoCre_grobox.ResumeLayout(false);
        toolsRoCre_grobox.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label titleRoboCre_lbl;
    private Label nameRoCre_lbl;
    private Label toboRoCre_lbl;
    private Label weightRoCre_lbl;
    private TextBox nameRoCre_tbx;
    private TextBox weightRoCre_tbx;
    private RadioButton smalltbRoCre_rdo;
    private RadioButton mediumtbRoCre_rdo;
    private RadioButton largetbRoCre_rdo;
    private Button createRoCre_btn;
    private GroupBox toolsRoCre_grobox;
}