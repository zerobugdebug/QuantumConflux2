using UnityEngine;

public class ItemFactory
{
    public ItemController CreateItem(string id, string name, Rarity rarity, ItemCategory category, int speedModifier, int mightModifier, int damageModifier)
    {
        ItemModel itemModel = new(id, name, rarity, category, speedModifier, mightModifier, damageModifier);
        ItemView itemView = new GameObject().AddComponent<ItemView>();
        return new ItemController(itemModel, itemView);
    }
}
