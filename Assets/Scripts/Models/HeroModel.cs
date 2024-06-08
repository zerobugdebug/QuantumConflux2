public class HeroModel
{
    private string id;
    private string name;
    private Rarity rarity;
    private TraitController trait;
    private int speed;
    private int might;
    private int damage;

    // Constructor for easy initialization
    public HeroModel(string id, string name, Rarity rarity, int speed, int might, int damage, TraitController trait)
    {
        this.id = id;
        this.name = name;
        this.rarity = rarity;
        this.speed = speed;
        this.might = might;
        this.damage = damage;
        this.trait = trait;
    }

    public string GetId() { return id; }
    public void SetId(string value) { id = value; }

    public string GetName() { return name; }

    public void SetName(string value) { name = value; }

    public Rarity GetRarity() { return rarity; }
    public void SetRarity(Rarity value) { rarity = value; }

    public TraitController GetTrait() { return trait; }
    public void SetTrait(TraitController value) { trait = value; }

    public int GetSpeed() { return speed; }
    public void SetSpeed(int value) { speed = value; }

    public int GetMight() { return might; }
    public void SetMight(int value) { might = value; }

    public int GetDamage() { return damage; }
    public void SetDamage(int value) { damage = value; }
}
