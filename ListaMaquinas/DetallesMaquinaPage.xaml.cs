using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaMaquinas
{
    public partial class DetallesMaquinaPage : ContentPage
    {
        public DetallesMaquinaPage(Maquina maquina)
        {
            InitializeComponent();

            BindingContext = maquina;
        }

        private void VolverMainPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
