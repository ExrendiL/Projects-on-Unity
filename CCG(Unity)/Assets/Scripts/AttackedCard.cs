using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackedCard : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {

        if (!GetComponent<CardMovementScr>().GameManager.IsPlayerTurn)
            return;

        CardInfoScr card = eventData.pointerDrag.GetComponent<CardInfoScr>();

        if (card && card.SelfCard.CanAttack &&
            transform.parent == GetComponent<CardMovementScr>().GameManager.EnemyField)
        {
            card.SelfCard.ChangeAttackState(false);

            if (card.IsPlayer)
                card.DeHighlightCard();

            GetComponent<CardMovementScr>().GameManager.CradsFight(card, GetComponent<CardInfoScr>());
        }

    }

    
}
