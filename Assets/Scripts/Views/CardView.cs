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
    [SerializeField] private TextMeshProUGUI clanText;
    [SerializeField] private TextMeshProUGUI bonusText;
    [SerializeField] private Image portraitImage;

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
        levelText.text = $"{this.cardModel.Level}/{this.cardModel.MaxLevel}";
        clanText.text = this.cardModel.Clan;
        bonusText.text = this.cardModel.Bonus;
        //portraitImage.sprite = this.cardModel.Portrait;
    }

    public void SetCardController(CardController cardController)
    {
        this.cardController = cardController;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Card clicked in view");
        cardController.OnCardClicked();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Pointer Up");
    }
}
