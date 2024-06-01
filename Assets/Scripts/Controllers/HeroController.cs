public class HeroController
{
    private HeroModel heroModel;
    private HeroView heroView;

    public HeroController(HeroModel model, HeroView view)
    {
        heroModel = model;
        heroView = view;
    }

    public void UpdateHeroName(string name)
    {
        heroModel.SetHeroName(name);
        heroView.DisplayHeroInfo(heroModel);
    }

    public void UpdateHeroRarity(Rarity rarity)
    {
        heroModel.SetRarity(rarity);
        heroView.DisplayHeroInfo(heroModel);
    }

    public void UpdateHeroTrait(TraitController trait)
    {
        heroModel.SetTrait(trait);
        heroView.DisplayHeroTrait(trait);
    }

    public void UpdateHeroRole(RoleController role)
    {
        heroModel.SetRole(role);
        heroView.DisplayHeroRole(role);
    }

    public void UpdateHeroStats(int speed, int might, int damage)
    {
        heroModel.SetSpeed(speed);
        heroModel.SetMight(might);
        heroModel.SetDamage(damage);
        heroView.DisplayHeroStats(heroModel);
    }

    public int GetSpeed()
    {
        return heroModel.GetSpeed();
    }

    public int GetMight()
    {
        return heroModel.GetMight();
    }

    public int GetDamage()
    {
        return heroModel.GetDamage();
    }
}
