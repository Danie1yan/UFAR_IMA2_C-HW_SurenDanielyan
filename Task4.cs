using System;
class ChessKnight
{
    static int[,] chessboard = new int[8, 8];
    static int moveCounter = 1;
    static int currentRow;
    static int currentCol;
    static void Main()
    {
        Console.Write("Enter the row (0-7) of the knight: ");
        currentRow = int.Parse(Console.ReadLine());
        Console.Write("Enter the column (0-7) of the knight: ");
        currentCol = int.Parse(Console.ReadLine());
        MoveKnight();
        DisplayChessboard();
    }
    static void MoveKnight()
    {
        int[] dx = { 1, 2, 2, 1, -1, -2, -2, -1 };
        int[] dy = { 2, 1, -1, -2, -2, -1, 1, 2 };
        chessboard[currentRow, currentCol] = moveCounter;
        while (TryMove(dx, dy)) ;
    }
    static bool TryMove(int[] dx, int[] dy)
    {
        bool moved = false;
        for (int i = 0; i < 8; i++)
        {
            int newRow = currentRow + dx[i];
            int newCol = currentCol + dy[i];
            if (IsValidMove(newRow, newCol) && chessboard[newRow, newCol] == 0)
            {
                chessboard[newRow, newCol] = ++moveCounter;
                currentRow = newRow;
                currentCol = newCol;
                moved = true;
                break;
            }
        }
        return moved;
    }
    static bool IsValidMove(int row, int col)
    {
        return row >= 0 && row < 8 && col >= 0 && col < 8;
    }
    static void DisplayChessboard()
    {
        Console.WriteLine("Chessboard with Knight's Possible Positions in One Step:");
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write($"{chessboard[i, j]:D2} ");
            }
            Console.WriteLine();
        }
    }
}
