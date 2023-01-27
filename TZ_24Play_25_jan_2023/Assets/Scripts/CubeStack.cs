using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStack : MonoBehaviour
{
    [Header("Item")]
    public Transform ItemHolderTransform;

    int NumOfItemHolding = 0;
    //float a = -7.357391f;
     void Start()
    {
        
    }

    public void AddNewItem(Transform _itemtoAdd)
    {
        
        _itemtoAdd.SetParent(ItemHolderTransform , true);
        _itemtoAdd.localPosition = new Vector3(0,  -NumOfItemHolding, 0);
        _itemtoAdd.localRotation = Quaternion.identity;
        NumOfItemHolding++;
    }
    public void DelItem(Transform _itemtoDel)
    {
        NumOfItemHolding--;
        _itemtoDel.SetParent(ItemHolderTransform, true);
        _itemtoDel.localPosition = new Vector3(0, NumOfItemHolding, 0);
      
    }

}
