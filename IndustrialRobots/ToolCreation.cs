namespace IndustrialRobots;

public partial class ToolCreation : Form
{
    public ToolCreation()
    {
        InitializeComponent();
        //Type radios
        arcWeldToCr_rdo.CheckedChanged += TypeRadiosChanged;
        drillToCr_rdo.CheckedChanged += TypeRadiosChanged;
        ductTapeToCr_rdo.CheckedChanged += TypeRadiosChanged;
        laserToCr_rdo.CheckedChanged += TypeRadiosChanged;
        compToCr_rdo.CheckedChanged += TypeRadiosChanged;

        //Category radios
        destroToCr_rdo.CheckedChanged += CategoryRadiosChanged;
        fixToCr_rdo.CheckedChanged += CategoryRadiosChanged;
        manipToCr_rdo.CheckedChanged += CategoryRadiosChanged;
        weldingToCr_rdo.CheckedChanged += CategoryRadiosChanged;

        //Material radios
        steelToCr_rdo.CheckedChanged += MaterialRadiosChanged;
        aluToCr_rdo.CheckedChanged += MaterialRadiosChanged;
        diamondToCr_rdo.CheckedChanged += MaterialRadiosChanged;
        woodToCr_rdo.CheckedChanged += MaterialRadiosChanged;
    }

    public string? ClassType { get; set; } //What kind of tool is to be build
    public string? ToolName { get; set; } //new keyword becauso of Controll.Name(tooltip said it)
    public string? Category { get; set; } //what kind of tool
    public string? Material { get; set; }
    public double Weight { get; set; } // Max load
    public int SerialNumber { get; set; }
    public int Watts { get; set; }
    public int Lumen { get; set; }
    public int Heat { get; set; }
    public int Length { get; set; }
    public int Flops { get; set; }

    private void TypeRadiosChanged(object sender, EventArgs e)
    {
        var rb = (RadioButton)sender;
        if (rb.Checked)
            if (typeToCr_grobo.Controls.Contains(rb))
            {
                if (rb == arcWeldToCr_rdo)
                {
                    //needed
                    ClassType = "ArcWelder";
                    wattsToCr_tbx.ReadOnly = false;
                    heatToCr_tbx.ReadOnly = false;
                    //not needed
                    lengthToCr_tbx.ReadOnly = true;
                    lumenToCr_tbx.ReadOnly = true;
                    flopsToCr_tbx.ReadOnly = true;
                }

                if (rb == drillToCr_rdo)
                {
                    //needed
                    ClassType = "Drill";
                    wattsToCr_tbx.ReadOnly = false;
                    //not needed
                    heatToCr_tbx.ReadOnly = true;
                    lengthToCr_tbx.ReadOnly = true;
                    lumenToCr_tbx.ReadOnly = true;
                    flopsToCr_tbx.ReadOnly = true;
                }

                if (rb == ductTapeToCr_rdo)
                {
                    //needed
                    ClassType = "DuctTape";
                    lengthToCr_tbx.ReadOnly = false;
                    //not needed
                    wattsToCr_tbx.ReadOnly = true;
                    heatToCr_tbx.ReadOnly = true;
                    flopsToCr_tbx.ReadOnly = true;
                }

                if (rb == laserToCr_rdo)
                {
                    //needed
                    ClassType = "Laser";
                    wattsToCr_tbx.ReadOnly = false;
                    lumenToCr_tbx.ReadOnly = false;
                    //not needed
                    heatToCr_tbx.ReadOnly = true;
                    lengthToCr_tbx.ReadOnly = true;
                    flopsToCr_tbx.ReadOnly = true;
                }

                if (rb == compToCr_rdo)
                {
                    //needed
                    ClassType = "Computer";
                    wattsToCr_tbx.ReadOnly = false;
                    flopsToCr_tbx.ReadOnly = false;
                    //not needed
                    heatToCr_tbx.ReadOnly = true;
                    lengthToCr_tbx.ReadOnly = true;
                    lumenToCr_tbx.ReadOnly = true;
                }
            }
    }

    //Get which kind of Category is used
    private void CategoryRadiosChanged(object sender, EventArgs e)
    {
        var rb = (RadioButton)sender;
        if (rb.Checked)
            if (catRdoToCr_grobo.Controls.Contains(rb))
                Category = rb == destroToCr_rdo ? "Destruction" :
                    rb == fixToCr_rdo ? "Fixation" :
                    rb == manipToCr_rdo ? "Manipulation" :
                    rb == weldingToCr_rdo ? "Welding" : "";
    }

    //Get which kind of Material is used
    private void MaterialRadiosChanged(object sender, EventArgs e)
    {
        var rb = (RadioButton)sender;
        if (rb.Checked)
            if (matsRdoToCr_grobo.Controls.Contains(rb))
                Material = rb == steelToCr_rdo ? "Steel" :
                    rb == aluToCr_rdo ? "Aluminum" :
                    rb == diamondToCr_rdo ? "Diamond" :
                    rb == woodToCr_rdo ? "Wood" : "";
    }

    #region TextboxesContent

    //Updates of the textboxes
    //Name of the tool
    private void nameToCr_tbx_TextChanged(object sender, EventArgs e)
    {
        ToolName = nameToCr_tbx.Text;
    }

    //SerialNumberGeneration
    private void serialNrGenerToCr_btn_Click(object sender, EventArgs e)
    {
        SerialNumber = Tools.SerialNumberGenerator();
        sernrToCr_lbl.Text = SerialNumber.ToString();
    }

    //Weight of the tool
    private void weightToCr_tbx_TextChanged(object sender, EventArgs e)
    {
        double.TryParse(weightToCr_tbx.Text, out var weight);
        Weight = weight;
    }

    //Watts of the tool
    private void wattsToCr_tbx_TextChanged(object sender, EventArgs e)
    {
        int.TryParse(wattsToCr_tbx.Text, out var result);
        Watts = result;
    }

    //Lumen of the lasertool
    private void lumenToCr_tbx_TextChanged(object sender, EventArgs e)
    {
        int.TryParse(lumenToCr_tbx.Text, out var result);
        Lumen = result;
    }

    //heat of the arcweldertool
    private void heatToCr_tbx_TextChanged(object sender, EventArgs e)
    {
        int.TryParse(heatToCr_tbx.Text, out var result);
        Heat = result;
    }

    //how much tape is enough? NO
    private void lengthToCr_tbx_TextChanged(object sender, EventArgs e)
    {
        int.TryParse(lengthToCr_tbx.Text, out var result);
        Length = result;
    }

    //computing power
    private void flopsToCr_tbx_TextChanged(object sender, EventArgs e)
    {
        int.TryParse(flopsToCr_tbx.Text, out var result);
        Flops = result;
    }

    #endregion


    #region Last call and close

    private void createToolToCr_btn_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
    }


    private void createToolToCr_btn_MouseEnter(object sender, EventArgs e)
    {
        if (ToolName == null || SerialNumber == null)
        {
            createToolToCr_btn.Enabled = false;
            MessageBox.Show("Please fill the Form correctly!");
        }
    }

    private void createToolToCr_btn_MouseLeave(object sender, EventArgs e)
    {
        createToolToCr_btn.Enabled = true;
    }

    #endregion
}