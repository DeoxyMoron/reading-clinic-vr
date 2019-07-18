using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slots : MonoBehaviour
{

    private inventory invent;
    public int i;

    private void Start() {
        invent = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
    }

    private void Update() {
        if (transform.childCount <= 0) {
            invent.isFull[i] = false;
        }

        if (Input.GetKeyDown("1"))
        {
            DropItem(0);
        }

        if (Input.GetKeyDown("2"))
        {
            DropItem(1);
        }

        /*
        if (Input.GetKeyDown("3"))
        {
            DropItem(2);
        }

        if (Input.GetKeyDown("4"))
        {
            DropItem(3);
        }

        if (Input.GetKeyDown("5"))
        {
            DropItem(4);
        }
        */
    }
    public void DropItem(int p) {
        invent.slots[p].transform.GetChild(p).GetComponent<spawn>().SpawnDroppedItem();
        GameObject.Destroy(invent.slots[p].transform.GetChild(p).gameObject);
     }
}
