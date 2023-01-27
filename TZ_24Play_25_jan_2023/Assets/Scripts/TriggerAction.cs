using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAction : MonoBehaviour
{
    [Header("Item")]
    public Transform ItemHolderTransform;

    int NumOfItemHolding = 0;
    void Start()
    {

    }

    public void AddNewItem(Transform _itemtoAdd)
    {

        _itemtoAdd.SetParent(ItemHolderTransform, true);
        _itemtoAdd.localPosition = new Vector3(0, 0, -NumOfItemHolding);
        _itemtoAdd.localRotation = Quaternion.identity;
    }
}
