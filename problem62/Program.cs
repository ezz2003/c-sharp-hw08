// Задача 62.Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int InputInt(string message)
{
  Console.Write(message + ": ");
  return Convert.ToInt32(Console.ReadLine());
}

void PrintMatrix(int[,] matrix)
{
  for (int i = 0; i < matrix.GetLength(0); i++)
  {
    for (int j = 0; j < matrix.GetLength(1) - 1; j++)
    {
      Console.Write($"{matrix[i, j],4},");
    }
    Console.WriteLine($"{matrix[i, matrix.GetLength(1) - 1],4}");
  }
}

int[,] SpiralArray(int size)
{
  int[,] arr = new int[size, size];
  int i = 0, j = 0;
  int sGoriz = size;
  int sVert = size;
  for (int n = 1; n <= size * size; n++)
  {
    Console.WriteLine($"{i}   {j}");
    arr[i, j] = n;
    if (i <= j + 1 & i + j < size - 1)
      j++;
    else if (i < j & i + j >= size - 1)
      i++;
    else if (i >= j & i + j > size - 1)
      j--;
    else
      i--;
  }
  return arr;
}

int siz = InputInt("Введите размер массива");
PrintMatrix(SpiralArray(siz));

