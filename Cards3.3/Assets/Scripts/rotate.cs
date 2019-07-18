using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{

    public float speed = 50.0f;

    public bool updateOn = true;

    void Start()
    {
        StartCoroutine(updateOff());
    }

    void Update()
    {
        if (updateOn == true)
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
            //whatever you want update to do.
        }
        // if you want certain parts of update to work at all times write them here.
    }

    IEnumerator updateOff()
    {
        yield return new WaitForSeconds(15.0f);
        updateOn = false;
    }
}