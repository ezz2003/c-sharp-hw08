// 59. Задайте двумерный массив из целых чисел. Напишите программу, которая удалит строку и столбец, на пересечении которых расположен наименьший элемент массива.


int InputInt(string message)
{
  Console.Write(message + ": ");
  return Convert.ToInt32(Console.ReadLine());
}

int[,] MakeMatrixIntRnd(int rows, int columns, int min, int max)
{
  int[,] matrix = new int[rows, columns];
  Random rnd = new Random();
  for (int i = 0; i < rows; i++)
  {
    for (int j = 0; j < columns; j++)
    {
      matrix[i, j] = rnd.Next(min, max + 1);
    }
  }
  return matrix;
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

int[] FindIndexMinElement(int[,] matr)
{
  int[] indexIJ = new int[2];
  for (int i = 0; i < matr.GetLength(0); i++)
  {
    for (int j = 0; j < matr.GetLength(1); j++)
    {
      if (matr[i, j] < matr[indexIJ[0], indexIJ[1]])
      {
        indexIJ[0] = i;
        indexIJ[1] = j;
      }
    }
  }
  return indexIJ;
}

int[,] CopyMatrixWithoutMin(int[,] matr, int[] minAr)
{
  int[,] matrCopyW = new int[matr.GetLength(0) - 1, matr.GetLength(1) - 1];
  int kI = 0, kJ = 0;
  for (int i = 0; i < matr.GetLength(0) - 1; i++)
  {
    if (i == minAr[0])
    {
      kI = 1;
    }
    for (int j = 0; j < matr.GetLength(1) - 1; j++)
    {
      if (j == minAr[1])
      {
        kJ = 1;
      }
      matrCopyW[i, j] = matr[i + kI, j + kJ];
    }
  }
  return matrCopyW;
}


int rowsMatrix = InputInt("Введите количество строк в матрице");
int columnsMatrix = InputInt("Введите количество столбцов в матрице");
int[,] readyMatrix = MakeMatrixIntRnd(rowsMatrix, columnsMatrix, -10, 10);
PrintMatrix(readyMatrix);
int[] min = FindIndexMinElement(readyMatrix);
Console.WriteLine();
Console.WriteLine($"{min[0]}  {min[1]}           {readyMatrix[min[0], min[1]]}");
Console.WriteLine();
PrintMatrix(CopyMatrixWithoutMin(readyMatrix, min));