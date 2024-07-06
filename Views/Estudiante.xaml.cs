using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace gtipansemana6.Views;

public partial class Estudiante : ContentPage
{
	private const string Url = "http://192.168.17.21/semana6/estudiantews.php";

	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Modelos.Estudiante> est;

    public Estudiante()
	{
		InitializeComponent();
		mostrar();
	}
	public async void mostrar()
	{
		var content = await cliente.GetStringAsync(Url);
		List<Modelos.Estudiante> mostrar = JsonConvert.DeserializeObject<List<Modelos.Estudiante>>(content);
		est = new ObservableCollection<Modelos.Estudiante>(mostrar);
        lisEstudiantes.ItemsSource = est;
	}
}