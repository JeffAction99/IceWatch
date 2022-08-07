using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SCRIPT BY LEA & SAM

public class FishingSystem : MonoBehaviour
{ 

    public SphereCast sphereCastScript;
    private bool fishingStatus = false; //could use an integer for this or enum
    private bool reaction = false;
    private int reeling = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && fishingStatus == false && sphereCastScript.currentHitObj != null)
        {
            //Debug.Log("F detected");
            if (sphereCastScript.currentHitObj.tag == "Water")
            {
                InitiateFishing();
            }
        }
        if (fishingStatus)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (reaction)
                {
                    reaction = false;
                    StopCoroutine(ReactTime());
                    Debug.Log("Fish Inbound, SPAM F!");
                    reeling++;
                    StartCoroutine(ReelTime());
                }
                if (reeling > 0)
                {
                    if(reeling < 15)
                    {
                        reeling++;
                    } else
                    {
                        Debug.Log("You Caught A Fish");
                        StopCoroutine(ReelTime());
                        reeling = 0;
                        fishingStatus = false;

                    }
                }
            }
            
        }
    }

    private void InitiateFishing()
    {
        Debug.Log("Fishing" );
        fishingStatus = true;
        StartCoroutine(BiteWait(5));
    }

    private IEnumerator BiteWait(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log(time);
        StartCoroutine(ReactTime());
    }
    private IEnumerator ReactTime()
    {
        reaction = true;
        yield return new WaitForSeconds(1f);

        if (reaction == true)
        {
            Debug.Log("You Left It too long");
        }

        reaction = false;
    }
    private IEnumerator ReelTime()
    {
        reeling = 1;
        yield return new WaitForSeconds(6);
        Debug.Log("the fish got away");
        reeling = 0;
        fishingStatus = false;
    }

}