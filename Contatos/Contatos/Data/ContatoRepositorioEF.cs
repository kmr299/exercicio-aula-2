using System.Collections.Generic;
using System.Linq;
using Contatos.Entity;

namespace Contatos.Data
{
    public class ContatoRepositorioEF : IContatoRepositorio
    {
        private readonly ContatosContext _contatosContext;

        public ContatoRepositorioEF()
        {
            _contatosContext = new ContatosContext();
        }

        public void Dispose()
        {
            _contatosContext.Dispose();
        }

        public IEnumerable<Contato> BuscarTodos()
        {
            return _contatosContext.Contatos.ToList();
        }

        public IEnumerable<Contato> BuscarTodosOrdenadoPorIdade()
        {
            return _contatosContext.Contatos.OrderByDescending(x => x.Idade).ToList();
        }

        public IEnumerable<Contato> FiltrarPorNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return new List<Contato>();

            nome = nome.Trim().ToLower();

            return _contatosContext.Contatos.Where(x => x.Nome.Trim().ToLower().Contains(nome));
        }

        public IEnumerable<Contato> FiltrarPorGenero(Genero genero)
        {
            return _contatosContext.Contatos.Where(x => x.Genero == genero).ToList();
        }

        public Dictionary<int, IEnumerable<Contato>> AgruparPorIdade()
        {
            return _contatosContext.Contatos
                .GroupBy(x => x.Idade)
                .ToDictionary(x => x.Key, x => (IEnumerable<Contato>)x.ToList());
        }

        public Dictionary<string, IEnumerable<Contato>> AgruparPorFaixaDeIdade(out int mediaTotal)
        {
            mediaTotal = _contatosContext.Contatos.Sum(x => x.Idade) / _contatosContext.Contatos.Count();

            var contatosFiltrados = _contatosContext.Contatos.Where(x => x.Idade >= 10 && x.Idade <= 90).ToList();

            var faixaDeIdade = new Dictionary<string, IEnumerable<Contato>>();

            faixaDeIdade.Add("10 - 20", contatosFiltrados.Where(x => x.Idade >= 10 && x.Idade <= 20).ToList());
            faixaDeIdade.Add("21 - 30", contatosFiltrados.Where(x => x.Idade >= 21 && x.Idade <= 30).ToList());
            faixaDeIdade.Add("31 - 40", contatosFiltrados.Where(x => x.Idade >= 31 && x.Idade <= 40).ToList());
            faixaDeIdade.Add("41 - 50", contatosFiltrados.Where(x => x.Idade >= 41 && x.Idade <= 50).ToList());
            faixaDeIdade.Add("51 - 60", contatosFiltrados.Where(x => x.Idade >= 51 && x.Idade <= 60).ToList());
            faixaDeIdade.Add("61 - 70", contatosFiltrados.Where(x => x.Idade >= 61 && x.Idade <= 70).ToList());
            faixaDeIdade.Add("71 - 80", contatosFiltrados.Where(x => x.Idade >= 71 && x.Idade <= 80).ToList());
            faixaDeIdade.Add("81 - 90", contatosFiltrados.Where(x => x.Idade >= 81 && x.Idade <= 90).ToList());

            return faixaDeIdade;
        }
    }
}