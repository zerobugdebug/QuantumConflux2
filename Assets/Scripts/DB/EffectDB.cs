using System.Collections.Generic;

public class EffectDB
{
    public List<EffectModel> Effects { get; private set; }

    public void SetEffects(List<EffectModel> effects)
    {
        Effects = effects;
    }

    public EffectModel GetEffectById(string id)
    {
        return Effects.Find(effect => effect.GetId() == id);
    }
}
