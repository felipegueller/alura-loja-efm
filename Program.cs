using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AluraLoja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Produto paoFrances = new Produto()
            {
                Nome = "Pão Francês",
                Unidade = "Unidade",
                Categoria = "Padaria",
                PrecoUnitario = 0.45
            };

            Compra compra = new()
            { 
                Produto = paoFrances,
                Quantidade = 4
            };
            compra.Preco = compra.Produto.PrecoUnitario * compra.Quantidade;

            Console.WriteLine($"R$ {compra.Preco:F2}");

            using LojaContexto context = new();

            context.Compras.Add(compra);
            //context.SaveChanges();


            ShowEntries(context.ChangeTracker.Entries());

            Console.WriteLine("Digite qualquer tecla para finalizar o programa!");
            Console.ReadKey();
        }

        private static void ShowEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("\n==============================\n");

            foreach (EntityEntry entry in entries)
            {
                Console.WriteLine($"{entry.Entity}\nEstado: {entry.State}\n");
            }
        }
    }
}