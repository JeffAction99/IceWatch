using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextOnCollision : MonoBehaviour
{
    [SerializeField] Text helpText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //helpText.text = "Retrieve lost notes in an abandoned building and exit the place";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            helpText.text = "";
        }
    }
}
