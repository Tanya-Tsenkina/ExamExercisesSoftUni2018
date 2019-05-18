using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compass
{
    class Program
    {
        static void Main(string[] args)
        {
            Char startPosition = char.Parse(Console.ReadLine());
            Char endPosition = 'N';
            //така са последователно
            char[] allDirection = new char[] { 'N', 'E', 'S', 'W' };
            //искам да ги подредя така, че старта да ми е на първо място
            char[] OrderDirection = ReorderDirection(startPosition, allDirection);

            //Console.WriteLine(string.Join(" ", OrderDirection));

            var input = Console.ReadLine();
            var sumDegees = 0;
            while (input != "END")
            {
                sumDegees += int.Parse(input);
                input = Console.ReadLine();
            }
            
            //Ако имаме положително число 
            if ((sumDegees <= 180) && (sumDegees >= 0))
            {
                endPosition = OrderDirection[(sumDegees / 45)%OrderDirection.Length];
            }else if (sumDegees > 180){
                sumDegees = sumDegees % 180;
                endPosition = OrderDirection[(sumDegees / 45) % OrderDirection.Length];
            }
            else if ((sumDegees >= -180) && (sumDegees <= 0))
            {
                endPosition = OrderDirection[OrderDirection.Length -Math.Abs((sumDegees / 45) % OrderDirection.Length)];
            } else if(sumDegees < -180){
                sumDegees = sumDegees % 180;
                endPosition = OrderDirection[OrderDirection.Length - Math.Abs((sumDegees / 45) % OrderDirection.Length)];
            }

            Dictionary<char, string> AllWord = new Dictionary<char, string>();
            AllWord.Add('N', "North");
            AllWord.Add('E', "East");
            AllWord.Add('W', "West");
            AllWord.Add('S', "South");


            Console.WriteLine($"Starting Position: {AllWord[startPosition]}");
            Console.WriteLine($"Position After Rotating: {AllWord[endPosition]}");
        }

        static char[] ReorderDirection(char position, char[] allDirection)
        {
            var index = 0;
            char[] output = new char[4];
            for (int i = 0; i < 4; i++)
            {
                if (allDirection[i] == position)
                {
                    index = i;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                output[i] = allDirection[(i + index) % 4];
            }
            return output;
        }
    }
}
