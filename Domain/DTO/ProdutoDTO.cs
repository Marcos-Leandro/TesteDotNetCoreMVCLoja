using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class ProdutoDTO
    {
        public int ProdutoId { get; private set; }
        public string Nome { get; private set; }
        public int CategoriaId { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }

    }
}
