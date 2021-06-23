using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum FieldType
{ 
SELF_HAND,
SELF_FIELD,
ENEMY_HAND,
ENEMY_FIELD

}

public class DropPlaceSrc : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public FieldType Type;
    public void OnDrop(PointerEventData eventData)
    {
        if (Type != FieldType.SELF_FIELD)
            return;

        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>();

        if (card && card.GameManager.PlayerFieldCards.Count < 6 && 
            card.GameManager.IsPlayerTurn  && card.GameManager.PlayerMana >=
            card.GetComponent<CardInfoScr>().SelfCard.Manacost &&
            !card.GetComponent<CardInfoScr>().SelfCard.IsPlaced) 
        {
            card.GameManager.PlayerHandCards.Remove(card.GetComponent<CardInfoScr>());
            card.GameManager.PlayerFieldCards.Add(card.GetComponent<CardInfoScr>());
            card.DefaultParent = transform;

            card.GetComponent<CardInfoScr>().SelfCard.IsPlaced = true;

            card.GameManager.ReduceMana(true, card.GetComponent<CardInfoScr>().SelfCard.Manacost);

            card.GameManager.CheckCardsForAvailability();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null || Type == FieldType.ENEMY_FIELD || 
            Type == FieldType.ENEMY_HAND || Type == FieldType.SELF_FIELD)
            return;

        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>();

        if (card)
            card.DefaultTempCardParent = transform;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>();

        if (card && card.DefaultTempCardParent == transform)
            card.DefaultTempCardParent = card.DefaultParent;
    }
}
