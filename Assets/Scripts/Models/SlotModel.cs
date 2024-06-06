using System.Collections.Generic;

public class SlotModel
{
    private string slotId;
    private string slotName;
    private List<ItemCategory> allowedCategories;
    private ItemController item;

    public SlotModel(string slotId, string slotName, List<ItemCategory> allowedCategories, ItemController item = null)
    {
        this.slotId = slotId;
        this.slotName = slotName;
        this.allowedCategories = allowedCategories;
        this.item = item;
    }

    public string GetSlotId() { return slotId; }
    public void SetSlotId(string value) { slotId = value; }

    public string GetSlotName() { return slotName; }
    public void SetSlotName(string value) { slotName = value; }

    public List<ItemCategory> GetAllowedCategories() { return allowedCategories; }
    public void SetAllowedCategories(List<ItemCategory> value) { allowedCategories = value; }

    public ItemController GetItem() { return item; }
    public void SetItem(ItemController value) { item = value; }
}
