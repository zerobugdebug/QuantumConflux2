
using System.Collections.Generic;
using UnityEngine;

public class RoleFactory
{
    public RoleController CreateRole(string roleId, string roleName, AbilityController ability, List<SlotController> slots)
    {
        RoleModel roleModel = new(roleId, roleName, ability, slots);
        RoleView roleView = new GameObject().AddComponent<RoleView>();
        return new RoleController(roleModel, roleView);
    }
}
