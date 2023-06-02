using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Olá, o que você deseja fazer?");
        Console.WriteLine("\n1- Adicionar conexão\n2 - Consultar conexão\n3 - Conhecendo mais sobre mim\n4 - Sair\n");
        int escolhaMenu = int.Parse(CR());
    }
}

public class Network
{
    int valorTotal;
    private List<int> dadosTotal;

    public Network()
    {
        dadosTotal = new List<int>();
    }

    
    public void Connect(int numero1, int numero2)
    {
        int conexao = numero1 * 10 + numero2; 

        if (!dadosTotal.Contains(conexao))
        {
            dadosTotal.Add(conexao);
            Console.WriteLine($"Conexão {numero1}-{numero2} adicionada com sucesso!");
        }
        else
        {
            Console.WriteLine($"A conexão {numero1}-{numero2} já existe!");
        }
    }

    public Network(int valorTotal)
    {
        if (valorTotal >= 0)
        {

        }
    }

    public static string CR()
    {
        return Console.ReadLine();
    }
}
