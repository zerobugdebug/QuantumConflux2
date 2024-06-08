using System.Collections.Generic;

public class AbilityDB
{
    public List<AbilityModel> Abilities { get; private set; }

    public void SetAbilities(List<AbilityModel> abilities)
    {
        Abilities = abilities;
    }

    public AbilityModel GetAbilityById(string id)
    {
        return Abilities.Find(ability => ability.GetId() == id);
    }
}
