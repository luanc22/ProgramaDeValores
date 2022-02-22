using System;

namespace ProgramaDeValores.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Programa. [OK]
            bool fecharApp = false;
            while (fecharApp == false)
            {
                Cabecalho();

                Console.WriteLine("Comece digitando os 10 numeros para a array.");
                Console.WriteLine("");
                Console.WriteLine("Digite o numero e aperte ENTER.");
                string[] arrayNumerosEmString = PegarNumerosArray();

                int[] arrayDeNumeros = new int[10];

                if (ChecarNumeros(arrayNumerosEmString) == false)
                {
                    continue;
                }
                else
                {
                    arrayDeNumeros = ConverterNumeros(arrayNumerosEmString);
                }

                Menu(arrayDeNumeros);
                OpcoesMenu(arrayDeNumeros);
                fecharApp = MenuFinal(fecharApp, arrayDeNumeros);
            }
            #endregion
        }

        #region Metodos. [OK]

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
            for (int i = 0; i < numerosDaArray.Length; i++)
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
            Console.WriteLine();
            Console.WriteLine(" 1 - Encontrar o Maior Valor da Sequencia.");
            Console.WriteLine(" 2 - Encontrar o Menor Valor da Sequencia.");
            Console.WriteLine(" 3 - Encontrar o Valor Medio da Sequencia.");
            Console.WriteLine(" 4 - Encontrar os 3 Maiores Valores da Sequencia.");
            Console.WriteLine(" 5 - Encontrar os Valores Negativos da Sequencia.");
            Console.WriteLine(" 6 - Mostrar os valores da Sequencia.");
            Console.WriteLine(" 7 - Remover um item da sequencia.");
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
                    Console.Clear();
                    Cabecalho();

                    if (verificarInput[i] == "" || verificarInput[i] == " ")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERRO!\nEspaco ou valor vazio identificado, por favor, digite os dez numeros!");
                        Console.WriteLine("");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERRO!\nLetra identificada, por favor, digite apenas numeros!");
                        Console.WriteLine("");
                        Console.ResetColor();
                    }

                    Console.Write("Aperte ENTER para prosseguir.");
                    Console.ReadLine();
                    Console.Clear();
                    somenteNumeros = false;
                    break;
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

        static int[] OpcoesMenu(int[] arrayNumeros)
        {
            bool opcaoValida = false;

            while (opcaoValida == false)
            {
                string opcaoSelecionada = Console.ReadLine();

                switch (opcaoSelecionada)
                {
                    case "1":
                        int maiorNumero = 0;
                        MaiorValor(arrayNumeros, ref maiorNumero);
                        Resultado(opcaoSelecionada, arrayNumeros, maiorNumero);
                        opcaoValida = true;
                        break;
                    case "2":
                        int menorNumero;
                        MenorValor(arrayNumeros, out menorNumero);
                        Resultado(opcaoSelecionada, arrayNumeros, menorNumero);
                        opcaoValida = true;
                        break;
                    case "3":
                        int mediaValores = 0;
                        mediaValores = MediaValores(arrayNumeros, mediaValores);
                        Resultado(opcaoSelecionada, arrayNumeros, mediaValores);
                        opcaoValida = true;
                        break;
                    case "4":
                        int[] tresMaiores = new int[3];
                        TresMaioresValores(arrayNumeros, tresMaiores);
                        ResultadoComArray(opcaoSelecionada, arrayNumeros, tresMaiores);
                        opcaoValida = true;
                        break;
                    case "5":
                        int[] valoresNegativos = ValoresNegativos(arrayNumeros);
                        ResultadoComArray(opcaoSelecionada, arrayNumeros, valoresNegativos);
                        opcaoValida = true;
                        break;
                    case "6":
                        MostrarValores(arrayNumeros);
                        opcaoValida = true;
                        break;
                    case "7":
                        int[] novaArray = RemoverValor(arrayNumeros);
                        ResultadoComArray(opcaoSelecionada, arrayNumeros, novaArray);
                        opcaoValida = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("");
                        Console.WriteLine("ERRO!");
                        Console.WriteLine("Opcao invalida! Por favor, selecione uma opcao valida.");
                        Console.ResetColor();
                        Console.WriteLine("");
                        Console.WriteLine("Pressione ENTER e tente novamente.");
                        Console.ReadLine();
                        Console.Clear();
                        Cabecalho();
                        Menu(arrayNumeros);
                        break;
                }
            }

            return arrayNumeros;
        }

        static int MaiorValor(int[] arrayNumeros, ref int maiorValor)
        {
            maiorValor = 0;

            Array.Sort(arrayNumeros);

            maiorValor = arrayNumeros[arrayNumeros.Length - 1];

            return maiorValor;
        }

        static int MenorValor(int[] arrayNumeros, out int menorValor)
        {
            Array.Sort(arrayNumeros);

            menorValor = arrayNumeros[0];

            return menorValor;
        }

        static int MediaValores(int[] arrayNumeros, int mediaValores)
        {
            int somaValores = 0;

            for (int i = 0; i < arrayNumeros.Length; i++)
            {
                somaValores = somaValores + arrayNumeros[i];
            }

            mediaValores = somaValores / 10;

            return mediaValores;
        }

        static int[] TresMaioresValores(int[] arrayNumeros, int[] tresMaiores)
        {
            int j = arrayNumeros.Length - 3;

            Array.Sort(arrayNumeros);

            for (int i = 0; i < tresMaiores.Length; i++)
            {
                tresMaiores[i] = arrayNumeros[j];
                j++;
            }

            return tresMaiores;
        }

        static int[] ValoresNegativos(int[] arrayNumeros)
        {
            int contador = 0;
            int j = 0;

            for (int i = 0; i < arrayNumeros.Length; i++)
            {
                if (arrayNumeros[i] < 0)
                {
                    contador++;
                }
            }

            int[] valoresNegativos = new int[contador];

            for (int i = 0; i < arrayNumeros.Length; i++)
            {
                if (arrayNumeros[i] < 0)
                {
                    valoresNegativos[j] = arrayNumeros[i];
                    j++;
                }
            }

            return valoresNegativos;
        }

        static int[] RemoverValor(int[] arrayNumeros)
        {
            int valorParaRemover = 0;
            int contador = 0;

            bool removivelValido = false;
            while (removivelValido == false)
            {


                Console.WriteLine("");
                Console.Write("Escolhe um valor para remover da Array: ");
                string[] checharCaracterString = new string[1];
                checharCaracterString[0] = Console.ReadLine();

                bool opcaoValida = false;
                while (opcaoValida == false)
                {
                    if (ChecarNumeros(checharCaracterString) == false)
                    {
                        Cabecalho();
                        Menu(arrayNumeros);
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.Write("Escolhe um valor para remover da Array: ");
                        checharCaracterString[0] = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        opcaoValida = true;
                    }
                }

                valorParaRemover = int.Parse(checharCaracterString[0]);
                contador = 0;

                for (int i = 0; i < arrayNumeros.Length; i++)
                {
                    if (arrayNumeros[i] == valorParaRemover)
                    {
                        contador++;
                    }
                }

                if (contador == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("");
                    Console.WriteLine("ERRO!");
                    Console.WriteLine("Nao existe um numero igual ao digitado na array! Por favor, digite um numero valido.");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("Pressione ENTER e tente novamente.");
                    Console.ReadLine();
                    Console.Clear();
                    Cabecalho();
                    Menu(arrayNumeros);
                    Console.WriteLine("");
                }
                else
                {

                    removivelValido = true;
                }
            }

            int[] novaArray = new int[arrayNumeros.Length - contador];
            int j = 0;

            for (int i = 0; i < novaArray.Length; i++)
            {
                if (arrayNumeros[j] == valorParaRemover)
                {
                    j++;
                    novaArray[i] = arrayNumeros[j];
                    j++;
                    continue;
                }
                else
                {
                    novaArray[i] = arrayNumeros[j];
                    j++;
                }
            }

            return novaArray;
        }

        static bool MenuFinal(bool fecharApp, int[] arrayNumeros)
        {
            bool opcaoValida = false;
            while (opcaoValida == false)
            {
                Console.WriteLine("");
                Console.WriteLine("Caso deseje realizar rodar o programa novamente e inserir novos comandos, digite 1 e aperte ENTER.");
                Console.WriteLine("Caso deseje fechar o programa, digite 0 e aperte ENTER.");
                Console.Write("Opcao escolhida: ");
                string fecharBotao = Console.ReadLine();

                if (fecharBotao == "0")
                {
                    fecharApp = true;
                    opcaoValida = true;
                    return fecharApp;
                }
                else if (fecharBotao == "1")
                {
                    Console.Clear();
                    opcaoValida = true;
                    continue;
                }
                else
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opcao invalida, selecione uma opcao valida!");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.Write("Aperte ENTER para prosseguir.");
                    Console.ReadLine();
                    Console.Clear();
                    Cabecalho();
                    Menu(arrayNumeros);
                    Console.WriteLine();
                    continue;
                }
            }
            return fecharApp;
        }

        static void Resultado(string opcaoEscolhida, int[] arrayNumeros, int Resultado)
        {
            switch (opcaoEscolhida)
            {
                case "1":
                    Console.WriteLine("");
                    Console.Write("O maior dos valores na Array eh: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Resultado + ".");
                    Console.ResetColor();
                    break;
                case "2":
                    Console.WriteLine("");
                    Console.Write("O menor dos valores na Array eh: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Resultado + ".");
                    Console.ResetColor();
                    break;
                case "3":
                    Console.WriteLine("");
                    Console.Write("A media dos valores eh de: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Resultado + ".");
                    Console.ResetColor();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("");
                    Console.WriteLine("ERRO!");
                    Console.WriteLine("Opcao invalida! Por favor, selecione uma opcao valida.");
                    Console.ResetColor();
                    Console.WriteLine("");
                    Console.WriteLine("Pressione ENTER e tente novamente.");
                    Console.ReadLine();
                    Console.Clear();
                    Cabecalho();
                    Menu(arrayNumeros);
                    break;
            }
            
        }

        static void ResultadoComArray(string opcaoEscolhida, int[] arrayNumeros, int[] resultadoArray)
        {
            switch (opcaoEscolhida)
            {
                case "4":
                    Console.WriteLine("");
                    Console.Write("Os tres maiores dos valores sao de: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (int i = 0; i < resultadoArray.Length; i++)
                    {
                        if (i == resultadoArray.Length - 1)
                        {
                            Console.Write(resultadoArray[i] + ".");
                        }
                        else
                        {
                            Console.Write(resultadoArray[i] + ", ");
                        }
                    }
                    Console.ResetColor();
                    Console.WriteLine("");
                    break;
                case "5":
                    Console.WriteLine("");
                    Console.Write("Os valores negativos da array sao: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (int i = 0; i < resultadoArray.Length; i++)
                    {
                        if (i == resultadoArray.Length - 1)
                        {
                            Console.Write(resultadoArray[i] + ".");
                        }
                        else
                        {
                            Console.Write(resultadoArray[i] + ", ");
                        }
                    }
                    Console.ResetColor();
                    Console.WriteLine("");
                    break;
                case "7":
                    Console.WriteLine("");
                    Console.Write("Sua array ficou: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (int i = 0; i < resultadoArray.Length; i++)
                    {
                        if (i == resultadoArray.Length - 1)
                        {
                            Console.Write(resultadoArray[i] + ".");
                        }
                        else
                        {
                            Console.Write(resultadoArray[i] + ", ");
                        }
                    }
                    Console.ResetColor();
                    Console.ReadLine();
                    break;
            }
        }
        
        static void MostrarValores(int[] arrayNumeros)
        {
            Console.WriteLine("");
            Console.WriteLine("Posicoes e numeros na Array: ");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < arrayNumeros.Length; i++)
            {
                if (i == 9)
                {
                    Console.Write(" [{0}] = {1}.", i, arrayNumeros[i]);
                    Console.WriteLine("");
                }
                else
                {
                    Console.Write(" [{0}] = {1};", i, arrayNumeros[i]);
                    Console.WriteLine("");
                }
            }

            Console.ResetColor();

            Console.WriteLine("");
        }
        #endregion
    }
}

