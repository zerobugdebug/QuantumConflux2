using TMPro;
using UnityEngine;

public class CharacterStatsView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI lifePointsText;
    [SerializeField] private TextMeshProUGUI pillzText;
    [SerializeField] private TextMeshProUGUI nameText;

    public void UpdateView(int lifePoints, int pillz)
    {
        lifePointsText.text = "Health: " + lifePoints.ToString();
        pillzText.text = "Charges: " + pillz.ToString();

    }

    public void Initialize(string name)
    {
        nameText.text = name;

    }
}
