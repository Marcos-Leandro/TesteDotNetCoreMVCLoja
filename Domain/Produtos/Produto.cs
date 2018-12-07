using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Produtos
{
    public class Produto
    {
        public Produto(string nome, Categoria categoria, decimal preco, int estoque)
        {
            ValidarProduto(nome, categoria, preco, estoque);
            SetProduto(nome, categoria, preco, estoque);
        }

        public void Update(string nome, Categoria categoria, decimal preco, int estoque)
        {
            ValidarProduto(nome, categoria, preco, estoque);
            SetProduto(nome, categoria, preco, estoque);
        }

        private void SetProduto(string nome, Categoria categoria, decimal preco, int estoque)
        {
            Nome = nome;
            Categoria = categoria;
            Preco = preco;
            Estoque = estoque;
        }

        private static void ValidarProduto(string nome, Categoria categoria, decimal preco, int estoque)
        {
            DomainException.When(!string.IsNullOrEmpty(nome), "O nome do produto é obrigatório.");
            DomainException.When(categoria == null, "A categoria é obrigatória.");
            DomainException.When(preco <= 0, "O preço é obrigatório.");
            DomainException.When(estoque <= 0, "O estoque é obrigatório.");
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public Categoria Categoria { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }
    }
}
