namespace IndustrialRobots;

partial class ProtocolDataSheet
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
        dataGridView1 = new DataGridView();
        loadProtocolDV_btn = new Button();
        refreshDataDV_btn = new Button();
        titleprotDV_lbl = new Label();
        toolListDV_lbl = new Label();
        roboListDV_lbl = new Label();
        protListDV_lbl = new Label();
        loadToolDV_btn = new Button();
        loadRoboDV_btn = new Button();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        SuspendLayout();
        // 
        // dataGridView1
        // 
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Location = new Point(48, 34);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.RowTemplate.Height = 25;
        dataGridView1.Size = new Size(1392, 375);
        dataGridView1.TabIndex = 0;
        // 
        // loadProtocolDV_btn
        // 
        loadProtocolDV_btn.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
        loadProtocolDV_btn.Location = new Point(392, 421);
        loadProtocolDV_btn.Name = "loadProtocolDV_btn";
        loadProtocolDV_btn.Size = new Size(90, 23);
        loadProtocolDV_btn.TabIndex = 1;
        loadProtocolDV_btn.Text = "Protocol";
        loadProtocolDV_btn.UseVisualStyleBackColor = true;
        loadProtocolDV_btn.Click += loadProtocolDV_btn_Click;
        // 
        // refreshDataDV_btn
        // 
        refreshDataDV_btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        refreshDataDV_btn.Location = new Point(1342, 419);
        refreshDataDV_btn.Name = "refreshDataDV_btn";
        refreshDataDV_btn.Size = new Size(75, 23);
        refreshDataDV_btn.TabIndex = 2;
        refreshDataDV_btn.Text = "Refresh";
        refreshDataDV_btn.UseVisualStyleBackColor = true;
        // 
        // titleprotDV_lbl
        // 
        titleprotDV_lbl.AutoSize = true;
        titleprotDV_lbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
        titleprotDV_lbl.ForeColor = Color.FromArgb(0, 0, 192);
        titleprotDV_lbl.Location = new Point(694, 9);
        titleprotDV_lbl.Name = "titleprotDV_lbl";
        titleprotDV_lbl.Size = new Size(132, 21);
        titleprotDV_lbl.TabIndex = 3;
        titleprotDV_lbl.Text = "Protocol Viewer";
        // 
        // toolListDV_lbl
        // 
        toolListDV_lbl.AutoSize = true;
        toolListDV_lbl.Location = new Point(501, 424);
        toolListDV_lbl.Name = "toolListDV_lbl";
        toolListDV_lbl.Size = new Size(79, 15);
        toolListDV_lbl.TabIndex = 4;
        toolListDV_lbl.Text = "Load Tool List";
        // 
        // roboListDV_lbl
        // 
        roboListDV_lbl.AutoSize = true;
        roboListDV_lbl.Location = new Point(694, 423);
        roboListDV_lbl.Name = "roboListDV_lbl";
        roboListDV_lbl.Size = new Size(89, 15);
        roboListDV_lbl.TabIndex = 5;
        roboListDV_lbl.Text = "Load Robotniks";
        // 
        // protListDV_lbl
        // 
        protListDV_lbl.AutoSize = true;
        protListDV_lbl.Location = new Point(305, 423);
        protListDV_lbl.Name = "protListDV_lbl";
        protListDV_lbl.Size = new Size(81, 15);
        protListDV_lbl.TabIndex = 6;
        protListDV_lbl.Text = "Load Protocol";
        // 
        // loadToolDV_btn
        // 
        loadToolDV_btn.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
        loadToolDV_btn.Location = new Point(584, 421);
        loadToolDV_btn.Name = "loadToolDV_btn";
        loadToolDV_btn.Size = new Size(90, 23);
        loadToolDV_btn.TabIndex = 7;
        loadToolDV_btn.Text = "Tools";
        loadToolDV_btn.UseVisualStyleBackColor = true;
        loadToolDV_btn.Click += loadToolDV_btn_Click;
        // 
        // loadRoboDV_btn
        // 
        loadRoboDV_btn.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
        loadRoboDV_btn.Location = new Point(789, 421);
        loadRoboDV_btn.Name = "loadRoboDV_btn";
        loadRoboDV_btn.Size = new Size(90, 23);
        loadRoboDV_btn.TabIndex = 8;
        loadRoboDV_btn.Text = "Robotniks";
        loadRoboDV_btn.UseVisualStyleBackColor = true;
        loadRoboDV_btn.Click += loadRoboDV_btn_Click;
        // 
        // ProtocolDataSheet
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1512, 450);
        Controls.Add(loadRoboDV_btn);
        Controls.Add(loadToolDV_btn);
        Controls.Add(protListDV_lbl);
        Controls.Add(roboListDV_lbl);
        Controls.Add(toolListDV_lbl);
        Controls.Add(titleprotDV_lbl);
        Controls.Add(refreshDataDV_btn);
        Controls.Add(loadProtocolDV_btn);
        Controls.Add(dataGridView1);
        Name = "ProtocolDataSheet";
        Text = "ProtocolDataSheet";
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DataGridView dataGridView1;
    private Button loadProtocolDV_btn;
    private Button refreshDataDV_btn;
    private Label titleprotDV_lbl;
    private Label toolListDV_lbl;
    private Label roboListDV_lbl;
    private Label protListDV_lbl;
    private Button loadToolDV_btn;
    private Button loadRoboDV_btn;
}