﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugControllerInput : MonoBehaviour {

    private BlockManager blockmanager;

    //Object Collision
    private GameObject collidingObject;
    private GameObject objectInHand;

    private GameObject collidingBlockControl;

    private string onset = "un";
    private string root = "comfort";
    private string offset = "able";



    // Use this for initialization
    void Awake () {
		blockmanager = GetComponent<BlockManager>();
	}

    private void SetCollidingObject(Collider col) {
        // 1


        if (col.tag == "BlockSpawn")
        {
            collidingBlockControl = col.gameObject;
            collidingObject = null;
            return;
        }

        else if (collidingObject || !col.GetComponent<Rigidbody>()) {
            return;
        }
        // 2
        collidingObject = col.gameObject;
    }
    public void OnTriggerEnter(Collider other) {
        SetCollidingObject(other);
    }

    // 2
    public void OnTriggerStay(Collider other) {
        SetCollidingObject(other);
    }

    // 3
    public void OnTriggerExit(Collider other) {

        collidingBlockControl = null;

        if (!collidingObject) {
            return;
        }

        collidingObject = null;
    }

    private void GrabObject() {
        // 1
        objectInHand = collidingObject;
        collidingObject = null;
        // 2
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();

        /*
        //Check if holding block
        if (objectInHand.tag == "Block") {

            //EXECUTE BLOCK FINDING OTHER BLOCKS
            objectInHand.GetComponent<Codeblock_Model>().setGrabbed(true);
        }
        */
    }

    // 3
    private FixedJoint AddFixedJoint() {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }


    private void ReleaseObject() {
        // 1
        if (GetComponent<FixedJoint>()) {
            // 2
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            // 3 - Sets object velocity to the controller's velocity
            objectInHand.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = GetComponent<Rigidbody>().angularVelocity;
        }
        // 4
        objectInHand.GetComponent<Codeblock_Model>().setGrabbed(false);
        objectInHand = null;
    }


    void Update () {
        
        // Input mapping for object grabbing.

        if (Input.GetKeyDown("space")) {
            if (collidingObject) {
                GrabObject();
            }

            if (collidingBlockControl) {

                if (collidingBlockControl.name == "BlockSpawnMoveForward")
                {
                    blockmanager.SpawnMoveForward("hello");

                }

                else if (collidingBlockControl.name == "BlockSpawnTurnRight")
                {
                    blockmanager.SpawnTurnRight("hi");
                }

                else if (collidingBlockControl.name == "BlockSpawnTurnLeft")
                {
                    blockmanager.SpawnTurnLeft("hi");
                }
                /*
             	else if (collidingBlockControl.name == "BlockDelete")
                {
					blockmanager.Clear();
                }
                */

                collidingBlockControl = null;
            }
            collidingBlockControl = null;

        }

        if (Input.GetKeyUp("space")) {
            if (objectInHand) {
                ReleaseObject();
            }
        }


        // Input mapping for block creation
   
        if (Input.GetKeyDown("2")) {
            //Debug.Log("Up");
            if (collidingObject) {

            }
            else {
                //Create a move forward motion block.
                blockmanager.SpawnMoveForward(root);
            }
        }

        else if (Input.GetKeyDown(KeyCode.Backspace)) {
            //Debug.Log("Down");
            if (collidingObject) {
                if (collidingObject.name != "Green Flag Block") {
                    Destroy(collidingObject);
                }
            }
        }

        else if (Input.GetKeyDown("3")) {
            //Debug.Log("Right");
            if (collidingObject) {
                //collidingObject.GetComponent<BlockInfo>().increment();
            }
            else {
                blockmanager.SpawnTurnRight(offset);
            }
        }

        else if (Input.GetKeyDown("1")) {
            //Debug.Log("Left");
            if (collidingObject) {
                //collidingObject.GetComponent<BlockInfo>().decrement();
            }
            else {
                blockmanager.SpawnTurnLeft(onset);
            }
        }

        /*
        else if (Input.GetKeyDown("4"))
        {
            //Debug.Log("Left");
            if (collidingObject)
            {
                //collidingObject.GetComponent<BlockInfo>().decrement();
            }
            else
            {
                //blockmanager.Test("hello");
            }
        }

        //Alternate inputs for increasing and decreasing parameter values:
        else if (Input.GetKeyDown("=")) {
            if (collidingObject) {
                //collidingObject.GetComponent<BlockInfo>().increment();
            }
        }

        else if (Input.GetKeyDown("-")) {
            if (collidingObject) {
                //collidingObject.GetComponent<BlockInfo>().decrement();
            }
        }
        */
    }
}
