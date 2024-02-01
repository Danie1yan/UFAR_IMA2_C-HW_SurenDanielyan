using System;
using System.Collections.Generic;
class QueensPlacement
{
    static int boardSize = 8;
    static void Main()
    {
        Tuple<int, int>[] queens = new Tuple<int, int>[boardSize];
        for (int i = 0; i < boardSize; i++)
        {
            PlaceQueenRandomly(queens);
        }
        DisplayChessboard(queens);
    }
    static bool Attacks(Tuple<int, int> queen1, Tuple<int, int> queen2)
    {
        return queen1.Item1 == queen2.Item1 || queen1.Item2 == queen2.Item2 || Math.Abs(queen1.Item1 - queen2.Item1) == Math.Abs(queen1.Item2 - queen2.Item2);
    }
    static void PlaceQueenRandomly(Tuple<int, int>[] queens)
    {
        Random random = new Random();
        List<Tuple<int, int>> safePositions;
        do
        {
            safePositions = GetSafePositions(queens);
            if (safePositions.Count > 0)
            {
                Tuple<int, int> position = safePositions[random.Next(safePositions.Count)];
                queens[Array.IndexOf(queens, null)] = position;
            }
        } while (safePositions.Count > 0);
    }
    static List<Tuple<int, int>> GetSafePositions(Tuple<int, int>[] queens)
    {
        List<Tuple<int, int>> safePositions = new List<Tuple<int, int>>();
        for (int row = 0; row < boardSize; row++)
        {
            for (int col = 0; col < boardSize; col++)
            {
                Tuple<int, int> position = Tuple.Create(row, col);
                if (!IsAttacked(position, queens))
                {
                    safePositions.Add(position);
                }
            }
        }
        return safePositions;
    }
    static bool IsAttacked(Tuple<int, int> position, Tuple<int, int>[] queens)
    {
        foreach (var queen in queens)
        {
            if (queen != null && Attacks(queen, position))
            {
                return true;
            }
        }
        return false;
    }
    static void DisplayChessboard(Tuple<int, int>[] queens)
    {
        Console.WriteLine("Chessboard with Randomly Placed Queens:");
        for (int i = 0; i < boardSize; i++)
        {
            for (int j = 0; j < boardSize; j++)
            {
                Console.Write(Array.IndexOf(queens, Tuple.Create(i, j)) != -1 ? "$ " : "# ");
            }
            Console.WriteLine();
        }
    }
}