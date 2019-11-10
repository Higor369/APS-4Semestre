using System;
using System.Collections.Generic;
using Aps4Semestre.Controllers;

namespace Testes
{
    class Program
    {
        static void Main(string[] args)
        {
            var lucas = "lucas";
            var amanda = "amanda";
            var pedro = "pedro";
            var higor = "higor";

            IList<string> lista = new List<string>();
            lista.Add(lucas);
            lista.Add(amanda);
            lista.Add(pedro);
            lista.Add(higor);
            lista.Add("aaaaaa");
            lista.Add("kuto");
            lista.Add("zna");
            lista.Add("atek");

            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Auxiliares.Ordena(lista, 0, lista.Count - 1);

            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }


            Console.ReadLine();
        }
    }
}
