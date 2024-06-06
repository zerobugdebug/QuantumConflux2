
using UnityEngine;

public class TraitFactory
{
    public TraitController CreateTrait(string traitId, string traitName, EffectController effect)
    {
        //EffectController effect = effectFactory.CreateEffect(effectId, effectName, luaScriptPath);
        TraitModel traitModel = new(traitId, traitName, effect);
        TraitView traitView = new GameObject().AddComponent<TraitView>();
        return new TraitController(traitModel, traitView);
    }
}
