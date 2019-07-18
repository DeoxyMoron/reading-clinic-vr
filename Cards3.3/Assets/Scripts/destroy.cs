using UnityEngine;
using System.Collections;

public class destroy : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "block")
        {
            Destroy(col.gameObject);
        }
    }
}
