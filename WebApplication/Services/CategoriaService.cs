using WebApplication.Data;
using WebApplication.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Services
{
    public class CategoriaService
    {
        private readonly SalesWebMvcContext _context;

        public CategoriaService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> FindAllAsync() 
        {
            return await _context.Categoria.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
