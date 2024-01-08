using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using ParkHouseV2.Models;

using Vehicles;
using Vehicles.Land;

namespace ParkHouseV2.ViewModel;

public class MainViewModel:INotifyPropertyChanged
	{
	public event PropertyChangedEventHandler? PropertyChanged;

	#region Statics and Inits

	public ParkHouse ParkHouseNow;

	#region bool failsafes what kind of vehicle is currently generated
	private bool _carBtnActive { get; set; }
	public bool CarBtnActive
		{
		get { return _carBtnActive; }
		set
			{
			_carBtnActive = value;
			OnPropertyChanged(nameof(CarBtnActive));
			}
		}

	private bool _moCycleBtnActive { get; set; }

	public bool MoCycleBtnActive
		{
		get
			{
			return _moCycleBtnActive;
			}
		set
			{
			_moCycleBtnActive = value;
			OnPropertyChanged(nameof(MoCycleBtnActive));
			}
		}

	private bool _truckBtnActive { get; set; }

	public bool TruckBtnActive
		{
		get { return _truckBtnActive; }
		set
			{
			_truckBtnActive = value;
			OnPropertyChanged(nameof(TruckBtnActive));
			}
		}
	//focusable or nah
	private bool _clearVehicleDataWindowBtn { get; set; }

	public bool ClearVehicleDataWindowBtn
		{
		get { return _clearVehicleDataWindowBtn; }
		set
			{
			_clearVehicleDataWindowBtn = value;
			OnPropertyChanged(nameof(ClearVehicleDataWindowBtn));
			}
		}

	#endregion

	#region ChosenVehicle Statics --> not to be started without reason

	private Car _carNow { get; set; }

	public Car CarNow
		{
		get { return _carNow; }
		set
			{
			_carNow = value;
			OnPropertyChanged(nameof(CarNow));
			}
		}

	private Motorcycle _bikeNow { get; set; }

	public Motorcycle BikeNow
		{
		get { return _bikeNow; }
		set
			{
			_bikeNow = value;
			OnPropertyChanged(nameof(BikeNow));
			}
		}

	private Truck _truckNow { get; set; }

	public Truck TruckNow
		{
		get
			{
			return _truckNow;
			}
		set
			{
			_truckNow = value;
			OnPropertyChanged(nameof(TruckNow));
			}
		}

	#endregion

	#region Lists

	private ObservableCollection<string> _licencePlates { get; set; }

	public ObservableCollection<string> LicencePlates
		{
		get => _licencePlates;
		set
			{
			_licencePlates = value;
			OnPropertyChanged(nameof(LicencePlates));
			}
		}

	private ObservableCollection<string> _models { get; set; }

	public ObservableCollection<string> Models
		{
		get => _models;
		set
			{
			_models = value;
			OnPropertyChanged(nameof(Models));
			}
		}

	private ObservableCollection<int> _usedLotNumbers { get; set; }

	public ObservableCollection<int> UsedLotNumbers
		{
		get => _usedLotNumbers;
		set
			{
			_usedLotNumbers = value;
			OnPropertyChanged(nameof(UsedLotNumbers));
			}
		}

	#endregion

	#region Value field inputs etc
	private string _lotNumber { get; set; } //string because textbox

	public string LotNumber
		{
		get { return _lotNumber; }
		set
			{
			_lotNumber = value;
			OnPropertyChanged(nameof(LotNumber));
			}
		}

	private string _errorTextBox { get; set; }

	public string ErrorTextBox
		{
		get { return _errorTextBox; }
		set
			{
			_errorTextBox = value;
			OnPropertyChanged(nameof(ErrorTextBox));
			}
		}

	private string _resultTextBox { get; set; }

	public string ResultTextBox
		{
		get
			{
			return _resultTextBox;
			}
		set
			{
			_resultTextBox = value;
			OnPropertyChanged(nameof(ResultTextBox));
			}
		}

	private string _okLightColor { get; set; }

	public string OkLightColor
		{
		get { return _okLightColor; }
		set
			{
			_okLightColor = value;
			OnPropertyChanged(nameof(OkLightColor));
			}
		}

	private string _errorLightColor { get; set; }

	public string ErrorLightColor
		{
		get { return _errorLightColor; }
		set
			{
			_errorLightColor = value;
			OnPropertyChanged(nameof(ErrorLightColor));
			}
		}

	private int _freeTickerTxtBox
		{
		get;
		set;
		}
	public int FreeTickerTxtBox
		{
		get { return _freeTickerTxtBox; }
		set
			{
			_freeTickerTxtBox = value;
			OnPropertyChanged(nameof(FreeTickerTxtBox));
			}
		}

	private int _usedTickerTxtBox
		{
		get;
		set;
		}
	public int UsedTickerTxtBox
		{
		get { return _usedTickerTxtBox; }
		set
			{
			_usedTickerTxtBox = value;
			OnPropertyChanged(nameof(FreeTickerTxtBox));
			}
		}
	#endregion

	#region VehicleInfofields

	private string _nameTxtBox { get; set; }

	public string NameTxtBox
		{
		get { return _nameTxtBox; }
		set
			{
			_nameTxtBox = value;
			OnPropertyChanged(nameof(NameTxtBox));
			}
		}

	private string _licenceTxtBox { get; set; }

	public string LicenceTxtBox
		{
		get { return _licenceTxtBox; }
		set
			{
			_licenceTxtBox = value;
			OnPropertyChanged(nameof(LicenceTxtBox));
			}
		}

	private string _typeTxtBox { get; set; }

	public string TypeTxtBox
		{
		get { return _typeTxtBox; }
		set
			{
			_typeTxtBox = value;
			OnPropertyChanged(nameof(TypeTxtBox));
			}
		}

	private string _modelTxtBox { get; set; }

	public string ModelTxtBox
		{
		get { return _modelTxtBox; }
		set
			{
			_modelTxtBox = value;
			OnPropertyChanged(nameof(ModelTxtBox));
			}
		}

	#endregion

	#region VehicleSearchDropboxesfields

	private string _searchLicenceCobo { get; set; }
	public string SearchLicenceCobo
		{
		get { return _searchLicenceCobo; }
		set
			{
			_searchLicenceCobo = value;
			OnPropertyChanged(nameof(SearchLicenceCobo));
			}
		}

	private string _searchModelCobo { get; set; }

	public string SearchModelCobo
		{
		get { return _searchModelCobo; }
		set
			{
			_searchModelCobo = value;
			OnPropertyChanged(nameof(SearchModelCobo));
			}
		}

	private string _searchLotNumberCobo { get; set; } //Cobocontent is string by default

	public string SearchLotNumberCobo
		{
		get { return _searchLotNumberCobo; }
		set
			{
			_searchLotNumberCobo = value;
			OnPropertyChanged(nameof(SearchLotNumberCobo));
			}
		}

	#endregion

	#endregion

	public MainViewModel()
		{
		_carBtnActive = new();
		CarBtnActive = new();
		_truckBtnActive = new();
		TruckBtnActive = new();
		_moCycleBtnActive = new();
		MoCycleBtnActive = new();
		_clearVehicleDataWindowBtn = new();
		ClearVehicleDataWindowBtn = new();
		////
		_licencePlates = new ObservableCollection<string>();
		LicencePlates = new ObservableCollection<string>();
		_models = new ObservableCollection<string>();
		Models = new ObservableCollection<string>();
		_usedLotNumbers = new ObservableCollection<int>();
		UsedLotNumbers = new ObservableCollection<int>();
		////

		}

	#region Load and Save Parkhouse

	/// <summary>
	/// Create a new Parkhouse
	/// </summary>
	public void CreateNewParkHouse()
		{
		//testing
		//		MessageBox.Show("Works");
		//todo:setting for money per hour
		if(LotNumber != null)
			{
			var bla = int.TryParse(LotNumber,out int lot);
			if(!bla)
				{
				ErrorTextBox = "Error,please just Integers!";
				}

			ParkHouseNow = new ParkHouse(lot);
			if(ParkHouseNow.OkLight)
				{
				OkLightColor = "Green";
				ResultTextBox = ParkHouseNow.OkMessage;
				}
			else if(ParkHouseNow.ErrorLight)
				{
				ErrorLightColor = "Red";
				ErrorTextBox = ParkHouseNow.ErrorMessage;
				}
			}
		}

	public void LoadParkHouse()
		{
		ParkHouseNow = ParkHouse.LoadParkHouse();
		if(ParkHouseNow != null)
			{
			OkLightColor = "Green";
			ResultTextBox = "Parkhouse successfull loaded.";
			}
		else
			{
			ErrorLightColor = "Red";
			ErrorTextBox = "sCuSi, SuMdInG wUnG.";
			}
		}

	#endregion

	#region Vehicle Creation 

	public void NewCar()
		{
		CarNow = VehicleGenerator.CarGenerator();
		ShowVehicleInfosUpdate(CarNow);

		CarBtnActive = true;
		MoCycleBtnActive = false;
		TruckBtnActive = false;
		ClearVehicleDataWindowBtn = true;

		}

	public void NewBike()
		{
		BikeNow = VehicleGenerator.MotorcycleGenerator();
		ShowVehicleInfosUpdate(BikeNow);
		CarBtnActive = false;
		MoCycleBtnActive = true;
		TruckBtnActive = false;
		ClearVehicleDataWindowBtn = true;
		}

	public void NewTruck()
		{
		TruckNow = VehicleGenerator.TruckGenerator();
		ShowVehicleInfosUpdate(TruckNow);
		CarBtnActive = false;
		MoCycleBtnActive = false;
		TruckBtnActive = true;
		ClearVehicleDataWindowBtn = true;
		}

	//Custom Setters, from CustomWindow
	//todo: obacht die müssen noch gemacht werden
	public void CustomCarSetter(Car car)
		{
		CarNow = car;
		ShowVehicleInfosUpdate(CarNow);
		CarBtnActive = true;
		MoCycleBtnActive = false;
		TruckBtnActive = false;
		ClearVehicleDataWindowBtn = true;
		}

	public void CustomBikeSetter(Motorcycle bike)
		{
		BikeNow = bike;
		ShowVehicleInfosUpdate(BikeNow);
		CarBtnActive = false;
		MoCycleBtnActive = true;
		TruckBtnActive = false;
		ClearVehicleDataWindowBtn = true;
		}

	public void CustomTruckSetter(Truck truck)
		{
		TruckNow = truck;
		ShowVehicleInfosUpdate(TruckNow);
		CarBtnActive = false;
		MoCycleBtnActive = false;
		TruckBtnActive = true;
		ClearVehicleDataWindowBtn = true;
		}

	#endregion

	#region Searchbutton Querries

	public void SearchLicence()
		{
		foreach(var vehicle in ParkHouseNow.parkingLots)
			if(vehicle is Car car)
				{
				if(car.LicencePlate.ToString() == SearchLicenceCobo)
					ShowVehicleInfosUpdate(car);
				CarNow = car;
				}
			else if(vehicle is Motorcycle mo)
				{
				if(mo.LicencePlate.ToString() == SearchLicenceCobo)
					ShowVehicleInfosUpdate(mo);
				BikeNow = mo;
				}
			else if(vehicle is Truck truck)
				{
				if(truck.LicencePlate.ToString() == SearchLicenceCobo)
					ShowVehicleInfosUpdate(truck);
				TruckNow = truck;
				}
		}

	public void SearchModel()
		{
		foreach(var vehicle in ParkHouseNow.parkingLots)
			if(vehicle is Car car)
				{
				if(car.Type.ToString() == SearchModelCobo)
					ShowVehicleInfosUpdate(car);
				CarNow = car;
				}
			else if(vehicle is Motorcycle mo)
				{
				if(mo.Type.ToString() == SearchModelCobo)
					ShowVehicleInfosUpdate(mo);
				BikeNow = mo;
				}
			else if(vehicle is Truck truck)
				{
				if(truck.Type.ToString() == SearchModelCobo)
					ShowVehicleInfosUpdate(truck);
				TruckNow = truck;
				}
		}

	public void SearchLotNumber()
		{
		var vehicle
			= ParkHouseNow.parkingLots[Convert.ToInt32(SearchLotNumberCobo)];
			{
			if(vehicle is Car car)
				{
				ShowVehicleInfosUpdate(car);
				CarNow = car;
				}
			else if(vehicle is Motorcycle mo)
				{
				ShowVehicleInfosUpdate(mo);
				BikeNow = mo;
				}
			else if(vehicle is Truck truck)
				{
				ShowVehicleInfosUpdate(truck);
				TruckNow = truck;
				}
			}
		}

	#endregion

	#region Park in and Out

	public void ParkIn()
		{
		if(CarBtnActive)
			{
			ParkHouseNow.Parking(CarNow);
			}
		else if(MoCycleBtnActive)
			{
			ParkHouseNow.Parking(BikeNow);
			}
		else if(TruckBtnActive)
			{
			ParkHouseNow.Parking(TruckNow);
			}
		else
			{
			ErrorLightColor = "Red";
			ErrorTextBox = "No Vehicle in active focus!";
			}

		if(ParkHouseNow.OkLight)
			{
			OkLightColor = "Green";
			ResultTextBox = ParkHouseNow.OkMessage;
			UpdateLotCounters();
			UpdateListsFromParkhouse(ParkHouseNow);
			}
		else if(ParkHouseNow.ErrorLight)
			{
			ErrorLightColor = "Red";
			ErrorTextBox = ParkHouseNow.ErrorMessage;
			}
		}

	public void ParkOut()
		{
		if(CarBtnActive)
			{
			ParkHouseNow.Leaving(CarNow);
			}
		else if(MoCycleBtnActive)
			{
			ParkHouseNow.Leaving(BikeNow);
			}
		else if(TruckBtnActive)
			{
			ParkHouseNow.Leaving(TruckNow);
			}

		OkLightColor = "Green";
		ResultTextBox = ParkHouseNow.OkMessage;
		UpdateLotCounters();
		UpdateListsFromParkhouse(ParkHouseNow);
		}


	#endregion

	#region Misc

	/// <summary>
	/// This fills the infoboxes with data of current chosen vehicle, wether by generating or search result.
	/// Needs to be public till bastard transformation done
	/// </summary>
	private void ShowVehicleInfosUpdate(Vehicle vec)
		{
		NameTxtBox = vec.Name;
		if(vec is Car car)
			{
			LicenceTxtBox = car.LicencePlate;
			TypeTxtBox = "Car";
			ModelTxtBox = car.Type;

			}
		else if(vec is Motorcycle mo)
			{
			LicenceTxtBox = mo.LicencePlate;
			TypeTxtBox = "MotorBike";
			ModelTxtBox = mo.Type;
			}
		else if(vec is Truck truck)
			{
			LicenceTxtBox = truck.LicencePlate;
			TypeTxtBox = "Truck";
			ModelTxtBox = truck.Type;
			}
		}

	public void ClearVehicleDataWindows()
		{
		CarBtnActive = false;
		TruckBtnActive = false;
		MoCycleBtnActive = false;
		//
		OkLightColor = "Grey";
		ErrorLightColor = "Grey";
		ResultTextBox = null;
		ErrorTextBox = null;
		//
		NameTxtBox = null;
		LicenceTxtBox = null;
		TypeTxtBox = null;
		ModelTxtBox = null;
		//
		ClearVehicleDataWindowBtn = false; //Inactive till next time
		}


	/// <summary>
	/// Whenever something changed, it gets updated here.
	/// </summary>
	public void UpdateListsFromParkhouse(ParkHouse parkhouse)
		{
		LicencePlates.Clear();
		Models.Clear();
		UsedLotNumbers.Clear();

		foreach(var licencePlate in parkhouse.LicencePlates)
			LicencePlates.Add(licencePlate);

		foreach(var model in parkhouse.Models)
			Models.Add(model);

		foreach(var lot in parkhouse.UsedLotNumbers)
			UsedLotNumbers.Add(lot);
		}

	private void UpdateLotCounters()
		{
		UsedTickerTxtBox = ParkHouseNow.UsedLots;
		FreeTickerTxtBox = ParkHouseNow.FreeLots;
		}

	#region TestArea

	public void TestingButton()
		{
		ErrorTextBox = ParkHouseNow.ShowTime();
		}

	#endregion

	#endregion

	#region OnPropertyChanged
	protected virtual void OnPropertyChanged(
		[CallerMemberName] string? propertyName = null)
		{
		PropertyChanged?.Invoke(this,
			new PropertyChangedEventArgs(propertyName));
		}

	protected bool SetField<T>(ref T field,T value,
							   [CallerMemberName] string? propertyName = null)
		{
		if(EqualityComparer<T>.Default.Equals(field,value))
			return false;
		field = value;
		OnPropertyChanged(propertyName);
		return true;
		}
	#endregion

	}