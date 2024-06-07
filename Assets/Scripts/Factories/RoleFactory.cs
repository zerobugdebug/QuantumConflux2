
using System.Collections.Generic;
using UnityEngine;

public class RoleFactory
{
    public RoleController CreateRole(string id, string name, AbilityController ability, List<SlotController> slots)
    {
        RoleModel roleModel = new(id, name, ability, slots);
        RoleView roleView = new GameObject().AddComponent<RoleView>();
        return new RoleController(roleModel, roleView);
    }
}
