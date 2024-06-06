using System.Collections.Generic;

public class RoleController
{
    private RoleModel roleModel;
    private RoleView roleView;

    public RoleController(RoleModel model, RoleView view)
    {
        roleModel = model;
        roleView = view;
    }

    public void UpdateRoleName(string name)
    {
        roleModel.SetName(name);
        roleView.DisplayRoleInfo(roleModel);
    }

    public void UpdateRoleAbility(AbilityController ability)
    {
        roleModel.SetAbility(ability);
        roleView.DisplayRoleAbility(ability);
    }

    public void UpdateRoleSlots(List<SlotController> slots)
    {
        roleModel.SetSlots(slots);
        roleView.DisplayRoleSlots(slots);
    }

    public void DisplayRole()
    {
        roleView.DisplayRoleInfo(roleModel);
        roleView.DisplayRoleAbility(roleModel.GetAbility());
        roleView.DisplayRoleSlots(roleModel.GetSlots());
    }

    public string GetName() { return roleModel.GetName(); }

    public int GetSpeed()
    {
        return roleModel.GetSpeed();
    }

    public int GetMight()
    {
        return roleModel.GetMight();
    }

    public int GetDamage()
    {
        return roleModel.GetDamage();
    }
}
