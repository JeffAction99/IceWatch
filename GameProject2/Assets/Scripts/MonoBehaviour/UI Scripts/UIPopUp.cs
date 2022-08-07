using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopUp : MonoBehaviour
{
    //Script if a UI element needs to pause the game
    void Update()
    {
        if (this.gameObject.activeSelf)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
