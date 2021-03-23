using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : Enemy
{
    //public Animator animator;
    private BatSonar sonar;
    private bool aggro = false;
    private Vector3 targetPosition;
    private float attackCounter;
    public float waitAfterAttack = 3;
    public int batAttackSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCounter > 0)
        {
            attackCounter -= Time.deltaTime;
        }
        if (aggro)
        {
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        if (attackCounter <= 0)
        {
            if (targetPosition == Vector3.zero)
            {
                targetPosition = FoxMovement.instance.transform.position;
            }
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, batAttackSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) <= .1f)
            {
                attackCounter = waitAfterAttack;
                targetPosition = Vector3.zero;
            }
        }
    }

    private void FixedUpdate()
    {
        //Animation(animator);
    }

    public void Aggro(Vector3 playerPosition)
    {
        aggro = true;
        targetPosition = playerPosition;
    }
}
