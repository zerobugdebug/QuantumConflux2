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

    private CardController cardController;

    private RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void UpdateView(CardModel cardModel)
    {
        if (cardModel == null)
        {
            Debug.LogError("CardModel is null");
            return;
        }

        // this.cardModel = cardModel;

        nameText.text = cardModel.Name;
        powerText.text = cardModel.Power.ToString();
        damageText.text = cardModel.Damage.ToString();
        levelText.text = $"{cardModel.Level}";
        abilitiesText.text = cardModel.Abilities[0];
        bonusText.text = cardModel.Bonus;
        clanLogoImage.sprite = cardModel.ClanLogo;
        portraitImage.sprite = cardModel.Portrait;

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

    public void EnlargeCard(bool enlarge, Vector3 position)
    {
        Debug.Log(rectTransform);
        if (enlarge)
        {
            rectTransform.localScale = new Vector3(1.5f, 1.5f, 1.5f); // Enlarge the card
            rectTransform.localPosition = position; // Move to specific position
        }
        else
        {
            rectTransform.localScale = Vector3.one; // Reset to normal size
            rectTransform.localPosition = Vector3.zero; // Reset to original position
        }
    }
}
