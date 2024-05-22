using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardView : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private readonly TextMeshProUGUI nameText;
    [SerializeField] private readonly TextMeshProUGUI powerText;
    [SerializeField] private readonly TextMeshProUGUI damageText;
    [SerializeField] private readonly TextMeshProUGUI levelText;
    [SerializeField] private readonly TextMeshProUGUI clanText;
    [SerializeField] private readonly TextMeshProUGUI bonusText;
    [SerializeField] private readonly Image portraitImage;

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
