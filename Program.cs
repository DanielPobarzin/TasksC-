using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int tests = int.Parse(Console.ReadLine());

        for (int t = 0; t < tests; t++)
        {
            string[] size = Console.ReadLine().Split();
            int rows = int.Parse(size[0]);
            int columns = int.Parse(size[1]);

            char[,] field = new char[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < columns; j++)
                {
                    field[i, j] = line[j];
                }
            }

            int rectangles = CountRectangles(field);
                        Console.WriteLine(rectangles);
            List<int> nestedCounts = CountNestedRectangles(field, rectangles);

            nestedCounts.Sort();

            foreach (int count in nestedCounts)
            {
                Console.Write(count + " ");
            }
            Console.WriteLine();
        }
    }

    static int CountRectangles(char[,] field)
    {
        int rows = field.GetLength(0);
        int columns = field.GetLength(1);

        int rectangles = 0;
        bool[,] visited = new bool[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {   
                if (field[i, j] == '*' && !visited[i, j])
                {
                    VisitRectangle(field, visited, i, j);
                    rectangles++;
                }
            }
        }

        return rectangles;
    }

    static void VisitRectangle(char[,] field, bool[,] visited, int row, int column)
    {
        int rows = field.GetLength(0);
        int columns = field.GetLength(1);

        if (row < 0 || row >= rows || column < 0 || column >= columns || field[row, column] != '*' || visited[row, column])
        {
            return;
        } 
        visited[row, column] = true; 
        VisitRectangle(field, visited, row - 1, column);
        VisitRectangle(field, visited, row + 1, column);
        VisitRectangle(field, visited, row, column - 1);
        VisitRectangle(field, visited, row, column + 1);
    }
    static List<int> CountNestedRectangles(char[,] field, int totalRectangles)
    {
        int rows = field.GetLength(0);
        int columns = field.GetLength(1);

        List<int> nestedCounts = new List<int>();
        bool[,] visited = new bool[rows, columns];
        int count = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (field[i, j] == '*' && !visited[i, j])
                {
                    count = CountNestedRectanglesHelper(field, visited, i, j, totalRectangles);
                    nestedCounts.Add(count);
                }
            }
        }

        return nestedCounts;
    }

    static int CountNestedRectanglesHelper(char[,] field, bool[,] visited, int row, int column, int totalRectangles)
    {
        int rows = field.GetLength(0);
        int columns = field.GetLength(1);

        if (row < 0 || row >= rows || column < 0 || column >= columns || field[row, column] != '*' || visited[row, column])
        {
            return 0;
        }
        visited[row, column] = true; 
        int count = 0;
        count += CountNestedRectanglesHelper(field, visited, row - 1, column, totalRectangles);
        count += CountNestedRectanglesHelper(field, visited, row + 1, column, totalRectangles);
        count += CountNestedRectanglesHelper(field, visited, row, column - 1, totalRectangles);
        count += CountNestedRectanglesHelper(field, visited, row, column + 1, totalRectangles);

        if (count == 0)
        {
            count = totalRectangles - 2;
        }

        return count;
    }
}