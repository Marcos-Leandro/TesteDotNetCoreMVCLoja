using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Domain.Produtos;
using Microsoft.AspNetCore.Mvc;
using TesteDotNetCoreMVCLoja.Models;

namespace TesteDotNetCoreMVCLoja.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaArmazenar _categoriaArmazenar;

        public CategoriaController(CategoriaArmazenar categoriaArmazenar)
        {
            _categoriaArmazenar = categoriaArmazenar;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateOrEdit()
        {
            var categoriaDto = new Domain.DTO.CategoriaDTO();

            return View(categoriaDto);
        }

        [HttpPost]
        public IActionResult CreateOrEdit(Domain.DTO.CategoriaDTO categoriaDTO)
        {
            _categoriaArmazenar.Armazenar(categoriaDTO);

            return View();
        }
    }
}
