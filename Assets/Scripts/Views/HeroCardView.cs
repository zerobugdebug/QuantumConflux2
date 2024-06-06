using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HeroCardView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mightText;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private Image slot1Image;
    [SerializeField] private Image slot2Image;
    [SerializeField] private Image slot3Image;

    private HeroCardController heroCard;

    private RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void UpdateView(HeroCardModel heroCardModel)
    {
        if (heroCardModel == null)
        {
            Debug.LogError("heroCardModel is null");
            return;
        }

        // this.cardModel = cardModel;
        mightText.text = heroCardModel.GetMight().ToString();
        damageText.text = heroCardModel.GetDamage().ToString();
        speedText.text = heroCardModel.GetSpeed().ToString();

    }

    public void SetHeroCardController(HeroCardController heroCard)
    {
        this.heroCard = heroCard;
    }

    public void DisplayHeroCardInfo(HeroCardModel heroCardModel)
    {
        // Code to display hero card information in the UI
    }

    public void DisplayHeroCardStats(HeroCardModel heroCardModel)
    {
        // Code to display hero card stats in the UI
    }

    public void DisplayHero(HeroController hero)
    {
        // Code to display hero information in the UI
    }

    public void DisplayItems(List<ItemController> items)
    {
        // Code to display items in the UI
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
