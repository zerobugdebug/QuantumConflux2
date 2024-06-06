
using System.Collections.Generic;
using UnityEngine;

public class SlotFactory
{
    public SlotController CreateSlot(string slotId, string slotName, List<ItemCategory> allowedCategories, ItemController item)
    {
        SlotView slotView = new GameObject().AddComponent<SlotView>();
        SlotModel slotModel = new(slotId, slotName, allowedCategories, item);
        return new SlotController(slotModel, slotView);
    }
}
