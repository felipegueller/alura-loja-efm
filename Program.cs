using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;

namespace AluraLoja
{
    internal class Program
    {
        static void Main(string[] args)
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

            Console.WriteLine("Digite qualquer tecla para finalizar o programa!");
            Console.ReadKey();
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