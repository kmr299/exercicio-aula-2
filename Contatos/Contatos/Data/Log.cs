using System;
using System.IO;

namespace Contatos.Data
{
    public static class Log
    {
        public static void PrintELog(string linha)
        {
            Console.WriteLine(linha);
            EscreverArquivo(linha);
        }

        public static void PrintELog(string linha, params object[] args)
        {
            PrintELog(string.Format(linha, args));
        }

        private static void EscreverArquivo(string linha)
        {
            var folder = Path.Combine(Path.GetTempPath(), "Contatos");

            if (Directory.Exists(folder) == false)
                Directory.CreateDirectory(folder);

            var path = Path.Combine(Path.GetTempPath()
                , "Contatos"
                , DateTime.Now.ToString("yyyy-mm-dd") + ".txt");

            using (var writter = new StreamWriter(path, true))
                writter.WriteLine(string.Format("{0} ==> {1}"
                    , DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")
                    , linha));
        }
    }
}