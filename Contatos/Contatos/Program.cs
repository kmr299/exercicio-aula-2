using Contatos.Data;
using System;
using System.Collections.Generic;
using System.Linq;

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
                var arrayDeEspacos = Enumerable.Range(0, limite - texto.Length).Select(x => " ");
                return texto + string.Join("", arrayDeEspacos);
            }
            return string.Join("", Enumerable.Range(0, limite).Select(x => " "));
        }

        static void ImprimirContatos(IEnumerable<Contato> contatos, bool mostrarTotalizador = true)
        {
            if (contatos != null && contatos.Count() > 0)
            {
                var stringPrint = string.Empty;

                if (mostrarTotalizador)
                    stringPrint += string.Format("Total de Contatos: {0}\n", contatos.Count());


                stringPrint +=
                    "--------------------------------------------------------------------------------------------------";
                stringPrint +=
                    "\n|    Nome Completo            |    Email            |    Gênero            |    Idade            |";
                stringPrint +=
                    "\n--------------------------------------------------------------------------------------------------";
                foreach (var contato in contatos)
                {
                    stringPrint += string.Format("\n|    {0}    |    {1}    |    {2}    |    {3}    |",
                        LimitarString(contato.NomeCompleto, 21), LimitarString(contato.Email, 13),
                        LimitarString(contato.Genero.ToString(), 14), LimitarString(contato.Idade.ToString(), 13));
                }
                stringPrint +=
                    "\n--------------------------------------------------------------------------------------------------";

                Console.WriteLine(stringPrint);
            }
            else

            {
                Log.PrintELog("=/ Nenhum contato encontrado");
            }
        }


        static void Main(string[] args)
        {
            using (IContatoRepositorio repositorio = new ContatoRepositorioEF())
            {
                while (true)
                {

                    Console.Clear();

                    //Listar todos contatos
                    Log.PrintELog("0 - Listar Todos Contatos");
                    /*
                     * Total de Contatos: XXX
                     * -----------------------------------------------------
                     * |    Nome Completo    |    Email    |    Gênero    |    Idade    |        
                     */
                    /////////////////////////////////////////////////////////////////////
                    //Listar todos contatos ordenados por idade
                    Log.PrintELog("1 - Listar Os Mais Velhos Primeiro");
                    /*
                     * Total de Contatos: XXX
                     * -----------------------------------------------------
                     * |    Nome Completo    |    Email    |    Gênero    |    Idade    |        
                     */
                    /////////////////////////////////////////////////////////////////////
                    //Perguntar ao usuário um nome
                    //Listar todos contatos que contenham o nome digitado pelo usuário
                    Log.PrintELog("2 - Filtrar por Nome");
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
                    Log.PrintELog("3 - Filtrar por Gênero");
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
                    Log.PrintELog("4 - Agrupar por Idade");
                    /*
                     * ==================================================================
                     * |    Idade: XX   | Contatos encontrados com esta idade: XX       |
                     * ------------------------------------------------------------------
                     * |    Nome Completo    |    Email    |    Gênero    |    Idade    |         
                     * ==================================================================
                     */
                    /////////////////////////////////////////////////////////////////////
                    //Mostrar a média de idade dos contatos da base
                    Log.PrintELog("5 - Mostrar Média de Idade");
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
                            ImprimirContatos(repositorio.BuscarTodos());
                            break;
                        case "1":
                            ImprimirContatos(repositorio.BuscarTodosOrdenadoPorIdade());
                            break;
                        case "2":
                            Console.WriteLine("Digite um nome para buscar contatos:");
                            var nome = Console.ReadLine();
                            ImprimirContatos(repositorio.FiltrarPorNome(nome));
                            break;
                        case "3":
                            while (true)
                            {
                                Console.WriteLine("Digite um gênero para buscar contatos (M ou F):");
                                
                                var generoString = Console.ReadLine();
                                Genero genero;
                                if (Enum.TryParse(generoString, out genero))
                                {
                                    ImprimirContatos(repositorio.FiltrarPorGenero(genero));
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("\nGênero Incorreto !!!\n");
                                }
                            }
                            break;
                        case "4":

                            var agroupadoPorIdade = repositorio.AgruparPorIdade();

                            foreach (var grupoIdade in agroupadoPorIdade)
                            {
                                var strPrint = string.Empty;

                                Log.PrintELog("==================================================================================================");
                                Log.PrintELog("|    Idade: {0}   | Contatos encontrados com esta idade: {1}                                      |", grupoIdade.Key.ToString("D2"), grupoIdade.Value.Count().ToString("D3"));
                                ImprimirContatos(grupoIdade.Value, false);
                                Log.PrintELog("||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||");
                            }


                            break;
                        case "5":
                            int media;

                            var agrupadoPorFaixaDeIdade = repositorio.AgruparPorFaixaDeIdade(out media);

                            var printString = "==================================================================" +
                             "\n| Média de idade é: " + media +
                             "\n------------------------------------------------------------------";
                            foreach (var linha in agrupadoPorFaixaDeIdade)
                            {
                                printString += string.Format("\n|    {0}: {1}", linha.Key, linha.Value == null ? 0 : linha.Value.Count());
                            }
                            printString += "\n------------------------------------------------------------------";
                            printString += "\n|      Total: " + agrupadoPorFaixaDeIdade.SelectMany(x => x.Value).Count();

                            printString += "\n==================================================================";
                            Log.PrintELog(printString);
                            break;
                        default:
                            return;
                    }

                    Console.ReadKey();
                }
            }
        }
    }

}
