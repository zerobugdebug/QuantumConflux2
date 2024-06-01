public class AbilityController
{
    private AbilityModel abilityModel;
    private AbilityView abilityView;

    public AbilityController(AbilityModel model, AbilityView view)
    {
        abilityModel = model;
        abilityView = view;
    }

    public void UpdateAbilityInfo(string id, string name, EffectController effect)
    {
        abilityModel.SetAbilityId(id);
        abilityModel.SetAbilityName(name);
        abilityModel.SetEffect(effect);
        abilityView.DisplayAbilityInfo(abilityModel);
        abilityView.DisplayAbilityEffect(effect);
    }

    public void DisplayAbility()
    {
        abilityView.DisplayAbilityInfo(abilityModel);
        abilityView.DisplayAbilityEffect(abilityModel.GetEffect());
    }

    public void ApplyAbilityEffect()
    {
        abilityModel.GetEffect().ApplyEffect();
    }
}
