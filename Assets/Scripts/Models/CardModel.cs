using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardModel
{
    // Private fields for card properties with public properties for access
    [SerializeField] private int id;
    [SerializeField] private string name;
    [SerializeField] private int power;
    [SerializeField] private int damage;
    [SerializeField] private List<string> abilities;
    [SerializeField] private int level;
    [SerializeField] private int maxLevel;
    [SerializeField] private string clan;
    [SerializeField] private string bonus;
    [SerializeField] private Sprite portrait;
    [SerializeField] private int pillz;

    //TODO: Replace public properties with the logical functions for the access
    public int Id { get => id; private set => id = value; }
    public string Name { get => name; private set => name = value; }
    public int Power { get => power; private set => power = value; }
    public int Damage { get => damage; private set => damage = value; }
    public List<string> Abilities { get => abilities; private set => abilities = value; }
    public int Level { get => level; private set => level = value; }
    public int MaxLevel { get => maxLevel; private set => maxLevel = value; }
    public string Clan { get => clan; private set => clan = value; }
    public string Bonus { get => bonus; private set => bonus = value; }
    public Sprite Portrait { get => portrait; private set => portrait = value; }
    public int Pillz { get => pillz; private set => pillz = value; }

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
