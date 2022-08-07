using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorAnimation : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private float duration;

    private void OnEnable()
    {
        StartCoroutine(moveAnimation());
    }

    IEnumerator moveAnimation()
    {
        LeanTween.moveX(gameObject, transform.position.x + distance, duration).setLoopPingPong();
        yield return new WaitForSeconds(5f);
        this.gameObject.SetActive(false);
    }
}
