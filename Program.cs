using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;

class Program
{
    static void Main()
    {
        Desafio1_Soma();
        Desafio2_Fibonacci(21);
        Desafio3_AnaliseFaturamento();
        Desafio4_PercentualPorEstado();
        Desafio5_InverterTexto("Hello, C#!");
    }

    static void Desafio1_Soma()
    {
        const int INDICE = 13;
        int soma = 0, k = 0;

        while (k < INDICE)
        {
            k++;
            soma += k;
        }

        Console.WriteLine($"Desafio 1 - Soma dos números de 1 a {INDICE}: {soma}");
    }

    static void Desafio2_Fibonacci(int numero)
    {
        bool pertence = EhFibonacci(numero);
        Console.WriteLine($"Desafio 2 - O número {numero} {(pertence ? "pertence" : "não pertence")} à sequência de Fibonacci.");
    }

    static bool EhFibonacci(int num)
    {
        int a = 0, b = 1;

        while (b < num)
        {
            int temp = a + b;
            a = b;
            b = temp;
        }

        return num == 0 || b == num;
    }

    static void Desafio3_AnaliseFaturamento()
    {
        string json = "{\"faturamento\": [15.5, 20.3, 0, 30.2, 0, 10.5, 50.1, 5.0, 0, 40.3]}";

        try
        {
            var dados = JsonConvert.DeserializeObject<Dictionary<string, List<double>>>(json);
            var faturamento = dados["faturamento"].Where(valor => valor > 0).ToList();

            double menor = faturamento.Min();
            double maior = faturamento.Max();
            double media = faturamento.Average();
            int diasAcimaMedia = faturamento.Count(valor => valor > media);

            Console.WriteLine($"Desafio 3 - Menor faturamento: {menor:F2}");
            Console.WriteLine($"Desafio 3 - Maior faturamento: {maior:F2}");
            Console.WriteLine($"Desafio 3 - Dias com faturamento acima da média: {diasAcimaMedia}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao analisar o faturamento: " + ex.Message);
        }
    }

    static void Desafio4_PercentualPorEstado()
    {
        var faturamentoEstados = new Dictionary<string, double>
        {
            {"SP", 67836.43},
            {"RJ", 36678.66},
            {"MG", 29229.88},
            {"ES", 27165.48},
            {"Outros", 19849.53}
        };

        double total = faturamentoEstados.Values.Sum();

        Console.WriteLine("Desafio 4 - Percentual de faturamento por estado:");
        foreach (var estado in faturamentoEstados)
        {
            double percentual = (estado.Value / total) * 100;
            Console.WriteLine($" - {estado.Key}: {percentual:F2}%");
        }
    }

    static void Desafio5_InverterTexto(string texto)
    {
        var sb = new StringBuilder();

        for (int i = texto.Length - 1; i >= 0; i--)
            sb.Append(texto[i]);

        Console.WriteLine($"Desafio 5 - String invertida: {sb}");
    }
}
