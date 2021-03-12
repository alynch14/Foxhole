using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, INPC
{
    public void Animation(Animator animator)
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
    }

    public void Movement()
    {
        throw new System.NotImplementedException();
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
