using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//SCRIPT BY LEA

public class InventoryButton : MonoBehaviour
{
    [SerializeField]
    private Image itemIcon;
    [SerializeField]
    private Text stackAmount;

    public ItemSwitch currentSlot;
    //private ItemSlot slot;
    private ItemSlot highlightedSlot;


    /*public void SetIndex(int index)
    {
        itemIndex = index;
    }*/

    public void HighlightCurrentItem(ItemSlot slot)
    {
        highlightedSlot = currentSlot.getCurrentSlot();
        if (slot == highlightedSlot)
        {
            slot.item.isHighlighted = true;
        }
        else
        {
            slot.item.isHighlighted = false;
        }
    }

    public void ShowItem(ItemSlot slot)
    {
        itemIcon.gameObject.SetActive(true);
        itemIcon.sprite = slot.item.sprite;
        if(slot.item.isHighlighted)
        {
            itemIcon.color = new Color(1, 0, 0);
        }
        else if(!slot.item.isHighlighted)
        {
            itemIcon.color = new Color(1, 1, 1);
        }
        if(slot.item.stackable == true)
        {
            //change message displayed by text
            stackAmount.text = slot.amount.ToString();
            stackAmount.gameObject.SetActive(true);
        }
        else
        {
            //if not stackable no text
            stackAmount.gameObject.SetActive(false);
        }
    }

    //remove the item text & image with this function
    public void ClearItem()
    {
        itemIcon.sprite = null;
        itemIcon.gameObject.SetActive(false);
        stackAmount.gameObject.SetActive(false);
    }
}
