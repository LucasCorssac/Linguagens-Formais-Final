using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path;//args[0];

            Console.WriteLine("Insira o caminho para o arquivo contendo a linguagem:\n");

            path = "..\\..\\gramatica 3.txt"; //Console.ReadLine();//

            Console.WriteLine("\n\n");

            System.IO.StreamReader file = new System.IO.StreamReader(path);

            Gramatica g = new Gramatica(file);

            ConsoleKey Key = new ConsoleKey();

            Parser p = new Parser(g);

            do
            {
                Console.Clear();
                Console.WriteLine("Pressione R para ver as regras da Linguagem.");
                Console.WriteLine("Pressione F para o reconhecedor de frases.");
                Console.WriteLine("Pressione G para entrar no gerador de frases aleatórias.");
                Console.WriteLine("Pressione H para entrar no gerador de frases aleatórias por tamanho.");
                Console.WriteLine("Pressione N para inserir um novo arquivo de linguagem");
                Console.WriteLine("Pressione I para informações sobre o grupo.");
                Console.WriteLine("Pressione Escape para sair.");

                Key = Console.ReadKey().Key;

                Console.WriteLine("\n");

                switch (Key)
                {
                    case ConsoleKey.R:
                        g.print();
                        Console.ReadKey();
                        break;

                    case ConsoleKey.F:
                        do
                        {
                            Console.WriteLine("\nInsira uma sequencia de strings a ser parsed, use # para separar strings\nNão use espaços entre as strings e os #:");
                            string input = Console.ReadLine();

                            List<string> ls = new List<string>();
                            string[] inputSplit = input.Split('#');

                            p = new Parser(g);
                            p.parseSentence(inputSplit);
                            p.printAllDs();

                            if (p.getSuccess())
                                Console.WriteLine("\nAceito!!!!!\n\n");
                            else
                                Console.WriteLine("\n\nNegado!!!!\n\n");

                            Console.WriteLine("Digite N para reconhecer uma nova frase, ou qualquer tecla para sair.\n");

                            Key = Console.ReadKey().Key;
                        } while (Key == ConsoleKey.N);

                        break;

                    case ConsoleKey.G:
                        Console.WriteLine("Pressione Enter para gerar novas frases o qualquer tecla para sair.");
                        string randomSentence =  "";
                        p.printD(0);
                        ConsoleKey ChaveG;
                        do
                        {
                            Console.WriteLine("\n");
                            randomSentence = p.generateSentence(randomSentence);
                            p.printD(p.inputPointer - 1);
                            Console.WriteLine(randomSentence);
                            Console.WriteLine("\n");

                            ChaveG = Console.ReadKey().Key;

                        } while (ChaveG == ConsoleKey.Enter);
                        break;

                    case ConsoleKey.H:
                        ConsoleKey keyH = new ConsoleKey();

                        do
                        {
                            string rndSentence = "";
                            Console.WriteLine("Digite o tamanho da frase que deseja:");
                            int sentenceSize = Convert.ToInt32(Console.ReadLine().ToString());
                            for (int i = 0; i < sentenceSize; i++)
                            {
                                rndSentence = p.generateSentence(rndSentence);
                            }
                            Console.WriteLine(rndSentence);
                            keyH = Console.ReadKey().Key;

                        } while (keyH == ConsoleKey.Y);



                        //do
                        //{
                        //    Console.WriteLine("Digite o tamanho da frase que deseja:");
                        //    int sentenceSize = Convert.ToInt32(Console.ReadLine().ToString());
                        //    Console.WriteLine(p.generateSentence(sentenceSize));

                        //    Console.WriteLine("\nGerar de novo?");
                        //    keyH = Console.ReadKey().Key;
                        //} while (keyH == ConsoleKey.Y);
                        
                        break;

                    case ConsoleKey.N:
                        Console.WriteLine("Insira o caminho para o arquivo contendo a linguagem:\n");

                        path = Console.ReadLine();
                        break;

                    case ConsoleKey.I:
                        Console.WriteLine("Grupo (inserir nome do grupo aqui)");
                        Console.WriteLine("Nomes:");
                        Console.WriteLine("Lucas Corssac");
                        Console.WriteLine("Bruno Engracio");
                        Console.WriteLine("Guilherme Silveira");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.Escape:
                        break;
                }
            } while ( Key != ConsoleKey.Escape );


            //Console.WriteLine("Insira uma sequencia de strings a ser parsed, use # para separar strings\nNão use espaços entre as strings e os #:");
            //string input = Console.ReadLine();

            ////List<string> ls = new List<string>();
            //string[] inputSplit = input.Split('#');

            //Parser p = new Parser(g);
            //p.printAllDs();

            //if (p.getSuccess())
            //    Console.WriteLine("\nAceito!!!!!\n\n");
            //else
            //    Console.WriteLine("\n\nNegado!!!!\n\n");

            //Gerador Gera = new Gerador(g);
            //do
            //{
            //    Gera.parseGrammar();

            //    Verificardor = Console.ReadKey().Key;

            //} while (Verificardor == ConsoleKey.Enter);


            //Console.ReadKey();

        }
    }

}
