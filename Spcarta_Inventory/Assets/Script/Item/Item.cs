using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType 
{   
    Usable, 
    Equiptable
}
public enum Equipped 
{ 
    Equipped,   // Âø¿ëÈÄ
    Yet,        // Âø¿ëÀü
    None        // Âø¿ë x
}

[System.Serializable]
public class Item 
{
    [SerializeField] protected int itemNum;
    [SerializeField] protected ItemType itemType;
    [SerializeField] protected string itemName;
    [SerializeField] protected string itemToolTip;
    [SerializeField] private Equipped euipType;

    public Item(int n, ItemType t, string name, string tool , Equipped equ) 
    {
        this.itemNum = n;
        this.itemType = t;
        this.itemName = name;
        this.itemToolTip = tool;
        this.euipType = equ;
    }

    public int ItemNum { get => itemNum; set => itemNum = value; }
    public ItemType ItemType { get => itemType; set => itemType = value; }
    public string ItemName { get => itemName; set => itemName = value; }
    public string ItemToolTip { get => itemToolTip; set => itemToolTip = value; }
    public Equipped EuipType { get => euipType; set => euipType = value; }
}

[System.Serializable]
public class Equip : Item
{
    [SerializeField] private List<StatusType> itemStatus;
    [SerializeField] private List<int> itemStatusValue;
    public List<StatusType> ItemStatus { get => itemStatus; set => itemStatus = value; }
    public List<int> ItemStatusValue { get => itemStatusValue; set => itemStatusValue = value; }

    public Equip(int n, ItemType ty , string name, string tool , 
        List<StatusType> typeList, List<int> typeValue , Equipped equ ) : base(n, ty, name, tool ,equ)
    {
        this.itemStatus = typeList;
        this.itemStatusValue = typeValue;
    }

}

[System.Serializable]
public class UseItem : Item 
{
    public UseItem(int n, ItemType ty, string name, string tool , Equipped equ) 
        : base(n, ty, name, tool , equ)
    {
    }
}
