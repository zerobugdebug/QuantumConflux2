public class ItemModel
{
    private string id;
    private string name;
    private Rarity rarity;
    private ItemCategory category;
    private int speedModifier;
    private int mightModifier;
    private int damageModifier;

    public ItemModel(string id, string name, Rarity rarity, ItemCategory category, int speedModifier, int mightModifier, int damageModifier)
    {
        this.id = id;
        this.name = name;
        this.rarity = rarity;
        this.category = category;
        this.speedModifier = speedModifier;
        this.mightModifier = mightModifier;
        this.damageModifier = damageModifier;
    }

    public string GetId() { return id; }
    public void SetId(string value) { id = value; }

    public string GetName() { return name; }
    public void SetName(string value) { name = value; }

    public Rarity GetRarity() { return rarity; }
    public void SetRarity(Rarity value) { rarity = value; }

    public ItemCategory GetCategory() { return category; }
    public void SetCategory(ItemCategory value) { category = value; }

    public int GetSpeedModifier() { return speedModifier; }
    public void SetSpeedModifier(int value) { speedModifier = value; }

    public int GetMightModifier() { return mightModifier; }
    public void SetMightModifier(int value) { mightModifier = value; }

    public int GetDamageModifier() { return damageModifier; }
    public void SetDamageModifier(int value) { damageModifier = value; }
}
