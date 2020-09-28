using System;
using System.Collections.Generic;
using System.Text;

namespace App1
{
    public class Veiculo
    {
        private string preco;

        public string Nome { get; set; }
        public string Preco { get => $"R$ {preco}"; set => preco = value; }
    }
}
