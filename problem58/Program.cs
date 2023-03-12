// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

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

int[,] MatrixMultiplication(int[,] matrA, int[,] matrB)
{
  int[,] matrixResult = new int[matrA.GetLength(0), matrB.GetLength(1)];
  for (int i = 0; i < matrA.GetLength(0); i++)
  {
    for (int j = 0; j < matrB.GetLength(1); j++)
    {
      matrixResult[i, j] = 0;
      for (int l = 0; l < matrA.GetLength(1); l++)
      {
        matrixResult[i, j] += matrA[i, l] * matrB[l, j];
      }
    }
  }
  return matrixResult;
}


int rowsMatrix = InputInt("Введите количество строк в 1 матрице");
int columnsMatrix = InputInt("Введите количество столбцов в 1 матрице");
int[,] readyMatrixA = MakeMatrixIntRnd(rowsMatrix, columnsMatrix, 1, 10);
rowsMatrix = InputInt("Введите количество строк во 2 матрице");
columnsMatrix = InputInt("Введите количество столбцов во 2 матрице");
int[,] readyMatrixB = MakeMatrixIntRnd(rowsMatrix, columnsMatrix, 1, 10);
PrintMatrix(readyMatrixA);
Console.WriteLine();
PrintMatrix(readyMatrixB);
Console.WriteLine();
if (readyMatrixA.GetLength(0) != readyMatrixB.GetLength(1))
{
  Console.WriteLine("Такие матрицы нельзя перемножить. Выберите другой размер матриц.");
}
else PrintMatrix(MatrixMultiplication(readyMatrixA, readyMatrixB));