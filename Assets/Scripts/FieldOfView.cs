using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
   [Range(0,360)]
   public float viewAngle;

    public Vector3 DirFromAngle(float angDegrees) {
        return new Vector3(Mathf.Sin(angDegrees * Mathf.Deg2Rad), Mathf.Cos(angDegrees * Mathf.Deg2Rad), 0);
    }
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
