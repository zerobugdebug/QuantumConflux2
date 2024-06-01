public class HeroModel
{
    private string heroId;
    private string heroName;
    private Rarity rarity;
    private TraitController trait;
    private RoleController role;
    private int speed;
    private int might;
    private int damage;

    public string GetHeroId() { return heroId; }
    public void SetHeroId(string value) { heroId = value; }

    public string GetHeroName() { return heroName; }
    public void SetHeroName(string value) { heroName = value; }

    public Rarity GetRarity() { return rarity; }
    public void SetRarity(Rarity value) { rarity = value; }

    public TraitController GetTrait() { return trait; }
    public void SetTrait(TraitController value) { trait = value; }

    public RoleController GetRole() { return role; }
    public void SetRole(RoleController value) { role = value; }

    public int GetSpeed() { return speed; }
    public void SetSpeed(int value) { speed = value; }

    public int GetMight() { return might; }
    public void SetMight(int value) { might = value; }

    public int GetDamage() { return damage; }
    public void SetDamage(int value) { damage = value; }
}
