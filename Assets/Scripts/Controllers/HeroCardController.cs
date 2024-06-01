using System.Collections.Generic;

public class HeroCardController
{
    private HeroCardModel heroCardModel;
    private HeroCardView heroCardView;

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

    public void AddItem(ItemController item)
    {
        List<ItemController> items = heroCardModel.GetItems();
        items.Add(item);
        heroCardModel.SetItems(items);
        heroCardModel.CalculateStats();
        heroCardView.DisplayItems(items);
    }

    public void RemoveItem(ItemController item)
    {
        List<ItemController> items = heroCardModel.GetItems();
        _ = items.Remove(item);
        heroCardModel.SetItems(items);
        heroCardModel.CalculateStats();
        heroCardView.DisplayItems(items);
    }

    public void DisplayHeroCard()
    {
        heroCardView.DisplayHeroCardInfo(heroCardModel);
        heroCardView.DisplayHeroCardStats(heroCardModel);
        heroCardView.DisplayHero(heroCardModel.GetHero());
        heroCardView.DisplayItems(heroCardModel.GetItems());
    }
}
