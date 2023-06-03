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
        //Segue a minha solução frente ao desafio proposto. Fazendo este código, detectei uns dois pontos de melhora que eu gostaria de explorar mais, porém como dei um prazo menor para entrega, não tive tempo de implementar. Contudo, a aplicação está rodando conforme o solicitado no desafio.
        static void Main(string[] args)
        {
            //Parto do princípio de criar um menu onde o usuário primeiramente vai determinar o que ele quer fazer. A variável menu serve para deixar o menu sempre rodando enquanto o usuário não optar por sair da aplicação.
            bool menu = true;
            Network network = new Network();
            while (menu)
            {
                Console.Clear();
                Console.WriteLine("Olá, o que você deseja fazer?");
                Console.WriteLine("\n1 - Adicionar conexão\n2 - Consultar conexão\n3 - Mostrar o total de conexões \n4 - Conhecendo mais sobre mim\n5 - Sair\n");
                //variável para receber a escolha do usuário
                int escolhaMenu = CR();
                int num1;
                int num2;
                int choice;

                switch (escolhaMenu)
                {
                    //Possíveis escolhas do usuário e suas ações
                    case 1:
                        //Variável para determinar se houve sucesso em adicionar a conexão, ou não.
                        bool addValida = false;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Digite os dois números que você deseja conectar:\n");
                            //Função de adicionar uma conexão entre dois inteiros
                            num1 = CR();
                            num2 = CR();
                            //Filtra se os dados inseridos estão no intervalo de inteiros entre 1 e 8, e se não são iguais
                            if (num1 < 1 || num1 > 8 || num2 < 1 || num2 > 8 || num1 == num2)
                            {
                                Console.WriteLine("\nATENÇÃO\nOs números precisam estar no intervalo entre 1 e 8, e não podem ser iguais\n\nClique \n1 - Sim (para tentar adicionar de novo a conexão\n2 - Não (para voltar ao menu principal)\n");
                                choice = CR();
                                    
                                        if (choice == 1)
                                        {
                                            Console.Clear();
                                            addValida = false;
                                        }
                                        else if (choice == 2)
                                        {
                                            addValida = true;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Escolha inválida, voltando ao menu principal...");
                                            CR();
                                            break;
                                        }
                                    
                                    
                            }
                            
                            else
                            {
                                //Variável adicionada, vai pra fora deste while
                                bool adicionada = network.Connect(num1, num2);
                                addValida = true;
                            }
                        } while (!addValida);
                        break;

                        case 2:
                        //Variável para determinar se a consulta gerou resultado, ou não.
                        bool consultaValida = false;
                        choice = CR();
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Digite os dois números que você deseja consultar:\n");
                            //Função de consultar os dois inteiros
                            num1 = CR();
                            num2 = CR();
                            //Filtra se os dados inseridos estão no intervalo de inteiros entre 1 e 8, e se não são iguais
                            if (num1 < 1 || num1 > 8 || num2 < 1 || num2 > 8 || num1 == num2)
                            {
                                Console.WriteLine("\nNão pode haver uma conexão entre os elementos, pois os números precisam estar no intervalo entre 1 e 8, e não podem ser iguais\n\nClique \n1 - Sim (quero fazer nova consulta\n2 - Não (para voltar ao menu principal)\n");
                                if (choice == 1)
                                {
                                    Console.Clear();
                                    consultaValida = false;
                                }
                                else if (choice == 2)
                                {
                                    consultaValida = true;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Escolha inválida, voltando ao menu principal...");
                                    CR();
                                    break;
                                }
                            }

                            else
                            {
                                //Variável pôde ser consultada
                                bool cnt = network.Query(num1, num2);
                                consultaValida = true;
                            }
                        } while (!consultaValida);
                        break;

                        case 3:
                        //Apresenta as conexões totais
                        int quantidadeConexoes = network.CountConnections();
                        Console.Clear();
                        Console.WriteLine($"Foram adicionadas {quantidadeConexoes} conexões.\n\nTecle 0 para voltar ao Menu Principal");
                        CR();
                        break;

                        case 4:
                        //Apenas uma apresentação a mais sobre mim
                        Console.WriteLine("Olá, meu nome é Emanuela e sou completamente apaixonada e curiosa pela área de tecnologia. \nAos 29 anos decidi fazer minha transição de carreira. Na minha adolescência não havia incentivos para mulheres atuarem na área de tecnologia, e minha família não tinha o conhecimento ou recursos financeiros para me apoiar na ideia de estudar algo ligado à informática. \nA única coisa que todos podiam observar em mim é que sempre fui muito autodidata quando precisava mexer no computador e sempre tive facilidade com raciocínio lógico. \nQuando estudei C# no Entra21, logo me apaixonei por esta linguagem de programação, mas tenho buscado aprender outras também.\nSei que há muito que ainda posso aprender dentro do C#, e estou procurando uma empresa que me dê uma chance para eu provar meu valor. Percebo que o mercado já está saturado para iniciantes, contudo estarei 100% comprometida, pois não me falta vontade de aprender e trabalhar com desenvolvimento. Fracasso não é uma opção para mim. \nSe me escolherem para esta vaga, posso lhes garantir que darei todo o meu 100% pra aprender cada dia mais e ser uma colaboradora que agrega valor à empresa.\n\nPor favor, ajudem a realizar o sonho de uma aspirante a Dev.\n\nNo mais, estou à disposição para quaisquer esclarecimentos.\n\nPerfil LinkedIn: https://www.linkedin.com/in/emanuela-wenning/ \n\nNúmero whats: (47) 99933 0234 \n\n\n\n\nPS:estou com um protótipo deste projeto no Visual Forms, posso finalizar ele e enviar caso queiram averiguar minha aptidão com o front end!");
                        Console.ReadLine();
                        break;            
                        
                        case 5:
                        //Fechar o console
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
                //Criação da lista para armazenar as conexões;
                dadosTotal = new List<int>();
            }

            public bool Connect(int numero1, int numero2)
            {
                //Recebe as variáveis inseridas pelo usuário, e insere eles nas duas sequências. Exemplo, se o usuário adiciona 1 e 2, vai adicionar 12 e 21, pois para o problema é entendido que a ordem dos fatores não altera a conexão.
                int conexao1 = numero1 * 10 + numero2;
                int conexao2 = numero2 * 10 + numero1;

                //Consulta a lista antes de adicionar
                if (!dadosTotal.Contains(conexao1) || !dadosTotal.Contains(conexao2))
                {
                    //Conexão ainda não consta na lista, pode ser adicionada
                    dadosTotal.Add(conexao1);
                    dadosTotal.Add(conexao2);
                    Console.WriteLine($"Conexão {numero1}-{numero2} adicionada com sucesso!\n\nTecle 0 para voltar ao Menu Principal");
                    CR();
                    return true;
                }
                else
                {
                    //Conexão já existe na lista, não pode ser adicionada
                    Console.WriteLine($"A conexão {numero1}-{numero2} já existe!\n\nTecle 0 para voltar ao Menu Principal");
                    CR();
                    return false;
                }
            }

            public bool Query(int numero1, int numero2)
            {
                //Mesma estrutura de adicionar conexão, é utilizada para as consultas...
                int conexao1 = numero1 * 10 + numero2;
                int conexao2 = numero2 * 10 + numero1;

                if (!dadosTotal.Contains(conexao1) || !dadosTotal.Contains(conexao2))
                {
                    Console.WriteLine($"Não há conexão entre os elementos {numero1}-{numero2}\n\nTecle 0 para voltar ao Menu Principal");
                    CR();
                    return false;
                }
                else
                {
                    Console.WriteLine($"Os elementos {numero1}-{numero2} já estão conectados!\n\nTecle 0 para voltar ao Menu Principal");
                    CR();
                    return true;
                }
            }

            public int CountConnections()
            {
                //Contagem total do número de conexões. Como é adicionado ambas as direções da conexão - 12 e 21, por exemplo - é necessário que o resultado seja dividido por 2 para dar o número real de conexões.
                return dadosTotal.Count/2;
            }
        }

        public static int CR()
        {
            string input = Console.ReadLine();
            int value;

            try
            {
                value = int.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("Valor inválido. Escolha entre:\n1 - Tentar novamente\n2 - Voltar ao menu principal");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine("Digite novamente:");
                    return CR();
                }
                else if (choice == "2")
                {
                    // Retornar um valor especial para indicar que o usuário deseja voltar ao menu principal
                    return -1;
                }
                else
                {
                    Console.WriteLine("Opção inválida. Digite novamente:");
                    return CR();
                }
            }

            return value;
        }
    }
}
    

