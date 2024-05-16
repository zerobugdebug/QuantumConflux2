using UnityEngine;
using TMPro;

public class PlayerStatsView : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI chargesText;

    public void UpdatePlayerStats(int health, int charges)
    {
        healthText.text = "Health: " + health.ToString();
        chargesText.text = "Pillz: " + charges.ToString();
    }
}