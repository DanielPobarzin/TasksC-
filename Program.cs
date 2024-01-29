using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            string line = Console.ReadLine();
            string[] numbers = line.Split(' ');
            int count1 = 0, count2 = 0, count3 = 0, count4 = 0;
            foreach (string num in numbers)
            {
                switch (num)
                {
                    case "1":
                        count1++;
                        break;
                    case "2":
                        count2++;
                        break;
                    case "3":
                        count3++;
                        break;
                    case "4":
                        count4++;
                        break;
                }
            }
            if (count4 == 1 && count3 == 2 && count2 == 3 && count1 == 4)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}