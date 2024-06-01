public class EffectModel
{
    private string effectId;
    private string effectName;
    private string luaScriptPath;

    public string GetEffectId() { return effectId; }
    public void SetEffectId(string value) { effectId = value; }

    public string GetEffectName() { return effectName; }
    public void SetEffectName(string value) { effectName = value; }

    public string GetLuaScriptPath() { return luaScriptPath; }
    public void SetLuaScriptPath(string value) { luaScriptPath = value; }
}
