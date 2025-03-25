using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickItemSlot : MonoBehaviour
{
    [SerializeField]
    private int slotNum;
    [SerializeField]
    private Image image;

    public int SlotNum { get => slotNum; set => slotNum = value; }

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void SetICon(Sprite sp ) 
    {
        image.sprite = sp;
    }
}
