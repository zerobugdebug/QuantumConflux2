using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI clanText;
    public TextMeshProUGUI bonusText;
    public Image portraitImage;  // Add a reference to the Image component

    public void UpdateView(CardModel cardModel)
    {
        if (cardModel == null)
        {
            Debug.LogError("CardModel is null");
            return;
        }

        nameText.text = cardModel.Name;
        powerText.text = cardModel.Power.ToString();
        damageText.text = cardModel.Damage.ToString();
        levelText.text = $"Level: {cardModel.Level}/{cardModel.MaxLevel}";
        clanText.text = cardModel.Clan;
        bonusText.text = cardModel.Bonus;
        portraitImage.sprite = cardModel.Portrait;  // Update the portrait image
    }
}
