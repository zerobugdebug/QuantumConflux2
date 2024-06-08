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
        slotModel.SetId(id);
        slotModel.SetName(name);
        slotModel.SetAllowedCategories(categories);
        slotView.DisplaySlotInfo(slotModel);
        slotView.DisplayAllowedCategories(categories);
    }

    public void DisplaySlot()
    {
        slotView.DisplaySlotInfo(slotModel);
        slotView.DisplayAllowedCategories(slotModel.GetAllowedCategories());
    }

    public ItemController GetItem() { return slotModel.GetItem(); }
    public void SetItem(ItemController value) { slotModel.SetItem(value); }
}
