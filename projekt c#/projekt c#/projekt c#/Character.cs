using System;
using System.Threading;

class Character
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
    public int Damage { get; set; }
    public int Mana { get; set; }
    public int Gold { get; set; }

    public Character(string name, int level, int experience, int health, int damage)
    {
        Name = name;
        Level = level;
        Experience = experience;
        Health = health;
        MaxHealth = health;
        Damage = damage;
        Mana = 100;
        Gold = 50;
    }

    public void Attack(Character target)
    {
        int damageDealt = Damage + new Random().Next(-5, 6);
        Console.WriteLine($"{Name} attacks {target.Name} for {damageDealt} damage!");
        target.TakeDamage(damageDealt);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0)
            Health = 0;
    }

    public bool IsAlive()
    {
        return Health > 0;
    }

    public void GainExperience(int experience)
    {
        Experience += experience;
        while (Experience >= Level * 100)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Level++;
        MaxHealth += 10;
        Health = MaxHealth;
        Damage += 5;
        Console.WriteLine($"{Name} leveled up to Level {Level}!");
    }

    public void UseSpecialAttack(Character target)
    {
        if (Mana >= 30)
        {
            int specialDamage = Damage + 30;
            Console.WriteLine($"{Name} uses a special attack on {target.Name} for {specialDamage} damage!");
            target.TakeDamage(specialDamage);
            Mana -= 30;
        }
        else
        {
            Console.WriteLine("Not enough mana to use a special attack.");
        }
    }

    public void RegenerateMana()
    {
        while (Mana < 100)
        {
            Thread.Sleep(5000);
            Mana += 5;
            if (Mana > 100)
                Mana = 100;
            Console.WriteLine($"{Name} regenerated 5 mana. Current mana: {Mana}");
        }
    }
}
