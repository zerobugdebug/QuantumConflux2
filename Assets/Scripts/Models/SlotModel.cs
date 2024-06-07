using System.Collections.Generic;

public class SlotModel
{
    private string id;
    private string name;
    private List<ItemCategory> allowedCategories;
    private ItemController item;

    public SlotModel(string id, string name, List<ItemCategory> allowedCategories, ItemController item = null)
    {
        this.id = id;
        this.name = name;
        this.allowedCategories = allowedCategories;
        this.item = item;
    }

    public string GetId() { return id; }
    public void SetId(string value) { id = value; }

    public string GetName() { return name; }
    public void SetName(string value) { name = value; }

    public List<ItemCategory> GetAllowedCategories() { return allowedCategories; }
    public void SetAllowedCategories(List<ItemCategory> value) { allowedCategories = value; }

    public ItemController GetItem() { return item; }
    public void SetItem(ItemController value) { item = value; }
}
