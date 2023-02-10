// Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

int GetNum(string text)
{
    Console.Write(text);
    int num = int.Parse(Console.ReadLine());
    return num;
}

int[,,] GetArrayMix(int rows)
{
    int count = 0;
    if (Math.Pow(rows, 3) > 90) return null;
    //Создать массив для выборки
    int[] arrayGet = new int[90];
    for (int i = 0; i <= 89; i++)
    {
        arrayGet[i] = i + 10;
        count++;
    }

    int index;
    //Перемешать массив
    for (int i = 0; i < arrayGet.Length; i++)
    {
        index = new Random().Next(0, arrayGet.Length);
        (arrayGet[i], arrayGet[index]) = (arrayGet[index], arrayGet[i]);
        count++;
    }

    index = 0;
    int[,,] arr = new int[rows, rows, rows];

    for (int i = 0; i < rows; i++)
        for (int j = 0; j < rows; j++)
            for (int k = 0; k < rows; k++)
            {
                arr[i, j, k] = arrayGet[index];
                index++;
                count++;
            }

    Console.WriteLine($"Первый способ {count} операций");
    return arr;
}

int[,,] GetArrayShot(int rows)
{
    int count = 0;
    if (Math.Pow(rows, 3) > 90) return null;
    //Создать массив для выборки
    int[] arrayGet = new int[90];
    for (int i = 0; i <= 89; i++)
    {
        arrayGet[i] = i + 10;
        count++;
    }

    int index;
    int size = arrayGet.Length;

    int[,,] arr = new int[rows, rows, rows];

    for (int i = 0; i < rows; i++)
        for (int j = 0; j < rows; j++)
            for (int k = 0; k < rows; k++)
            {
                //Поймать индекс
                index = new Random().Next(0, size);
                arr[i, j, k] = arrayGet[index];
                //сдвиг
                for (int x = index; x < size - 1; x++)
                {
                    arrayGet[x] = arrayGet[x + 1];
                    count++;
                }
                size--;
                count++;
            }
    Console.WriteLine($"Второй способ {count} операций");
    //Console.WriteLine(String.Join(", ",arrayGet));
    return arr;
}

void PrintArray3D(int[,,] array)
{
    int rows1 = array.GetLength(0);
    int rows2 = array.GetLength(1);
    int rows3 = array.GetLength(2);

    for (int i = 0; i < rows1; i++)
    {
        for (int j = 0; j < rows2; j++)
        {
            for (int k = 0; k < rows3; k++)
            {
                Console.WriteLine(String.Format("{0,5}", array[i, j, k], i, j, k) + $" ({i},{j},{k})");
            }
        }
    }
}

int sizeM = GetNum("Введите размер M: ");

int[,,] arrayMix = GetArrayMix(sizeM);
int[,,] arrayShot = GetArrayShot(sizeM);

if (arrayMix == null) Console.WriteLine($"Не хватает неповторяющихся двузначных чисел для массива {sizeM}*{sizeM}*{sizeM}");
else PrintArray3D(arrayMix);

Console.WriteLine();

if (arrayShot == null) Console.WriteLine($"Не хватает неповторяющихся двузначных чисел для массива {sizeM}*{sizeM}*{sizeM}");
else PrintArray3D(arrayShot);