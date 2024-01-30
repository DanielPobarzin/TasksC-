using System;
using System.Text.RegularExpressions;

class Program
{          
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string line = Convert.ToString(Console.ReadLine());
            string[] carNumbers = new string[line.Length];
            for(int j=0; j < line.Length; j++)
            {
             carNumbers[j] = line[j].ToString();
            }  
           if (carNumbers.Length == CheckCarNumbers(carNumbers).Replace(" ","").Length){
                Console.WriteLine($"{CheckCarNumbers(carNumbers)}");
            } else {
                    Console.WriteLine("-");   
            }
        }
    }
    static string CheckCarNumbers(string[] carNumbers)
    {
        string patternOne = @"^[A-Z]\d{2}[A-Z]{2}$"; 
        string patternTwo = @"^[A-Z]\d[A-Z]{2}$"; 
        string result = "";
        string currentCarNumber = "";
        for (int i = 0; i < carNumbers.Length; i++)
        {
            currentCarNumber += carNumbers[i];
            if ((Regex.IsMatch(currentCarNumber, patternOne) || Regex.IsMatch(currentCarNumber, patternTwo))&& currentCarNumber.Length >=4)
            {
                result += currentCarNumber + " ";
                currentCarNumber = "";
            }
        }
        return result;
    }
}