using System;
using UnityEngine;

public class CardController // : MonoBehaviour
{
    private CardModel cardModel;
    private CardView cardView;
    private GameObject cardPrefab;
    //private readonly bool isPlayable = true;

    public event Action<CardController> CardClicked;

    public bool IsPlayed { get; set; } = false;

    public void Initialize(CardModel cardModel, GameObject cardPrefab)
    {
        this.cardModel = cardModel;
        this.cardPrefab = cardPrefab;
    }

    public CardController Clone()
    {
        CardController card = new();
        card.Initialize(cardModel.Clone(), cardPrefab);
        return card;
    }

    // Method to instantiate a card and assign its view
    public void InstantiateCard(Transform parent = null)
    {
        GameObject cardObject = GameObject.Instantiate(cardPrefab, parent);

        if (cardObject.TryGetComponent(out cardView))
        {
            cardView.UpdateView(cardModel);
            cardView.SetCardController(this);
            CreateTooltip(cardObject, "ClanIcon", "Clan: " + cardModel.Clan);
            CreateTooltip(cardObject, "Background/PowerBackground", "Show the power of the card attack\r\nPower: " + cardModel.Power);
            CreateTooltip(cardObject, "Background/DamageBackground", "Show the damage of the card\r\nDamage: " + cardModel.Damage);
            /*            Transform clanLogo = cardObject.transform.Find("ClanIcon");
                        if (clanLogo.gameObject.TryGetComponent(out TooltipController tooltip))
                        {
                            TooltipModel tooltipModel = new("Clan: " + cardModel.Clan);
                            tooltip.Initialize(tooltipModel);
                        }

                        Transform powerBackground = cardObject.transform.Find("Background/PowerBackground");
                        if (powerBackground.gameObject.TryGetComponent(out tooltip))
                        {
                            TooltipModel tooltipModel = new("Power: " + cardModel.Power);
                            tooltip.Initialize(tooltipModel);
                        }
            */
        }
        else
        {
            Debug.LogError("View is not assigned to cardPrefab");
            return;
        }
    }

    // Method to update the card view with the current card model
    public void UpdateView()
    {
        if (cardView != null && cardModel != null)
        {
            if (IsPlayed)
            {
                cardView.HighlightCard(true);
            }
            cardView.UpdateView(cardModel);
        }
        else
        {
            Debug.LogError("CardView or CardModel is null");
        }
    }

    // Method called when the card is clicked
    public void OnCardClicked()
    {
        if (!IsPlayed)
        {
            CardClicked?.Invoke(this); // Raise event
        }
        else
        {
            Debug.Log("Cannot interact with this card.");
        }
    }

    public bool IsPillzAssigned()
    {
        return cardModel.IsPillzAssigned();
    }

    public int GetAssignedPillz()
    {
        return cardModel.GetPillz();
    }

    public CardView GetCardView()
    {
        return cardView;
    }

    public void SetPillz(int value)
    {
        cardModel.SetPillz(value);
    }

    public string GetName()
    {
        return cardModel.GetName();
    }

    internal int CalculateAttack()
    {
        return (GetAssignedPillz() + 1) * cardModel.GetMight();
    }

    internal int GetDamage()
    {
        return cardModel.GetDamage();
    }

    public void CreateTooltip(GameObject parent, string childName, string text)
    {
        Transform transform = parent.transform.Find(childName);
        if (!transform.gameObject.TryGetComponent(out TooltipController tooltip))
        {
            tooltip = transform.gameObject.AddComponent<TooltipController>();
            tooltip.SetPrefab(Resources.Load<GameObject>("Prefabs/Tooltip"));
        }
        TooltipModel tooltipModel = new(text);
        tooltip.Initialize(tooltipModel);
    }
}
