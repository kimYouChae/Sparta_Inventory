using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPopUp : UiPopUp
{
    [Header("===Component===")]
    [SerializeField] Transform scrollContent;
    [SerializeField] GameObject itemSlotPrefab;
    [SerializeField] GameObject[] itemSlot;

    [SerializeField] Button backButton;

    private void Start()
    {
        backButton.onClick.AddListener(base.OffPanel);
    }

    // 인벤토리 업데이트
    public void SetUpInventory()
    {
        UpdateInventory();
    }

    public void UpdateInventory()
    {
                
    }
}
