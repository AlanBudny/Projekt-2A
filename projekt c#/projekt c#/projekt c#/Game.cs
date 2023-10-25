using System;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        Player player = new Player("player");
        Weapon sword = new Weapon("Sword", 50, 10);
        Weapon bow = new Weapon("Bow", 75, 20);
        Weapon staff = new Weapon("Staff", 60, 15);
        Potion healthPotion = new Potion("Health Potion", 20, 30);
        Item Sword = new Item("Sword", 50, 15, 0);
        Item Bow = new Item("Bow", 75, 20, 0);
        Item Staff = new Item("Staff", 60, 10, 0);
        Item healthpotion = new Item("Health Potion", 20, 0, 30);

        List<Item> shopItems = new List<Item> { Sword, Bow, Staff, healthpotion };
        List<Weapon> shopWeapon = new List<Weapon> { sword, bow, staff };

        Console.WriteLine("Welcome to the RPG Game!");

        while (player.IsAlive())
        {

            player.PrintInventory();
            Console.WriteLine($"Gold: {player.Gold}");
            Console.WriteLine($"Level: {player.Level}, Experience: {player.Experience}");
            Console.WriteLine($"Health: {player.Health}/{player.MaxHealth}, Mana: {player.Mana}/100");

            Console.WriteLine("\n--- Shop ---");
            for (int i = 0; i < shopWeapon.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Buy {shopItems[i].Name} (+{shopItems[i].DamageBonus} Damage) for {shopItems[i].Price} gold");
            }
            Console.WriteLine($"4 Buy health potion (Heal 30 hp) for 20 gold");
            Console.WriteLine("0. Continue the adventure");

            int shopChoice = int.Parse(Console.ReadLine());

            if (shopChoice == 0)
            {
                Enemy enemy = Enemy.GetRandomEnemy(player.Level);
                Console.WriteLine($"\nYou encounter a Level {enemy.Level} {enemy.Name}!");

                while (enemy.IsAlive() && player.IsAlive())
                {
                    Console.Clear();

                    Console.WriteLine($"{player.Name} - Health: {player.Health}/{player.MaxHealth}, Mana: {player.Mana}/100");
                    Console.WriteLine($"{enemy.Name} - Health: {enemy.Health}");

                    Console.WriteLine("\nSelect an attack type:");
                    Console.WriteLine("1. Normal Attack");
                    Console.WriteLine("2. Special Attack (requires mana)");
                    Console.WriteLine("3. Heal (requires health potion");

                    int attackChoice = int.Parse(Console.ReadLine());

                    if (attackChoice == 1)
                    {

                        int playerDamage = player.Damage + new Random().Next(-5, 6);
                        player.Attack(enemy);
                        Console.WriteLine($"{player.Name} deals {playerDamage} damage to {enemy.Name}");
                    }
                    else if (attackChoice == 2)
                    {
                        if (player.Mana >= 30)
                        {
                            int specialDamage = player.Damage + 30; 
                            player.UseSpecialAttack(enemy);
                            Console.WriteLine($"{player.Name} uses a special attack and deals {specialDamage} damage to {enemy.Name}");
                        }
                        else
                        {
                            Console.WriteLine("Not enough mana to use a special attack.");
                        }
                    }
                    else if (attackChoice == 3)
                    {
                        player.UsePotion(healthPotion);
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                    }

                    if (enemy.IsAlive())
                    {

                        int enemyDamage = enemy.Damage + new Random().Next(-5, 6);
                        enemy.Attack(player);
                        Console.WriteLine($"{enemy.Name} deals {enemyDamage} damage to {player.Name}");
                    }

                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }

                if (!enemy.IsAlive())
                {
                    int goldReward = enemy.Level * 10;
                    player.Gold += goldReward;
                    Console.WriteLine($"You defeated {enemy.Name} and earned {goldReward} gold!");
                }
            }
            else if (shopChoice > 0 && shopChoice < 4 && shopChoice <= shopItems.Count)
            {
                player.BuyWeapon(shopWeapon[shopChoice - 1]);
            }
            else
            {
                player.BuyPotion(healthPotion);
            }
        }

        Console.WriteLine("Game Over!");
    }
}
