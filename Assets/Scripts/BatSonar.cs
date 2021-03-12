using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BatSonar : MonoBehaviour, ISonar
{
    public CircleCollider2D sonar;
    public float maxRadius = 10.0f;
    UnityEvent wakeUp = new UnityEvent();
    private BatController myBat;

    public BatSonar(BatController sonarOwner)
    {
        myBat = sonarOwner;
    }

    // Start is called before the first frame update
    void Start()
    {
        sonar.radius = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        EmitSonar();
    }

    public void EmitSonar()
    {
        if (Mathf.Abs(maxRadius - sonar.radius) > 0.1)
        {
            sonar.radius += 0.1f;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            myBat.Aggro(collision.gameObject.transform.position);
        }
        
    }
}
