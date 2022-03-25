using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    int range = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyChecker();
    }

    private void EnemyChecker()
    {

        //  out RaycastHit hitinfo;

        Vector3 direction = Vector3.forward;
        Ray downRay = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range), Color.red);

/*        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 200))
        {
            Debug.Log("working");
            // Debug.Log("enemyHit");
            //animator.SetBool("nearEnemy", true);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);

        }
        else
        {
            // Debug.Log("nothing hit");
            // animator.SetBool("nearEnemy", false);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
            // Debug.DrawRay(enemyDetector.transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.yellow);
        }*/
    }
}
