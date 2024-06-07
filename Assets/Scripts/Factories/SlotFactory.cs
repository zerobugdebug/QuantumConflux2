
using System.Collections.Generic;
using UnityEngine;

public class SlotFactory
{
    public SlotController CreateSlot(string id, string name, List<ItemCategory> allowedCategories, ItemController item)
    {
        SlotView slotView = new GameObject().AddComponent<SlotView>();
        SlotModel slotModel = new(id, name, allowedCategories, item);
        return new SlotController(slotModel, slotView);
    }
}
