using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardControllerScr : MonoBehaviour
{
    public Card Card;
    public bool IsPlayerCard;
    public CardInfoScr Info;
    public CardMovementScr Movement;
    public CardAbility Ability;

    GameManagerScr gameManager;

    public void Init(Card card, bool isPlayerCard)
    {
        Card = card;
        gameManager = GameManagerScr.Instance;
        IsPlayerCard = isPlayerCard;

        if (isPlayerCard)
        {
            Info.ShowCardInfo();
            GetComponent<AttackedCard>().enabled = false;
        }
        else
            Info.HideCardInfo();
    }

    public void OnCast()
    {
        if (IsPlayerCard)
        {
            gameManager.PlayerHandCards.Remove(this);
            gameManager.PlayerFieldCards.Add(this);
            gameManager.ReduceMana(true, Card.Manacost);
            gameManager.CheckCardsForManaAvailability();
        }
        else
        {
            gameManager.EnemyHandCards.Remove(this);
            gameManager.EnemyFieldCards.Add(this);
            gameManager.ReduceMana(false, Card.Manacost);
        }

        Card.IsPlaced = true;
    }

    public void OnTakeDamage(CardControllerScr playerCard = null)
    {
        CheckForalive();
    }

    public void OnDamageDeal()
    {
        Card.CanAttack = false;
        Info.HighlightCard(false);
    }

    public void CheckForalive()
    {
        if (Card.IsAlive)
            Info.RefreshData();
        else
            DestroyCard();
    }

    public void DestroyCard()
    {
        Movement.OnEndDrag(null);
        RemoveCardFromList(gameManager.EnemyFieldCards);
        RemoveCardFromList(gameManager.EnemyHandCards);
        RemoveCardFromList(gameManager.PlayerFieldCards);
        RemoveCardFromList(gameManager.PlayerHandCards);
        Destroy(gameObject);
    }

    void RemoveCardFromList(List<CardControllerScr> list)
    {
        if (list.Exists(x => x == this))
            list.Remove(this);
    }

}
