// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка


int GetNum(string text)
{
    Console.Write(text);
    int num = int.Parse(Console.ReadLine());
    return num;
}

int[,] GetArray(int rows, int cols, int min, int max)
{
    int[,] arr = new int[rows, cols];
    int maxTemp = max + 1;
    for (int i = 0; i < rows; i++)
        for (int j = 0; j < cols; j++)
        {
            arr[i, j] = new Random().Next(min, maxTemp);
        }
    return arr;
}

void PrintArray2D(int[,] array)
{
    int rows = array.GetLength(0);
    int cols = array.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            Console.Write(String.Format("{0,5} ", array[i, j]));
        }
        Console.WriteLine();
    }
}

///<summary>Строка с наименьшей суммой элементов</summary>
int MinSumString(int[,] array)
{
    int rows = array.GetLength(0);
    int cols = array.GetLength(1);

    if (cols == 0 || rows == 0) return -1;

    int min = 0;
    int minStr = 0;
    for (int i = 0; i < cols; i++)
    {
        min += array[0, i];
    }

    for (int i = 1; i < rows; i++)
    {
        int sum = 0;
        for (int j = 0; j < cols; j++)
        {
            sum += array[i, j];
        }

        if (min > sum)
        {
            min = sum;
            minStr = i;
        }
    }
    return minStr + 1;
}

int sizeM = GetNum("Введите размер M: ");
int sizeN = GetNum("Введите размер N: ");

int[,] array = GetArray(sizeM, sizeN, 0, 9);

PrintArray2D(array);

int minStr = MinSumString(array);

if (minStr == -1) Console.WriteLine("Строки с минимальной суммой не существует");
else Console.WriteLine($"{minStr} строка");