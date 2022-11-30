using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>();

        public Categoria()
        {

        }

        public Categoria(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddProduto(Produto produto) 
        {
            Produtos.Add(produto);
        }

        public List<ProdutosRegistro> TodosProdutos() 
        {
            return (List<ProdutosRegistro>)Produtos;
        }
    }
}
