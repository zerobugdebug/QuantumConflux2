
using UnityEngine;

public class EffectFactory
{
    public EffectController CreateEffect(string id, string name, string luaScriptPath)
    {
        EffectModel effectModel = new(id, name, luaScriptPath);
        EffectView effectView = new GameObject().AddComponent<EffectView>();
        return new EffectController(effectModel, effectView);
    }
}
