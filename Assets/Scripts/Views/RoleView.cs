using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoleView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI roleText;
    [SerializeField] private TextMeshProUGUI abilitiyText;

    public void DisplayRoleInfo(RoleModel roleModel)
    {
        // Code to display role information in the UI
    }

    public void DisplayRoleAbility(AbilityController ability)
    {
        // Code to display role ability in the UI
    }

    public void DisplayRoleSlots(List<SlotController> slots)
    {
        // Code to display role slots in the UI
    }
}
