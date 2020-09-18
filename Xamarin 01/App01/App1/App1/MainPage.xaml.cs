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
                new Veiculo{ Nome="Sandero", Preco="R$ 54.290"},
                new Veiculo{ Nome="Kwid", Preco="R$ 37.490"},
                new Veiculo{ Nome="Stepway :)", Preco="R$ 70.090"},
                new Veiculo{ Nome="Sandero RS", Preco="R$ 59.390"},
                new Veiculo{ Nome="Sandero Vibe", Preco="R$ 59.390"},
                new Veiculo{ Nome="Sandero GT Line", Preco="R$ 59.390"},
                new Veiculo{ Nome="Logan", Preco="R$ 58.490"},
                new Veiculo{ Nome="Captur", Preco="R$ 97.990"},
                new Veiculo{ Nome="Duster", Preco="R$ 71.790"},
                new Veiculo{ Nome="Oroch", Preco="R$ 69.590"},
                new Veiculo{ Nome="Master", Preco="R$ 144.490"}
            };

            //definido pelo XAML
            //ListaVeiculos.ItemsSource = Veiculos;

            //Poderia ser definida outra classe para contexto de binding desacoplando, ou complicando um pouco mais as coisas ...
            BindingContext = this;
        }
    }
}
