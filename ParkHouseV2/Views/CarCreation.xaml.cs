using System.Windows;
using System.Windows.Input;

using ParkHouseV2.ViewModel;


namespace ParkHouseV2.Views;


/// <summary>
/// Interaction logic for CarCreation.xaml
/// </summary>
public partial class CarCreation:Window
	{
	public CarCreationViewModel carCreationViewModel;

	public CarCreation()
		{
		InitializeComponent();
		carCreationViewModel = new CarCreationViewModel();
		DataContext = carCreationViewModel;
		}

	private void createVehicle_btn_Click(object sender,RoutedEventArgs e)
		{
		//todo: send to viewmodel with all collected data,
		//todo: close window
		//todo: dunno
		carCreationViewModel.VehicleCreationForwarder();
		Close();
		;
		}

	private void CloseCommandHandler(object sender,ExecutedRoutedEventArgs e)
		{
		this.Close();
		}

	private void Testbutton_OnClick(object sender,RoutedEventArgs e)
		{
		carCreationViewModel.testtextfiller();
		}
	}