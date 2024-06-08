using System.Collections.Generic;

public class SlotDB
{
    public List<SlotModel> Slots { get; private set; }

    public void SetSlots(List<SlotModel> slots)
    {
        Slots = slots;
    }

    public SlotModel GetSlotById(string id)
    {
        return Slots.Find(slot => slot.GetId() == id);
    }
}
