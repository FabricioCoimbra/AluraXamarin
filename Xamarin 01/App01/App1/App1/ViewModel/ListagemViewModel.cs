using App1.Model;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App1.ViewModel
{
    public class ListagemViewModel : BaseViewModel
    {
        private Veiculo veiculoSelecionado;
        private List<Veiculo> veiculos;
        public List<Veiculo> Veiculos {
            get => veiculos; 
            set 
            { 
                veiculos = value;
                OnPropertyChanged();
            }
        }
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
        }
    }
}
