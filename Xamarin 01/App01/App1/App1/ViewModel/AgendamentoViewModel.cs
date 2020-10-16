using App1.Model;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModel
{
    public class AgendamentoViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataAgendamento { get; set; }
        public TimeSpan HoraAgendamento { get; set; }
        public Veiculo Veiculo { get; set; }
        public string AgendamentoFormatado => string.Format(@"
            Nome: {0}
            Fone: {1}
            E-mail: {2}
            Data Agendamento: {3}
            Hora Agendamento: {4}",
            Nome, Telefone, Email, DataAgendamento.ToString("dd/MM/yyyy"), HoraAgendamento);
        public AgendamentoViewModel(Veiculo veiculo)
        {
            Veiculo = veiculo;
            DataAgendamento = DateTime.Now.AddDays(3);
            AgendarCommand = new Command(() => MessagingCenter.Send(this, "Agendar"));
        }
        public ICommand AgendarCommand { get; set; }
    }
}
