using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [Header("===Ui 컴포넌트===")]
    [SerializeField] private Button characterInfoSetUpButton;
    [SerializeField] private Button inventoryButton;

    private void Start()
    {
        // 캐릭터 
        characterInfoSetUpButton.onClick.AddListener(OnoffPlayerStatus);
        
        // 인벤토리 
        inventoryButton.onClick.AddListener(ItemManager.Instance.InventoryUI);
    }

    private void OnoffPlayerStatus() 
    {
        var temp = UIManager.Instance.ShowPopUp<CharacterStatusPopUp>();
        temp.SetUpPlayerStatus(CharacterManager.Instance.Character);
    }

    
}
