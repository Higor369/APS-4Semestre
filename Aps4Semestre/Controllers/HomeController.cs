using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Aps4Semestre.Models;

namespace Aps4Semestre.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OrdenacaoPorInsercao([FromBody] IList<string> lista)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int atual = 0; atual < lista.Count; atual++)
            {
                int analise = atual;
                int menor = Auxiliares.bucaMenor(lista, analise);
                Auxiliares.trocar(lista, atual, menor);
            }

            stopwatch.Stop();

            return Ok(new { stopwatch.Elapsed, lista });

        }

        [HttpPost]
        public IActionResult OrdenacaoPorSelecao([FromBody] IList<string> lista)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int atual = 1; atual < lista.Count; atual++)
            {
                int analise = atual;
                while (analise > 0 && Auxiliares.EMenorQue(lista[analise - 1], lista[analise]))
                {

                    Auxiliares.trocar(lista, analise - 1, analise);

                    analise--;
                }
            }

            stopwatch.Stop();

            return Ok(new { stopwatch.Elapsed, lista });
        }

        [HttpPost]
        public IActionResult OrdenacaoPorFundicao([FromBody] IList<string> lista)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Auxiliares.Ordena(lista, 0, lista.Count - 1);

            stopwatch.Stop();

            return Ok(new { stopwatch.Elapsed, lista });

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult teste([FromBody]string[] t)
        {
            return Ok(t);
        }
    }




    public class Auxiliares
    {

        public static bool EMenorQue(string valor1, string valor2)
        {
            var compareVal = String.Compare(valor1, valor2);
            if (compareVal == 0 || compareVal <= -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        } 
        public static void trocar(IList<string> lista, int posicao1, int posicao2)
        {
            string valorAnalise = lista[posicao1];
            string valorAnaliseMenos1 = lista[posicao2];

            lista[posicao1] = valorAnaliseMenos1;
            lista[posicao2] = valorAnalise;
        }
        public static int bucaMenor(IList<string> lista, int comeco)
        {
            int menor = comeco;

            for (var atual = comeco; comeco < lista.Count; atual++)
            {
                if(lista.Count <= atual)
                {
                    return menor;
                }
                if (Auxiliares.EMenorQue(lista[menor], lista[atual])){
                    menor = atual;
                }
            }
            return menor;
        }
        public static IList<string> Intercala(IList<string> lista ,int posicaoInicial, int posicaoMedio, int posicaoTermino)
        {
            IList<string> novaLista = new List<string>();
            var inicial = posicaoInicial;
            var medio = posicaoMedio;
            var termino = posicaoTermino;

            while (inicial < posicaoMedio && medio <= posicaoTermino)
            {
                if (EMenorQue(lista[medio], lista[inicial]))
                {
                    novaLista.Add(lista[medio]);
                    medio++;
                }
                else
                {
                    novaLista.Add(lista[inicial]);
                    inicial++;
                }

            }
            while(inicial < posicaoMedio)
            {
                novaLista.Add(lista[inicial]);
                inicial++;
            }
            while(medio <= posicaoTermino)
            {
                novaLista.Add(lista[medio]);
                medio++;
            }
            for(var con = 0; con<novaLista.Count; con++)
            {
                lista[posicaoInicial + con] = novaLista[con];
            }

            return lista;
        }

        public static void Ordena(IList<string> lista, int inicial, int final)
        {
            int quantidade = final - inicial;

            if (quantidade > 1)
            {
                int meio = (inicial + final) / 2;
                Ordena(lista, inicial, meio);
                Ordena(lista, meio, final);

                Intercala(lista, inicial, meio, final);
            }
        }
       
        


        //apenas para teste
       
    }
}



