using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSceneOnCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //end scene
            SceneManager.LoadScene(2);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
