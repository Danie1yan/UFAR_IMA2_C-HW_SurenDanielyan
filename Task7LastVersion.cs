using System;
class MainClass {
    static int[,] board = new int[8, 8];
    static int[,] used = new int[8, 8];
    public static void Main (string[] args) {
        Console.WriteLine("Enter the starting row for placing the queens (0-7):");
        int startRow = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the starting column for placing the queens (0-7):");
        int startCol = Convert.ToInt32(Console.ReadLine());
        PlaceQueen(startRow, startCol);
        PlaceQueens();
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
        PrintBoard();
    }
    static void PlaceQueens() {
        for (int i = 0; i < 8; i++) {
            int minAttacks = int.MaxValue;
            int bestRow = -1;
            int bestCol = -1;
            for (int row = 0; row < 8; row++) {
                for (int col = 0; col < 8; col++) {
                	if(used[row,  col] > 0)
                		continue;
                    if (board[row, col] == 0) {
                        int newAttacks = CountNewAttacks(row, col);
                        if (newAttacks < minAttacks) {
                            minAttacks = newAttacks;
                            bestRow = row;
                            bestCol = col;
                        }
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
    static int CountNewAttacks(int row, int col) {
        int newAttacks = 0;
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                if ((i == row || j == col || Math.Abs(row - i) == Math.Abs(col - j)) && (i != row || j != col)) {
                    if (board[i, j] == 0) {
                        newAttacks++;
                    }
                }
            }
        }
        return newAttacks;
    }
    static void PrintBoard() {
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                if (board[i, j] == 1) {
                    Console.Write("Q ");
                } else if (used[i, j] > 0) {
                    Console.Write("X ");
                } else {
                    Console.Write(CountNewAttacks(i, j) + " ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}