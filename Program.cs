using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine()); // количество входных данных
        for (int k = 0; k<n; k++){
        int totalPageCount = int.Parse(Console.ReadLine()); // общее количество страниц в документе

        List<int> printedPages = new List<int>();
        string[] input = Console.ReadLine().Split(',');
        foreach (string item in input)
        {
            if (item.Contains("-"))
            {
                string[] range = item.Split('-');
                int start = int.Parse(range[0]);
                int end = int.Parse(range[1]);
                for (int i = start; i <= end; i++)
                {
                    printedPages.Add(i);
                }
            }
            else
            {
                printedPages.Add(int.Parse(item));
            }
        }

        List<int> remainingPages = Enumerable.Range(1, totalPageCount).Except(printedPages).ToList();

        List<string> result = new List<string>();
        int startRange = remainingPages[0];
        int endRange = remainingPages[0];
        for (int i = 1; i < remainingPages.Count; i++)
        {
            if (remainingPages[i] == endRange + 1)
            {
                endRange = remainingPages[i];
            }
            else
            {
                if (startRange == endRange)
                {
                    result.Add(startRange.ToString());
                }
                else
                {
                    result.Add($"{startRange}-{endRange}");
                }
                startRange = remainingPages[i];
                endRange = remainingPages[i];
            }
        }

        if (startRange == endRange)
        {
            result.Add(startRange.ToString());
        }
        else
        {
            result.Add($"{startRange}-{endRange}");
        }

        Console.WriteLine(string.Join(",", result));
    }
    }
}
