using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

using ParkHouseV2.Models;

using Vehicles;


namespace ParkHouseV2.ViewModel;


//todo: how the fuck to use this shit with commands
public class CarCreationViewModel:INotifyPropertyChanged
	{
	public event PropertyChangedEventHandler? PropertyChanged;

	public CarCreationViewModel()
		{
		//aNd A fUcKtOn If InItS...
		_carModels = new ObservableCollection<string>(VehicleGenerator.DataListExporter("CarTypes"));
		CarModels = new ObservableCollection<string>();
		_bikeModels = new ObservableCollection<string>(VehicleGenerator.DataListExporter("MotorcycleTypes"));
		BikeModels = new ObservableCollection<string>();
		_truckModels = new ObservableCollection<string>(VehicleGenerator.DataListExporter("TruckTypes"));
		TruckModels = new ObservableCollection<string>();
		_carModelSelected = new();
		CarModelSelected = new();
		_bikeModelSelected = new();
		BikeModelSelected = new();
		_truckModelSelected = new();
		TruckModelSelected = new();
		_carRdoChecked = new();
		CarRdoChecked = new();
		_bikeRdoChecked = new();
		BikeRdoChecked = new();
		_truckRdoChecked = new();
		TruckRdoChecked = new();

		}

	/// <summary>
	/// build new vehcle, give params to method
	/// </summary>
	public void VehicleCreationForwarder()
		{   //todo: send to viewmodel with all collected data,
			//todo: close window
			//todo: dunno

		var vehicle =
			CarRdoChecked ? "car" :
			BikeRdoChecked ? "bike" :
			TruckRdoChecked ? "truck" :
			null;

		string model = vehicle switch
			{
				"car" => model = CarModelSelected.ToString(),
				"bike" => model = BikeModelSelected.ToString(),
				"truck" => model = TruckModelSelected.ToString(),
				_ => model = null
				};
		var licence = LicencePlateTyped.ToString();
		CustomVehicleCreator.CustomVehicleCreation(vehicle,model,licence);
		}

	#region Collections

	#region Get the modelnames
	private ObservableCollection<string> _carModels { get; set; }

	public ObservableCollection<string> CarModels
		{
		get { return _carModels; }
		set
			{
			_carModels = value;
			OnPropertyChanged(nameof(CarModels));
			}
		}

	private ObservableCollection<string> _bikeModels { get; set; }

	public ObservableCollection<string> BikeModels
		{
		get { return _bikeModels; }
		set
			{
			_bikeModels = value;
			OnPropertyChanged(nameof(BikeModels));
			}

		}

	private ObservableCollection<string> _truckModels { get; set; }

	public ObservableCollection<string> TruckModels
		{
		get { return _truckModels; }
		set
			{
			_truckModels = value;
			OnPropertyChanged(nameof(TruckModels));
			}
		}
	#endregion

	#region Get the selected names
	//Now the objects from the cobos for the vehicleCreationforwarder
	private object _carModelSelected { get; set; }

	public object CarModelSelected
		{
		get { return _carModelSelected; }
		set
			{
			_carModelSelected = value;
			OnPropertyChanged(nameof(CarModelSelected));
			}
		}

	private object _bikeModelSelected { get; set; }
	public object BikeModelSelected
		{
		get { return _bikeModelSelected; }
		set
			{
			_bikeModelSelected = value;
			OnPropertyChanged(nameof(BikeModelSelected));
			}
		}

	private object _truckModelSelected { get; set; }
	public object TruckModelSelected
		{
		get { return _truckModelSelected; }
		set
			{
			_truckModelSelected = value;
			OnPropertyChanged(nameof(TruckModelSelected));
			}

		}

	private object _licencePlateTyped { get; set; }
	public object LicencePlateTyped
		{
		get { return _licencePlateTyped; }
		set
			{
			_licencePlateTyped = value;
			OnPropertyChanged(nameof(LicencePlateTyped));
			}
		}
	#endregion

	#region Get the radiobuttons

	private bool _carRdoChecked { get; set; }

	public bool CarRdoChecked
		{
		get { return _carRdoChecked; }
		set
			{
			_carRdoChecked = value;
			OnPropertyChanged(nameof(CarRdoChecked));
			}
		}

	private bool _bikeRdoChecked { get; set; }

	public bool BikeRdoChecked
		{
		get
			{
			return _bikeRdoChecked;
			}
		set
			{
			_bikeRdoChecked = value;
			OnPropertyChanged(nameof(BikeRdoChecked));
			}
		}

	private bool _truckRdoChecked { get; set; }

	public bool TruckRdoChecked
		{
		get { return _truckRdoChecked; }
		set
			{
			_truckRdoChecked = value;
			OnPropertyChanged(nameof(TruckRdoChecked));
			}
		}

	#endregion

	#endregion

	#region MyRegion


	public void testtextfiller()
		{
		string testtext = "";
		int test = CarModels.Count;
		foreach(string ding in CarModels)
			{
			testtext += ding;
			testtext += ", ";
			}

		MessageBox.Show(test.ToString());
		}

	#endregion
	//todo: successtextbox

	#region onpropertychanged

	protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		{
		PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
		}

	protected bool SetField<T>(ref T field,T value,[CallerMemberName] string? propertyName = null)
		{
		if(EqualityComparer<T>.Default.Equals(field,value))
			return false;
		field = value;
		OnPropertyChanged(propertyName);
		return true;
		}

	#endregion

	}