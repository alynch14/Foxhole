using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class BatSonar : MonoBehaviour, ISonar
{
    public CircleCollider2D sonar;
    public float maxRadius = 10.0f;
    UnityEvent wakeUp = new UnityEvent();
    private BatController myBat;
    private bool playerDetected = false;
    public BatSonar(BatController sonarOwner)
    {
        myBat = sonarOwner;
    }

    // Start is called before the first frame update
    void Start()
    {
        myBat = this.GetComponentInParent<BatController>();
        sonar.radius = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        EmitSonar();
    }

    void FixedUpdate()
    {
       
    }

    public void EmitSonar()
    {
        if (maxRadius > sonar.radius && !playerDetected)
        {
           sonar.radius += (0.1f * Time.deltaTime);
           //Code to draw circle collider in editor
           //Handles.DrawWireDisc(this.gameObject.transform.position, Vector3.forward, sonar.radius);
        }
        else
        {
            sonar.gameObject.SetActive(false);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerDetected = true;
            myBat.Aggro(collision.gameObject.transform.position);
        }
    }
}
