public class EffectController
{
    private EffectModel effectModel;
    private EffectView effectView;

    public EffectController(EffectModel model, EffectView view)
    {
        effectModel = model;
        effectView = view;
    }

    public void UpdateEffectInfo(string id, string name, string luaScriptPath)
    {
        effectModel.SetEffectId(id);
        effectModel.SetEffectName(name);
        effectModel.SetLuaScriptPath(luaScriptPath);
        effectView.DisplayEffectInfo(effectModel);
    }

    public void DisplayEffect()
    {
        effectView.DisplayEffectInfo(effectModel);
    }

    public void ApplyEffect()
    {
        // Code to apply the effect using the LUA script
        _ = effectModel.GetLuaScriptPath();
        // Load and execute the LUA script from scriptPath
    }
}
