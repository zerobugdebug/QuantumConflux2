public class TraitModel
{
    private string traitId;
    private string traitName;
    private EffectController effect;

    public string GetTraitId() { return traitId; }
    public void SetTraitId(string value) { traitId = value; }

    public string GetTraitName() { return traitName; }
    public void SetTraitName(string value) { traitName = value; }

    public EffectController GetEffect() { return effect; }
    public void SetEffect(EffectController value) { effect = value; }
}
