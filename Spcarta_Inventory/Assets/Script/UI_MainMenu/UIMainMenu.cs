using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [Header("===Ui ������Ʈ===")]
    [SerializeField] private Button characterInfoSetUpButton;
    [SerializeField] private Button inventoryButton;

    private void Start()
    {
        // ĳ���� 
        characterInfoSetUpButton.onClick.AddListener(OnoffPlayerStatus);
        
        // �κ��丮 
        inventoryButton.onClick.AddListener(ItemManager.Instance.InventoryUI);
    }

    private void OnoffPlayerStatus() 
    {
        var temp = UIManager.Instance.ShowPopUp<CharacterStatusPopUp>();
        temp.SetUpPlayerStatus(CharacterManager.Instance.Character);
    }

    
}
