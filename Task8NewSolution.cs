using System;
class MainClass {
    static int[] dx = { 1, 1, 2, 2, -1, -1, -2, -2 };
    static int[] dy = { 2, -2, 1, -1, 2, -2, 1, -1 };
    static int[,] used = new int[8, 8];
    static int n = 8;
    public static void Main (string[] args) {
        Random random = new Random();
        int currentY = random.Next(n);
        int currentX = random.Next(n);
        int moves = 1;
        used[currentY, currentX] = moves;
        while (moves < n * n) {
            Console.WriteLine($"Current position: ({currentY}, {currentX})");
            Console.WriteLine("Possible moves:");
            int nextY = -1;
            int nextX = -1;
            int minMoves = n + 1;
            for (int dir = 0; dir < 8; dir++) {
                int nx = currentX + dx[dir];
                int ny = currentY + dy[dir];
                if (nx >= 0 && nx < n && ny >= 0 && ny < n && used[ny, nx] == 0) {
                    int possibleMoves = NumberOfMoves(ny, nx);
                    Console.WriteLine($"({ny}, {nx}): {possibleMoves}");
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
            Console.WriteLine($"Selected move: ({currentY}, {currentX})");
            Console.WriteLine();
        }
        Console.WriteLine("Used array:");
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                Console.Write(used[i, j] + " ");
            }
            Console.WriteLine();
        }
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