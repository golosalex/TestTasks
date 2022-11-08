//Пользователь вводит в консоли несколько слов через пробел.
//В консоль нужно вывести самое длинное общее начало, если оно есть, и “–“ если его
//нет.
//Пример:
//input >> "abc abcd abe abk"
//output >> ab
//input >> "abc dfg tyu yui"
//output >> -

using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(MethodForTask("abc abcd abe abk"));
        Console.WriteLine(MethodForTask("abc dfg tyu yui"));

        Console.WriteLine(MethodForTask("qwertyjnsjnksnk qwertyuiopo qwertyuisnjnsjsnkanmk"));
    }

    static string MethodForTask(string str)
    {
        var words = str.Split(' ').ToList();
        string iteration = words[0];
        foreach (var word in words)
        {
            iteration = GetSameChars(iteration, word);
            if (iteration == string.Empty) return "-";
        }
        return iteration;
    }

    private static string GetSameChars(string iteration, string word)
    {
        int minLengthOfWords = Math.Min(iteration.Length, word.Length);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < minLengthOfWords; i++)
        {
            if (iteration[i] == word[i])
            {
                sb.Append(word[i]);
            }
            else break;
        }
        return sb.ToString();
    }
}