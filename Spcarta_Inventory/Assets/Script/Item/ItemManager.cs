using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    // �̱���
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
        // ������ �������� 
        itemIcon = ResourceUtility.ReturnResource("ItemIcon");

        // ������ �ʱ�ȭ 
        InitItemData();
    }

    private void InitItemData() 
    {
        // ������ȭ 
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

    // ������ ���� Ŭ�� �� ���� 
    public void ClickItemSlot(int idx ) 
    {
        // �ε����� �ش��ϴ� item �迭�� ������ 
        if (idx < 0 || idx >= itemData.Count)
            return;

        // ������ �� ������ or �̹� ���������� 
        if (itemData[idx].EuipType == Equipped.None)
            return;

        // �������̸� 
        if (itemData[idx].EuipType == Equipped.Equipped) 
        {
            // ���� 
            ItemAppy(itemData[idx], Equipped.Yet , -1);
            return;
        }

        // ���� 
        ItemAppy(itemData[idx], Equipped.Equipped );    
    }

    private void ItemAppy(Item item , Equipped nextType, int var = 1) 
    {
        Debug.Log($" {item.ItemName} ������ ���� ");

        // �������� Equipped ���� 
        ChangeEquipeState(item, nextType);

        // Equip �̸� 
        // Usable �϶��� x 
        if (item is Equip equi)
        {
            for (int i = 0; i < equi.ItemStatus.Count; i++) 
            {
                int value = equi.ItemStatusValue[i] * var;
                StatusType type = equi.ItemStatus[i];

                CharacterManager.Instance.UpdateCharaterState(type , value);
            }
        }

        // UI ������Ʈ 
        inventoryPopUp.UpdateEquipSlot(itemData);
    }

    private void ChangeEquipeState(Item item , Equipped type) 
    {
        item.EuipType = type;
    }
}
