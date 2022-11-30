using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Services;
using WebApplication.Services.Exceptions;
using WebApplication.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ProdutoService _produtoService;
        private readonly CategoriaService _categoriaService;

        public ProdutosController(ProdutoService produtoService, CategoriaService categoriaService)
        {
            _produtoService = produtoService;
            _categoriaService = categoriaService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _produtoService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var categorias = await _categoriaService.FindAllAsync();
            var viewModel = new ProdutoFormViewModel { Categorias = categorias };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                var categorias = await _categoriaService.FindAllAsync();
                var viewModel = new ProdutoFormViewModel { Produto = produto, Categorias = categorias };
                return View(viewModel);
            }
            await _produtoService.InsertAsync(produto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not provided"});
            }

            var obj = await _produtoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not found"});
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id) 
        {
            try
            {
                await _produtoService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }            
        }

        /// <summary>
        /// Action responsável pela exibição dos detalhes do vendedor selecionado.
        /// </summary>
        /// <param name="id">Parâmetro de exibição dos detalhes do vendedor.</param>
        /// <returns>View com dados do vendedor selecionado.</returns>
        public async Task<IActionResult> Details(int? id) 
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not provided"});
            }

            var obj = await _produtoService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not found"});
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null) 
            {
                return RedirectToAction(nameof(Error), new {message = "Id not provided"});
            }

            var obj = await _produtoService.FindByIdAsync(id.Value);

            if (obj == null) 
            {
                return RedirectToAction(nameof(Error), new {message = "Id not found"});
            }

            List<Categoria> categorias = await _categoriaService.FindAllAsync();
            ProdutoFormViewModel viewModel = new ProdutoFormViewModel { Produto = obj, Categorias = categorias  };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto) 
        {
            if (!ModelState.IsValid)
            {
                var categorias = await _categoriaService.FindAllAsync();
                var viewModel = new ProdutoFormViewModel { Produto = produto, Categorias = categorias };
                return View(viewModel);
            }

            if (id != produto.Id) 
            {
                return RedirectToAction(nameof(Error), new {message = "Id mismatch"});
            }
            try
            {
                await _produtoService.UpdateAsync(produto);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new {message = e.Message});
            }
            
        }

        /// <summary>
        /// Action responsável por exibir mensagem de tratamento de erro.
        /// </summary>
        /// <param name="message">Parâmetro de exibição de mensagem de erro.</param>
        /// <returns>View com dados do vendedor.</returns>
        public IActionResult Error(string message) 
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(viewModel);
        }
    }
}
