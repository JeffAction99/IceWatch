using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://answers.unity.com/questions/1657594/how-to-spawn-prefab-anywhere-within-box-collider-2.html
//part taken from here to spawn inside box collider

public class GeyserSpawner : MonoBehaviour
{
    //area of spawn 
    private float spawnSizeArea = 10f;
    [SerializeField] private BoxCollider bc;
    [SerializeField] private GameObject geyser;

    Vector3 cubeSize;
    Vector3 cubeCenter;

    // Update is called once per frame

    private void Awake()
    {
        Transform cubeTrans = bc.GetComponent<Transform>();
        cubeCenter = cubeTrans.position;

        // Multiply by scale because it does affect the size of the collider
        cubeSize.x = cubeTrans.localScale.x * bc.size.x;
        cubeSize.y = cubeTrans.localScale.y * bc.size.y;
        cubeSize.z = cubeTrans.localScale.z * bc.size.z;
    }
    void Update()
    {
        if (Random.Range(1, 1000) < 5)
        {
            SpawnGeyser();
        }
    }

    private void SpawnGeyser()
    {
        //print("spawn");
        //change rotation
        Instantiate(geyser, GetRandomPosition(), Quaternion.identity);
    }

    private Vector3 GetRandomPosition()
    {
        // You can also take off half the bounds of the thing you want in the box, so it doesn't extend outside.
        // Right now, the center of the prefab could be right on the extents of the box
        Vector3 randomPosition = new Vector3(Random.Range(-cubeSize.x / 2, cubeSize.x / 2), Random.Range(-cubeSize.y / 2, cubeSize.y / 2), Random.Range(-cubeSize.z / 2, cubeSize.z / 2));

        return cubeCenter + randomPosition;
    }
}
