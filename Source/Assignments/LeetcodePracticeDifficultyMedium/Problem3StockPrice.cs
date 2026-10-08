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


        public int[] FindNextDiscounted(int day)
        {
            int nextDiscountedOffering = -1;
            int dayPrice = WeekyPrices[day];

            Stack<int> days = new Stack<int>();
            int[] output = new int[WeekyPrices.Count()];

            for (int i = day; i < WeekyPrices.Count() ; i++)
            {
                int currentDayPrice = WeekyPrices[i];

                bool peakResult = days.TryPeek(out int result);
                if (currentDayPrice < result)
                {
                    output[i] = days.Pop();
                }

                days.Push(currentDayPrice);
            }

            return output;
        }
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
