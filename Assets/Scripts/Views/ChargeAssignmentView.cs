// Filename: PillzAssignmentView.cs
using TMPro;
using UnityEngine;

public class ChargeAssignmentView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pillzAmountText;
    private int maxPillz;
    private int currentPillz;
    private CharacterController character;
    //private System.Action<int> onPillzConfirmed;

    public void Initialize(int maxPillz, CharacterController character)
    {
        this.maxPillz = maxPillz;
        this.character = character;
        //this.onPillzConfirmed = onPillzConfirmed;
        currentPillz = 0;
        UpdatePillzAmount();
    }

    private void UpdatePillzAmount()
    {
        pillzAmountText.text = currentPillz.ToString();
    }

    public void IncrementPillz()
    {
        if (currentPillz < maxPillz)
        {
            currentPillz++;
            UpdatePillzAmount();
        }
    }

    public void DecrementPillz()
    {
        if (currentPillz > 0)
        {
            currentPillz--;
            UpdatePillzAmount();
        }
    }

    public void ConfirmPillzAssignment()
    {
        character.ConfirmPillzSelection(currentPillz);
        gameObject.SetActive(false);
    }
}
