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
            MessagingCenter.Subscribe<AgendamentoViewModel>(this, "Agendar", async (msg) => {
                var confirma = await DisplayAlert("Salvar agendamento", "Deseja confirmar o agendamento?", "Sim", "Não");
                if (confirma)
                    await msg.SalvarAgendamentoAsync();
            });

            MessagingCenter.Subscribe<AgendamentoViewModel>(this, "SucessoAgendamento", async (msg) => {
                    await DisplayAlert("Agendamento gravado com sucesso", msg.AgendamentoFormatado, "OK");
            });

            MessagingCenter.Subscribe<ArgumentException>(this, "ErroAgendamento", async (msg) => {
                await DisplayAlert("Erro ao gravar o agendamento", msg.Message, "OK");
            });
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<AgendamentoViewModel>(this, "Agendar");
            MessagingCenter.Unsubscribe<AgendamentoViewModel>(this, "SucessoAgendamento");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "ErroAgendamento");
        }
    }
}