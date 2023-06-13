using AluraLoja.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;

namespace AluraLoja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new LojaContexto())
            {
                var cliente = context
                    .Clientes
                    .Include(c => c.EnderecoDeEntrega)
                    .FirstOrDefault();

                Console.WriteLine(cliente.EnderecoDeEntrega);

                var produto = context
                    .Produtos
                    .Where(p => p.Id == 15)
                    .FirstOrDefault();

                if (produto != null)
                {
                   context
                      .Entry(produto) /*Acesso a Entry de produto*/
                      .Collection(p => p.Compras) /*Acessando a coleção de Compras*/
                      .Query() /*Comando que emite uma busca no modelo de Compras*/
                      .Where(c => c.Preco >= 10) /*Filtro em cima das propriedades de Compra*/
                      .Load(); /*Carregando essa segunda query em cima do retorno de produto*/

                    foreach (var item in produto.Compras)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }

        private static void ExibeProdutosDaPromocao()
        {
            using (LojaContexto context = new())
            {
                var promocao = context
                    .Promocoes
                    .Include(promocao => promocao.Produtos)
                    .ThenInclude(promocaoProduto => promocaoProduto.Produto)
                    .FirstOrDefault();

                Console.WriteLine("Dados da Promoção:\n");
                Console.WriteLine(promocao);


                Console.WriteLine("\nExibindo os produtos da promoção:\n");

                foreach (var item in promocao.Produtos)
                {
                    Console.WriteLine(item.Produto + "\n");
                }
            }
        }

        private static void IncluiPromocao()
        {
            using (LojaContexto context = new())
            {
                Promocao promocao = new(
                    "Queima de estoque de Janeiro - 2023",
                    new DateTime(2023, 1, 1),
                    new DateTime(2023, 1, 31)
                );

                var alimentos = context.Produtos
                    .Where(produto => produto.Categoria == "Alimentos")
                    .ToList();

                foreach (var alimento in alimentos)
                    promocao.AdicionarProduto(alimento);

                context.Promocoes.Add(promocao);
                ShowEntries(context.ChangeTracker.Entries());

                context.SaveChanges();
            }
        }

        private static void FecharConsole()
        {
            Console.WriteLine("Digite qualquer tecla para finalizar o programa!");
            Console.ReadKey();
        }

        private static void RelacionamentoUmParaUm()
        {
            Cliente fulano = new("Fulano de Tal");
            fulano.EnderecoDeEntrega = new Endereco()
            {
                Numero = 13,
                Logradouro = "Rua dos Alfeneiros",
                Cep = "29360000",
                Bairro = "Centro",
                Cidade = "Itamaraju"
            };

            using LojaContexto context = new();

            context.Clientes.Add(fulano);
            context.SaveChanges();
        }

        private static void RelacionamentoMuitosParaMuitos()
        {
            Promocao promocaoDePascoa = new(
               "Promoção da Páscoa 2023",
               DateTime.Now,
               DateTime.Now.AddMonths(3));

            Produto p1 = new("Farinha", "Alimentos", 2.69, "Quilos");
            Produto p2 = new("Feijão", "Alimentos", 10.28, "Quilos");
            Produto p3 = new("Arroz", "Alimentos", 21.00, "Quilos");

            promocaoDePascoa.AdicionarProduto(p1);
            promocaoDePascoa.AdicionarProduto(p2);
            promocaoDePascoa.AdicionarProduto(p3);

            using LojaContexto context = new();

            //context.Add(promocaoDePascoa);

            var promocao = context.Promocoes.Find(1);

            if (!(promocao == null))
                context.Promocoes.Remove(promocao);

            context.SaveChanges();

            ShowEntries(context.ChangeTracker.Entries());
        }

        private static void ShowEntries(IEnumerable<EntityEntry> entries)
        {
            if (!entries.Any()) return;

            Console.WriteLine("\n==============================\n");

            foreach (EntityEntry entry in entries)
            {
                Console.WriteLine($"{entry.Entity}\nEstado: {entry.State}\n");
            }
        }
    }
}