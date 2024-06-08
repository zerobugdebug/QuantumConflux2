using System.Collections.Generic;

public class HeroCardDB
{
    public List<HeroCardModel> HeroCards { get; private set; }

    public void SetHeroCards(List<HeroCardModel> heroCards)
    {
        HeroCards = heroCards;
    }

    public HeroCardModel GetHeroCardById(string id)
    {
        return HeroCards.Find(heroCard => heroCard.GetId() == id);
    }
}
