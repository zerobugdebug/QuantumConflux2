using UnityEngine;

public class HeroCardFactory
{
    public HeroCardController CreateHeroCard(string heroCardId, HeroController hero, RoleController role, int heroSpeed, int heroMight, int heroDamage)
    {
        HeroCardModel heroCardModel = new(heroCardId, hero, role, heroSpeed, heroMight, heroDamage);
        HeroCardView heroCardView = new GameObject().AddComponent<HeroCardView>();
        return new HeroCardController(heroCardModel, heroCardView);
    }
}
