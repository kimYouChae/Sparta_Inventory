using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickItemSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private int slotNum;
    [SerializeField]
    private Image image;

    public int SlotNum { get => slotNum; set => slotNum = value; }

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetICon(Sprite sp ) 
    {
        if (sp == null) 
        {
            Debug.Log($"ClickItemSlot - SetICon: {sp} 가 null");
            return;
        }
        if(image == null)
        {
            Debug.Log($"ClickItemSlot - SetICon: {image} 가 null");
            return;
        }

        try
        {
            image.sprite = sp;
        }
        catch (Exception e) { Debug.Log($"ClickItemSlot - SetICon: {e}"); }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // 클릭 시 인덱스 넘기기 
        ItemManager.Instance.ClickItemSlot(slotNum);
    }
}
