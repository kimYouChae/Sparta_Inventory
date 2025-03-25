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
    [SerializeField] GameObject[] itemSlot;         // 생성한 아이템 슬롯 

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
        if (itemSlot.Length <= 0)
            InitItemSlot(item);

        // 슬롯 이미지 업데이트

        // 슬롯 착용 업데이트

    }

    private void UpdateSlotImage(List<Item> item ) 
    {
        for(int i = 0; i < item.Count; i++) 
        {
            itemSlot[i].GetComponent<ClickItemSlot>().SetICon();
        }
    }

    private void InitItemSlot(List<Item> item) 
    {
        // 장비 생성
        for (int i = 0; i < item.Count; i++)
        {
            var temp = InstanceSlot();

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
