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
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            AgendamentoViewModel = new AgendamentoViewModel(veiculo);
            BindingContext = AgendamentoViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<AgendamentoViewModel>(this, "Agendar", (msg) => DisplayAlert("Agendamento", msg.AgendamentoFormatado, "OK"));
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<AgendamentoViewModel>(this, "Agendar");
        }
    }
}