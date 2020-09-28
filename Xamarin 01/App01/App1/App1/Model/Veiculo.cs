namespace App1.Model
{
    public class Veiculo
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string PrecoFormatado { get => $"R$ {Preco}"; }
    }
}
