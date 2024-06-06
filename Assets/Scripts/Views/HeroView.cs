using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI traitText;
    [SerializeField] private Image portraitImage;

    public void DisplayHeroInfo(HeroModel heroModel)
    {
        // Code to display hero information in the UI
    }

    public void DisplayHeroStats(HeroModel heroModel)
    {
        // Code to display hero stats in the UI
    }

    public void DisplayHeroTrait(TraitController trait)
    {
        // Code to display hero trait in the UI
    }

    public void DisplayHeroRole(RoleController role)
    {
        // Code to display hero role in the UI
    }
}
