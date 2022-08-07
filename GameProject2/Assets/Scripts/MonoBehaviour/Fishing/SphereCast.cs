using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereCast : MonoBehaviour
{
    public GameObject currentHitObj = null;

    public Vector3 origin;
    public float rad;
    private Vector3 direction;
    public float maxDist;
    private float curDist;
    public LayerMask layerMask;

    void LateUpdate()
    {
        origin = transform.position;
        direction = transform.forward;
        RaycastHit hit;

        if (Physics.SphereCast(origin, rad,direction, out hit, maxDist, layerMask, QueryTriggerInteraction.UseGlobal))
        {
            currentHitObj = hit.transform.gameObject;
            curDist = hit.distance;
        } else
        {
            currentHitObj = null;
            curDist = maxDist;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Debug.DrawLine(origin, origin + direction * curDist);
        Gizmos.DrawWireSphere(origin + direction * curDist, rad);
    }
}
