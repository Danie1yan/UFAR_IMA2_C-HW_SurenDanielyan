using System;
class MainClass {
    static int[,] board = new int[8, 8];
    static int[,] used = new int[8, 8];
    public static void Main (string[] args) {
        PlaceQueens();
        PrintBoard();
    }
    static void PlaceQueens() {
        for (int i = 0; i < 8; i++) {
            int minAttacks = int.MaxValue;
            int bestRow = -1;
            int bestCol = -1;
            for (int row = 0; row < 8; row++) {
                for (int col = 0; col < 8; col++) {
                    if(used[row,col]>0)
                        continue;
                    if (board[row, col] == 0 && CountAttacks(row, col) < minAttacks) {
                        minAttacks = CountAttacks(row, col);
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }
            if (bestRow != -1 && bestCol != -1) {
                PlaceQueen(bestRow, bestCol);
            } else {
                break;
            }
        }
    }
    static void PlaceQueen(int row, int col) {
        board[row, col] = 1;
        used[row, col] = 1;
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                if (used[i, j] == 0 && (i == row || j == col || Math.Abs(row - i) == Math.Abs(col - j))) {
                    used[i, j]++;
                }
            }
        }
    }
    static int CountAttacks(int row, int col) {
        int attacks = 0;
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                if (used[i, j] == 0 && (i == row || j == col || Math.Abs(row - i) == Math.Abs(col - j))) {
                    attacks++;
                }
            }
        }
        return attacks;
    }
    static void PrintBoard() {
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                Console.Write(board[i, j] == 1 ? "Q " : "- ");
            }
            Console.WriteLine();
        }
    }
}