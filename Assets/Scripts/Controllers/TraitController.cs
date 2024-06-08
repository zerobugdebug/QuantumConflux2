public class TraitController
{
    private TraitModel traitModel;
    private TraitView traitView;

    public TraitController(TraitModel model, TraitView view)
    {
        traitModel = model;
        traitView = view;
    }

    public void UpdateTraitInfo(string id, string name, EffectController effect)
    {
        traitModel.SetId(id);
        traitModel.SetName(name);
        traitModel.SetEffect(effect);
        traitView.DisplayTraitInfo(traitModel);
        traitView.DisplayTraitEffect(effect);
    }

    public void DisplayTrait()
    {
        traitView.DisplayTraitInfo(traitModel);
        traitView.DisplayTraitEffect(traitModel.GetEffect());
    }

    public void ApplyTraitEffect()
    {
        traitModel.GetEffect().ApplyEffect();
    }
}
