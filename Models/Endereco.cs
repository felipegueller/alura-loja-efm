namespace AluraLoja.Models
{
    public class Endereco
    {
        public int Numero { get; internal set; }
        public string Logradouro { get; internal set; }
        public string Cep { get; internal set; }
        public string Bairro { get; internal set; }
        public string Cidade { get; internal set; }
        public Cliente Cliente { get; internal set; }

        public override string ToString()
        {
            return
                $"Número: {this.Numero}\n" +
                $"Logradouro: {this.Logradouro}\n" +
                $"Cep: {this.Cep}\n" +
                $"Bairro: {this.Bairro}\n" +
                $"Cidade: {this.Cidade}\n";
        }
    }
}