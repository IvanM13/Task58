/*Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18*/

int[,] Matrix(int line, int column)
{
    int[,] arr = new int[line, column];
    Random rnd = new Random();
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
            arr[i, j] = rnd.Next(0, 100);
    }
    return arr;
}

int GetNumber(string message)
{
    while (true)
    {
        Console.WriteLine(message);
        string? num = Console.ReadLine();
        if (int.TryParse(num, out int number) == false)
            Console.WriteLine("Введено не число");
        else
        {
            if (number <= 0)
                Console.WriteLine("Задайте число больше 0");
            else
                return number;
        }
    }
}

void PrintArray(int[,] arr, string message)
{
    Console.WriteLine(message);
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if (arr[i, j] / 10 <= 0)
                Console.Write($" {arr[i, j]} ");
            else Console.Write($"{arr[i, j]} ");
        }
        Console.WriteLine();
    }
}

void MultiplicationArray(int[,] a, int[,] b)
{
    if (a.GetLength(1) == b.GetLength(0))
    {
        int[,] c = new int[a.GetLength(0), b.GetLength(1)];
        for (int i = 0; i < c.GetLength(0); i++)
        {
            for (int j = 0; j < c.GetLength(1); j++)
            {
                for (int t = 0; t < a.GetLength(1); t++)
                {
                    c[i, j] += a[i, t] * b[t, j];
                }
            }
        }
        PrintArray(c, "Матрица произведений первой и второй матриц имеет следующий вид:");
    }
    else
    {
        Console.WriteLine("Перемножение матриц невозможно.");
        Console.WriteLine("Кол-во столбцов первой матрицы должно совпадать с кол-вом строк во второй матрице!!!");
    }


}

int line = GetNumber("Задайте число строк m первой матрицы : ");
int column = GetNumber("Задайте число столбцов n первой матрицы : ");
int[,] arr1 = Matrix(line, column);
int line2 = GetNumber("Задайте число строк m второй матрицы : ");
int column2 = GetNumber("Задайте число столбцов n второй матрицы: ");
int[,] arr2 = Matrix(line2, column2);
PrintArray(arr1, "Первая матрица имеет следующий вид:");
PrintArray(arr2, "Вторая матрица имеет следующий вид");
MultiplicationArray(arr1, arr2);
