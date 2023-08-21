
using System;
using System.Text;
using System.Data;

namespace Calculadora;

class Program
{
    static void Main(string[] args)
    {
        
        Console.Write(" Digite a operação: ");
        string resposta = Console.ReadLine()!;

        StringBuilder operacao = new StringBuilder();

        for (int i = 0; i < resposta.Length; i++)
        {
            if (ENumeroOuOperador(resposta[i]))
            {
                operacao.Append(resposta[i]);
            }
        }

        Console.WriteLine($" Resultado: {CalculaOperacao(Convert.ToString(operacao))}");
        Console.ReadKey();
           
    }

    static bool ENumeroOuOperador(char caracter)
    {
        if (char.IsDigit(caracter) || caracter == '+' || caracter == '-' || caracter == '/' || caracter == '*')
        {
            return true;
        }

        return false;
    }

    static double CalculaOperacao (string operacao)
    {
        //estrutura de dados em forma de tabela
        DataTable tabela = new DataTable();

        //adiciona coluna "operacao" ao DataTable, que armazena textos,
        //e passamos a variável 'operacao' 
        tabela.Columns.Add("operacao", typeof(string), operacao);

        //cria nova linha
        DataRow linha = tabela.NewRow();

        //adiciona nova linha ao DataTable
        tabela.Rows.Add(linha);

        //a coluna é tratada como expressão, e ela toda é convertida em double, dando o resultado
        return Convert.ToDouble((string)linha["operacao"]);
    }
}
