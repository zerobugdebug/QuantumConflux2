using UnityEngine;

public class PlayerController : CharacterController
{
    public PlayerModel playerModel;

    private void Awake()
    {
        if (characterHandView == null)
        {
            Debug.LogError("PlayerHandView is not assigned in the inspector.");
            return;
        }

        characterModel = playerModel = new PlayerModel();
    }

    public override int AssignPillz()
    {
        int assignedPillz = 3; // Placeholder for actual Pillz assignment logic
        return assignedPillz;
    }

    public override CardController SelectCard()
    {
        throw new System.NotImplementedException();
    }
}
