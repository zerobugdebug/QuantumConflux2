using System.Collections.Generic;

public class SlotModel
{
    private string slotId;
    private string slotName;
    private List<ItemCategory> allowedCategories;

    public string GetSlotId() { return slotId; }
    public void SetSlotId(string value) { slotId = value; }

    public string GetSlotName() { return slotName; }
    public void SetSlotName(string value) { slotName = value; }

    public List<ItemCategory> GetAllowedCategories() { return allowedCategories; }
    public void SetAllowedCategories(List<ItemCategory> value) { allowedCategories = value; }
}
