using Contatos.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contatos
{
    class Program
    {
        static string LimitarString(string texto, int limite)
        {
            if (!string.IsNullOrWhiteSpace(texto) && texto.Length > limite)
                return texto.Substring(0, limite);

            if (!string.IsNullOrWhiteSpace(texto) && texto.Length == limite)
                return texto;

            if (!string.IsNullOrWhiteSpace(texto) && texto.Length < limite)
            {
                var arrayDeEspacos = Enumerable.Range(0, limite - texto.Length).Select(x=> " ");
                return texto + string.Join("", arrayDeEspacos);
            }
            return string.Join("",Enumerable.Range(0, limite).Select(x => " "));
        }

        static void Main(string[] args)
        {
            var diretorioAtual = Directory.GetCurrentDirectory();
            var caminhoArquivo = Path.Combine(diretorioAtual, "Data", "MOCK_DATA_Contato.csv");
            using (IContatoRepositorio repositorio = new ContatoRepositorioCSV(caminhoArquivo))
            {
                while (true)
                {
                    //Listar todos contatos
                    Console.WriteLine("0 - Listar Todos Contatos");
                    /*
                     * Total de Contatos: XXX
                     * -----------------------------------------------------
                     * |    Nome Completo    |    Email    |    Gênero    |    Idade    |        
                     */
                    /////////////////////////////////////////////////////////////////////
                    //Listar todos contatos ordenados por idade
                    Console.WriteLine("1 - Listar Os Mais Velhos Primeiro");
                    /*
                     * Total de Contatos: XXX
                     * -----------------------------------------------------
                     * |    Nome Completo    |    Email    |    Gênero    |    Idade    |        
                     */
                    /////////////////////////////////////////////////////////////////////
                    //Perguntar ao usuário um nome
                    //Listar todos contatos que contenham o nome digitado pelo usuário
                    Console.WriteLine("2 - Filtrar por Nome");
                    /*
                     * Digite um nome: 
                     */

                    /*
                     * Total de Contatos Encontrados: XXX
                     * -----------------------------------------------------
                     * |    Nome Completo    |    Email    |    Gênero    |    Idade    |        
                     */
                    /////////////////////////////////////////////////////////////////////
                    //Perguntar ao usuário um gênero
                    //Listar todos contatos daquele gênero
                    Console.WriteLine("3 - Filtrar por Gênero");
                    /*
                     * Digite um nome: 
                     */

                    /*
                     * Total de Contatos Encontrados: XXX
                     * -----------------------------------------------------
                     * |    Nome Completo    |    Email    |    Gênero    |    Idade    |        
                     */
                    /////////////////////////////////////////////////////////////////////
                    //Listar todos contatos agrupados por idade
                    Console.WriteLine("4 - Agrupar por Idade");
                    /*
                     * ==================================================================
                     * |    Idade: XX   | Contatos encontrados com esta idade: XX       |
                     * ------------------------------------------------------------------
                     * |    Nome Completo    |    Email    |    Gênero    |    Idade    |         
                     * ==================================================================
                     */
                    /////////////////////////////////////////////////////////////////////
                    //Mostrar a média de idade dos contatos da base
                    Console.WriteLine("5 - Mostrar Média de Idade");
                    /*
                     * ==================================================================
                     * | Média de idade é: XX
                     * ------------------------------------------------------------------
                     * |    10 - 20: XX
                     * |    21 - 30: XX
                     * |    31 - 40: XX
                     * |    41 - 50: XX
                     * |    51 - 60: XX
                     * |    61 - 70: XX
                     * |    71 - 80: XX
                     * |    81 - 90: XX
                     * ==================================================================
                     */

                    switch (Console.ReadLine())
                    {
                        case "0":
                            Console.Clear();
                            var todosContatos = repositorio.BuscarTodos();

                            if (todosContatos != null && todosContatos.Count() > 0)
                            {

                                Console.WriteLine("Total de Contatos: {0}", todosContatos.Count());
                                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                                Console.WriteLine("|    Nome Completo            |    Email            |    Gênero            |    Idade            |");
                                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                                foreach (var contato in todosContatos)
                                {
                                    Console.WriteLine("|    {0}    |    {1}    |    {2}    |    {3}    |", LimitarString(contato.NomeCompleto, 21), LimitarString(contato.Email, 13), LimitarString(contato.Genero.ToString(), 14), LimitarString(contato.Idade.ToString(), 13));
                                }
                                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                            }
                            else
                            {
                                Console.WriteLine("=/ Nenhum contato encontrado");
                            }
                            Console.ReadKey();
                            Console.Clear();

                            break;
                        case "1":
                            break;
                        case "2":
                            break;

                        case "3":
                            break;

                        case "4":
                            break;

                        case "5":
                            break;
                        default:
                            return;
                    }
                }
            }
        }
    }
}
