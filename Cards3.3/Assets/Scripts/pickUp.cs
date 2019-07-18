using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUp : MonoBehaviour
{
    private inventory invent;
    public GameObject itemButton;

	private void Start()
	{
        //sets equal to inventory components of player
        invent = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
	}

	private void OnTriggerEnter(Collider other)
	{
        //check if item collided with player
        if (other.CompareTag("Player")) {
            //checks if inventory is full
            for (int i = 0; i < invent.slots.Length; i++) {
                print("hello");
                if(invent.isFull[i] == false) {
                    //add item to inventory
                    //inventory flot full now
                    invent.isFull[i] = true;
                    //spawns icon in inventory slot
                    Instantiate(itemButton, invent.slots[i].transform, false);
                    Destroy(gameObject);
                    //stop loop
                    break;
                }
            }
        }
	}
}
