using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of spots (M): ");
        int M = int.Parse(Console.ReadLine());

        Console.Write("Enter max boxes per spot (N): ");
        int N = int.Parse(Console.ReadLine());

        int[,] warehouse = new int[N, M];

        // Input warehouse data (boxes per spot)
        for (int i = 0; i < N; i++)
        {
            Console.Write($"Enter boxes for spot {i + 1} (space-separated): ");
            string[] input = Console.ReadLine().Split(' ');

            for (int j = 0; j < M; j++)
            {
                warehouse[i, j] = int.Parse(input[j]);
            }
        }

        // Find the spot with the maximum boxes
        int maxBoxes = 0;
        int maxSpot = -1;

        for (int i = 0; i < N; i++)
        {
            int boxCount = 0;
            for (int j = 0; j < M; j++)
            {
                boxCount += warehouse[i, j];
            }

            if (boxCount > maxBoxes)
            {
                maxBoxes = boxCount;
                maxSpot = i + 1; // Store spot number (1-based index)
            }
        }

        // Display the result
        Console.WriteLine($"\nIndex: {maxSpot}");
    }
}