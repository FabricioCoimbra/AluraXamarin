using App1.Model;
using System;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace App1.ViewModel
{
    public class AgendamentoViewModel : BaseViewModel
    {
        private const string URL_POST_AGENDATMENTO = "https://aluracar.herokuapp.com/salvaragendamento";
        private string nome;
        private string email;
        private string telefone;

        public string Nome
        {
            get => nome;
            set
            {
                nome = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }
        public string Telefone
        {
            get => telefone;
            set
            {
                telefone = value;
                OnPropertyChanged();
                ((Command)AgendarCommand).ChangeCanExecute();
            }
        }
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
            AgendarCommand = new Command(
                () => MessagingCenter.Send(this, "Agendar"),
                () =>
                {
                    return !string.IsNullOrEmpty(Nome)
                        && !string.IsNullOrEmpty(Email)
                        && !string.IsNullOrEmpty(Telefone);
                }
            );
        }
        public ICommand AgendarCommand { get; set; }

        public async Task SalvarAgendamentoAsync()
        {
            HttpClient client = new HttpClient();

            var dataHoraAgendamento = new DateTime(DataAgendamento.Year, DataAgendamento.Month, DataAgendamento.Day,
                HoraAgendamento.Hours, HoraAgendamento.Minutes, HoraAgendamento.Seconds);

            var json = JsonConvert.SerializeObject(new
            {
                nome = Nome,
                fone = Telefone,
                email = Email,
                carro = Veiculo.Nome,
                preco = Veiculo.Preco,
                dataAgendamento = dataHoraAgendamento
            }
            );

            var conteudo = new StringContent(json, Encoding.UTF8, "application/json");
            var resposta = await client.PostAsync(URL_POST_AGENDATMENTO, conteudo);
            if (resposta.IsSuccessStatusCode)
            {
                MessagingCenter.Send(this, "SucessoAgendamento");
            }
            else
            {
                MessagingCenter.Send(new ArgumentException("Falha ao gravar o agendamento \r\n" + resposta.ReasonPhrase), "ErroAgendamento");
            }

        }
    }
}
