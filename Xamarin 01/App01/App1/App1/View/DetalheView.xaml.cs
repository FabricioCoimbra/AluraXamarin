using App1.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheView : ContentPage
    {
        public Veiculo Veiculo { get; set; }
        public DetalheView(Veiculo veiculo)
        {
            InitializeComponent();
            Veiculo = veiculo;
            Title = Veiculo.Nome;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(Veiculo));
        }
    }
}