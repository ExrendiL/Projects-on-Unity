using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class CardMovementScr : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

   public  CardControllerScr CC;

    Camera MainCamera;
    Vector3 offset;
   public Transform DefaultParent,DefaultTempCardParent;
    GameObject TempCardGO;
    public bool IsDraggable;
   
    void Awake() 
    {
        MainCamera = Camera.allCameras[0];
        TempCardGO = GameObject.Find("TempCardGO");
        

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = transform.position - MainCamera.ScreenToWorldPoint(eventData.position);

        DefaultParent = DefaultTempCardParent= transform.parent;

        IsDraggable = GameManagerScr.Instance.IsPlayerTurn &&
            (
            (DefaultParent.GetComponent<DropPlaceSrc>().Type == FieldType.SELF_HAND &&
            GameManagerScr.Instance.PlayerMana >=CC.Card.Manacost) ||
            (DefaultParent.GetComponent<DropPlaceSrc>().Type == FieldType.SELF_FIELD &&
            CC.Card.CanAttack)
            );
      

        if (!IsDraggable)
            return;

        if(CC.Card.CanAttack)
        GameManagerScr.Instance.HighlightTargets(true);

        TempCardGO.transform.SetParent(DefaultParent);
        TempCardGO.transform.SetSiblingIndex(transform.GetSiblingIndex());

        transform.SetParent(DefaultParent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!IsDraggable)
            return;

        Vector3 newPos = MainCamera.ScreenToWorldPoint(eventData.position);

        transform.position = newPos+offset;

        if (TempCardGO.transform.parent != DefaultTempCardParent)
            TempCardGO.transform.SetParent(DefaultTempCardParent);

        if(DefaultParent.GetComponent<DropPlaceSrc>().Type !=FieldType.SELF_HAND)
        CheckPosition();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!IsDraggable)
            return;
        GameManagerScr.Instance.HighlightTargets(false);

        transform.SetParent(DefaultParent);

        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.SetSiblingIndex(TempCardGO.transform.GetSiblingIndex());
        TempCardGO.transform.SetParent(GameObject.Find("Canvas").transform);
        TempCardGO.transform.localPosition = new Vector3(1165, 0);

     
    }

    public void CheckPosition()
    {
        int newIndex = DefaultTempCardParent.childCount;
        for (int i =0; i<DefaultTempCardParent.childCount; i++)
        {
            if (transform.position.x < DefaultTempCardParent.GetChild(i).position.x)
            {
                newIndex = i;

                if (TempCardGO.transform.GetSiblingIndex() < newIndex)
                    newIndex--;
                break;
            }
        }
        TempCardGO.transform.SetSiblingIndex(newIndex);
    
    }

    public void MoveToFields(Transform fields)
    {
        transform.SetParent(GameObject.Find("Canvas").transform);
        transform.DOMove(fields.position, .5f);
    }

    public void MoveToTarget(Transform target)
    {
        StartCoroutine(MoveToTargetCor(target));
    }

    IEnumerator MoveToTargetCor(Transform target)
    {
        Vector3 pos = transform.position;
        Transform parent = transform.parent;
        int index = transform.GetSiblingIndex();

        transform.parent.GetComponent<HorizontalLayoutGroup>().enabled = false;

        transform.SetParent(GameObject.Find("Canvas").transform);

        transform.DOMove(target.position, .25f);

        yield return new WaitForSeconds(.25f);

        transform.DOMove(pos, .25f);

        yield return new WaitForSeconds(.25f);

        transform.SetParent(parent);
        transform.SetSiblingIndex(index);

        transform.parent.GetComponent<HorizontalLayoutGroup>().enabled = true;
    }
}
