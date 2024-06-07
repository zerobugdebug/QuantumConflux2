
using UnityEngine;

public class AbilityFactory
{
    public AbilityController CreateAbility(string id, string name, EffectController effect)
    {
        //EffectController effect = effectFactory.CreateEffect(effectId, effectName, luaScriptPath);
        AbilityModel abilityModel = new(id, name, effect);
        AbilityView abilityView = new GameObject().AddComponent<AbilityView>();
        return new AbilityController(abilityModel, abilityView);
    }
}
