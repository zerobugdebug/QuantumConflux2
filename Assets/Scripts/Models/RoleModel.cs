using System.Collections.Generic;

public class RoleModel
{
    private string id;
    private string name;
    private AbilityController ability;
    private List<SlotController> slots;
    private int speed;
    private int might;
    private int damage;

    public RoleModel(string id, string name, AbilityController ability, List<SlotController> slots)
    {
        this.id = id;
        this.name = name;
        this.ability = ability;
        this.slots = slots;
    }

    public string GetId() { return id; }
    public void SetId(string value) { id = value; }

    public string GetName() { return name; }
    public void SetName(string value) { name = value; }

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
