using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ordenador
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Informe o local do arquivo (c:/pasta/arquivo.txt): ");
            string filePath = Console.ReadLine();
            //C:\Users\Dorigon\source\repos\Ordenador\teste.txt
            string[] lines = File.ReadAllLines(filePath);

            Console.WriteLine("Linhas encontradas: " + lines.Count());

            int cont = 1;
            List<string> listaFormatada = new List<string>();

            foreach (var item in lines)
            {

                //Id da linha
                string id = item.Substring(0, item.Length.ToString().Length);

                //1 é o espaço do ID para o Código
                string codigo = item.Substring((id.Length + 3), 10);

                //2 - numero de espaços
                int inicio = id.Length + codigo.Length + 4;

                //conteudo da linha
                string conteudo = item.Substring(inicio, (item.Length - inicio));

                string idFormatado = cont.ToString().PadLeft(item.Length.ToString().Length, '0');

                listaFormatada.Add(idFormatado + " " + codigo + idFormatado + " " + conteudo);

                Console.WriteLine(listaFormatada[cont -1]);

                cont++;
            }

            string fileName = Path.GetDirectoryName(filePath) + "\\" + Path.GetFileNameWithoutExtension(filePath) + "_ordenado.txt";

            File.WriteAllLines(fileName, listaFormatada);

            Console.WriteLine();
            Console.WriteLine("Arquivo salvo em : " + fileName);
            Console.WriteLine();
            Console.WriteLine("Pressione uma tecla para finalizar...");

            Console.ReadLine();
        }
    }
}
