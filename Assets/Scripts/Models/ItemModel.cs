public class ItemModel
{
    private string itemId;
    private string itemName;
    private Rarity rarity;
    private ItemCategory category;
    private int speedModifier;
    private int mightModifier;
    private int damageModifier;
    private SlotModel slot;

    public string GetItemId() { return itemId; }
    public void SetItemId(string value) { itemId = value; }

    public string GetItemName() { return itemName; }
    public void SetItemName(string value) { itemName = value; }

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

    public SlotModel GetSlot() { return slot; }
    public void SetSlot(SlotModel value) { slot = value; }
}
