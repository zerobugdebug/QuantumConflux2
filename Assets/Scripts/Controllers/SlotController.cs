using System.Collections.Generic;

public class SlotController
{
    private SlotModel slotModel;
    private SlotView slotView;

    public SlotController(SlotModel model, SlotView view)
    {
        slotModel = model;
        slotView = view;
    }

    public void UpdateSlotInfo(string id, string name, List<ItemCategory> categories)
    {
        slotModel.SetSlotId(id);
        slotModel.SetSlotName(name);
        slotModel.SetAllowedCategories(categories);
        slotView.DisplaySlotInfo(slotModel);
        slotView.DisplayAllowedCategories(categories);
    }

    public void DisplaySlot()
    {
        slotView.DisplaySlotInfo(slotModel);
        slotView.DisplayAllowedCategories(slotModel.GetAllowedCategories());
    }
}
