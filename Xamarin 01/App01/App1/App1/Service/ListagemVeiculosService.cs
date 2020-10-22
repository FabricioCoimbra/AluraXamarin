using App1.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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

            //ContractResolver = new CamelCasePropertyNamesContractResolver()
            var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() };
            var veiculosJson = JsonConvert.DeserializeObject<VeiculoJson[]>(response, jsonSerializerSettings);
            Veiculos.Clear();
            foreach (var veiculo in veiculosJson)
            {
                Veiculos.Add(new Veiculo { Nome = veiculo.Nome, Preco = veiculo.Preco });
            }
            return Veiculos;
        }
    }
}
