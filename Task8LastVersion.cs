using System;
class MainClass {
    static int[] dx = { 1, 1, 2, 2, -1, -1, -2, -2 };
    static int[] dy = { 2, -2, 1, -1, 2, -2, 1, -1 };
    static int[,] used = new int[8, 8];
    static int n = 8;
    public static void Main (string[] args) {
        Console.WriteLine("Enter the starting position (row 0-7):");
        int startY = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the starting position (column 0-7):");
        int startX = Convert.ToInt32(Console.ReadLine());
        int currentY = startY;
        int currentX = startX;
        int moves = 1;
        used[currentY, currentX] = moves;
        while (moves < n * n) {
            Console.WriteLine("Current grid:");
            PrintGrid(currentY, currentX, moves);
            int nextY = -1;
            int nextX = -1;
            int minMoves = n + 1;
            for (int dir = 0; dir < 8; dir++) {
                int nx = currentX + dx[dir];
                int ny = currentY + dy[dir];
                if (nx >= 0 && nx < n && ny >= 0 && ny < n && used[ny, nx] == 0) {
                    int possibleMoves = NumberOfMoves(ny, nx);
                    if (possibleMoves < minMoves) {
                        minMoves = possibleMoves;
                        nextY = ny;
                        nextX = nx;
                    }
                }
            }
            if (nextY == -1 || nextX == -1) {
                Console.WriteLine("No possible moves. Stopping.");
                break;
            }
            currentY = nextY;
            currentX = nextX;
            used[currentY, currentX] = ++moves;
        }
        Console.WriteLine("Final grid:");
        PrintGrid(currentY, currentX, moves);
    }
   static void PrintGrid(int currentY, int currentX, int moves) {
	    for (int i = 0; i < n; i++) {
	        for (int j = 0; j < n; j++) {
	            if (i == currentY && j == currentX) {
	                Console.Write("K ");
	            } else if (used[i, j] > 0) {
	                Console.Write("X ");
	            } else {
	                bool reachable = false;
	                for (int dir = 0; dir < 8; dir++) {
	                    int nx = currentX + dx[dir];
	                    int ny = currentY + dy[dir];
	                    if (nx == j && ny == i) {
	                        reachable = true;
	                        break;
	                    }
	                }
	                if (reachable) {
	                    Console.Write(NumberOfMoves(i, j) + " ");
	                } else {
	                    Console.Write(". ");
	                }
	            }
	        }
	        Console.WriteLine();
	    }
	    Console.WriteLine();
	}
    static int NumberOfMoves(int y, int x) {
        int res = 0;
        for (int dir = 0; dir < 8; dir++) {
            int nx = x + dx[dir];
            int ny = y + dy[dir];
            if (nx >= 0 && nx < n && ny >= 0 && ny < n && used[ny, nx] == 0) {
                res++;
            }
        }
        return res;
    }
}