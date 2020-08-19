using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor (typeof (FieldOfView))]
public class FieldOfViewEditor : Editor
{
    void OnSceneGUI() {
        FieldOfView fow = (FieldOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.forward, Vector3.right, 360, fow.viewRadius);
        Vector3 viewAngleA = fow.DirFromAngle (-fow.viewAngle / 2);
        Vector3 viewAngleB = fow.DirFromAngle (fow.viewAngle / 2);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.viewRadius);

    }
}
