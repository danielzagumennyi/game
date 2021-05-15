using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;    

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public Image iconImage;
    public Text countText;
    public EquipmentController controller;

    public void SetItem(Sprite sprite, int count)
    {
        countText.text = count.ToString();
        iconImage.sprite = sprite;
        iconImage.enabled = true;
        countText.enabled = true;
    }

    public void Clear()
    {
        countText.text = "";
        iconImage.sprite = null;
        iconImage.enabled = false;
        countText.enabled = false;
    }

    
    public void OnPointerClick(PointerEventData eventData)
    {
        int index = transform.GetSiblingIndex();
        Debug.Log("click");
        Debug.Log(index);
        controller.ClickItem(index);
    }
}
