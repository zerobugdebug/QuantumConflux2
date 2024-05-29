using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardView : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI powerText;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI abilitiesText;
    [SerializeField] private TextMeshProUGUI bonusText;
    [SerializeField] private Image portraitImage;
    [SerializeField] private Image highlightOverlay;  // New overlay for highlighting
    [SerializeField] private Image clanLogoImage;

    private CardModel cardModel;
    private CardController cardController;

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
        levelText.text = $"{this.cardModel.Level}";
        abilitiesText.text = this.cardModel.Abilities[0];
        bonusText.text = this.cardModel.Bonus;
        clanLogoImage.sprite = this.cardModel.ClanLogo;
        portraitImage.sprite = this.cardModel.Portrait;
    }

    public void SetCardController(CardController cardController)
    {
        this.cardController = cardController;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        cardController.OnCardClicked();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    public void HighlightCard(bool highlight)
    {
        if (highlightOverlay != null)
        {
            highlightOverlay.enabled = highlight;
        }
    }

    public void MoveCardUp(bool moveUp)
    {
        transform.localPosition += moveUp ? new Vector3(0, 100, 0) : new Vector3(0, -100, 0);
    }
}
