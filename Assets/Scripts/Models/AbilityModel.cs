public class AbilityModel
{
    private string id;
    private string name;
    private EffectController effect;

    public AbilityModel(string id, string name, EffectController effect)
    {
        this.id = id;
        this.name = name;
        this.effect = effect;
    }

    public string GetId() { return id; }
    public void SetId(string value) { id = value; }

    public string GetName() { return name; }
    public void SetName(string value) { name = value; }

    public EffectController GetEffect() { return effect; }
    public void SetEffect(EffectController value) { effect = value; }
}
