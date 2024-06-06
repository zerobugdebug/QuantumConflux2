
using UnityEngine;

public class AbilityFactory
{
    public AbilityController CreateAbility(string abilityId, string abilityName, EffectController effect)
    {
        //EffectController effect = effectFactory.CreateEffect(effectId, effectName, luaScriptPath);
        AbilityModel abilityModel = new(abilityId, abilityName, effect);
        AbilityView abilityView = new GameObject().AddComponent<AbilityView>();
        return new AbilityController(abilityModel, abilityView);
    }
}
