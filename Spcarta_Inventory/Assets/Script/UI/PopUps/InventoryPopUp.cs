using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPopUp : UiPopUp
{
    [Header("===Component===")]
    [SerializeField] Transform scrollContent;       // 스크롤 content
    [SerializeField] GameObject itemSlotPrefab;     // 슬롯 프리팹
    [SerializeField] List<GameObject> itemSlot;         // 생성한 아이템 슬롯 
    [SerializeField] List<GameObject> equiptText;       // 착용 [E] 이미지 

    [SerializeField] Button backButton;

    private void Start()
    {
        backButton.onClick.AddListener(base.OffPanel);
    }

    // 인벤토리 업데이트
    public void SetUpInventory(List<Item> item)
    {
        UpdateInventory(item);
    }

    public void UpdateInventory(List<Item> item)
    {
        // 만들어진 슬롯이 없으면 -> 생성
        if (itemSlot.Count <= 0)
            InitItemSlot(item);

        // 슬롯 이미지 업데이트
        UpdateSlotImage(item);

        // 슬롯 착용 업데이트
        UpdateEquipSlot(item);
    }

    private void UpdateSlotImage(List<Item> item ) 
    {
        for(int i = 0; i < item.Count; i++) 
        {
            int currNum = item[i].ItemNum;
            
            ClickItemSlot cs;

            try
            {
                cs = itemSlot[i].GetComponent<ClickItemSlot>();
                cs.SetICon(ItemManager.Instance.ItemIcon[currNum]);

            }
            catch (Exception e) { Debug.Log($"InventoryPopUp - UpdateSlotImage: {e}"); }
        
        }
    }

    public void UpdateEquipSlot(List<Item> item) 
    {
        for (int i = 0; i < item.Count; i++)
        {
            try 
            {
                Equipped type = item[i].EuipType;
                if (type == Equipped.Equipped)
                    equiptText[i].SetActive(true);
                else
                    equiptText[i].SetActive(false);
            }
            catch (Exception e) { Debug.Log($"InventoryPopUp - UpdateEquipSlot: {e}"); }
        }
    }

    private void InitItemSlot(List<Item> item) 
    {
        // 장비 생성
        for (int i = 0; i < item.Count; i++)
        {
            var temp = InstanceSlot();

            try
            {
                // 자식 리스트에 넣기 
                equiptText.Add(temp.transform.GetChild(0).gameObject);
            }
            catch (Exception e) { Debug.Log($"InventoryPopUp - InitItemSlot : {e}"); }

            // 리스트에 넣기 
            itemSlot.Add(temp);

            // num 넣기 
            temp.GetComponent<ClickItemSlot>().SlotNum = item[i].ItemNum;

        }
    }

    private GameObject InstanceSlot() 
    {
        var temp = Instantiate(itemSlotPrefab);
        temp.transform.SetParent(scrollContent.transform);
        temp.transform.position = Vector3.zero;

        return temp;
    }

}
