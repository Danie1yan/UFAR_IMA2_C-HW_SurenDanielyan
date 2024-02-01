using System;
class ChessQueen
{
    static void Main()
    {
        int[,] chessboard = new int[8, 8];
        Console.Write("Enter the row (0-7) of the queen: ");
        int row = int.Parse(Console.ReadLine());
        Console.Write("Enter the column (0-7) of the queen: ");
        int col = int.Parse(Console.ReadLine());
        MarkPossibleMoves(chessboard, row, col);
        DisplayChessboard(chessboard);
    }
    static void MarkPossibleMoves(int[,] chessboard, int row, int col)
    {
        for (int i = 0; i < 8; i++)
        {
            if (i != row)
            {
                chessboard[i, col] = 1;
            }
            if (i != col)
            {
                chessboard[row, i] = 1;
            }
            if (IsValidMove(row + i, col + i))
            {
                chessboard[row + i, col + i] = 1;
            }
            if (IsValidMove(row - i, col + i))
            {
                chessboard[row - i, col + i] = 1;
            }
            if (IsValidMove(row + i, col - i))
            {
                chessboard[row + i, col - i] = 1;
            }
            if (IsValidMove(row - i, col - i))
            {
                chessboard[row - i, col - i] = 1;
            }
        }
        chessboard[row, col] = 2;
    }
    static bool IsValidMove(int row, int col)
    {
        return row >= 0 && row < 8 && col >= 0 && col < 8;
    }
    static void DisplayChessboard(int[,] chessboard)
    {
        Console.WriteLine("Chessboard with Queen's Possible Positions:");
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (chessboard[i, j] == 0)
                {
                    Console.Write("0 ");
                }
                else if (chessboard[i, j] == 2)
                {
                    Console.Write("$ ");
                }
                else
                {
                    Console.Write("# ");
                }
            }
            Console.WriteLine();
        }
    }
}