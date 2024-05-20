using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI powerText;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI clanText;
    [SerializeField] private TextMeshProUGUI bonusText;
    [SerializeField] private Image portraitImage;

    private CardModel card;

    // Method to update the view with card details
    public void UpdateView(CardModel card)
    {
        if (card == null)
        {
            Debug.LogError("CardModel is null");
            return;
        }

        this.card = card;

        nameText.text = this.card.Name;
        powerText.text = this.card.Power.ToString();
        damageText.text = this.card.Damage.ToString();
        levelText.text = $"Level: {this.card.Level}/{this.card.MaxLevel}";
        clanText.text = this.card.Clan;
        bonusText.text = this.card.Bonus;
        portraitImage.sprite = this.card.Portrait;
    }
}
