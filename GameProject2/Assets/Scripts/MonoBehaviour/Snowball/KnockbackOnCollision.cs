using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackOnCollision : MonoBehaviour
{
    [SerializeField] private float knockbackStrength;
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

        if(rb != null)
        {
            //vector 3 of position of what player collided - position of player
            Vector3 direction = collision.transform.position - transform.position;
            direction.y = 0; //knockback horizontally

            //get normalized vector of direction
            rb.AddForce(direction.normalized * knockbackStrength, ForceMode.Impulse);
        }
    }
}
