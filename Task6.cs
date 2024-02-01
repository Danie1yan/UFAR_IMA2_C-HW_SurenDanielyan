using System;
class RandomMatrix
{
    static void Main()
    {
        Console.Write("Enter the number of rows (n): ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter the number of columns (m): ");
        int m = int.Parse(Console.ReadLine());
        int[,] matrix = Matrix(n, m);
        Console.WriteLine("The Matrix Strokes:");
        DisplayMatrix(matrix);
    }
    static int[,] Matrix(int rows, int cols)
    {
        int[,] matrix = new int[rows, cols];
        Random random = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int randomNumber;
                do
                {
                    randomNumber = random.Next(1, 1000001);
                } while (IsNumberUsed(matrix, randomNumber));
                matrix[i, j] = randomNumber;
            }
        }
        return matrix;
    }
    static bool IsNumberUsed(int[,] matrix, int number)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (matrix[i, j] == number)
                {
                    return true;
                }
            }
        }
        return false;
    }
    static void DisplayMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{matrix[i, j]:D2} ");
            }
            Console.WriteLine();
        }
    }
}