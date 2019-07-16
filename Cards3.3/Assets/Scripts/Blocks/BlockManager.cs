using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {
	public GameObject motionblock_moveforward;
	public GameObject motionblock_turnRight;
	public GameObject motionblock_turnLeft;
	public GameObject spawnNode;
    public GameObject spawnNode2;
    public GameObject spawnNode3;
    //public GameObject delete;

    private GameObject[] blocks;
    //private GameObject greenFlagBlock;

    /// <summary>Spawns a "Move Forward" motion block at the spawn node.</summary>
	public void SpawnMoveForward(string d) {
		GameObject clone;
        clone = Instantiate(motionblock_moveforward, spawnNode2.transform.position, spawnNode2.transform.rotation) as GameObject;
		clone.GetComponent<BlockInfo>().opcode = "move_forward";
		clone.GetComponent<BlockInfo>().setParams(d);
        clone.GetComponent<BlockInfo>().name = "middle";
        //clone.transform.localScale = new Vector3(scalex, scaley, scalez);
	}

    /// <summary>
    /// Spawns a "Turn Right" motion block at the spawn node.
    /// </summary>
	public void SpawnTurnRight(string d) {
		GameObject clone;
        clone = Instantiate(motionblock_turnRight, spawnNode3.transform.position, spawnNode3.transform.rotation) as GameObject;
		clone.GetComponent<BlockInfo>().opcode = "turn_right";
		clone.GetComponent<BlockInfo>().setParams(d);
        clone.GetComponent<BlockInfo>().name = "suffix";
	}

    /// <summary>
    /// Spawns a "Turn Left" motion block at the spawn node.
    /// </summary>
	public void SpawnTurnLeft(string d) {
		GameObject clone;
		clone = Instantiate(motionblock_turnLeft, spawnNode.transform.position, spawnNode.transform.rotation) as GameObject;
		clone.GetComponent<BlockInfo>().opcode = "turn_left";
		clone.GetComponent<BlockInfo>().setParams(d);
        clone.GetComponent<BlockInfo>().name = "prefix";
	}
	
    /*
    public void Clear()
    {
        //Clears all blocks
        blocks = GameObject.FindGameObjectsWithTag("Block");

        greenFlagBlock = GameObject.Find("Green Flag Block");


        //Debug.Log(blocks);

		//deletes last created obj
        foreach (GameObject obj in blocks)
        {
            if (obj.name == greenFlagBlock.name)
            {
                //Debug.Log("wwwww");
            }
            else
            {
                Destroy(obj);
				break;
            }
        }

		//deletes selected block
		foreach (GameObject obj in blocks)
		{
			if (obj.name == greenFlagBlock.name)
			{
				//Debug.Log("wwwww");
			}
			else
			{
				Destroy(obj);
				break;
			}
		}
    }
    */
}
