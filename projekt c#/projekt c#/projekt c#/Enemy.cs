using System;
using System.Collections.Generic;

class Enemy : Character
{
    public Enemy(string name, int level) : base(name, level, 0, level * 100, level * 10)
    {
    }

    public static Enemy GetRandomEnemy(int playerLevel)
    {
        Random random = new Random();
        int enemyType = random.Next(1, 4);

        switch (enemyType)
        {
            case 1:
                return new Dragon("Dragon", playerLevel);
            case 2:
                return new Goblin("Goblin", playerLevel);
            case 3:
                return new Skeleton("Skeleton", playerLevel);
            default:
                return new Dragon("Dragon", playerLevel);
        }
    }
}

class Dragon : Enemy
{
    public Dragon(string name, int level) : base(name, level)
    {
    }
}

class Goblin : Enemy
{
    public Goblin(string name, int level) : base(name, level)
    {
    }
}

class Skeleton : Enemy
{
    public Skeleton(string name, int level) : base(name, level)
    {
    }
}
