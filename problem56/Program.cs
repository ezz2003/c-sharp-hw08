// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:

// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7

// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка


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

int SearchMinSummRow(int[,] matr)
{
    int minSummRow = 0;
    int minNumRow = 0;
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        int tempSummRow = 0;
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            tempSummRow += matr[i, j];
        }
        if (i==1) minSummRow = tempSummRow;
        if (tempSummRow<minSummRow)
        {
            minSummRow = tempSummRow;
            minNumRow = i;
        }
    }
    return minNumRow;
}


int rowsMatrix = InputInt("Введите количество строк в матрице");
int columnsMatrix = InputInt("Введите количество столбцов в матрице");
int[,] readyMatrix = MakeMatrixIntRnd(rowsMatrix, columnsMatrix, 1, 10);
PrintMatrix(readyMatrix);
Console.WriteLine();
Console.WriteLine($"Строка с минимальной суммой элементов: {SearchMinSummRow(readyMatrix)+1} строка"); 
// как п задании: строки считаем с 1, а не с 0.