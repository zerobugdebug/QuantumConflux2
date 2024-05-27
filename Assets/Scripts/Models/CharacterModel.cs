using UnityEngine;

public class CharacterModel
{
    private int lifePoints;
    private int pillz;
    private string name;

    public CharacterModel()
    {
        lifePoints = 12;  // Default life points
        pillz = 12;  // Default Pillz
        name = "Player";
    }

    // Method to add life points
    public int AddLifePoints(int amount)
    {
        if (amount > 0)
        {
            lifePoints += amount;
        }
        return lifePoints;
    }

    // Method to remove life points, ensuring they do not go below 0
    public int RemoveLifePoints(int amount)
    {
        if (amount > 0)
        {
            lifePoints = Mathf.Max(lifePoints - amount, 0);
        }
        return lifePoints;
    }

    // Method to add pillz
    public void AddPillz(int amount)
    {
        if (amount > 0)
        {
            pillz += amount;
        }
    }

    // Method to remove pillz, ensuring they do not go below 0
    public void RemovePillz(int amount)
    {
        if (amount > 0)
        {
            pillz = Mathf.Max(pillz - amount, 0);
        }
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public string GetName()
    {
        return name;
    }

    public int GetPillz()
    {
        return pillz;
    }

    internal int GetLifePoints()
    {
        return lifePoints;
    }
}