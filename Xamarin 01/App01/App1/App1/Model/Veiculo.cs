namespace App1.Model
{
    public class Veiculo
    {
        public const int FREIO_ABS = 800;
        public const int CONTROLE_TRACAO = 1200;
        public const int ASSISTENTE_PARTIDA_RAMPA = 1500;
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string PrecoFormatado { get => $"R$ {Preco}"; }
        public bool TemFreioABS { get; set; }
        public bool TemControleTracao { get; set; }
        public bool TemAssistentePartida { get; set; }
    }
}
