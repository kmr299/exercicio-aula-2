using System;
using System.Collections.Generic;

namespace Contatos.Data
{
    public interface IContatoRepositorio : IDisposable
    {
        /// <summary>
        /// Busca todos contatos da fonte de dados
        /// </summary>
        /// <returns>Lista de contatos</returns>
        IEnumerable<Contato> BuscarTodos();
        /// <summary>
        /// Busca todos contatos ordenados por idade
        /// </summary>
        /// <returns>Lista de contatos</returns>
        IEnumerable<Contato> BuscarTodosOrdenadoPorIdade();
        /// <summary>
        /// Busca todos contatos que contenham um nome
        /// </summary>
        /// <param name="nome">Valor para utilizar como filtro</param>
        /// <returns>Lista de contatos</returns>
        IEnumerable<Contato> FiltrarPorNome(string nome);
        /// <summary>
        /// Busca todos contatos que contenham um genero
        /// </summary>
        /// <param name="genero">Valor para utilizar como filtro</param>
        /// <returns>Lista de contatos</returns>
        IEnumerable<Contato> FiltrarPorGenero(Genero genero);
        /// <summary>
        /// Busca todos contatos agrupados por idade
        /// </summary>
        /// <returns>Dicionário com a idade e uma lista de contatos</returns>
        Dictionary<int, IEnumerable<Contato>> AgruparPorIdade();
        /// <summary>
        /// Busca todos contatos agrupados por faixa de idade
        /// </summary>
        /// <param name="mediaTotal">Retorna a média de idade geral</param>
        /// <returns>Dicionário com uma faixa de idade e um lista de contatos</returns>
        Dictionary<string, IEnumerable<Contato>> AgruparPorFaixaDeIdade(out int mediaTotal);
    }
}
