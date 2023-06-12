using System;

namespace AluraLoja
{
    public class Compra
    {
        public int Id { get; internal set; }
        public int Quantidade { get; internal set; }
        public Produto Produto { get; internal set; }
        public double Preco { get; internal set; }

        public override string ToString()
        {
            return
                $"ID: {this.Id}\n" +
                $"Produto: {this.Produto.Nome}\n" +
                $"Quantidade: {this.Quantidade}\n" +
                $"Preco: {this.Preco}";
        }
    }
}
