using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldOfCodeCraft
{
    class Program
    {
        static void Main(string[] args)
        {
            var temp = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                temp.Add(double.Parse(Console.ReadLine()));
            }

            double minTemp = 100;//слагаме възможно най високата темп
            double maxtemp = -100;
            int daysminustemp = 0;
            for (int i = 0; i < 10; i++)
            {
                if (temp[i] < minTemp)
                {
                    minTemp = temp[i];
                }
                if (temp[i] > maxtemp)
                {
                    maxtemp = temp[i];
                }
                if (temp[i] < 0)
                {
                    daysminustemp++;
                }
            }
            if ((minTemp >= -10) && (maxtemp <= 45) && (daysminustemp <5))
            {
                Console.WriteLine($"The lowest temperature is {minTemp:f1} degrees. The coders are off to battle!");
            }
            else
            {
                Console.WriteLine($"The lowest temperature is {minTemp:f1} degrees. The coders rest.");
            }
        }
    }
}
