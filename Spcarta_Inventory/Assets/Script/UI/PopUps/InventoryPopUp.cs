using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPopUp : UiPopUp
{
    [Header("===Component===")]
    [SerializeField] Button backButton;

    private void Start()
    {
        backButton.onClick.AddListener(base.OffPanel);
    }
}
