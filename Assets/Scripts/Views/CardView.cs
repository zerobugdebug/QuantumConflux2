using UnityEngine;
using TMPro;

public class CardView : MonoBehaviour
{
    public TextMeshProUGUI cardNameText;
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI abilityText;
    public TextMeshProUGUI clanText;

    public void SetCardData(CardModel cardData)
    {
        cardNameText.text = cardData.cardName;
        powerText.text = "Power: " + cardData.power.ToString();
        damageText.text = "Damage: " + cardData.damage.ToString();
        abilityText.text = "Ability: " + cardData.ability;
        clanText.text = "Clan: " + cardData.clan;
    }
}