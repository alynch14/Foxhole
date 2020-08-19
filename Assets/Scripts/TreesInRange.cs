using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TreesInRange : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        GameObject[] grappleTrees = GameObject.FindGameObjectsWithTag("Grapple Tree");
        GameObject[] orderedTrees = grappleTrees.OrderBy(e => Vector3.Distance(this.transform.position, e.transform.position)).ToArray();
        // Vector3 forward = transform.TransfromDirection(Vector3.forward) * 10;
        int layerMask = 0 << 10;
        layerMask = ~layerMask;
        foreach (var tree in orderedTrees)
        {
            RaycastHit2D hitTree = Physics2D.Raycast(this.transform.position, tree.GetComponent<Rigidbody2D>().position);
            float angle = Vector3.Angle(this.transform.position, tree.transform.position);

            if (hitTree.collider != null)
            {
                BasicTrees treeDetected = hitTree.collider.GetComponent<BasicTrees>();
                Debug.DrawRay(gameObject.transform.position, new Vector3((-gameObject.GetComponent<Rigidbody2D>().position.x) + tree.transform.position.x, tree.transform.position.y - gameObject.GetComponent<Rigidbody2D>().position.y, 0), Color.blue, 0.2f, false);
                Debug.Log(gameObject.GetComponent<Rigidbody2D>().position.x);
                Debug.Log(hitTree.point.x);
                if (treeDetected)
                {
                    Debug.Log("Detected");
                }
                else
                {
                    Debug.Log("Not Detected");
                }
            }
        
        
        }
    }
}
