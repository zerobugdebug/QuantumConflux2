using UnityEngine;

public class HeroCardFactory
{
    public HeroCardController CreateHeroCard(string id, HeroController hero, RoleController role)
    {
        HeroCardModel heroCardModel = new(id, hero, role);
        HeroCardView heroCardView = new GameObject().AddComponent<HeroCardView>();
        return new HeroCardController(heroCardModel, heroCardView);
    }
}
