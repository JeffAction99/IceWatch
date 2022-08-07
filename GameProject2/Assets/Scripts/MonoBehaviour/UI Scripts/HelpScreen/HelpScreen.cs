using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
//Script by Lea

public class HelpScreen : MonoBehaviour
{
    [Header("Player Input Field")]
    [SerializeField] private PlayerInput playerInput;

    [Header("Sphere cast Field")]
    [SerializeField] private SphereCast sphereCast;
    private GameObject currentHit;

    [Header("Text Fields")]
    [SerializeField] private Text keyBindHelp1;
    [SerializeField] private Text keyBindHelp2;
    [SerializeField] private Text keyBindHelpMiddle;

    private void Update()
    {
        currentHit = sphereCast.currentHitObj;
        if (currentHit == null) return;
        
        if (currentHit.tag == "Chest")
        {
            keyBindHelpMiddle.text = "[" + InputControlPath.ToHumanReadableString(playerInput.actions["Interact"].bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice) + "] Open";
            return;
        }
        if(currentHit.tag == "ResearchNote")
        {
            keyBindHelpMiddle.text = "[" + InputControlPath.ToHumanReadableString(playerInput.actions["Interact"].bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice) + "] Pick up";
            return;
        }
        if(currentHit.tag == "Snack")
        {
            keyBindHelpMiddle.text = "[" + InputControlPath.ToHumanReadableString(playerInput.actions["Interact"].bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice) + "] Pick up \r\n [" + InputControlPath.ToHumanReadableString(playerInput.actions["Use"].bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice) + "] Eat";
        }
        else
        {
            keyBindHelp1.text = "[" + InputControlPath.ToHumanReadableString(playerInput.actions["Slow"].bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice) + "] Slow down";
            keyBindHelp2.text = "[" + InputControlPath.ToHumanReadableString(playerInput.actions["Boost"].bindings[0].effectivePath, InputControlPath.HumanReadableStringOptions.OmitDevice) + "] Boost";
            keyBindHelpMiddle.text = "";
            return;
        }
    }
}
