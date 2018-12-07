using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Produtos
{
    public class ProdutoArmazenar
    {
        private readonly IRepositorio<Produto> _produtoRepository;
        private readonly IRepositorio<Categoria> _categoriaRepository;

        public ProdutoArmazenar(IRepositorio<Produto> produtoRepository, IRepositorio<Categoria> categoriaRepository)
        {
            _produtoRepository = produtoRepository;
            _categoriaRepository = categoriaRepository;
        }

        public void Armazenar(ProdutoDTO produtoDTO)
        {
            var categoria = _categoriaRepository.GetById(produtoDTO.CategoriaId);
            DomainException.When(categoria == null, "Categoria inválida");

            var produto = _produtoRepository.GetById(produtoDTO.ProdutoId);

            if(produto == null)
            {
                produto = new Produto(produtoDTO.Nome, categoria, produtoDTO.Preco, produtoDTO.Estoque);
                _produtoRepository.Save(produto);
            }
            else
            {
                produto.Update(produtoDTO.Nome, categoria, produtoDTO.Preco, produtoDTO.Estoque);
            }
        }
    }
}
