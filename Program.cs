namespace AluraLoja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoEntity();
            //RecuperarProdutos();
            //ExcluirProdutos();
            //RecuperarProdutos();
            AtualizarProduto();
        }

        private static void GravarUsandoEntity()
        {
            Produto harryPotterBook = new()
            {
                Nome = "Harry Potter e a Ordem da Fênix",
                Categoria = "Livros",
                Preco = 19.89
            };

            using ProdutoDAOEntity produtoDAO = new();
            produtoDAO.Adicionar(harryPotterBook);
        }

        private static void RecuperarProdutos()
        {
            using ProdutoDAOEntity produtoDAO = new();

            IList<Produto> listaDeProdutos = produtoDAO.Produtos();
            int quantidadeDeProdutos = listaDeProdutos.Count;
            bool existemProdutos = Convert.ToBoolean(quantidadeDeProdutos);

            if (!existemProdutos)
            {
                Console.WriteLine("Nenhum produto foi encontrado!");
            }
            else
            {
                Console.WriteLine($"Foram encontrados {quantidadeDeProdutos} produtos!");

                foreach (Produto item in listaDeProdutos)
                {
                    Console.WriteLine(item.Nome);
                }
            }
        }

        private static void ExcluirProdutos()
        {
            using ProdutoDAOEntity produtoDAO = new();

            IList<Produto> produtos = produtoDAO.Produtos();


            foreach (Produto produto in produtos)
            {
                produtoDAO.Remover(produto);
            }
        }
    
        private static void AtualizarProduto()
        {
            //Inserir e reculperar os produtos
            GravarUsandoEntity();
            RecuperarProdutos();

            //Obter e alterar o primeiro produto
            using ProdutoDAOEntity produtoDAO = new();
            Produto primeiroProduto = produtoDAO.Produtos().First();
            primeiroProduto.Nome = "Harry Potter e a Pedra Filosofal";
            produtoDAO.Atualizar(primeiroProduto);

            //Listar Produtos
            RecuperarProdutos();
        }
    }
}