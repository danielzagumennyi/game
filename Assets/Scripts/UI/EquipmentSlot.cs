using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    public Image iconImage;

    public void SetItem(Sprite newIcon)
    {
        iconImage.sprite = newIcon;
    }
}
