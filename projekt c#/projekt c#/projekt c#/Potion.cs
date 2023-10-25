class Potion
{
    public string Name { get; set; }
    public int Price { get; set; }
    public int HealingAmount { get; set; }

    public Potion(string name, int price, int healingAmount)
    {
        Name = name;
        Price = price;
        HealingAmount = healingAmount;
    }
}
