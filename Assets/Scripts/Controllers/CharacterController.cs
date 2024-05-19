using UnityEngine;
using System.Collections.Generic;

public abstract class CharacterController : MonoBehaviour
{
    public CharacterModel character;
    private CharacterHandView characterHandView;

    protected virtual void InitializeCharacter()
    {
        character = new CharacterModel();
        ShuffleDeck(character.Deck);

        for (int i = 0; i < 4; i++)
        {
            character.DrawCard();
        }

        characterHandView.UpdateView(character.Hand);
    }

    protected void ShuffleDeck(List<CardModel> deck)
    {
        for (int i = 0; i < deck.Count; i++)
        {
            CardModel temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    public abstract CardModel SelectCard();

    public abstract int AssignPillz();
}
