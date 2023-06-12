using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluraLoja
{
    internal class ProdutoDAOEntity : IProdutoDAO, IDisposable
    {
        private readonly LojaContexto contexto;

        public ProdutoDAOEntity()
        {
            this.contexto = new();
        }

        public void Adicionar(Produto produto)
        {
            contexto.Add(produto);
            contexto.SaveChanges();
        }

        public void Atualizar(Produto produto)
        {
            contexto.Update(produto);
            contexto.SaveChanges();
        }

        public IList<Produto> Produtos()
        {
            return contexto.Produtos.ToList();
        }

        public void Remover(Produto produto)
        {
            contexto.Remove(produto);
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose();
        }

    }
}
