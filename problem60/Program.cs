// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// Результат:
// 66(0, 0, 0) 27(0, 0, 1) 25(0, 1, 0) 90(0, 1, 1)
// 34(1, 0, 0) 26(1, 0, 1) 41(1, 1, 0) 55(1, 1, 1)

int InputInt(string message)
{
  Console.Write(message + ": ");
  return Convert.ToInt32(Console.ReadLine());
}

int[,,] GetCubData(int x, int y, int z)
{
  int[,,] cub = new int[x, y, z];
  int n = 10;
  for (int i = 0; i < cub.GetLength(0); i++)
  {
    for (int j = 0; j < cub.GetLength(1); j++)
    {
      for (int l = 0; l < cub.GetLength(2); l++)
      {
        cub[i, j, l] = n;
        if (n >= 99) return cub;
        n++;
      }
    }
  }
  return cub;
}

void PrintCubForRows(int[,,] cuboid)
{
  for (int i = 0; i < cuboid.GetLength(0); i++)
  {
    for (int j = 0; j < cuboid.GetLength(1); j++)
    {
      for (int l = 0; l < cuboid.GetLength(2); l++)
      {
        Console.Write($"{cuboid[i, j, l]}({i},{j},{l}) ");
      }
    }
    Console.WriteLine();
  }
  Console.WriteLine();
}

int sizeX = InputInt("Введите измерение x");
int sizeY = InputInt("Введите измерение y");
int sizeZ = InputInt("Введите измерение z");
if (sizeX * sizeY * sizeZ + 10 <= 99)
{
  PrintCubForRows(GetCubData(sizeX, sizeY, sizeZ));
}
else
{ Console.WriteLine("Не сможем выполнить условия задачи. Введите меньшие размеры массива."); }

