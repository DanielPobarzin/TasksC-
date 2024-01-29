using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            string[] numbers = line.Split(' ');
            int day = int.Parse(numbers[0]);
            int month = int.Parse(numbers[1]);
            int year = int.Parse(numbers[2]);
            bool isValidDate = IsValidDate(day, month, year);
            if (isValidDate)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }

    static bool IsValidDate(int day, int month, int year)
    {
        if ( day > DateTime.DaysInMonth(year, month))
        {
            return false;
        }
        if (month == 2 && day == 29 && !DateTime.IsLeapYear(year))
        {
            return false;
        }
        return true;
    }
}