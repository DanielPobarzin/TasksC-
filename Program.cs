using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < n; i++)
        {
            int len = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine().Split(' ');
            int[] numbers = new int[len];
            
            for (int j = 0; j < len; j++)
            {
                numbers[j] = int.Parse(input[j]);
            }
            
            List<int> compressedSequence = CompressSequence(numbers);
            
            Console.WriteLine(compressedSequence.Count);
            Console.WriteLine(string.Join(" ", compressedSequence));
        }
    }
    
    static List<int> CompressSequence(int[] numbers)
    {
        List<int> compressedSequence = new List<int>();
        
        int start = 0;
        while (start < numbers.Length)
        {
            int diff = 0;
            int end = start + 1;
            while (end < numbers.Length && Math.Abs(numbers[end] - numbers[end - 1]) == 1)
            {
                
                if (numbers[end] - numbers[end - 1] == 1 && diff>=0){
                    diff++; 
                    if (numbers[end] - numbers[end - 1] == -1){
                        break;
                    }
                } else if (numbers[end] - numbers[end - 1] == -1&& diff<=0){
                    diff--; 
                    if (numbers[end] - numbers[end - 1] == 1){
                        break;
                    }
                }else {
                    break;
                }
                end++; 
            } 
            if (end - start == 1)
            {
                compressedSequence.Add(numbers[start]);
                compressedSequence.Add(0);
            }
            else if (end - start > 1)
            {
                compressedSequence.Add(numbers[start]);
                compressedSequence.Add(diff);
            }
            else
            {
                compressedSequence.Add(numbers[start]);
                compressedSequence.Add(numbers[end - 1] - numbers[start]);
            }
            
            start = end;
        }
        
        return compressedSequence;
    }
}