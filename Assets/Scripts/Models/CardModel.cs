using System.Collections.Generic;
using UnityEngine;

public class CardModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Power { get; set; }
    public int Damage { get; set; }
    public List<string> Abilities { get; set; }
    public int Level { get; set; } // Represents the card's current level
    public int MaxLevel { get; set; } // Represents the card's maximum level
    public string Clan { get; set; } // Represents the card's clan affiliation
    public string Bonus { get; set; } // Represents the card's clan bonus
    public Sprite Portrait { get; set; } // Represents the card's portrait image
    public int Pillz { get; set; }

    // Constructor for easy initialization
    public CardModel(
        int id,
        string name,
        int power,
        int damage,
        List<string> abilities,
        int level,
        int maxLevel,
        string clan,
        string bonus,
        Sprite portrait,
        int pillz
    )
    {
        Id = id;
        Name = name;
        Power = power;
        Damage = damage;
        Abilities = abilities;
        Level = level;
        MaxLevel = maxLevel;
        Clan = clan;
        Bonus = bonus;
        Portrait = portrait;
        Pillz = pillz;
    }
}
