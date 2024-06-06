public class AbilityModel
{
    private string abilityId;
    private string abilityName;
    private EffectController effect;

    public AbilityModel(string abilityId, string abilityName, EffectController effect)
    {
        this.abilityId = abilityId;
        this.abilityName = abilityName;
        this.effect = effect;
    }

    public string GetAbilityId() { return abilityId; }
    public void SetAbilityId(string value) { abilityId = value; }

    public string GetAbilityName() { return abilityName; }
    public void SetAbilityName(string value) { abilityName = value; }

    public EffectController GetEffect() { return effect; }
    public void SetEffect(EffectController value) { effect = value; }
}
