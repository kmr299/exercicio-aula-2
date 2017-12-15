namespace Contatos.Data
{
    public class ContatoTelefone : Contato
    {
        public ContatoTelefone()
        {
        }

        public ContatoTelefone(int id, string nome, string sobreNome, string email, Genero genero, int idade, string pais, string telefone) : base(id, nome, sobreNome, email, genero, idade)
        {
            Pais = pais;
            Telefone = telefone;
        }

        public string Pais { get; set; }
        public string Telefone { get; set; }
    }
}
