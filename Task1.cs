using System;
class ChessKnight
{
    static void Main()
    {
        int[,] chessboard = new int[8, 8];
        Console.Write("Enter the row (0-7) of the knight: ");
        int row = int.Parse(Console.ReadLine());
        Console.Write("Enter the column (0-7) of the knight: ");
        int col = int.Parse(Console.ReadLine());
        MarkPossibleMoves(chessboard, row, col);
        DisplayChessboard(chessboard);
    }

    static void MarkPossibleMoves(int[,] chessboard, int row, int col)
    {
        int[] dx = { 1, 2, 2, 1, -1, -2, -2, -1 };
        int[] dy = { 2, 1, -1, -2, -2, -1, 1, 2 };
        chessboard[row,col] = 2;

        for (int i = 0; i < 8; i++)
        {
            int newRow = row + dx[i];
            int newCol = col + dy[i];

            if (IsValidMove(newRow, newCol))
            {
                chessboard[newRow, newCol] = 1;
            }
        }
    }

    static bool IsValidMove(int row, int col)
    {
        return row >= 0 && row < 8 && col >= 0 && col < 8;
    }

    static void DisplayChessboard(int[,] chessboard)
    {
        Console.WriteLine("Chessboard with Knight's Possible Positions in One Step:");
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if(chessboard[i,j] == 0){
                    Console.Write("0 ");  
                }
                else if(chessboard[i,j] == 2){
                    Console.Write("$ "); 
                }
                else{
                    Console.Write("# ");  
                }
            }
            Console.WriteLine();
        }
    }
}