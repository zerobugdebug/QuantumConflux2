using System.Collections.Generic;

public class ItemDB
{
    public List<ItemModel> Items { get; private set; }

    public void SetItems(List<ItemModel> items)
    {
        Items = items;
    }

    public ItemModel GetItemById(string id)
    {
        return Items.Find(item => item.GetId() == id);
    }
}
