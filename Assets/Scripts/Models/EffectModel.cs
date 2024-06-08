public class EffectModel
{
    private string id;
    private string name;
    private string luaScriptPath;

    // Constructor for easy initialization
    public EffectModel(string id, string name, string luaScriptPath)
    {
        this.id = id;
        this.name = name;
        this.luaScriptPath = luaScriptPath;
    }

    public string GetId() { return id; }
    public void SetId(string value) { id = value; }

    public string GetName() { return name; }
    public void SetName(string value) { name = value; }

    public string GetLuaScriptPath() { return luaScriptPath; }
    public void SetLuaScriptPath(string value) { luaScriptPath = value; }
}
