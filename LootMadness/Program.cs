using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootMadness
{
    class Program
    {
        static void Main(string[] args)
        {
            long currentGold = int.Parse(Console.ReadLine());
            var currentHealth = decimal.Parse(Console.ReadLine());

            Dictionary<string, Armor> MartoColection = new Dictionary<string, Armor>();

            var input = Console.ReadLine();
            while (input != "NO MORE LOOT")
            {
                var data = input.Split(':').ToList();
                if (data[0] == "Gold")
                {
                    currentGold += int.Parse(data[1].Trim());
                }
                else
                {
                    //създаваме си армор
                    Armor armor = new Armor(data[0], data[1].Trim());
                    if ((armor.Quality != "Legendary") && (armor.Quality != "Rare"))
                    {
                        //продаваме ги
                        currentGold += armor.Gold;
                    }
                    else
                    {
                        //ако не съсържа този item го добавямe и 
                        if (!MartoColection.ContainsKey(armor.Name))
                        {
                            MartoColection.Add(armor.Name, armor);
                            currentHealth += armor.HealthBonus;
                        }
                        else// иначе го продаваме
                        {
                            //ако не е Legendary го продава иначе нищо не правим
                            if (!(armor.Quality == "Legendary"))
                            {
                                currentGold += armor.Gold;
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Marto has a total of {currentGold} gold.");
            Console.WriteLine($"Marto's total health is {currentHealth}.");
            Console.WriteLine("Marto has collected the following items:");
            foreach (var item in MartoColection)
            {
                Console.WriteLine($"> {item.Value.Name} [Quality: {item.Value.Quality}] [HP Bonus: {item.Value.HealthBonus}]");
            }

        }

    }
    class Armor
    {
        public Armor(string name, string additionalData)
        {
            var data = additionalData.Split(' ');
            this.Name = name;
            this.Quality = data[0];
            this.Gold = int.Parse(data[1]);
            this.HealthBonus = decimal.Parse(data[2]);
        }

        public string Name { get; set; }
        public string Quality { get; set; }
        public int Gold { get; set; }
        public decimal HealthBonus { get; set; }

    }
}
