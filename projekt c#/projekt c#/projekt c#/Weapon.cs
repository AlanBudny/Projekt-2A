class Weapon
{
    public string Name { get; set; }
    public int Price { get; set; }
    public int DamageBonus { get; set; }

    public Weapon(string name, int price, int damageBonus)
    {
        Name = name;
        Price = price;
        DamageBonus = damageBonus;
    }
}
