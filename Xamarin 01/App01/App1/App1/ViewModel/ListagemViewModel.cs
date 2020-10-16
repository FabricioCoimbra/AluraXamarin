using App1.Model;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App1.ViewModel
{
    public class ListagemViewModel
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
        public ListagemViewModel()
        {
            Veiculos = new ListagemVeiculos().ListarVeiculos;

        }
    }
}
