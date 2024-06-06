using System.Collections.Generic;

public class RoleModel
{
    private string roleId;
    private string roleName;
    private AbilityController ability;
    private List<SlotController> slots;
    private int speed;
    private int might;
    private int damage;

    public RoleModel(string roleId, string roleName, AbilityController ability, List<SlotController> slots)
    {
        this.roleId = roleId;
        this.roleName = roleName;
        this.ability = ability;
        this.slots = slots;
    }

    public string GetRoleId() { return roleId; }
    public void SetRoleId(string value) { roleId = value; }

    public string GetName() { return roleName; }
    public void SetName(string value) { roleName = value; }

    public AbilityController GetAbility() { return ability; }
    public void SetAbility(AbilityController value) { ability = value; }

    public List<SlotController> GetSlots() { return slots; }
    public void SetSlots(List<SlotController> value) { slots = value; }

    public void CalculateStats()
    {
        foreach (SlotController slot in GetSlots())
        {
            speed += slot.GetItem().GetSpeedModifier();
            might += slot.GetItem().GetMightModifier();
            damage += slot.GetItem().GetDamageModifier();
        }
    }

    public int GetSpeed() { return speed; }
    public int GetMight() { return might; }
    public int GetDamage() { return damage; }
}
