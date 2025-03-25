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

    [Header("===Item Inventory Ui===")]
    InventoryPopUp inventoryPopUp;

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

        // 데이터 초기화 
        InitItemData();
    }

    private void InitItemData() 
    {
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

                equipItem.Add(e);
                itemData.Add(e);
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

                useItem.Add(n);
                itemData.Add(n);
            }
        }
    }

    public void InventoryUI() 
    {
        inventoryPopUp = UIManager.Instance.ShowPopUp<InventoryPopUp>();
        inventoryPopUp.SetUpInventory(ItemData);
    }

    // 아이템 슬롯 클릭 시 실행 
    public void ClickItemSlot(int idx ) 
    {
        // 인덱스에 해당하는 item 배열을 넘으면 
        if (idx < 0 || idx >= itemData.Count)
            return;

        // 착용할 수 없으면 or 이미 착용했으면 
        if (itemData[idx].EuipType == Equipped.None)
            return;

        // 착용중이면 
        if (itemData[idx].EuipType == Equipped.Equipped) 
        {
            // 벗기 
            ItemAppy(itemData[idx], Equipped.Yet , -1);
            return;
        }

        // 착용 
        ItemAppy(itemData[idx], Equipped.Equipped );    
    }

    private void ItemAppy(Item item , Equipped nextType, int var = 1) 
    {
        Debug.Log($" {item.ItemName} 아이템 착용 ");

        // 아이템이 Equipped 변경 
        ChangeEquipeState(item, nextType);

        // Equip 이면 
        // Usable 일때는 x 
        if (item is Equip equi)
        {
            for (int i = 0; i < equi.ItemStatus.Count; i++) 
            {
                int value = equi.ItemStatusValue[i] * var;
                StatusType type = equi.ItemStatus[i];

                CharacterManager.Instance.UpdateCharaterState(type , value);
            }
        }

        // UI 업데이트 
        inventoryPopUp.UpdateEquipSlot(itemData);
    }

    private void ChangeEquipeState(Item item , Equipped type) 
    {
        item.EuipType = type;
    }
}
