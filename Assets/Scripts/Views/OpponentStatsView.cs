using UnityEngine;
using TMPro;

public class OpponentStatsView : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI chargesText;

    public void UpdateOpponentStats(int health, int charges)
    {
        healthText.text = "Health: " + health.ToString();
        chargesText.text = "Pillz: " + charges.ToString();
    }
}