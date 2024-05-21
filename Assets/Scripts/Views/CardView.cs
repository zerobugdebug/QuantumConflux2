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

    private CardModel cardModel;

    // Method to update the view with card details
    public void UpdateView(CardModel cardModel)
    {
        if (cardModel == null)
        {
            Debug.LogError("CardModel is null");
            return;
        }

        this.cardModel = cardModel;

        nameText.text = this.cardModel.Name;
        powerText.text = this.cardModel.Power.ToString();
        damageText.text = this.cardModel.Damage.ToString();
        levelText.text = $"Level: {this.cardModel.Level}/{this.cardModel.MaxLevel}";
        clanText.text = this.cardModel.Clan;
        bonusText.text = this.cardModel.Bonus;
        portraitImage.sprite = this.cardModel.Portrait;
    }
}
