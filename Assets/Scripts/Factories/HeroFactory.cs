
using UnityEngine;

public class HeroFactory
{
    public HeroController CreateHero(int id, string name, Rarity rarity, int speed, int might, int damage, TraitController trait)
    {
        HeroModel heroModel = new(id, name, rarity, speed, might, damage, trait);
        HeroView heroView = new GameObject().AddComponent<HeroView>();
        return new HeroController(heroModel, heroView);
    }
}
