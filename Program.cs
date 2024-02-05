using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {   int m = Convert.ToInt32(Console.ReadLine());
            string[] input = Console.ReadLine().Split();
            int[] sequence = new int[m];
            for (int j = 0; j < m; j++)
            {
                sequence[j] = int.Parse(input[j]);
            }

            List<int> compressedSequence = CompressSequence(sequence);
            
            Console.WriteLine(compressedSequence.Count);
            foreach (int num in compressedSequence)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
static List<int> CompressSequence(int[] sequence)
    {
        List<int> compressedSequence = new List<int>();
        int start = 0;
        while (start < sequence.Length )
        {   int end = start + 1;     
            int diff = 0;
            while (end < sequence.Length && sequence[end] == sequence[end - 1] + 1){
                diff = sequence[end] - sequence[start];
                end++;
            }  
            while (end < sequence.Length && sequence[end] == sequence[end - 1] - 1){
                diff = sequence[end] - sequence[start];
                end++;
            } 

            compressedSequence.Add(sequence[start]);
            compressedSequence.Add(diff);
            start = end;    
    }
     return compressedSequence;
}}