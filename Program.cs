using System;
class Program
{
static void Main()
    {
      int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
        int LowLimit = 15; 
        int UppLimit = 30; 
        int person = Convert.ToInt32(Console.ReadLine());
        for (int j = 0; j < person; j++){
            string[] input = Console.ReadLine().Split(' ');
            string sign = input[0];
            int value = Convert.ToInt32(input[1]);
            Console.WriteLine(CheckTemperature(sign, value, ref LowLimit, ref UppLimit));
        }
        Console.Write("\n");
        }   
    }
    static int CheckTemperature(string sign, int value, ref int LowLimit, ref int UppLimit)
    {
    int codeError = -1;
    switch (sign)
        {
        case ">=": LowLimit = (value <= LowLimit)? LowLimit : value;
            if (LowLimit <= UppLimit){
                    return LowLimit;
                } else{
                        return codeError;  
                }
        case "<=": UppLimit = (value >= UppLimit)? UppLimit : value;
            if (LowLimit <= UppLimit){
                    return LowLimit;
                } else{
                        return codeError;  
                }
        default:
                return codeError;
        }
    }
}



   