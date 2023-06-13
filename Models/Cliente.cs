namespace AluraLoja.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Endereco EnderecoDeEntrega { get; set; }

        public Cliente(string nome) { 
            Nome = nome;
        }
    
    }
}
