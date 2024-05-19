using UnityEngine;

public class HandController : MonoBehaviour
{
    public HandModel Hand { get; private set; }

    private void Awake()
    {
        Hand = new HandModel();
    }

    public void DrawHandFromDeck(DeckModel deck)
    {
        Hand.DrawHand(deck);
    }
}
