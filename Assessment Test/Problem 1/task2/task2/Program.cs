using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Read matrix size
        Console.Write("Enter number of rows (m): ");
        int m = int.Parse(Console.ReadLine());

        Console.Write("Enter number of columns (n): ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[m, n];

        // Read matrix values
        Console.WriteLine($"Enter {m}×{n} matrix values row by row:");
        for (int i = 0; i < m; i++)
        {
            string[] input = Console.ReadLine().Split(' '); // Read row as space-separated numbers
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = int.Parse(input[j]);
            }
        }

        // Get spiral order
        List<int> result = SpiralOrder(matrix);

        // Print result
        Console.WriteLine("Spiral Order: " + string.Join(", ", result));
    }

    static List<int> SpiralOrder(int[,] matrix)
    {
        List<int> result = new List<int>();
        if (matrix == null || matrix.Length == 0) return result;

        int m = matrix.GetLength(0); // Rows
        int n = matrix.GetLength(1); // Columns

        int top = 0, bottom = m - 1;
        int left = 0, right = n - 1;

        while (top <= bottom && left <= right)
        {
            // Traverse from left to right
            for (int i = left; i <= right; i++)
                result.Add(matrix[top, i]);
            top++;

            // Traverse from top to bottom
            for (int i = top; i <= bottom; i++)
                result.Add(matrix[i, right]);
            right--;

            // Traverse from right to left (if still valid)
            if (top <= bottom)
            {
                for (int i = right; i >= left; i--)
                    result.Add(matrix[bottom, i]);
                bottom--;
            }

            // Traverse from bottom to top (if still valid)
            if (left <= right)
            {
                for (int i = bottom; i >= top; i--)
                    result.Add(matrix[i, left]);
                left++;
            }
        }
        return result;
    }
}