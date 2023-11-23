using System;
using System.Collections.Immutable;
using static System.Console;
using C__HW_modul_02_Массивы_и_Строки_Задание_2._3._4_;
internal class Program
{
   static void randomize(int[,]arr)
    {
        Random random = new Random();
        int rows = arr.GetUpperBound(0)+1;
        int colums = arr.GetUpperBound(1)+1;
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < colums; j++)
            {
                arr[i,j]=random.Next(-100,100);
            }
    }
    static void showArray(int[,]arr)
    {
        int rows = arr.GetUpperBound(0) + 1;
        int colums = arr.GetUpperBound(1) + 1;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < colums; j++)
            {
                Write("\t"+ arr[i, j]);
            }
            WriteLine();
        }
    }
    static int sumArray(int[,]arr)
    {
        int[] OneDimArray = new int[arr.Length];
        int k = 0;
        int sum = 0;
        int rows = arr.GetUpperBound(0) + 1;
        int colums = arr.GetUpperBound(1) + 1;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < colums; j++)
            {
                OneDimArray[k] = arr[i, j];
                k++;
            }
        }
        int indexMaxElem = Array.IndexOf(OneDimArray, OneDimArray.Max());
        int indexMinElem = Array.IndexOf(OneDimArray, OneDimArray.Min());
        int begin,end;
        if (indexMaxElem > indexMinElem)
        {
            end = indexMaxElem;
            begin = indexMinElem;
        }
        else
        {
            end = indexMinElem;
            begin = indexMaxElem;
        }
        for (int i = begin+1; i < end; i++)
        {
            sum += OneDimArray[i];
        }
        return sum;
    }
    static void multOnNumber(int[,]arr, int number)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
            for (int j = 0; j < arr.GetLength(1); j++)
                arr[i, j] *= number;
    }
    static int[,] sumOfMatrix(int[,] arr,int[,] arr2)
    {
        int[,] rezult = new int[arr.GetLength(0), arr.GetLength(1)];
        for (int i = 0; i < arr.GetLength(0); i++)
            for (int j = 0; j < arr.GetLength(1); j++)
                rezult[i,j] = arr[i, j] + arr2[i, j];

        return rezult;
    }
    static int[,] multOfMatrix(int[,] arr, int[,] arr2)
    {
        int[,] rezult = new int[arr.GetLength(0), arr.GetLength(1)];
        for (int i = 0; i < arr.GetLength(0); i++)
            for (int j = 0; j < arr.GetLength(1); j++)
                rezult[i, j] = arr[i, j] * arr2[i, j];

        return rezult;
    }



    private static void Main(string[] args)
    {
        //<задание 2>
        int[,] arr = new int[5, 5];
        randomize(arr);
        showArray(arr);
        WriteLine("Сумма элементов массива, расположенных между минимальным и максимальным элементами: " + sumArray(arr));
        //</задание2>
        //<задание3>
        WriteLine("Введите предложение: ");
        string? str = ReadLine();
        if (str != null)
        {
            EncryptCezar code = new(str);
            WriteLine("Шифровка строки шифром Цезаря:");
            string str1 = code.Encryptor();
            WriteLine("Расшифровка строки шифром Цезаря:");
            code.Decryptor(str1);
        }
        //</задание3>
        //<задание4>

        multOnNumber(arr, 2);
        WriteLine("Матрица 1 как результат умножения на целое число:\n");
        showArray(arr);
        int[,] arr2 = new int[5, 5];
        randomize(arr2);
        WriteLine("Матрица 2:\n");
        showArray(arr2);
        int[,] arr3 = sumOfMatrix(arr, arr2);
        WriteLine("Результат сложения двух матриц:\n");
        showArray(arr3);
        int[,] arr4 = multOfMatrix(arr, arr2);
        WriteLine("Произведение двух матриц:\n");
        showArray(arr4);
        //</задание4>

        //<задание5>

        Calculator calc = new Calculator();
        Write("Enter an expression: ");
        string expression = ReadLine();
        char sign = ' ';
        foreach (char item in expression)
        {
            if (item == '+' || item == '-')
            {
                sign = item;
                break;
            }
        }
        try
        {
            string[] numbers = expression.Split(sign);
            CalcDelegate del = null;
            switch (sign)
            {
                case '+':
                    del = new CalcDelegate(calc.Add);
                    break;
                case '-':
                    del = new CalcDelegate(Calculator.
                    Sub);
                    break;
                default:
                    throw new
                    InvalidOperationException();
            }
            WriteLine("rezult: " + del(double.
            Parse(numbers[0]),
            double.Parse(numbers[1])));
        }
        catch (Exception ex)
        {
            WriteLine(ex.Message);
        }
       // </ задание5 > 
        //< задание6 >
        WriteLine("Введите несколько предложений:");
        UpRegister userStr = new UpRegister { StrFromUser = ReadLine() };
        userStr.ToUp();
        WriteLine();
        //</ Задание6 >

        //< Задание7 >

        Censor test1 = new();
        WriteLine(test1);
        Write("\n\tВедите недопустимое для вас слово в поэме: ");
        test1.InadmissWord = ReadLine();
        test1.inadmissible();
        test1.Staticstic();

    }
}
