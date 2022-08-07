using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
//SCRIPT BY LEA

public class PlayerInputs : MonoBehaviour
{
    [Header("Player Input Field")]
    [SerializeField] private PlayerInput playerInput;

    [Header("Sphere cast Field")]
    [SerializeField] private SphereCast sphereCast;
    private GameObject currentHit;

    [Header("UI Canvas Fields")]
    [SerializeField] private GameObject choiceCanvas;
    [SerializeField] private GameObject noteCanvas;
    [SerializeField] private GameObject optionCanvas;
    [SerializeField] private Image indicatorUI;
    [SerializeField] private Text description;

    [Header("Items Fields")]
    [SerializeField] private Item snack;
    [SerializeField] private Note note;
    [SerializeField] private NoteDescriptions descriptions;
    private string[] text;

    [Header("Scripts Fields")]
    [SerializeField] private PlayerStatManagement stats;
    [SerializeField] private ItemSwitch currentItem;
    [SerializeField] private ItemHolder inventory;

    private bool openOption;
    private void Start()
    {
        openOption = true;
    }

    void Update()
    {
        print(openOption);

        //print(InputControlPath.ToHumanReadableString(playerControls.Game.Interact.bindings[0].effectivePath,InputControlPath.HumanReadableStringOptions.OmitDevice));
        currentHit = sphereCast.currentHitObj;
        readNote(note);
        if(optionCanvas.activeSelf)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if(!optionCanvas.activeSelf)
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (!noteCanvas.activeSelf && playerInput.actions["Escape"].triggered && openOption)
        {
            optionCanvas.SetActive(true);
        }

        if (currentHit == null) return;

        if (currentHit.tag == "Chest")
        {
            if(playerInput.actions["Interact"].ReadValue<float>()>0)
            {
                Destroy(sphereCast.currentHitObj.gameObject);
                choiceCanvas.SetActive(true);
            }

        }
        if(currentHit.tag == "Snack")
        {
            if (playerInput.actions["Interact"].ReadValue<float>() > 0)
            {
                inventory.Add(snack);
                Destroy(sphereCast.currentHitObj);
            }
            if (playerInput.actions["Use"].ReadValue<float>() > 0)
            {
                stats.setStaminaPlayer(-20); //add 20 to stamina of player if eat
                Destroy(sphereCast.currentHitObj);
            }
        }
        if(currentHit.tag == "ResearchNote")
        {
            if (playerInput.actions["Interact"].triggered)
            {
                inventory.Add(note);
                noteCanvas.SetActive(true);
                openOption = false;
                Destroy(sphereCast.currentHitObj);
            }
        }

        if (currentItem.getCurrentSlot().item == null) return;

        if(currentItem.getCurrentSlot().item.title == "Snack")
        {
            if (playerInput.actions["Interact"].triggered)
            {
                inventory.Remove(currentItem.getCurrentSlot().item);
                stats.setStaminaPlayer(-20);
            }
        }
    }

    public void readNote(Note note)
    {
        if(noteCanvas.activeSelf)
        {
            description.text = descriptions.text[note.order];
            if (note.order == 0)
            {
                indicatorUI.gameObject.SetActive(true);
            }
            if (noteCanvas.activeSelf && playerInput.actions["Escape"].triggered)
            {
                noteCanvas.SetActive(false);
                note.order++;
                StartCoroutine(openOptionEnable());
            }
        }
    }

    IEnumerator openOptionEnable()
    {
        yield return new WaitForSeconds(3);
        openOption = true;
    }
}
