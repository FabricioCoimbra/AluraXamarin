using App1.Model;
using App1.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        private AgendamentoViewModel AgendamentoViewModel { get; set; }
        //public Veiculo Veiculo { get; set; }
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            //Veiculo = veiculo;
            AgendamentoViewModel = new AgendamentoViewModel(veiculo);
            BindingContext = AgendamentoViewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento", AgendamentoViewModel.AgendamentoFormatado, "OK");
        }
    }
}