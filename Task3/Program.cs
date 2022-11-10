//Задача 3:
//Дан массив строк, заполненный целыми числами и простыми операторами + - * / ,
//выполнить данные как выражение использующее польскую нотацию. Например, ["3",
//"+", "8", "*", "5"] должен дать результат 43.
//(Вкратце: выполнить выражение по польской нотации)

// условие задачи содержит ошибку.
// раз надо хоть что-то решить, то предположу что программа должно решать обратную польскую запись:
// 


internal class Program
{
    private static void Main(string[] args)
    {
        string[] arr = new string[] { "3", "8", "+", "5", "*" };
        int result = GetResultPolish(arr); // (3+8)*5=55
        Console.WriteLine(result);


        Console.WriteLine(GetResultPolish(new string[] { "3", "8", "5", "*", "+" })); //3+(8*5)=43
    }

    private static int GetResultPolish(string[] arr)
    {
        Stack<int> stack = new Stack<int>();
        int i = 0;
        do
        {
            int number;
            if (int.TryParse(arr[i], out number))
            {
                stack.Push(number);
                i++;
                continue;
            }
            switch (arr[i])
            {
                case "+":
                    try
                    {
                        stack.Push(stack.Pop() + stack.Pop());
                    }
                    catch
                    {
                        Console.WriteLine("неверная запись");
                        return int.MinValue;
                    }
                    break;
                case "-":
                    try
                    {

                        stack.Push((-1) * (stack.Pop() - stack.Pop()));
                    }
                    catch
                    {
                        Console.WriteLine("неверная запись");
                        return int.MinValue;
                    }
                    break;
                case "*":
                    try
                    {
                        stack.Push(stack.Pop() * stack.Pop());
                    }
                    catch
                    {
                        Console.WriteLine("неверная запись");
                        return int.MinValue;
                    }
                    break;
                case "/":
                    try
                    {
                        int second = stack.Pop();
                        int first = stack.Pop();
                        stack.Push(first / second);  // целочисленное деление
                    }
                    catch
                    {
                        Console.WriteLine("неверная запись");
                        return int.MinValue;
                    }
                    break;
            }
            i++;
        }
        while(i<arr.Length);
        if(stack.Count==1) return stack.Pop();
        Console.WriteLine("не корректная запись");
        return int.MinValue;
    }
}