using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatos.Data
{
    public class Contato
    {
        public Contato()
        {
        }

        public Contato(int id, string nome, string sobreNome, string email, Genero genero, int idade)
        {
            Id = id;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            SobreNome = sobreNome ?? throw new ArgumentNullException(nameof(sobreNome));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Genero = genero;
            Idade = idade;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Email { get; set; }
        public Genero Genero { get; set; }
        public int Idade { get; set; }

        public string NomeCompleto
        {
            get { return string.Format("{0} {1}", Nome, SobreNome); }
        }
    }
}
