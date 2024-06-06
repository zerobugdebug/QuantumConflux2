using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class CardModel
{
    // Private fields for card properties with public properties for access
    [SerializeField] private int id;
    [SerializeField] private int speed;
    [SerializeField] private int might;
    [SerializeField] private int damage;
    //[SerializeField] private List<string> abilities;
    //[SerializeField] private int level;
    //[SerializeField] private int maxLevel;
    //[SerializeField] private string clan;
    //[SerializeField] private string bonus;
    //[SerializeField] private Sprite portrait;
    [SerializeField] private int pillz = 0;
    [SerializeField] private bool pillzAssigned = false;
    //[SerializeField] private Sprite clanLogo;
    private HeroController hero;
    private List<ItemController> items;

    //TODO: Replace public properties with the logical functions for the access
    //public int Id { get => id; private set => id = value; }
    //public int Speed { get => speed; private set => speed = value; }
    //public int Might { get => might; private set => might = value; }
    //public int Damage { get => damage; private set => damage = value; }
    //public int Pillz { get => pillz; private set => pillz = value; }

    public int GetId() { return id; }
    public void SetId(int value) { id = value; }

    public HeroController GetHero() { return hero; }
    public void SetHero(HeroController value) { hero = value; }

    public string GetName() { return hero.GetFullHeroName(); }

    public List<ItemController> GetItems() { return items; }
    public void SetItems(List<ItemController> value) { items = value; }

    public int GetSpeed() { return speed; }
    public void SetSpeed(int value) { speed = value; }

    public int GetMight() { return might; }
    public void SetMight(int value) { might = value; }

    public int GetDamage() { return damage; }
    public void SetDamage(int value) { damage = value; }

    //public Sprite ClanLogo { get => clanLogo; private set => clanLogo = value; }

    public int GetPillz() { return pillz; }
    public void SetPillz(int value)
    {
        pillz = value;
        pillzAssigned = true;
    }
    public bool IsPillzAssigned()
    {
        return pillzAssigned;
    }

    //public void SetClanLogo(Sprite clanLogo)
    //{
    //    this.clanLogo = clanLogo;
    //}

    //public void SetPortrait(Sprite portrait)
    //{
    //    this.portrait = portrait;
    //}

    // Constructor for easy initialization
    public CardModel(
        int id,
        int speed,
        int might,
        int damage,
        int pillz,
        HeroController hero,
        List<ItemController> items
    )
    {
        this.id = id;
        this.speed = speed;
        this.might = might;
        this.damage = damage;
        this.pillz = pillz;
        this.hero = hero;
        this.items = items;
    }

    public CardModel Clone()
    {
        List<ItemController> itemsClone = new();

        foreach (ItemController item in items)
        {
            itemsClone.Add(item.Clone());
        }

        return new CardModel(
             id,
         speed,
         might,
         damage,
         pillz,
        hero.Clone(),

       itemsClone);
    }
}
