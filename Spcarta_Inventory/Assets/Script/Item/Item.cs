using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType 
{   
    Usable, 
    Equiptable
}

[System.Serializable]
public class Item 
{
    [SerializeField] private int itemNum;
    [SerializeField] private ItemType itemType;
    [SerializeField] private string itemName;
    [SerializeField] private string itemToolTip;

    public Item(int n, ItemType t, string name, string tool) 
    {
        this.itemNum = n;
        this.itemType = t;
        this.itemName = name;
        this.itemToolTip = tool;
    }

    public int ItemNum { get => itemNum; set => itemNum = value; }
    public ItemType ItemType { get => itemType; set => itemType = value; }
    public string ItemName { get => itemName; set => itemName = value; }
    public string ItemToolTip { get => itemToolTip; set => itemToolTip = value; }
}

public class Equip : Item
{
    [SerializeField] private List<StatusType> itemStatus;
    [SerializeField] private List<int> itemStatusValue;
    public List<StatusType> ItemStatus { get => itemStatus; set => itemStatus = value; }
    public List<int> ItemStatusValue { get => itemStatusValue; set => itemStatusValue = value; }

    public Equip(int n, ItemType ty , string name, string tool ,
        List<StatusType> typeList, List<int> typeValue) : base(n, ty, name, tool)
    {
        this.itemStatus = typeList;
        this.itemStatusValue = typeValue;
    }

}

public class UseItem : Item 
{
    public UseItem(int n, ItemType ty, string name, string tool): base(n, ty, name, tool)
    {
    }
}
