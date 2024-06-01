using System.Collections.Generic;

public class HeroCardModel
{
    private string heroCardId;
    private HeroController hero;
    private List<ItemController> items;
    private int speed;
    private int might;
    private int damage;

    public string GetHeroCardId() { return heroCardId; }
    public void SetHeroCardId(string value) { heroCardId = value; }

    public HeroController GetHero() { return hero; }
    public void SetHero(HeroController value) { hero = value; }

    public List<ItemController> GetItems() { return items; }
    public void SetItems(List<ItemController> value) { items = value; }

    public int GetSpeed() { return speed; }
    public void SetSpeed(int value) { speed = value; }

    public int GetMight() { return might; }
    public void SetMight(int value) { might = value; }

    public int GetDamage() { return damage; }
    public void SetDamage(int value) { damage = value; }

    public void CalculateStats()
    {
        speed = hero.GetSpeed();
        might = hero.GetMight();
        damage = hero.GetDamage();

        foreach (ItemController item in items)
        {
            speed += item.GetSpeedModifier();
            might += item.GetMightModifier();
            damage += item.GetDamageModifier();
        }
    }
}
