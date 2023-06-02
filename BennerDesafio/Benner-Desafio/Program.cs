using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Benner_Desafio.Program;

namespace Benner_Desafio
{
    class Program
    {

        static void Main(string[] args)
        {
            bool menu = true;
            Network network = new Network();
            while (menu)
            {
                Console.Clear();
                Console.WriteLine("Olá, o que você deseja fazer?");
                Console.WriteLine("\n1- Adicionar conexão\n2 - Consultar conexão\n3 - Mostrar o total de conexões \n4 - Conhecendo mais sobre mim\n5 - Sair\n");
                int escolhaMenu = int.Parse(CR());
                int num1;
                int num2;                

                switch (escolhaMenu)
                {
                    case 1:
                        bool addValida = false;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Digite os dois números que você deseja conectar:\n");
                            num1 = int.Parse(CR());
                            num2 = int.Parse(CR());
                            if (num1 < 1 || num1 > 8 || num2 < 1 || num2 > 8 || num1 == num2)
                            {
                                try
                                {
                                    throw new ArgumentException("\nATENÇÃO\nOs números precisam estar no intervalo entre 1 e 8, e não podem ser iguais\n\nClique enter para adicionar de novo...");
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ex.Message);
                                    CR();
                                }
                            }
                            else
                            {
                                bool adicionada = network.Connect(num1, num2);
                                addValida = true;
                            }
                        } while (!addValida);
                        break;

                        case 2:
                        bool consultaValida = false;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Digite os dois números que você deseja consultar:\n");
                            num1 = int.Parse(CR());
                            num2 = int.Parse(CR());
                            if (num1 < 1 || num1 > 8 || num2 < 1 || num2 > 8 || num1 == num2)
                            {
                                try
                                {
                                    throw new ArgumentException("\nNão pode haver uma conexão entre os elementos, pois os números precisam estar no intervalo entre 1 e 8, e não podem ser iguais\n\nClique enter para consultar novamente");
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.Clear();
                                    Console.WriteLine(ex.Message);
                                    CR();
                                }
                            }
                            else
                            {
                                bool consulta = network.Query(num1, num2);
                                consultaValida = true;
                            }
                        } while (!consultaValida);
                        break;

                        case 3:                    
                        int quantidadeConexoes = network.CountConnections();
                        Console.Clear();
                        Console.WriteLine($"Foram adicionadas {quantidadeConexoes} conexões.\n\nTecle enter para voltar ao Menu Principal");
                        CR();
                        break;

                        case 4:
                        Console.Clear();
                        Console.WriteLine("Olá, meu nome é Emanuela e sou completamente apaixonada e curiosa pela área de tecnologia. \nAos 29 anos decidi fazer minha transição de carreira. Na minha adolescência não havia incentivos para mulheres atuarem na área de tecnologia, e minha família não tinha o conhecimento ou recursos financeiros para me apoiar na ideia de estudar algo ligado à informática. \nA única coisa que todos podiam observar em mim é que sempre fui muito autodidata quando precisava mexer no computador e sempre tive facilidade com raciocínio lógico. \nQuando estudei C# no Entra21, logo me apaixonei por esta linguagem de programação, mas tenho buscado aprender outras também.\nSei que há muito que ainda posso aprender dentro do C#, e estou procurando uma empresa que me dê uma chance para eu provar meu valor. Percebo que o mercado já está saturado para iniciantes, contudo estarei 100% comprometida, pois não me falta vontade de aprender e trabalhar com desenvolvimento. Fracasso não é uma opção para mim. \nSe me escolherem para esta vaga, posso lhes garantir que darei todo o meu 100% pra aprender cada dia mais e ser uma colaboradora que agrega valor à empresa.\n\nPor favor, ajudem a realizar o sonho de uma aspirante a Dev.\n\nNo mais, estou à disposição para quaisquer esclarecimentos.\n\nPerfil LinkedIn: https://www.linkedin.com/in/emanuela-wenning/ \n\nNúmero whats: (47) 99933 0234 \n\n\n\n\nPS:estou com um protótipo deste projeto no Visual Forms, posso finalizar ele e enviar caso queiram averiguar minha aptidão com o front end!");
                        CR();
                        break;            
                        
                        case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public class Network
        {
            private List<int> dadosTotal;

            public Network()
            {
                dadosTotal = new List<int>();
            }

            public bool Connect(int numero1, int numero2)
            {
                int conexao1 = numero1 * 10 + numero2;
                int conexao2 = numero2 * 10 + numero1;

                if (!dadosTotal.Contains(conexao1) || !dadosTotal.Contains(conexao2))
                {
                    dadosTotal.Add(conexao1);
                    dadosTotal.Add(conexao2);
                    Console.WriteLine($"Conexão {numero1}-{numero2} adicionada com sucesso!\n\nTecle enter para voltar ao Menu Principal");
                    CR();
                    return true;
                }
                else
                {
                    Console.WriteLine($"A conexão {numero1}-{numero2} já existe!\n\nTecle enter para voltar ao Menu Principal");
                    CR();
                    return false;
                }
            }

            public bool Query(int numero1, int numero2)
            {
                int conexao1 = numero1 * 10 + numero2;
                int conexao2 = numero2 * 10 + numero1;

                if (!dadosTotal.Contains(conexao1) || !dadosTotal.Contains(conexao2))
                {
                    dadosTotal.Add(conexao1);
                    dadosTotal.Add(conexao2);
                    Console.WriteLine($"Não há conexão entre os elementos {numero1}-{numero2}\n\nTecle enter para voltar ao Menu Principal");
                    CR();
                    return false;
                }
                else
                {
                    Console.WriteLine($"Os elementos {numero1}-{numero2} já estão conectados!\n\nTecle enter para voltar ao Menu Principal");
                    CR();
                    return true;
                }
            }

            public int CountConnections()
            {
                return dadosTotal.Count/2;
            }
        }

        public static string CR()
        {
            return Console.ReadLine();
        }
    }
}
    

