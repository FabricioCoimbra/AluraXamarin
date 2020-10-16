using App1.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModel
{
    public class AcessorioViewModel : INotifyPropertyChanged
    {
        public string TextoFreioABS { get => $"Freio ABS - R$ {Veiculo.FREIO_ABS}"; }
        public string TextoControleTracao { get => $"Controle de tração - R$ {Veiculo.CONTROLE_TRACAO}"; }
        public string TextoAssistentePartidaRampa { get => $"Assitente de partida em rampa - R$ {Veiculo.ASSISTENTE_PARTIDA_RAMPA}"; }
        public bool TemFreioABS
        {
            get => Veiculo.TemFreioABS;
            set
            {
                Veiculo.TemFreioABS = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TextoTotal));
            }
        }

        public bool TemControleTracao
        {
            get => Veiculo.TemControleTracao;
            set
            {
                Veiculo.TemControleTracao = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TextoTotal));
            }
        }
        public bool TemAssistentePartida
        {
            get => Veiculo.TemAssistentePartida;
            set
            {
                Veiculo.TemAssistentePartida = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TextoTotal));
            }
        }
        public string TextoTotal
        {
            get
            {
                return string.Format("Total = R$ {0}", Veiculo.Preco
                    + (TemFreioABS ? Veiculo.FREIO_ABS : 0)
                    + (TemControleTracao ? Veiculo.CONTROLE_TRACAO : 0)
                    + (TemAssistentePartida ? Veiculo.ASSISTENTE_PARTIDA_RAMPA : 0)
                    );
            }
        }
        public Veiculo Veiculo { get; set; }
        public AcessorioViewModel(Veiculo veiculo)
        {
            Veiculo = veiculo;
            ProximoCommand = new Command(() => MessagingCenter.Send(Veiculo, "Proximo"));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand ProximoCommand { get; set; }
    }
}
