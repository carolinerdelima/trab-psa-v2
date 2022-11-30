using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApplication.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public string Local { get; set; }

        public double Valor { get; set; }

        public Categoria Categoria { get; set; }

        public int CategoriaId { get; set; }

        public ICollection<ProdutosRegistro> Produtos { get; set; } = new List<ProdutosRegistro>();

        public Produto()
        {

        }

        public Produto(int id, string name, string desc, string local, double valor, Categoria categoria)
        {
            Id = id;
            Name = name;
            Desc = desc;
            Local = local;
            Valor = valor;
            Categoria = categoria;
        }

        public void AddProdutos(ProdutosRegistro sr) 
        {
            Produtos.Add(sr);
        }

        public void RemoveProdutos(ProdutosRegistro prod) 
        {
            Produtos.Remove(prod);
        }

        public List<ProdutosRegistro> TodosProdutos() 
        {
            return (List<ProdutosRegistro>)Produtos;
        }
    }
}
