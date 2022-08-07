using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SCRIPT BY LEA

public class SnowballScript : MonoBehaviour
{
    private Vector3 baseScale;
    private Vector3 targetScale;
    private int age = 0;

    private float speed = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        //set base scale and target scale
        baseScale = transform.localScale;
        targetScale = baseScale * 100;
    }

    // Update is called once per frame
    void Update()
    {
        age++;
        if(age > 10000)
        {
            Destroy(gameObject);
            return;
        }
        StartCoroutine(scaleDown());
    }

    private IEnumerator scaleDown()
    {
        yield return new WaitForSeconds(8f);
        //melt the snow away after x amount of time
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);
    }
}
