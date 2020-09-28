using App1.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheView : ContentPage
    {
        private const int FREIO_ABS = 800;
        private const int CONTROLE_TRACAO = 1200;
        private const int ASSISTENTE_PARTIDA_RAMPA = 1500;
        private bool temFreioABS;

        public String TextoFreioABS { get => $"Freio ABS - R$ {FREIO_ABS}"; }
        public String TextoControleTracao { get => $"Controle de tração - R$ {CONTROLE_TRACAO}"; }
        public String TextoAssistentePartidaRampa { get => $"Assitente de partida em rampa - R$ {ASSISTENTE_PARTIDA_RAMPA}"; }
        public String TextoTotal { get => $"Total = R$ {Veiculo.Preco}"; }
        public bool TemFreioABS
        {
            get => temFreioABS;
            set
            {
                temFreioABS = value;
                if (temFreioABS)
                    DisplayAlert("Freio ABS", "Ligado", "OK");
                else
                    DisplayAlert("Freio ABS", "Desligado", "OK");
            }
        }
        public Veiculo Veiculo { get; set; }
        public DetalheView(Veiculo veiculo)
        {
            InitializeComponent();
            Veiculo = veiculo;
            Title = Veiculo.Nome;
            BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgendamentoView(Veiculo));
        }
    }
}