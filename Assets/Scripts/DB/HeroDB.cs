using System.Collections.Generic;

public class HeroDB
{
    public List<HeroModel> Heroes { get; private set; }

    public void SetHeroes(List<HeroModel> heroes)
    {
        Heroes = heroes;
    }

    public HeroModel GetHeroById(string id)
    {
        return Heroes.Find(hero => hero.GetId() == id);
    }
}
