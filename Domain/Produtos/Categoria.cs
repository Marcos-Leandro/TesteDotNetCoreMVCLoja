using Domain.Produtos;
using System;

namespace Domain.Produtos
{
    public class Categoria : Entity
    {
        public Categoria(string nome)
        {
            ValidarCategoria(nome);
            SetCategoria(nome);
        }

        public void Update(string nome)
        {
            ValidarCategoria(nome);
            SetCategoria(nome);
        }

        private void SetCategoria(string nome)
        {
            Nome = nome;
        }

        private static void ValidarCategoria(string nome)
        {
            DomainException.When(string.IsNullOrEmpty(nome), "O nome da categoria é obrigatório.");
            DomainException.When(nome.Length <= 3, "O nome deve conter mais de 3 caracteres.");
        }

        public string Nome { get; private set; }
    }
}
