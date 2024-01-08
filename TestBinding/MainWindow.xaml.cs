using System.Collections.ObjectModel;
using System.Windows;

namespace TestBinding;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow: Window
	{
	public MainWindow()
		{
		InitializeComponent();

		DataContext = Storage;
		Storage = new Storage();
		coboString.ItemsSource = Storage.Strings;
		}

	public Storage Storage { get; private set; }
	private void btnString_Click(object sender, RoutedEventArgs e)
		{
		Storage.Strings.Add(tbxString.Text);
		tbxString.Text = null;
		}
	}

public class Storage
	{
	public ObservableCollection<string>? Strings { get; set; }

	public Storage()
		{
		Strings = new ObservableCollection<string>();
		}

	}
