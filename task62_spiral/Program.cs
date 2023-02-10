// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int[,] array = new int[4, 4];
int sizeM = array.GetLength(0);
int sizeN = array.GetLength(1);
int count = 1;

//0-right, 1-down, 2-left, 3-up
void Spiral(int x, int y, int move)
{
    array[y, x] = count;
    if (count == sizeM * sizeN) return;
    count++;
    //Console.WriteLine($"x={x} y={y} move={move}");

    if (move == 0)
    {
        if (x + 1 < sizeN && array[y, x + 1] == 0) Spiral(x + 1, y, 0);
        else Spiral(x, y + 1, 1);
    }
    else if (move == 1)
    {
        if (y + 1 < sizeM && array[y + 1, x] == 0) Spiral(x, y + 1, 1);
        else Spiral(x - 1, y, 2);
    }
    else if (move == 2)
    {
        if (x - 1 >= 0 && array[y, x - 1] == 0) Spiral(x - 1, y, 1);
        else Spiral(x, y - 1, 3);
    }
    else if (move == 3)
    {
        if (y - 1 >= 0 && array[y - 1, x] == 0) Spiral(x, y - 1, 3);
        else Spiral(x + 1, y, 0);
    }
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

Spiral(0, 0, 0);

PrintArray2D(array);


