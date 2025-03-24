using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [Header("===Container===")]
    [SerializeField]
    private List<Equip> equipItem;
    [SerializeField]
    private List<UseItem> useItem;
    
    void Start()
    {
        var temp = JsonSerialized.Deserialization<ItemWrapper>("ItemWrapper");

        equipItem = new List<Equip>();
        useItem = new List<UseItem>();
        foreach (var item in temp) 
        {
            if (item.itemType == ItemType.Equiptable)
            {
                Equip e = new Equip
                (
                    item.itemNum,
                    item.itemType,
                    item.itemName,
                    item.itemToolTip,
                    item.itemStatus,
                    item.itemStatusValue
                );

                equipItem.Add( e );
            }
            else 
            {
                UseItem n = new UseItem
                (
                    item.itemNum,
                    item.itemType,
                    item.itemName,
                    item.itemToolTip
                );

                useItem.Add( n );
            }
        }
    }


}
