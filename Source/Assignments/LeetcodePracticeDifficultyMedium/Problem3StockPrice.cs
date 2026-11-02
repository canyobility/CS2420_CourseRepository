using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Assignments.LeetcodePracticeDifficultyMedium
{
    public class StockPriceMinimimCalculator
    {
        public int[] WeekyPrices { get; private set; }

        public StockPriceMinimimCalculator(int[] weekyPrices)
        {
            WeekyPrices = weekyPrices; 
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        //public int[] FindNextDiscounted(int[] days)
        //{
        //    int[] arrayOut = new int[WeekyPrices.Count()];
        //    Stack<int> prices = new Stack<int>();

        //    for (int i = 0; i < WeekyPrices.Count(); i++)
        //    {
        //        int dayPrice = days[i];

        //        prices.TryPeek(out int previousPrice);
                
        //        if (dayPrice < previousPrice)
        //        {
        //            arrayOut[i] = prices.Pop();
        //        }

        //        prices.Push();    

        //    }

        //    return arrayOut;
        //}
    }

    public static class Extentions
    {
        public static string PreviewArrayAsString(this int[] intArray)
        {
            string output = string.Empty;
            foreach (int i in intArray)
            {
                output = output + $"{i}, ";
            }

            return $"{{{output.Substring(0, output.Length - 2)}}}";
        }
    }

}
