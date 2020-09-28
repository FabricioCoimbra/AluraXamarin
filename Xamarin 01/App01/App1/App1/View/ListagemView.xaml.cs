using App1.Model;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App1.View
{
    public partial class ListagemView : ContentPage
    {
        public List<Veiculo> Veiculos { get; set; }
        public ListagemView()
        {
            InitializeComponent();

            Veiculos = new ListagemVeiculos().ListarVeiculos;

            //definido pelo XAML em ItemsSource="{Binding Veiculos}"
            //ListaVeiculos.ItemsSource = Veiculos;

            //Poderia ser definida outra classe para contexto de binding desacoplando, ou complicando um pouco mais as coisas ...
            BindingContext = this;
        }

        private void ListaVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var veiculo = (Veiculo)e.Item;            
            var detalhe = new DetalheView(veiculo);
            Navigation.PushAsync(detalhe);
        }
    }
}
