using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [Header("===Ui ÄÄÆ÷³ÍÆ®===")]
    [SerializeField] private Button characterInfoSetUpButton;
    [SerializeField] private Button inventoryButton;

    private void Start()
    {
        inventoryButton.onClick.AddListener(OnoffInventrory);
        characterInfoSetUpButton.onClick.AddListener(OnoffPlayerStatus);
    }

    private void OnoffInventrory() 
    {
        var temp = UIManager.Instance.ShowPopUp<InventoryPopUp>();
        temp.SetUpInventory();
    }

    private void OnoffPlayerStatus() 
    {
        var temp = UIManager.Instance.ShowPopUp<CharacterStatusPopUp>();
        temp.SetUpPlayerStatus();
    }

    
}
