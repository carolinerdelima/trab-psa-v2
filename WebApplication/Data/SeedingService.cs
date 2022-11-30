using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Models.Enums;

namespace WebApplication.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed() 
        {
            if (_context.Categoria.Any() ||
                _context.Produto.Any() ||
                _context.ProdutosRegistro.Any())
            {
                return;
            }

            Categoria d1 = new Categoria(1, "Computers");
            Categoria d2 = new Categoria(2, "Electronics");
            Categoria d3 = new Categoria(3, "Fashion");
            Categoria d4 = new Categoria(4, "Books");

            Produto s1 = new Produto(1, "PS4", "Bem usado", "Porto Alegre", 1000.0, d1);
            Produto s2 = new Produto(2, "Skate", "Bem usado", "Porto Alegre", 3500.0, d2);
            Produto s3 = new Produto(3, "Celular", "Bem usado", "Porto Alegre", 2200.0, d1);
            Produto s4 = new Produto(4, "PC", "Bem usado", "Porto Alegre", 3000.0, d4);
            Produto s5 = new Produto(5, "Livro", "Bem usado", "Porto Alegre", 4000.0, d3);
            Produto s6 = new Produto(6, "Copo", "Bem usado", "Porto Alegre", 3000.0, d2);

            ProdutosRegistro r1 = new ProdutosRegistro(1, new DateTime(2018, 09, 25), 11000.0, ProdutoStatus.disponivel, s1);
            ProdutosRegistro r2 = new ProdutosRegistro(2, new DateTime(2018, 09, 4), 7000.0, ProdutoStatus.cancelado, s5);
            ProdutosRegistro r3 = new ProdutosRegistro(3, new DateTime(2018, 09, 13), 4000.0, ProdutoStatus.fechado, s4);
            ProdutosRegistro r4 = new ProdutosRegistro(4, new DateTime(2018, 09, 1), 8000.0, ProdutoStatus.negociacao, s1);
            ProdutosRegistro r5 = new ProdutosRegistro(5, new DateTime(2018, 09, 21), 3000.0, ProdutoStatus.disponivel, s3);
            ProdutosRegistro r6 = new ProdutosRegistro(6, new DateTime(2018, 09, 15), 2000.0, ProdutoStatus.disponivel, s1);
            ProdutosRegistro r7 = new ProdutosRegistro(7, new DateTime(2018, 09, 28), 13000.0, ProdutoStatus.disponivel, s2);
            ProdutosRegistro r8 = new ProdutosRegistro(8, new DateTime(2018, 09, 11), 4000.0, ProdutoStatus.disponivel, s4);
            ProdutosRegistro r9 = new ProdutosRegistro(9, new DateTime(2018, 09, 14), 11000.0, ProdutoStatus.cancelado, s6);
            ProdutosRegistro r10 = new ProdutosRegistro(10, new DateTime(2018, 09, 7), 9000.0, ProdutoStatus.disponivel, s6);
            ProdutosRegistro r11 = new ProdutosRegistro(11, new DateTime(2018, 09, 13), 6000.0, ProdutoStatus.disponivel, s2);
            ProdutosRegistro r12 = new ProdutosRegistro(12, new DateTime(2018, 09, 25), 7000.0, ProdutoStatus.negociacao, s3);
            ProdutosRegistro r13 = new ProdutosRegistro(13, new DateTime(2018, 09, 29), 10000.0, ProdutoStatus.disponivel, s4);
            ProdutosRegistro r14 = new ProdutosRegistro(14, new DateTime(2018, 09, 4), 3000.0, ProdutoStatus.disponivel, s5);
            ProdutosRegistro r15 = new ProdutosRegistro(15, new DateTime(2018, 09, 12), 4000.0, ProdutoStatus.disponivel, s1);
            ProdutosRegistro r16 = new ProdutosRegistro(16, new DateTime(2018, 10, 5), 2000.0, ProdutoStatus.disponivel, s4);
            ProdutosRegistro r17 = new ProdutosRegistro(17, new DateTime(2018, 10, 1), 12000.0, ProdutoStatus.disponivel, s1);
            ProdutosRegistro r18 = new ProdutosRegistro(18, new DateTime(2018, 10, 24), 6000.0, ProdutoStatus.disponivel, s3);
            ProdutosRegistro r19 = new ProdutosRegistro(19, new DateTime(2018, 10, 22), 8000.0, ProdutoStatus.disponivel, s5);
            ProdutosRegistro r20 = new ProdutosRegistro(20, new DateTime(2018, 10, 15), 8000.0, ProdutoStatus.disponivel, s6);
            ProdutosRegistro r21 = new ProdutosRegistro(21, new DateTime(2018, 10, 17), 9000.0, ProdutoStatus.disponivel, s2);
            ProdutosRegistro r22 = new ProdutosRegistro(22, new DateTime(2018, 10, 24), 4000.0, ProdutoStatus.disponivel, s4);
            ProdutosRegistro r23 = new ProdutosRegistro(23, new DateTime(2018, 10, 19), 11000.0, ProdutoStatus.cancelado, s2);
            ProdutosRegistro r24 = new ProdutosRegistro(24, new DateTime(2018, 10, 12), 8000.0, ProdutoStatus.disponivel, s5);
            ProdutosRegistro r25 = new ProdutosRegistro(25, new DateTime(2018, 10, 31), 7000.0, ProdutoStatus.disponivel, s3);
            ProdutosRegistro r26 = new ProdutosRegistro(26, new DateTime(2018, 10, 6), 5000.0, ProdutoStatus.disponivel, s4);
            ProdutosRegistro r27 = new ProdutosRegistro(27, new DateTime(2018, 10, 13), 9000.0, ProdutoStatus.negociacao, s1);
            ProdutosRegistro r28 = new ProdutosRegistro(28, new DateTime(2018, 10, 7), 4000.0, ProdutoStatus.disponivel, s3);
            ProdutosRegistro r29 = new ProdutosRegistro(29, new DateTime(2018, 10, 23), 12000.0, ProdutoStatus.disponivel, s5);
            ProdutosRegistro r30 = new ProdutosRegistro(30, new DateTime(2018, 10, 12), 5000.0, ProdutoStatus.disponivel, s2);

            _context.Categoria.AddRange(d1, d2, d3, d4);

            _context.Produto.AddRange(s1, s2, s3, s4, s5, s6);

            _context.ProdutosRegistro.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
            );

            _context.SaveChanges();

        }
    }
}
