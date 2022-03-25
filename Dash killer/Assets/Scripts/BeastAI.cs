using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastAI : EnemyAI
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Updatee();
    }
    protected override void Patroling()
    {

        if (!player.gameObject.GetComponent<PlayerController>().gameOver)
        {
            //  agent.SetDestination(walkPoint);
            if (!walkPointSet)
                SearchWalkPoint();
            if (walkPointSet)
                agent.SetDestination(walkPoint);
            Vector3 distanceToWalkPoint = transform.position - walkPoint;
            if (distanceToWalkPoint.magnitude < 1)
                walkPointSet = false;
        }
        else
        {
            agent.SetDestination(transform.position);
            animator.SetBool("gameOver", true);
        }
    }

    protected override void ChasePlayer()
    {
      
        if (!player.gameObject.GetComponent<PlayerController>().gameOver)
        {
            agent.SetDestination(player.position);
            transform.LookAt(player);
            agent.speed = 5;
            animator.SetInteger("Running", 0);
        }
        else
        {
            agent.SetDestination(transform.position);
            animator.SetBool("gameOver", true);
        }


        //  Debug.Log("chase player in enemy ai is working");
    }
    protected override void AttackPlayer()
    {
     

        if (!player.gameObject.GetComponent<PlayerController>().gameOver)
        {
            agent.speed = 10;
           // Debug.Log("beAi is working");
            agent.SetDestination(player.position);
            transform.LookAt(player);
            animator.SetInteger("Running", 1);
        }
        else
        {
            agent.SetDestination(transform.position);
            animator.SetBool("gameOver", true);
        }

    }
}
