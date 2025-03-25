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
    [SerializeField] GameObject[] itemSlot;         // ������ ������ ���� 

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
        if (itemSlot.Length <= 0)
            InitItemSlot(item);

        // ���� �̹��� ������Ʈ

        // ���� ���� ������Ʈ

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
        // ��� ����
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
