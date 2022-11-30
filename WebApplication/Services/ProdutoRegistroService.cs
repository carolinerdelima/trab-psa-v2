using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Services
{
    public class ProdutoRegistroService
    {
        private readonly SalesWebMvcContext _context;

        public ProdutoRegistroService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<ProdutosRegistro>> FindByDateAsync(DateTime? minDate, DateTime? maxDate) 
        {
            var result = from obj in _context.ProdutosRegistro select obj;
            if (minDate.HasValue) 
            {
                result = result.Where(x => x.Date >= minDate);
            }
            if (maxDate.HasValue) 
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(x => x.Produto)
                .Include(x => x.Produto.Categoria)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Categoria,ProdutosRegistro>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.ProdutosRegistro select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            return await result
                .Include(x => x.Produto)
                .Include(x => x.Produto.Categoria)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Produto.Categoria)
                .ToListAsync();
        }
    }
}
