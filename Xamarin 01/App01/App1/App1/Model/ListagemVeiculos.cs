using System.Collections.Generic;

namespace App1.Model
{
    public class ListagemVeiculos
    {
        public List<Veiculo> ListarVeiculos => new List<Veiculo>
            {
                new Veiculo{ Nome = "Sandero", Preco = 54290.0},
                new Veiculo{ Nome = "Kwid", Preco = 37490.0},
                new Veiculo{ Nome = "Stepway :)", Preco = 70090.0},
                new Veiculo{ Nome = "Sandero RS", Preco = 59390.0},
                new Veiculo{ Nome = "Sandero Vibe", Preco = 59390.0},
                new Veiculo{ Nome = "Sandero GT Line", Preco = 59390.0},
                new Veiculo{ Nome = "Logan", Preco = 58490.0},
                new Veiculo{ Nome = "Captur", Preco = 97990.0},
                new Veiculo{ Nome = "Duster", Preco = 71790.0},
                new Veiculo{ Nome = "Oroch", Preco = 69590.0},
                new Veiculo{ Nome = "Master", Preco = 144490.0}
            };
    }
}
