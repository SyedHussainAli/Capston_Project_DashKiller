
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling when enemy is far
    public Vector3 walkPoint;
    protected bool walkPointSet;
    public float walkPointRange ;



    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    
    private void Awake()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    public void Updatee()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
      //  Debug.Log("enemyAi is working");
        //checking player positions
        if (!playerInSightRange && !playerInAttackRange)
            Patroling();
        if (playerInSightRange && !playerInAttackRange)
            ChasePlayer();
        if (playerInSightRange && playerInAttackRange)
            AttackPlayer();
    }

    protected virtual void Patroling()
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
    }

    protected void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint,-transform.up,3f,whatIsGround))
        {
            walkPointSet = true;
        }
    }

    protected virtual void ChasePlayer()
    {
       
    }

    protected virtual void AttackPlayer()
    {
        
    }

    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
