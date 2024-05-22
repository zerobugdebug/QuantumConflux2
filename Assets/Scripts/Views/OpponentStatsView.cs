using TMPro;
using UnityEngine;

public class OpponentStatsView : MonoBehaviour
{
    public TextMeshProUGUI lifePointsText;
    public TextMeshProUGUI pillzText;

    public void UpdateView(int lifePoints, int pillz)
    {
        lifePointsText.text = "Health: " + lifePoints.ToString();
        pillzText.text = "Charges: " + pillz.ToString();
    }
}