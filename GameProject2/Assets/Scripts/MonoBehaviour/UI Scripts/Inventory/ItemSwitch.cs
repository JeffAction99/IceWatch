using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SCRIPT BY LEA
public class ItemSwitch : MonoBehaviour
{
    private PlayerControls playerControls;
    [SerializeField]
    private ItemHolder inventory;

    private ItemSlot currentSlot;
    private int currentSlotIndex = 1;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        SelectItem();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchItem();
    }
    
    void SelectItem()
    {
        for(int i = 0; i < inventory.slots.Count; i++)
        {
            if(i == currentSlotIndex)
            {
                currentSlot = inventory.slots[i];
                currentSlotIndex = i;
            }
        }
    }

    void SwitchItem()
    {
        float scrollValue = playerControls.Game.InventoryScroll.ReadValue<float>();
        if (scrollValue > 0f) //forwards
        {
            if(currentSlotIndex >= inventory.slots.Count - 1)
            {
                currentSlotIndex = 0;
                currentSlot = inventory.slots[currentSlotIndex];
            }
            else
            {
                currentSlotIndex++;
                currentSlot = inventory.slots[currentSlotIndex];
            }
            Debug.Log("Scroll up");
        }
        if (scrollValue < 0f) //backwards
        {
            if(currentSlotIndex <= 0)
            {
                currentSlotIndex = inventory.slots.Count - 1;
                currentSlot = inventory.slots[currentSlotIndex];
            }
            else
            {
                currentSlotIndex--;
                currentSlot = inventory.slots[currentSlotIndex];
            }
            Debug.Log("Scroll down");
        }
    }

    public ItemSlot getCurrentSlot()
    {
        return currentSlot;
    }
}
