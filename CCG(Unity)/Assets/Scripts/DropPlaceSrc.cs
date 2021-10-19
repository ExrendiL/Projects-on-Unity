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

        CardControllerScr card = eventData.pointerDrag.GetComponent<CardControllerScr>();

        if (card && 
            GameManagerScr.Instance.IsPlayerTurn  && 
            GameManagerScr.Instance.PlayerMana >= card.Card.Manacost &&
            !card.Card.IsPlaced) 
        {
            
            card.Movement.DefaultParent = transform;
            card.OnCast();

           
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
