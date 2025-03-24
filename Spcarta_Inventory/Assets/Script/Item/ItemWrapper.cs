using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWrapper : ICsvParsable
{
    
    public int itemNum;
    public ItemType itemType;
    public string itemName;
    public string itemToolTip;
    public List<StatusType> itemStatus;
    public List<int> itemStatusValue;

    public void Parse(string[] values)
    {
        // [0] Num
        // [1] EquipType
        // [2] itemname
        // [3] itemTooltip
        // [4] statusType
        // [5] statusValue

        itemNum = int.Parse(values[0]);
        itemType = (ItemType)Enum.Parse(typeof(ItemType), values[1]);
        itemName = values[2];
        itemToolTip = values[3];

        itemStatus = new List<StatusType>();
        var temp = values[4].Split("-");
        for (int i = 0; i < temp.Length; i++) 
        {
            itemStatus.Add((StatusType)Enum.Parse(typeof(StatusType), temp[i]));
        }

        itemStatusValue = new List<int>();
        var var = values[5].Split("-");
        for (int i = 0; i < temp.Length; i++)
        {
            itemStatusValue.Add(int.Parse(var[i]));
        }
    }
}
