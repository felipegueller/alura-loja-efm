using AluraLoja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraLoja
{
    public class Produto
    {

        public int Id { get; internal set; }
        public string Nome { get; internal set; }
        public string Categoria { get; internal set; }
        public double PrecoUnitario { get; internal set; }
        public string Unidade { get; internal set; }

        public IList<PromocaoProduto> Promocoes { get; internal set; }
        public IList<Compra> Compras { get; internal set; }

        public Produto() { }

        public Produto(string nome, string categoria, double precoUnitario, string unidade) { 
            Nome = nome;
            Categoria = categoria;
            PrecoUnitario = precoUnitario;
            Unidade = unidade;
            Promocoes = new List<PromocaoProduto>();
        }

        public override string ToString()
        {
            return
                $"ID: {this.Id}\n" +
                $"Nome: {this.Nome}\n" +
                $"Categoria: {this.Categoria}\n" +
                $"Preço: {this.PrecoUnitario}";
        }
    }

}
