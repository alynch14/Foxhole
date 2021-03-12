using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : Enemy
{
    public Animator animator;
    private BatSonar sonar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Animation(animator);
    }

    public void Aggro(Vector3 playerPosition)
    {

    }
}
