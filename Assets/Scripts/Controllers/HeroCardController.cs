using System;
using UnityEngine;

public class HeroCardController
{
    private HeroCardModel heroCardModel;
    private HeroCardView heroCardView;

    private GameObject heroCardPrefab;

    public event Action<HeroCardController> HeroCardClicked;

    public bool IsPlayed { get; set; } = false;

    public HeroCardController(HeroCardModel model, HeroCardView view)
    {
        heroCardModel = model;
        heroCardView = view;
    }

    public void UpdateHero(HeroController hero)
    {
        heroCardModel.SetHero(hero);
        heroCardModel.CalculateStats();
        heroCardView.DisplayHeroCardStats(heroCardModel);
    }

    //public void AddItem(ItemController item)
    //{
    //    List<ItemController> items = heroCardModel.GetItems();
    //    items.Add(item);
    //    heroCardModel.SetItems(items);
    //    heroCardModel.CalculateStats();
    //    heroCardView.DisplayItems(items);
    //}

    //public void RemoveItem(ItemController item)
    //{
    //    List<ItemController> items = heroCardModel.GetItems();
    //    _ = items.Remove(item);
    //    heroCardModel.SetItems(items);
    //    heroCardModel.CalculateStats();
    //    heroCardView.DisplayItems(items);
    //}

    public void DisplayHeroCard()
    {
        heroCardView.DisplayHeroCardInfo(heroCardModel);
        heroCardView.DisplayHeroCardStats(heroCardModel);
        heroCardView.DisplayHero(heroCardModel.GetHero());
        //heroCardView.DisplayItems(heroCardModel.GetItems());
    }

    public string GetName()
    {
        return heroCardModel.GetName();
    }

    // Method called when the card is clicked
    public void OnHeroCardClicked()
    {
        if (!IsPlayed)
        {
            HeroCardClicked?.Invoke(this); // Raise event
        }
        else
        {
            Debug.Log("Cannot interact with this hero card.");
        }
    }

    public void Initialize(HeroCardModel heroCardModel, GameObject heroCardPrefab)
    {
        this.heroCardModel = heroCardModel;
        this.heroCardPrefab = heroCardPrefab;
    }

    public void CreateTooltip(GameObject parent, string childName, string text)
    {
        Transform transform = parent.transform.Find(childName);
        if (!transform.gameObject.TryGetComponent(out TooltipController tooltip))
        {
            tooltip = transform.gameObject.AddComponent<TooltipController>();
            tooltip.SetPrefab(Resources.Load<GameObject>("Prefabs/Tooltip"));
        }
        TooltipModel tooltipModel = new(text);
        tooltip.Initialize(tooltipModel);
    }
}
