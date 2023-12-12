using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuProyecto;
using Xamarin.Forms;

namespace ListaMaquinas
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Maquina> maquinas;

        private readonly SqlManager sqlManager;

        public MainPage()
        {
            InitializeComponent();

            maquinas = new ObservableCollection<Maquina>
            {
                new Maquina { CodMaq = 1, Descripcion = "Máquina 1", Tipo = "Tipo A" },
                new Maquina { CodMaq = 2, Descripcion = "Máquina 2", Tipo = "Tipo B" },
                // Agrega más máquinas según sea necesario
            };

            maquinasListView.ItemsSource = maquinas;

            // Reemplaza "tu_cadena_de_conexion" con tu cadena de conexión real
            sqlManager = new SqlManager("LAPTOP-KAM0F61V\\SQLEXPRESS02");
        }

        private void OnObtenerValorClicked(object sender, EventArgs e)
        {
            // Reemplaza la consulta con tu consulta real
            string query = "SELECT codmaq FROM [dbo].[APPStMaqui] WHERE codmaq=11;";

            // Ejecutar la consulta y obtener el resultado
            string resultado = sqlManager.EjecutarConsulta(query);

            // Mostrar el resultado en el Label
            resultadoLabel.Text = $"Resultado: {resultado}";
        }
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            // Navegar a la página de detalles de la máquina
            Navigation.PushAsync(new DetallesMaquinaPage((Maquina)e.SelectedItem));

            // Desseleccionar el ítem de la lista
            maquinasListView.SelectedItem = null;
        }
    }
}

