using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTrees : MonoBehaviour
{

    bool grappleTree = true;

    public bool getGrappleTree() {
        return grappleTree;
    }

    public Vector2 getPosition() {
        Vector2 pos = gameObject.transform.position;
        return pos;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
