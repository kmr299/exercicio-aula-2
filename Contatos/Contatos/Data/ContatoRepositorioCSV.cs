using System;
using System.Collections.Generic;
using System.IO;

namespace Contatos.Data
{
    public class ContatoRepositorioCSV : IContatoRepositorio
    {
        private readonly List<Contato> _todosContatos;

        public ContatoRepositorioCSV(string caminhoCSV)
        {
            _todosContatos = new List<Contato>();
            using (var reader = new StreamReader(caminhoCSV))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var contato = LinhaParaContato(reader.ReadLine());
                    if (contato != null)
                        _todosContatos.Add(contato);
                }
            }
        }

        private Contato LinhaParaContato(string linha)
        {
            var linhaSplit = linha.Split(',');
            if (int.TryParse(linhaSplit[0], out int id) &&
                Enum.TryParse(linhaSplit[4], out Genero genero) &&
                int.TryParse(linhaSplit[5], out int idade))
            {
                var nome = linhaSplit[1];
                var sobreNome = linhaSplit[2];
                var email = linhaSplit[3];

                var contato = new Contato(id, nome, sobreNome, email, genero, idade);
                return contato;
            }
            return null;
        }

        public IEnumerable<Contato> BuscarTodos()
        {
            return _todosContatos;
        }

        public IEnumerable<Contato> BuscarTodosOrdenadoPorIdade()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contato> FiltrarPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contato> FiltrarPorGenero(Genero genero)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, IEnumerable<Contato>> AgruparPorIdade()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, IEnumerable<Contato>> AgruparPorFaixaDeIdade(out int mediaTotal)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }
    }
}
