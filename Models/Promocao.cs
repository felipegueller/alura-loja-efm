using AluraLoja.Models;

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
    }
}
