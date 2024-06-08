using System.Collections.Generic;

public class TraitDB
{
    public List<TraitModel> Traits { get; private set; }

    public void SetTraits(List<TraitModel> traits)
    {
        Traits = traits;
    }

    public TraitModel GetTraitById(string id)
    {
        return Traits.Find(trait => trait.GetId() == id);
    }
}
