using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackedCard : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {

        if (!GameManagerScr.Instance.IsPlayerTurn)
            return;

        CardControllerScr attacker = eventData.pointerDrag.GetComponent<CardControllerScr>(),
            defender = GetComponent<CardControllerScr>();

        if (attacker && attacker.Card.CanAttack &&
            defender.Card.IsPlaced)
        {
          

           GameManagerScr.Instance.CradsFight(attacker, defender);
        }

    }

    
}
