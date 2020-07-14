using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListaDENO
{
    class Program
    {
        static void Main(string[] args)
        {
            Random x = new Random();
            int Posicao;
            string cor = "";
            int op = 0;

            do
            {
                Lista MinhaLista = new Lista();     // Instância da classe
                while (MinhaLista.Tamanho != 8)     //Gerar os 8 primeiros elementos.
                {
                    cor = GeraCor(x);
                    MinhaLista.InserirInicio(cor);
                    MinhaLista.VerificarPontos();
                }

                do
                {
                    MinhaLista.VerificarPontos();       //Verifica se existem 3 ou mais elementos em sequência

                    MinhaLista.MostraListaINIFIM();
                    cor = GeraCor(x);                   //Gera uma cor aleatória

                    Console.Write("\nPróxima cor: ");

                    ConsoleUtils.ChangeConsoleColor(cor);

                    Console.WriteLine(cor);

                    ConsoleUtils.ChangeConsoleColor();

                    Console.Write("Posição para inserir: ");
                    Posicao = int.Parse(Console.ReadLine());    //Usuário escolhe onde será inserida

                    if (Posicao > MinhaLista.Tamanho)
                    {
                        Posicao = MinhaLista.Tamanho + 1;
                    }
                    MinhaLista.InserirPosicao(cor, Posicao);     //Executa a inserção

                    MinhaLista.MostraListaINIFIM();

                } while (MinhaLista.Tamanho <= 20);
                Console.Clear();

                Console.WriteLine("Elementos na lista: " + MinhaLista.Tamanho);
                Console.WriteLine("Pontuação: " + MinhaLista.Pontuacao);
                Console.WriteLine("\nVocê perdeu!!");
                Console.WriteLine("Deseja jogar novamente ?");
                Console.WriteLine("[1] - Sim\n[2] - Não");
                op = int.Parse(Console.ReadLine());
            } while (op != 2);
        }
        public static string GeraCor(Random x)              //Função para gerar aleatóriamente uma das 4 cores.
        {
            int var;

            var = x.Next(1, 5);

            if (var == 1)
            {
                return "Vermelho";
            }
            else if (var == 2)
            {
                return "Verde";
            }
            else if (var == 3)
            {
                return "Amarelo";
            }
            else if (var == 4)
            {
                return "Azul";
            }

            return "";
        }
    }
}
