using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createObject : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;

    // This script will simply instantiate the Prefab when the game starts.

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity).AddComponent<pickUp>();
        }
    }
}
