using System;
using System.Collections.Generic;

class Player : Character
{
    public List<Weapon> Weapons { get; set; }
    public List<Potion> Potions { get; set; }

    public Player(string name) : base(name, 1, 0, 100, 10)
    {
        Weapons = new List<Weapon>();
        Potions = new List<Potion>();
    }

    public void PrintInventory()
    {
        Console.WriteLine($"--- Inventory ---");
        Console.WriteLine("Weapons:");
        foreach (Weapon weapon in Weapons)
        {
            Console.WriteLine($"{weapon.Name} (+{weapon.DamageBonus} Damage)");
        }
        Console.WriteLine("Potions:");
        foreach (Potion potion in Potions)
        {
            Console.WriteLine($"{potion.Name} (Heals {potion.HealingAmount} HP)");
        }
    }

    public void BuyWeapon(Weapon weapon)
    {
        if (Gold >= weapon.Price)
        {
            Gold -= weapon.Price;
            Damage += weapon.DamageBonus;
            Weapons.Add(weapon);
            Console.WriteLine($"{Name} bought {weapon.Name} (+{weapon.DamageBonus} Damage) for {weapon.Price} gold.");
        }
        else
        {
            Console.WriteLine("Not enough gold to buy this weapon.");
        }
    }

    public void BuyPotion(Potion potion)
    {
        if (Gold >= potion.Price)
        {
            Gold -= potion.Price;
            Potions.Add(potion);
            Console.WriteLine($"{Name} bought {potion.Name} for {potion.Price} gold.");
        }
        else
        {
            Console.WriteLine("Not enough gold to buy this potion.");
        }
    }

    public void UsePotion(Potion potion)
    {
        if (Potions.Contains(potion))
        {
            Health += potion.HealingAmount;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
            Potions.Remove(potion);
            Console.WriteLine($"{Name} used {potion.Name} and healed {potion.HealingAmount} HP.");
        }
        else
        {
            Console.WriteLine($"{Name} does not have {potion.Name} in their inventory.");
        }
    }
}
