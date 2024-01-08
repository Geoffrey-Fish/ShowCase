namespace IndustrialRobots;

public partial class RobotCreation : Form
{
    public RobotCreation()
    {
        InitializeComponent();
        //RadioButtons for ToolBoxSize
        smalltbRoCre_rdo.CheckedChanged += toolSizeRadioChanged;
        mediumtbRoCre_rdo.CheckedChanged += toolSizeRadioChanged;
        largetbRoCre_rdo.CheckedChanged += toolSizeRadioChanged;
    }

    public int ToolBoxSize { get; set; }
    public string? RobotName { get; set; }
    public double MaxWeight { get; set; }

    //checking which radio is clicked
    //And set the toolbox size accordingly
    private void toolSizeRadioChanged(object sender, EventArgs e)
    {
        var rb = (RadioButton)sender;
        if (rb.Checked)
            if (toolsRoCre_grobox.Controls.Contains(rb))
                ToolBoxSize = rb == smalltbRoCre_rdo ? 3 :
                    rb == mediumtbRoCre_rdo ? 6 :
                    rb == largetbRoCre_rdo ? 9 : 0; //simple chain
    }

    //RobotName of the robot
    private void nameRoCre_tbx_TextChanged(object sender, EventArgs e)
    {
        RobotName = nameRoCre_tbx.Text;
    }

    //The max weight the robot can carry
    private void weightRoCre_tbx_TextChanged(object sender, EventArgs e)
    {
        double.TryParse(weightRoCre_tbx.Text, out var result);
        MaxWeight = result;
    }

    #region close dialogue, close form

    private void createRoCre_btn_Click(object sender, EventArgs e)
    {
        //Got all infos set? Close window, give data back for creation of robot
        if (Name != null && ToolBoxSize != null && MaxWeight != null)
            DialogResult = DialogResult.OK;
        else
            MessageBox.Show("Please fill the form correctly!");
    }

    private void createRoCre_btn_MouseEnter(object sender, EventArgs e)
    {
        if (RobotName == null || ToolBoxSize == null || MaxWeight == null)
        {
            createRoCre_btn.Enabled = false;
            MessageBox.Show("Please fill the form correctly!");
        }
    }

    private void createRoCre_btn_MouseLeave(object sender, EventArgs e)
    {
        createRoCre_btn.Enabled = true;
    }

    #endregion
}