public class HeroCardModel
{
    private string heroCardId;
    private HeroController hero;
    private RoleController role;
    private int speed;
    private int might;
    private int damage;
    private int pillz = 0;
    private bool pillzAssigned = false;

    public HeroCardModel(string heroCardId, HeroController hero, RoleController role)
    {
        this.heroCardId = heroCardId;
        this.hero = hero;
        this.role = role;
        speed = 0;
        might = 0;
        damage = 0;
        pillz = 0;
        pillzAssigned = false;
    }

    public string GetHeroCardId() { return heroCardId; }
    public void SetHeroCardId(string value) { heroCardId = value; }

    public HeroController GetHero() { return hero; }
    public void SetHero(HeroController value) { hero = value; }

    public RoleController GetRole() { return role; }
    public void SetRole(RoleController value) { role = value; }

    public string GetName() { return $"{hero.GetName()} [{role.GetName()}]"; }

    public int GetSpeed() { return speed; }
    public void SetSpeed(int value) { speed = value; }

    public int GetMight() { return might; }
    public void SetMight(int value) { might = value; }

    public int GetDamage() { return damage; }
    public void SetDamage(int value) { damage = value; }

    public void CalculateStats()
    {
        speed = hero.GetSpeed() + role.GetSpeed();
        might = hero.GetMight() + role.GetMight();
        damage = hero.GetDamage() + role.GetDamage();
    }
}
