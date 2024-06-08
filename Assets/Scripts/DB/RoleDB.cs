using System.Collections.Generic;

public class RoleDB
{
    public List<RoleModel> Roles { get; private set; }

    public void SetRoles(List<RoleModel> roles)
    {
        Roles = roles;
    }

    public RoleModel GetRoleById(string id)
    {
        return Roles.Find(role => role.GetId() == id);
    }
}
