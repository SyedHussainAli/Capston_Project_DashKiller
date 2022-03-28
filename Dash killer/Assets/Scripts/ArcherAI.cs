using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAI : EnemyAI
{
    private Animator animator;
    public GameObject projectile;



 

    //Attacking 
    public float timeBetweenAttacks;
    bool alreadyAttacked;

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

    protected override void ChasePlayer()
    {
      
        if(!player.gameObject.GetComponent<PlayerController>().gameOver)
        {
            agent.SetDestination(player.position);
            transform.LookAt(player);
            agent.speed = 6;
        }
        else
        {
            agent.SetDestination(transform.position);
        }
       

      //  Debug.Log("chase player in archary ai is working");
    }
    protected override void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        
       
        if (!alreadyAttacked && !player.gameObject.GetComponent<PlayerController>().gameOver)
        {
           // Vector3 position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z + 1f);

         

            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(player.transform.position* 6, ForceMode.Impulse);
          //  rb.AddForce(transform.up * 9, ForceMode.Impulse);

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);

        }

    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
