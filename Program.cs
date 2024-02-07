using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int setsCount = int.Parse(Console.ReadLine());
        List<string> results = new List<string>();

        for (int i = 0; i < setsCount; i++)
        {
            int playersCount = int.Parse(Console.ReadLine());
            List<string> playerCards = new List<string>();

            for (int j = 0; j < playersCount; j++)
            {
                playerCards.AddRange(Console.ReadLine().Split());
            }

            string[] myCards = playerCards.Take(2).ToArray();

            List<string> possibleTableCards = GetPossibleTableCards(myCards, playerCards);

            results.Add(possibleTableCards.Count.ToString());
            results.AddRange(possibleTableCards);
        }

        foreach (string result in results)
        {
            Console.WriteLine(result);
        }
    }

    static List<string> GetPossibleTableCards(string[] myCards, List<string> allCards)
    {
        List<string> possibleTableCards = new List<string>();

        string[] suits = { "S", "C", "D", "H" };

        // Check for Set or Pair
        if (myCards[0][0] == myCards[1][0] || allCards.GroupBy(x => x).Any(g => g.Count() >= 3) || allCards.GroupBy(x => x[0]).Any(g => g.Count() >= 2 && g.Key != myCards[0][0]))
        {
            possibleTableCards.Add(myCards[0]);
            possibleTableCards.Add(myCards[1]);
        }
        else
        {
            char[] values = { 'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2' };
            foreach (char value in values)
            {
                foreach (string suit in suits)
                {
                    if (myCards.Concat(allCards).Any(card => card[0] == value && card[1] == suit[0]))
                    {
                        possibleTableCards.Add(value.ToString() + suit);
                        break;
                    }
                }
                if (possibleTableCards.Count > 0)
                {
                    break;
                }
            }
        }

        return possibleTableCards;
    }
}