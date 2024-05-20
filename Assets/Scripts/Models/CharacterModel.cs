using System.Collections.Generic;
using UnityEngine;

public class CharacterModel
{
    public int LifePoints { get; private set; }
    public int Pillz { get; private set; }

    public CharacterModel()
    {
        LifePoints = 12;  // Default life points
        Pillz = 12;  // Default Pillz
    }

    // Method to add life points
    public void AddLifePoints(int amount)
    {
        if (amount > 0)
        {
            LifePoints += amount;
        }
    }

    // Method to remove life points, ensuring they do not go below 0
    public void RemoveLifePoints(int amount)
    {
        if (amount > 0)
        {
            LifePoints = Mathf.Max(LifePoints - amount, 0);
        }
    }

    // Method to add pillz
    public void AddPillz(int amount)
    {
        if (amount > 0)
        {
            Pillz += amount;
        }
    }

    // Method to remove pillz, ensuring they do not go below 0
    public void RemovePillz(int amount)
    {
        if (amount > 0)
        {
            Pillz = Mathf.Max(Pillz - amount, 0);
        }
    }
}
