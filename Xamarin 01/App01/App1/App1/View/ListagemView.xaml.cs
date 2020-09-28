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

            this.Veiculos = new List<Veiculo>
            {
                new Veiculo{ Nome="Sandero", Preco= 54290.0},
                new Veiculo{ Nome="Kwid", Preco=37490.0},
                new Veiculo{ Nome="Stepway :)", Preco=70090.0},
                new Veiculo{ Nome="Sandero RS", Preco=59390.0},
                new Veiculo{ Nome="Sandero Vibe", Preco=59390.0},
                new Veiculo{ Nome="Sandero GT Line", Preco=59390.0},
                new Veiculo{ Nome="Logan", Preco=58490.0},
                new Veiculo{ Nome="Captur", Preco=97990.0},
                new Veiculo{ Nome="Duster", Preco=71790.0},
                new Veiculo{ Nome="Oroch", Preco=69590.0},
                new Veiculo{ Nome="Master", Preco=144490.0}
            };

            //definido pelo XAML em ItemsSource="{Binding Veiculos}"
            //ListaVeiculos.ItemsSource = Veiculos;

            //Poderia ser definida outra classe para contexto de binding desacoplando, ou complicando um pouco mais as coisas ...
            BindingContext = this;
        }

        private void ListaVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var veiculo = (Veiculo)e.Item;
            //DisplayAlert("Veículo selecionado", $"Voçê selecionou o veículo {veiculo.Nome} que custa {veiculo.Preco} ", "Entendi");
            var detalhe = new DetalheView(veiculo);
            Navigation.PushAsync(detalhe);
        }
    }
}
