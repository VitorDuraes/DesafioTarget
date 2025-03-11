using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        // Desafio 1: Soma dos números de 1 a 13
        int INDICE = 13, SOMA = 0, K = 0;
        while (K < INDICE)
        {
            K = K + 1;
            SOMA = SOMA + K;
        }
        Console.WriteLine("Desafio 1 - Soma: " + SOMA);

        // Desafio 2: Verifica se um número pertence à sequência de Fibonacci
        int numero = 21; // Número para verificar
        Console.WriteLine($"Desafio 2 - O número {numero} pertence à sequência de Fibonacci? " + EhFibonacci(numero));

        // Desafio 3: Análise de faturamento mensal
        string json = "{\"faturamento\": [15.5, 20.3, 0, 30.2, 0, 10.5, 50.1, 5.0, 0, 40.3]}";
        var faturamentoMensal = JsonConvert.DeserializeObject<Dictionary<string, List<double>>>(json)["faturamento"];
        AnaliseFaturamento(faturamentoMensal);

        // Desafio 4: Cálculo percentual de faturamento por estado
        Dictionary<string, double> faturamentoEstados = new Dictionary<string, double>
        {
            {"SP", 67836.43},
            {"RJ", 36678.66},
            {"MG", 29229.88},
            {"ES", 27165.48},
            {"Outros", 19849.53}
        };
        CalcularPercentualFaturamento(faturamentoEstados);

        // Desafio 5: Inverter string
        string texto = "Hello, C#!";
        Console.WriteLine("Desafio 5 - String invertida: " + InverterString(texto));
    }

    static bool EhFibonacci(int num)
    {
        int a = 0, b = 1, temp;
        while (b < num)
        {
            temp = a + b;
            a = b;
            b = temp;
        }
        return b == num || num == 0;
    }

    static void AnaliseFaturamento(List<double> faturamento)
    {
        var valoresValidos = faturamento.Where(x => x > 0).ToList();
        double menor = valoresValidos.Min();
        double maior = valoresValidos.Max();
        double media = valoresValidos.Average();
        int diasAcimaMedia = valoresValidos.Count(x => x > media);

        Console.WriteLine($"Desafio 3 - Menor faturamento: {menor}");
        Console.WriteLine($"Desafio 3 - Maior faturamento: {maior}");
        Console.WriteLine($"Desafio 3 - Dias acima da média: {diasAcimaMedia}");
    }

    static void CalcularPercentualFaturamento(Dictionary<string, double> estados)
    {
        double total = estados.Values.Sum();
        foreach (var estado in estados)
        {
            double percentual = (estado.Value / total) * 100;
            Console.WriteLine($"Desafio 4 - {estado.Key}: {percentual:F2}%");
        }
    }

    static string InverterString(string str)
    {
        char[] caracteres = new char[str.Length];
        for (int i = 0; i < str.Length; i++)
        {
            caracteres[i] = str[str.Length - 1 - i];
        }
        return new string(caracteres);
    }
}