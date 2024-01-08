using System.Windows;
using System.Windows.Controls;

using ParkHouseV2.ViewModel;
using ParkHouseV2.Views;


namespace ParkHouseV2;


public partial class MainWindow
	{

	public MainViewModel viewModel;

	#region initialization

	public MainWindow()
		{
		InitializeComponent();

		//Binding
		viewModel = new MainViewModel();
		DataContext = viewModel;
		}

	#endregion


	#region Create & Load Parkhouse

	/// <summary>
	/// Create a new Parkhouse
	/// </summary>
	private void CreatePhouse_btn_OnClick(object sender,RoutedEventArgs e)
		{
		viewModel.CreateNewParkHouse(); //Let the Viewmodel handle it
										//Clear up
		createPhouse_btn.Focusable = false; //save button from idots
		loadLastPh_btn.Focusable = false; //same
		lotAmount_tbx.Text = null; //same
		}

	/// <summary>
	///     Load last configured Parkhouse
	/// </summary>
	private void LoadLastPh_btn_OnClick(object sender,RoutedEventArgs e)
		{
		//Clear up
		createPhouse_btn.Focusable = false; //save button from idots
		loadLastPh_btn.Focusable = false; //same
		lotAmount_tbx.Text = null; //same
		}

	#endregion

	#region Vehicle Creation

	private void Car_btn_OnClick(object sender,RoutedEventArgs e)
		{
		viewModel.NewCar();
		}

	private void MoCy_btn_OnClick(object sender,RoutedEventArgs e)
		{
		viewModel.NewBike();
		}

	private void Truck_btn_OnClick(object sender,RoutedEventArgs e)
		{
		viewModel.NewTruck();
		}

	#endregion

	#region In and out buttons

	/// <summary>
	///     Park in Call, check which type is currently chosen via BtnActive
	/// </summary>
	private void ParkIn_btn_OnClick(object sender,RoutedEventArgs e)
		{
		viewModel.ParkIn();
		}

	private void DriveOut_btn_OnClick(object sender,RoutedEventArgs e)
		{
		viewModel.ParkOut();
		}

	#endregion


	#region SearchButtons

	private void SearchLicence_btn_OnClick(object sender,RoutedEventArgs e)
		{
		viewModel.SearchLicence();
		}

	private void SearchType_btn_OnClick(object sender,RoutedEventArgs e)
		{
		viewModel.SearchModel();
		}

	private void SearchLot_btn_OnClick(object sender,RoutedEventArgs e)
		{
		viewModel.SearchLotNumber();
		}

	#endregion


	#region Clear All & miscallenous

	/// <summary>
	///     Reset the textboxes and bools and all
	/// </summary>
	private void ClearVehicleDataWindows_btn_OnClick
	(
		object sender,
		RoutedEventArgs e) //for the data in bottomleft
		{
		viewModel.ClearVehicleDataWindows();
		}


	private void Testing_btn_OnClick(object sender,RoutedEventArgs e)
		{
		viewModel.TestingButton();
		}

	#endregion


	//dafux is dis
	private void SearchLicence_cobx_OnSelectionChanged(object sender,SelectionChangedEventArgs e)
		{
		resultText_tbx.Text = searchLicence_cobx.Text;
		}

	private void CustomCreation_btn_OnClick(object sender,RoutedEventArgs e)
		{
		var carCreation = new CarCreation();
		carCreation.Show();

		}

	}