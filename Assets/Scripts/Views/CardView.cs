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
    public Image portraitImage;  // Reference to the Image component

    private CardModel card;  // Field to hold the corresponding model for the Card

    // Property to access the CardModel
    public CardModel Card
    {
        get { return card; }
    }

    public void UpdateView(CardModel card)
    {
        if (card == null)
        {
            Debug.LogError("CardModel is null");
            return;
        }

        this.card = card;  // Set the CardModel

        nameText.text = card.Name;
        powerText.text = card.Power.ToString();
        damageText.text = card.Damage.ToString();
        levelText.text = $"Level: {card.Level}/{card.MaxLevel}";
        clanText.text = card.Clan;
        bonusText.text = card.Bonus;
        portraitImage.sprite = card.Portrait;  // Update the portrait image
    }
}
