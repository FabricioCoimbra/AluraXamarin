using App1.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App1.Service
{
    public class ListagemVeiculosService : BaseService
    {
        private readonly List<Veiculo> Veiculos;
        public ListagemVeiculosService()
        {
            Veiculos = new List<Veiculo>();
        }
        public async Task<List<Veiculo>> ListarVeiculosAsync()
        {
            var response = await Client.GetStringAsync(BASE_ADDRESS);
            var veiculosJson = JsonConvert.DeserializeObject<VeiculoJson[]>(response);
            Veiculos.Clear();

            foreach (var veiculo in veiculosJson)
            {
                Veiculos.Add(new Veiculo { Nome = veiculo.nome, Preco = veiculo.preco });
            }
            return Veiculos;
        }
    }
    class VeiculoJson
    {
        public string nome { get; set; }
        public int preco { get; set; }
    }

}
