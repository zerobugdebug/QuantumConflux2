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
        roleModel.SetRoleName(name);
        roleView.DisplayRoleInfo(roleModel);
    }

    public void UpdateRoleAbility(AbilityController ability)
    {
        roleModel.SetAbility(ability);
        roleView.DisplayRoleAbility(ability);
    }

    public void UpdateRoleSlots(List<SlotModel> slots)
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
}
