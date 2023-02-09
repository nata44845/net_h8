// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

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

///<summary>Сортировка массива построчно по убыванию</summary>
void SortArray(int[,] array)
{
    int rows = array.GetLength(0);
    int cols = array.GetLength(1);

    for (int i = 0; i < rows; i++)
    {   int max=array[i,0];
        for (int j = 1; j < cols-1; j++)
        {   
            if (array[i,j]>max)
            {
                max=array[i,j];
                //сдвиг
                for (int k=0; k<j; k++)
                    array[i,k+1]=array[i,k];
                array[i,0]=max;
                Console.WriteLine(max);
            }
        }
    }
}


int sizeM = GetNum("Введите размер M: ");
int sizeN = GetNum("Введите размер N: ");

int[,] array = GetArray(sizeM, sizeN, 0, 100);

PrintArray2D(array);

SortArray(array);

PrintArray2D(array);