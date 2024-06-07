
using UnityEngine;

public class TraitFactory
{
    public TraitController CreateTrait(string id, string name, EffectController effect)
    {
        //EffectController effect = effectFactory.CreateEffect(effectId, effectName, luaScriptPath);
        TraitModel traitModel = new(id, name, effect);
        TraitView traitView = new GameObject().AddComponent<TraitView>();
        return new TraitController(traitModel, traitView);
    }
}
