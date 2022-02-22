using System;

namespace ProgramaDeValores.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool fecharApp = false;
            while (fecharApp == false)
            {
                Cabecalho();

                Console.WriteLine("Comece digitando os 10 numeros para a array.");
                Console.WriteLine("");
                string[] arrayDezNumeros = PegarNumerosArray();

                int[] arrayDeNumeros = new int[10];

                if (ChecarNumeros(arrayDezNumeros) == false)
                {
                    continue;
                }
                else
                {    
                    arrayDeNumeros = ConverterNumeros(arrayDezNumeros);
                }

                Menu(arrayDeNumeros);
                string inputOpcao = Console.ReadLine();
                OpcoesMenu(inputOpcao, arrayDeNumeros);

                Console.WriteLine("");

                Console.ReadLine();
            }
        }

        #region Metodos. [WIP]

        static void Cabecalho()
        {
            Console.WriteLine("===== Menu de 10 Arrays =====");
            Console.WriteLine("");
            Console.WriteLine("Utilize esse programa para utilizar as funcoes em 10 arrays digitadas.");
            Console.WriteLine("");
            Console.WriteLine("===================================");
            Console.WriteLine("");
        }

        static void Menu(int[] numerosDaArray)
        {
            Console.Clear();

            Cabecalho();

            Console.Write("Sua Array de Numeros: ");
            for (int i = 0; i < 10; i++)
            {
                if (i == 9)
                {
                    Console.Write(numerosDaArray[i] + ".");
                    Console.WriteLine("");
                }
                else
                {
                    Console.Write(numerosDaArray[i] + ", ");
                }
            }

            Console.WriteLine("");

            Console.WriteLine("Bem vindo ao menu da aplicacao, escolha uma opcao abaixo: ");
            Console.WriteLine("1 - Encontrar o Maior Valor da Sequencia.");
            Console.WriteLine("2 - Encontrar o Menor Valor da Sequencia.");
            Console.WriteLine("3 - Encontrar o Valor Medio da Sequencia.");
            Console.WriteLine("4 - Encontrar os 3 Maiores Valores da Sequencia.");
            Console.WriteLine("5 - Encontrar os 3 Valores Negativos da Sequencia.");
            Console.WriteLine("6 - Mostrar os valores da Sequencia.");
            Console.WriteLine("7 - Remover um item da sequencia.");
            Console.WriteLine("");
            Console.Write("Opcao escolhida: ");
        }

        static string[] PegarNumerosArray()
        {
            string[] numerosNaArray = new string[10];
            int j = 0;

            for (j = 0; j < numerosNaArray.Length; j++)
            {
                if (j != 0)
                {
                    Cabecalho();

                    Console.WriteLine("Digite o numero e aperte ENTER.");
                    Console.WriteLine("");

                    Console.Write("Numeros na Array: ");
                    for (int k = 0; k < j; k++)
                    {

                        Console.Write(numerosNaArray[k] + ",  ");

                    }
                }

                Console.WriteLine("");

                Console.Write("Numero: ");
                numerosNaArray[j] = Console.ReadLine();

                Console.Clear();
            }


            return numerosNaArray;
        }

        static bool ChecarNumeros(string[] verificarInput)
        {
            bool somenteNumeros = true;

            for (int i = 0; i < verificarInput.Length; i++)
            {

                bool verificarNumerosCondicao = int.TryParse(verificarInput[i], out _);

                if (verificarNumerosCondicao == false)
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO!\nLetra identificada, por favor, digite apenas numeros!");
                    Console.WriteLine("");
                    Console.ResetColor();
                    Console.Write("Aperte ENTER para prosseguir.");
                    Console.ReadLine();
                    Console.Clear();
                    somenteNumeros = false;
                }
            }

            return somenteNumeros;
        }

        static int[] ConverterNumeros(string[] stringDeNumeros)
        {
            int[] arrayDeNumeros = new int[10];

            for (int i = 0; i < stringDeNumeros.Length; i++)
            {
                arrayDeNumeros[i] = int.Parse(stringDeNumeros[i]);
            }

            return arrayDeNumeros;
        }

        // Continuar aqui.
        static int[] OpcoesMenu(string opcaoEscolhida, int[] arrayNumeros) //WIP
        {
            switch (opcaoEscolhida)
            {
                case "1":
                    Console.WriteLine("");
                    break;
                case "2":
                    Console.WriteLine("");
                    break;
                case "3":
                    MediaValores(arrayNumeros);
                    break;
                case "4":
                    Console.WriteLine("");
                    break;
                case "5":
                    Console.WriteLine("");
                    break;
                case "6":
                    Console.WriteLine("");
                    break;
                case "7":
                    Console.WriteLine("");
                    break;
            }

            return arrayNumeros;
        }
        static int MaiorValor(int[] arrayNumeros) //WIP
        {
            int maiorValor = 0;

            return maiorValor;
        }

        static int MenorValor(int[] arrayNumeros) //WIP
        {
            int menorValor = 0;

            return menorValor;
        }

        static int MediaValores(int[] arrayNumeros) 
        {
            int mediaValores = 0;
            int somaValores = 0;

            for (int i = 0; i < arrayNumeros.Length; i++)
            {
              somaValores = somaValores + arrayNumeros[i];
            }

            mediaValores = somaValores / 10;

            Console.WriteLine("");
            Console.WriteLine("A media dos valores eh de: {0}.", mediaValores);

            return mediaValores;
        }
        #endregion
    }
}

