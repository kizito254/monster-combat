using System;

namespace MonsterCombat
{
    class Monster
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }

        public void Attack(Monster other)
        {
            other.Health -= AttackPower;
            Console.WriteLine($"{Name} attacks {other.Name} for {AttackPower} damage!");
        }

        public void Defend(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} defends against {damage} damage!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Monster[] monsters = {
                new Monster { Name = "Goblin", Health = 100, AttackPower = 15 },
                new Monster { Name = "Skeleton", Health = 75, AttackPower = 20 },
                new Monster { Name = "Zombie", Health = 50, AttackPower = 25 }
            };

            Console.WriteLine("Choose a monster to fight:");
            for (int i = 0; i < monsters.Length; i++)
            {
                Console.WriteLine($"{i + 1}: {monsters[i].Name} (Health: {monsters[i].Health}, Attack Power: {monsters[i].AttackPower})");
            }

            int choice = int.Parse(Console.ReadLine()) - 1;
            Monster enemy = monsters[choice];

            Console.WriteLine($"You have chosen to fight the {enemy.Name}!");

            Monster player = new Monster { Name = "Player", Health = 100, AttackPower = 10 };

            while (player.Health > 0 && enemy.Health > 0)
            {
                Console.WriteLine($"{player.Name}'s turn! (Health: {player.Health}, Attack Power: {player.AttackPower})");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Defend");
                int action = int.Parse(console.ReadLine());

                if (action == 1)
                {
                    player.Attack(enemy);
                }
                else
                {
                    player.Defend(5);
                }

                if (enemy.Health > 0)
                {
                    Console.WriteLine($"{enemy.Name}'s turn! (Health: {enemy.Health}, Attack Power: {enemy.AttackPower})");
                    enemy.Attack(player);
                }
            }

            if (player.Health > 0)
            {
                Console.WriteLine($"{player.Name} wins!");
            }
            else
            {
                Console.WriteLine($"{enemy.Name} wins!");
            }
        }
    }
}

