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
        Console.WriteLine("__________________");
        Console.WriteLine( MethodForTaskV2("a abc abcd abe abk"));
        Console.WriteLine( MethodForTaskV2("abc abc abcd abe abk helloworld4 helloworld1") ); 

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

    //Добрый день,
    //ниже ревью одного из наших программистов
    //первое неправильное, а третьего нет(если хочет фидбек пусть попробует в первом тесткейсы "a abc abcd abe abk"
    //(должно быть abc, выдает a) или "abc abc abcd abe abk helloworld4 helloworld1"
    //(должно быть helloworld, выдает что нет общего начала)

    // предположу что вы имеете ввиду что наибольшее общее начало - это если минимум 2 слова имеют общее начало. 
    // ниже мое решение, но меня сильно смущает, что претензии не соотносятся с исходным заданием

    private static string MethodForTaskV2(string str)
    {
        string result = "-";
        var words = str.Split(' ').ToList();

        words.Sort();
        for(int i=0; i<words.Count-1; i++)
        {
            string same = CompareTwoWord(words[i], words[i + 1]);
            if (same.Length >= result.Length)
            {
                result = same;
            }
        }
        
        return result;

    }

    private static string CompareTwoWord(string word1, string word2)
    {
        StringBuilder sb = new StringBuilder();
        int minLength = Math.Min(word1.Length, word2.Length);
        for (int i = 0; i < minLength; i++)
        {
            if (word1[i] == word2[i])
            {
                sb.Append(word1[i]);
            }
            else
            {
                if (sb.Length == 0) return String.Empty;
                break;
            }
            
        }
        return sb.ToString();
    }
}