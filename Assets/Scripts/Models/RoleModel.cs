using System.Collections.Generic;

public class RoleModel
{
    private string roleId;
    private string roleName;
    private AbilityController ability;
    private List<SlotModel> slots;

    public string GetRoleId() { return roleId; }
    public void SetRoleId(string value) { roleId = value; }

    public string GetRoleName() { return roleName; }
    public void SetRoleName(string value) { roleName = value; }

    public AbilityController GetAbility() { return ability; }
    public void SetAbility(AbilityController value) { ability = value; }

    public List<SlotModel> GetSlots() { return slots; }
    public void SetSlots(List<SlotModel> value) { slots = value; }
}
