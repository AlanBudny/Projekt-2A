class Item
{
    public string Name { get; set; }
    public int Price { get; set; }
    public int DamageBonus { get; set; }
    public int HealingAmount { get; set; }

    public Item(string name, int price, int damageBonus, int healingAmount)
    {
        Name = name;
        Price = price;
        DamageBonus = damageBonus;
        HealingAmount = healingAmount;
    }

    public string GetDescription()
    {
        if (DamageBonus > 0)
        {
            return $"+{DamageBonus} Damage";
        }
        else if (HealingAmount > 0)
        {
            return $"Heals {HealingAmount} HP";
        }
        return "Invalid Item";
    }
}
