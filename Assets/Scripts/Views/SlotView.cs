using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotView : MonoBehaviour
{
    [SerializeField] private Image slotImage;

    public void DisplaySlotInfo(SlotModel slotModel)
    {
        // Code to display slot information in the UI
    }

    public void DisplayAllowedCategories(List<ItemCategory> categories)
    {
        // Code to display allowed item categories in the UI
    }
}
