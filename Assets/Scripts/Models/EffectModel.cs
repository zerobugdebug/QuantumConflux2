public class EffectModel
{
    private int id;
    private string name;
    private string luaScriptPath;

    // Constructor for easy initialization
    public EffectModel(int id, string name, string luaScriptPath)
    {
        this.id = id;
        this.name = name;
        this.luaScriptPath = luaScriptPath;
    }

    public int GetId() { return id; }
    public void SetId(int value) { id = value; }

    public string GetName() { return name; }
    public void SetName(string value) { name = value; }

    public string GetLuaScriptPath() { return luaScriptPath; }
    public void SetLuaScriptPath(string value) { luaScriptPath = value; }
}
