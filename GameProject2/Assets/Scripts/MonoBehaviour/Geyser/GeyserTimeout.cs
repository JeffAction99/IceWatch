using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserTimeout : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(geyserTime());
    }

     IEnumerator geyserTime()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
