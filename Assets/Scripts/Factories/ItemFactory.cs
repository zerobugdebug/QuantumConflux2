using UnityEngine;

public class ItemFactory
{
    public ItemController CreateItem(string itemId, string itemName, Rarity rarity, ItemCategory category, int speedModifier, int mightModifier, int damageModifier)
    {
        ItemModel itemModel = new(itemId, itemName, rarity, category, speedModifier, mightModifier, damageModifier);
        ItemView itemView = new GameObject().AddComponent<ItemView>();
        return new ItemController(itemModel, itemView);
    }
}
