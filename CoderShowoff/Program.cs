using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderShowoff
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var playersList = new List<Player>();

            long totalEndurance = 0;
            long totalStrength = 0;
            long totalIntellect = 0;

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Player player = new Player(input);
                if (!((player.Name =="")|| (player.Stamina <=0) || (player.Strength <= 0)
                    ||(player.Intellect <= 0)|| (player.Rank == '\0') || (player.Guild == "")))
                {
                    totalEndurance += player.Stamina;
                    totalStrength += player.Strength;
                    totalIntellect += player.Intellect;
                    playersList.Add(player); 
                }               
            }
            var maxStamina = playersList.Max(p => p.Stamina);
            var minStrength = playersList.Min(p => p.Strength);
            var maxIntellect = playersList.Max(p => p.Intellect);

            foreach (var item in playersList)
            {
                if (item.Stamina == maxStamina)
                {
                    Console.WriteLine($"Most endurable player is: {item.Name} with rank {item.Rank} from guild {item.Guild}");
                    break;
                } 
            }
            var strengthList = new List<Player>();
            foreach (var item in playersList)
            {
                if (item.Strength == minStrength)
                {
                    strengthList.Add(item);                   
                }
            }
            if (strengthList.Count > 0)
            {
                Console.WriteLine($"Weakest player is: {strengthList[strengthList.Count-1].Name} with rank {strengthList[strengthList.Count - 1].Rank} from guild {strengthList[strengthList.Count - 1].Guild}");
            }

            foreach (var item in playersList)
            {
                if (item.Intellect == maxIntellect)
                {
                    Console.WriteLine($"Wisest player is: {item.Name} with rank" +
                                     $" {item.Rank} from guild {item.Guild}");
                    break;
                }
            }
            Console.WriteLine($"Total Endurance {totalEndurance}");
            Console.WriteLine($"Total Strength {totalStrength}");
            Console.WriteLine($"Total Intellect {totalIntellect}");
        }
    }
    class Player
    {
        public Player(string inputData)
        {
            var input = inputData.Split('|').ToArray();
            this.Name = input[0];
            this.Stamina = int.Parse(input[1]);
            this.Strength = int.Parse(input[2]);
            this.Intellect = int.Parse(input[3]);
            this.Rank = char.Parse(input[4]);
            this.Guild = input[5];
        }
        public string Name { get; set; }
        public int Stamina { get; set; }
        public int Strength { get; set; }
        public int Intellect { get; set; }
        public char Rank { get; set; }
        public string Guild { get; set; }
    }
}
