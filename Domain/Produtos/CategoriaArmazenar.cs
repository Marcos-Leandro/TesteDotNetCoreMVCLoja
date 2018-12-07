using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Produtos
{
    public class CategoriaArmazenar
    {
        private readonly IRepositorio<Categoria> _categoriaRepository;

        public CategoriaArmazenar(IRepositorio<Categoria> categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public void Armazenar(CategoriaDTO categoriaDTO)
        {
            var categoria = _categoriaRepository.GetById(categoriaDTO.Id);

            if (categoria == null)
            {
                categoria = new Categoria(categoriaDTO.Nome);
                _categoriaRepository.Save(categoria);
            }
            else
            {
                categoria.Update(categoriaDTO.Nome);
            }
        }
    }
}
