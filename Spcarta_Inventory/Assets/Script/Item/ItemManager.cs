using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // 싱글톤
    private static ItemManager instance;
    public static ItemManager Instance
    {
        get
        {
            if (instance != null)
                return instance;

            instance = new GameObject("ItemManager").AddComponent<ItemManager>();
            return instance;
        }
    }

    [Header("===Container===")]
    [SerializeField]
    private List<Equip> equipItem;
    [SerializeField]
    private List<UseItem> useItem;
    [SerializeField]
    private List<Item> itemData;

    [Header("===ItemIcon===")]
    [SerializeField]
    private Sprite[] itemIcon;

    public List<Item> ItemData { get => itemData; set => itemData = value; }
    public Sprite[] ItemIcon { get => itemIcon; set => itemIcon = value; }

    private void Awake()
    {
        instance = this;

    }

    void Start()
    {
        // 아이콘 가져오기 
        itemIcon = ResourceUtility.ReturnResource("ItemIcon");
        
        // 역직렬화 
        var temp = JsonSerialized.Deserialization<ItemWrapper>("ItemWrapper");

        equipItem = new List<Equip>();
        useItem = new List<UseItem>();
        itemData = new List<Item>();
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
                    item.itemStatusValue,
                    item.itemEquit
                );

                equipItem.Add( e );
                itemData.Add( e );
            }
            else 
            {
                UseItem n = new UseItem
                (
                    item.itemNum,
                    item.itemType,
                    item.itemName,
                    item.itemToolTip,
                    item.itemEquit
                );

                useItem.Add( n );
                itemData.Add( n );
            }
        }
    }


}
