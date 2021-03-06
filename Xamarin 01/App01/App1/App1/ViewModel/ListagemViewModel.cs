﻿using App1.Model;
using App1.Service;
using System.Collections.Generic;
using Xamarin.Forms;

namespace App1.ViewModel
{
    public class ListagemViewModel : BaseViewModel
    {
        private Veiculo veiculoSelecionado;
        private List<Veiculo> veiculos;
        private bool aguarde;
        public ListagemViewModel()
        {
            Aguarde = true;
        }
        public List<Veiculo> Veiculos
        {
            get => veiculos;
            set
            {
                veiculos = value;
                OnPropertyChanged();
            }
        }
        public Veiculo VeiculoSelecionado
        {
            get => veiculoSelecionado;
            set
            {
                veiculoSelecionado = value;
                if (value != null)
                    MessagingCenter.Send(veiculoSelecionado, "VeiculoSelecionado");
            }
        }
        public async void CarregarVeiculos()
        {
            var listagem = new ListagemVeiculosService();
            Veiculos = await listagem.ListarVeiculosAsync();
            Aguarde = false;
        }

        public bool Aguarde { 
            get => aguarde; 
            set 
            { 
                aguarde = value; 
                OnPropertyChanged(); 
            } 
        }
    }
}
