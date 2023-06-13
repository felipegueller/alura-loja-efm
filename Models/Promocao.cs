using AluraLoja.Models;
using System.Text;

namespace AluraLoja
{
    public class Promocao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public IList<PromocaoProduto> Produtos { get; set; }

        public Promocao(string descricao, DateTime dataInicio, DateTime dataFim)
        {
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFim = dataFim;
            Produtos = new List<PromocaoProduto>();
        }

        public void AdicionarProduto(Produto produto)
        {
            Produtos.Add(new PromocaoProduto { Produto = produto });
        }

        public override string ToString()
        {
            string dadosDaPromocao =
                $"Descricao: {this.Descricao}\n" +
                $"Data de início: {this.DataInicio}\n" +
                $"Data de término: {this.DataFim}\n";

            StringBuilder stringBuider = new();
            stringBuider.Append(dadosDaPromocao);

            if (this.Produtos.Any())
            {
                var produtos = this.Produtos.ToList();
                stringBuider.Append("\nProdutos em promoção:\n");

                foreach ( var item in produtos )
                {
                    stringBuider.Append(item.Produto + "\n\n");
                }
            }

            return stringBuider.ToString();
        }
    }
}
