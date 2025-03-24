using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStatusPopUp : UiPopUp
{
    [Header("===Component===")]
    [SerializeField] Button backButton;

    private void Start()
    {
        backButton.onClick.AddListener(base.OffPanel);
    }

    // 인벤토리 업데이트
    public void SetUpPlayerStatus()
    {
        UpdateStatus();
    }

    public void UpdateStatus()
    {

    }

}
