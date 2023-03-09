// 57. Составить частотный словарь элементов двумерного массива. Частотый словарь содержит информацию о том, сколько раз встречается элемент входных данных.

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

int[][] GetFrequencyDictionary(int[,] matr)
{
  int[][] dict = new int[1][];
  dict[0] = new int[2] { matr[0, 0], 0 };
  for (int i = 0; i < matr.GetLength(0); i++)
  {
    for (int j = 0; j < matr.GetLength(1); j++)
    {
      int lenDict = dict.Length;
      bool flag = true;
      for (int k = 0; k < lenDict; k++)
      {
        if (dict[k][0] == matr[i, j])
        {
          dict[k][1] += 1;
          flag = false;
        }
      }
      if (flag)
      {
        Array.Resize(ref dict, (lenDict + 1));
        dict[dict.Length - 1] = new int[2] { matr[i, j], 0 };
        dict[dict.Length - 1][1] += 1;
      }
    }
  }
  return dict;
}

void PrintDictionary(int[][] dic)
{
  SortDict(ref dic);
  for (int i = 0; i < dic.Length; i++)
  {
    Console.WriteLine($" {dic[i][0],4} встречается {dic[i][1],4} раз");
  }
}

void PrintMatrix(int[,] matrix)
{
  Console.WriteLine("В матрице:");
  for (int i = 0; i < matrix.GetLength(0); i++)
  {
    for (int j = 0; j < matrix.GetLength(1) - 1; j++)
    {
      Console.Write($"{matrix[i, j],4},");
    }
    Console.WriteLine($"{matrix[i, matrix.GetLength(1) - 1],4}");
  }
}

void SortDict(ref int[][] dic)
{
  for (int i = 0; i < dic.Length - 1; i++)
  {
    int minIndex = i;
    for (int j = i + 1; j < dic.Length; j++)
    {
      if (dic[j][0] < dic[minIndex][0])
      {
        minIndex = j;
      }
    }
    (dic[i], dic[minIndex]) = (dic[minIndex], dic[i]);
  }
}

int rowsMatrix = InputInt("Введите количество строк в матрице");
int columnsMatrix = InputInt("Введите количество столбцов в матрице");
int[,] readyMatrix = MakeMatrixIntRnd(rowsMatrix, columnsMatrix, 1, 10);
PrintMatrix(readyMatrix);
PrintDictionary(GetFrequencyDictionary(readyMatrix));




