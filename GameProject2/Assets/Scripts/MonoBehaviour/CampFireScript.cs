using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFireScript : MonoBehaviour
{
    public PlayerStatManagement stats;
    private bool timeout;
    // Start is called before the first frame update

    private void OnTriggerStay(Collider other)
    {
        if (timeout == false)
        {
            stats.playerTemp += 3f;
            stats.playerTemp = Mathf.Clamp(stats.playerTemp, -5, 45);
            StartCoroutine(IncreaseTemp());
        }
    }

    private IEnumerator IncreaseTemp()
    {
        timeout = true;
        yield return new WaitForSeconds(1);
        timeout = false;
    }
}
