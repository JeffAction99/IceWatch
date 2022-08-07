using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class ItemSlot
{
    public Item item;
    public int amount;

    public void Clear()
    {
        item = null;
        amount = 0;
    }
}

[CreateAssetMenu(fileName = "Inventory", menuName = "Assets/ItemHolder")]
public class ItemHolder : ScriptableObject
{
    public List<ItemSlot> slots;

    public void Add(Item itemToAdd, int count = 1)
    {
        if(itemToAdd.stackable)
        {
            //STACKABLE
            //look for item in list
            ItemSlot itemSlot = slots.Find(x => x.item == itemToAdd);
            //if item was found => not null
            if(itemSlot != null)
            {
                itemSlot.amount += count;
            }
            //if no item found => null
            else
            {
                //we dont have it so we look for empty space
                itemSlot = slots.Find(x => x.item == null);
                if(itemSlot != null) //empty space found
                {
                    itemSlot.item = itemToAdd;
                    itemSlot.amount = count;
                }
                else
                {
                    Debug.Log("Inventory full");
                }
            }
        }
        else
        {
            //NON STACKABLE 
            //look for empty space
            ItemSlot itemSlot = slots.Find(x => x.item == null);
            //if we found empty space => itemslot != null
            if (itemSlot != null)//empty space found
            {
                itemSlot.item = itemToAdd; //we add item
            }
            else
            {
                Debug.Log("Inventory Full");
            }
        }
    }

    public void Remove(Item itemToRemove, int count = 1)
    {
        if(itemToRemove.stackable)
        {
            ItemSlot itemSlot = slots.Find(x => x.item == itemToRemove);
            if(itemSlot != null)
            {
                //if we have more than one only remove one but if last one remove item fully
                if (itemSlot.amount > 1)
                {
                    itemSlot.amount -= count;
                }
                else if (itemSlot.amount == 1)
                {
                    itemSlot.Clear();
                }
            }
        }
        else
        {
            //if we found the item and its not stackable => just need to clear it to remove it
            ItemSlot itemSlot = slots.Find(x => x.item == itemToRemove);
            if (itemSlot != null)
            {
                itemSlot.Clear();
            }
        }
    }
}
