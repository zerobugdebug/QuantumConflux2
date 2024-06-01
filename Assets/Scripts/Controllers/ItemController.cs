public enum Rarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}

public enum ItemCategory
{
    Visor,
    Helmet,
    Necklace,
    Pendant,
    // Add other categories as needed
}

public class ItemController
{
    private ItemModel itemModel;
    private ItemView itemView;

    public ItemController(ItemModel model, ItemView view)
    {
        itemModel = model;
        itemView = view;
    }

    public void UpdateItemInfo(string id, string name, Rarity rarity, ItemCategory category, int speedModifier, int mightModifier, int damageModifier, SlotModel slot)
    {
        itemModel.SetItemId(id);
        itemModel.SetItemName(name);
        itemModel.SetRarity(rarity);
        itemModel.SetCategory(category);
        itemModel.SetSpeedModifier(speedModifier);
        itemModel.SetMightModifier(mightModifier);
        itemModel.SetDamageModifier(damageModifier);
        itemModel.SetSlot(slot);
        itemView.DisplayItemInfo(itemModel);
        itemView.DisplayItemModifiers(itemModel);
    }

    public int GetSpeedModifier()
    {
        return itemModel.GetSpeedModifier();
    }

    public int GetMightModifier()
    {
        return itemModel.GetMightModifier();
    }

    public int GetDamageModifier()
    {
        return itemModel.GetDamageModifier();
    }

    public void DisplayItem()
    {
        itemView.DisplayItemInfo(itemModel);
        itemView.DisplayItemModifiers(itemModel);
    }
}
