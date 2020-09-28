using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public List<Veiculo> Veiculos { get; set; }
        public MainPage()
        {
            InitializeComponent();

            this.Veiculos = new List<Veiculo>
            {
                new Veiculo{ Nome="Sandero", Preco="54.290"},
                new Veiculo{ Nome="Kwid", Preco="37.490"},
                new Veiculo{ Nome="Stepway :)", Preco="70.090"},
                new Veiculo{ Nome="Sandero RS", Preco="59.390"},
                new Veiculo{ Nome="Sandero Vibe", Preco="59.390"},
                new Veiculo{ Nome="Sandero GT Line", Preco="59.390"},
                new Veiculo{ Nome="Logan", Preco="58.490"},
                new Veiculo{ Nome="Captur", Preco="97.990"},
                new Veiculo{ Nome="Duster", Preco="71.790"},
                new Veiculo{ Nome="Oroch", Preco="69.590"},
                new Veiculo{ Nome="Master", Preco="144.490"}
            };

            //definido pelo XAML em ItemsSource="{Binding Veiculos}"
            //ListaVeiculos.ItemsSource = Veiculos;

            //Poderia ser definida outra classe para contexto de binding desacoplando, ou complicando um pouco mais as coisas ...
            BindingContext = this;
        }

        private void ListaVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var veiculo = (Veiculo)e.Item;
            DisplayAlert("Veículo selecionado", $"Voçê selecionou o veículo {veiculo.Nome} que custa {veiculo.Preco} ", "Entendi");
        }
    }
}
