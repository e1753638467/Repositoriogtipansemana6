namespace gtipansemana6.Views;
using gtipansemana6.Modelos;
using System.Collections.Specialized;
using System.Net;

public partial class ActEliminar : ContentPage
{
	public ActEliminar(Modelos.Estudiante datos)
	{
		InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre;
        txtApellido.Text = datos.apellido;
        txtEdad.Text = datos.edad.ToString();

    }


    private void btnElimianr_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new NameValueCollection();
            parametros.Add("codigo", txtCodigo.Text); // Envía solo el código para eliminar

            cliente.UploadValues("http://192.168.17.21/semana6/estudiantews.php", "POST", parametros);

            DisplayAlert("Eliminado", "El estudiante ha sido eliminado correctamente.", "OK");
            Navigation.PushAsync(new Estudiante()); // Vuelve a la página de lista de estudiantes
        }
        catch (Exception ex)
        {
            DisplayAlert("Alerta", ex.Message, "OK");
        }
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();
            var parametros = new NameValueCollection();
            parametros.Add("codigo", txtCodigo.Text);
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);

            cliente.UploadValues("http://192.168.17.21/semana6/estudiantews.php", "POST", parametros);

            DisplayAlert("Actualizado", "El estudiante ha sido actualizado correctamente.", "OK");
            Navigation.PushAsync(new Estudiante()); // Vuelve a la página de lista de estudiantes
        }
        catch (Exception ex)
        {
            DisplayAlert("Alerta", ex.Message, "OK");
        }
    }
}