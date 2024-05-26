using UnityEngine;

public class PlayerController : CharacterController
{
    public PlayerModel playerModel;
    private GameObject chargeAssignment;
    [SerializeField] private GameObject chargeAssignmentViewPrefab;
    private ChargeAssignmentView chargeAssignmentView;

    private void Awake()
    {
        if (characterHandView == null)
        {
            Debug.LogError("PlayerHandView is not assigned in the inspector.");
            return;
        }

        characterModel = playerModel = new PlayerModel();
    }

    public override void AssignPillz()
    {

        if (chargeAssignment == null)
        {
            chargeAssignment = Instantiate(chargeAssignmentViewPrefab, GetCurrentCard().GetCardView().transform);
            if (chargeAssignment.TryGetComponent(out chargeAssignmentView))
            {
                RectTransform rt = chargeAssignment.GetComponent<RectTransform>();
                rt.anchorMin = Vector2.up;
                rt.anchorMax = Vector2.up;
                rt.pivot = Vector2.zero;

                chargeAssignmentView.Initialize(playerModel.GetPillz(), this);
                chargeAssignmentView.gameObject.SetActive(true);
            }
        }

        //int availablePillz = playerModel.Pillz;

        //return 0; // Placeholder return

    }

    public override void ConfirmPillzSelection(int value)
    {
        selectedCard.SetPillz(value);
    }

    public override CardController SelectCard()
    {
        throw new System.NotImplementedException();
    }
}
