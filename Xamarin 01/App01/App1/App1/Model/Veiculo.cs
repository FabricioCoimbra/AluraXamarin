namespace App1.Model
{
    public class Veiculo
    {
        private string preco;

        public string Nome { get; set; }
        public string Preco { get => $"R$ {preco}"; set => preco = value; }
    }
}
