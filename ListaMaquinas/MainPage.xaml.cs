using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListaMaquinas
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Maquina> maquinas;

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

