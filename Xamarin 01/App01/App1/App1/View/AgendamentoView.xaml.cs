using App1.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataAgendamento { get; set; }
        public TimeSpan HoraAgendamento { get; set; }
        public Veiculo Veiculo { get; set; }
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            Veiculo = veiculo;
            Title = Veiculo.Nome;
            DataAgendamento = DateTime.Now.AddDays(3);
            BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Agendamento", string.Format(
                @"Nome = {0}
Fone: {1}
E-mail: {2}
Data Agendamento: {3}
Hora Agendamento: {4}",
                Nome, Telefone, Email, DataAgendamento.ToString("dd/MM/yyyy"), HoraAgendamento), "OK");
        }
    }
}