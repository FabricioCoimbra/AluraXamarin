using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace App1.Model
{
    public class ListagemVeiculos
    {
        private const string GET_URL_VEICULOS = "https://aluracar.herokuapp.com/";
        private readonly List<Veiculo> Veiculos;
        public ListagemVeiculos()
        {
            Veiculos = new List<Veiculo>();
        }
        public async Task<List<Veiculo>> ListarVeiculosAsync()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync(GET_URL_VEICULOS);
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
