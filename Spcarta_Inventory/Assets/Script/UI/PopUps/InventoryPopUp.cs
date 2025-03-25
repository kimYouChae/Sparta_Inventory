using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPopUp : UiPopUp
{
    [Header("===Component===")]
    [SerializeField] Transform scrollContent;       // ��ũ�� content
    [SerializeField] GameObject itemSlotPrefab;     // ���� ������
    [SerializeField] List<GameObject> itemSlot;         // ������ ������ ���� 
    [SerializeField] List<GameObject> equiptText;       // ���� [E] �̹��� 

    [SerializeField] Button backButton;

    private void Start()
    {
        backButton.onClick.AddListener(base.OffPanel);
    }

    // �κ��丮 ������Ʈ
    public void SetUpInventory(List<Item> item)
    {
        UpdateInventory(item);
    }

    public void UpdateInventory(List<Item> item)
    {
        // ������� ������ ������ -> ����
        if (itemSlot.Count <= 0)
            InitItemSlot(item);

        // ���� �̹��� ������Ʈ
        UpdateSlotImage(item);

        // ���� ���� ������Ʈ
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
        // ��� ����
        for (int i = 0; i < item.Count; i++)
        {
            var temp = InstanceSlot();

            try
            {
                // �ڽ� ����Ʈ�� �ֱ� 
                equiptText.Add(temp.transform.GetChild(0).gameObject);
            }
            catch (Exception e) { Debug.Log($"InventoryPopUp - InitItemSlot : {e}"); }

            // ����Ʈ�� �ֱ� 
            itemSlot.Add(temp);

            // num �ֱ� 
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
