﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    public class ProdutosRegistroController : Controller
    {
        private readonly ProdutoRegistroService _produtoRegistroService;

        public ProdutosRegistroController(ProdutoRegistroService produtoRegistroService)
        {
            _produtoRegistroService = produtoRegistroService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue) 
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue) 
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _produtoRegistroService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }

        /// <summary>
        /// Action responsável por pesquisa de grupo de vendas por data.
        /// </summary>
        /// <param name="minDate">Define uma data mínima para a pesquisa.</param>
        /// <param name="maxDate">Define uma data maxima para a pesquisa.</param>
        /// <returns>Registro de um grupo de vendas de acordo com a data especificada.</returns>
        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result = await _produtoRegistroService.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }
    }
}
