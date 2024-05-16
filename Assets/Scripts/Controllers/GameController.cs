using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<CardModel> playerDeck;
    public List<CardModel> opponentDeck;
    public PlayerModel playerModel;
    public OpponentModel opponentModel;

    void Start()
    {
        InitializeGame();
    }

    void InitializeGame()
    {
        ShuffleDeck(playerDeck);
        ShuffleDeck(opponentDeck);

        playerModel = new PlayerModel();
        opponentModel = new OpponentModel();

        // Draw initial hands
        for (int i = 0; i < 4; i++)
        {
            playerModel.DrawCard();
            opponentModel.DrawCard();
        }
    }

    void Update()
    {
        // Handle game logic, turns, etc.
    }

    void ShuffleDeck(List<CardModel> deck)
    {
        for (int i = 0; i < deck.Count; i++)
        {
            CardModel temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    public void PlayRound(CardModel playerCard, CardModel opponentCard, int playerPillz, int opponentPillz)
    {
        int playerAttack = playerCard.Power * playerPillz;
        int opponentAttack = opponentCard.Power * opponentPillz;

        if (playerAttack > opponentAttack)
        {
            // Player wins the round
            opponentModel.LifePoints -= playerCard.Damage;
        }
        else if (opponentAttack > playerAttack)
        {
            // Opponent wins the round
            playerModel.LifePoints -= opponentCard.Damage;
        }
        else
        {
            // Handle tie case
        }

        // Update game state, check for win/loss, etc.
    }
}