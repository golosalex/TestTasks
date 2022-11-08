//На языке C# решить следующую задачу. Дана произвольная строка, необходимо в
//этой строке найти сумму всех чисел (именно чисел, а не цифр).
//Предпочтительнее использовать регулярные выражения.
//Пример:
//input >> "gf5k 35yt hf 2 fd12k "
//output >> 54

// предполагаю, что числа целые и положительные, так как не сказано обратное.

using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        int sum = GetSum("gf5k 35yt hf 2 fd12k");
        Console.WriteLine(sum);
        sum = GetSum("617ds8d77ds8w9s8d7d6dfd7s8d999s8 d7f 6d7 8s99s 8");
        Console.WriteLine(sum);
    }

    private static int GetSum(string s)
    {
        Regex rg = new Regex(@"\d+");
        var maches = rg.Matches(s);

        int sum = 0;
        foreach (Match m in maches)
        {
            sum += int.Parse(m.Value);
        }

        return sum;
    }
}