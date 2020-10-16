using App1.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace App1.ViewModel
{
    public class ListagemViewModel : INotifyPropertyChanged
    {
        private Veiculo veiculoSelecionado;
        public List<Veiculo> Veiculos { get; set; }
        public Veiculo VeiculoSelecionado { 
            get => veiculoSelecionado; 
            set 
            { 
                veiculoSelecionado = value;
                if (value != null)
                    MessagingCenter.Send(veiculoSelecionado, "VeiculoSelecionado");
            } 
        }
        public async void CarregarVeiculos() {
            var listagem = new ListagemVeiculos();
            Veiculos = await listagem.ListarVeiculosAsync();
            OnPropertyChanged(nameof(Veiculos));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
