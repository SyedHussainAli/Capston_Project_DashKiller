using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera mainCamera;
    public float dashSpeed=20;
    private Animator animator;
    public float dashTime;
    private bool allowKill = false;
    public GameObject enemyDetector;
    float range = 14.74f;
    public bool gameOver;
    

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        PlayerRotation();

        GroundChecker();
        //Movement through mouse
        if (Input.GetMouseButtonDown(0))
        {
            var mousePositions = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var distance = Vector3.Distance(transform.position, mousePositions);
            dashSpeed = distance;
            //    Debug.Log(dashSpeed);
            StartCoroutine(Dash());

        }

    }

    private void GroundChecker()
    {
        if (transform.position.x < -range)
        {
            transform.position = new Vector3(-range, transform.position.y, transform.position.z);
        }
        if (transform.position.x > range)
        {
            transform.position = new Vector3(range, transform.position.y, transform.position.z);
        }
        if (transform.position.z < -range)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -range);
        }
        if (transform.position.z > range)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, range);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && allowKill)
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy") && !allowKill)
        {
            Destroy(collision.gameObject);
            animator.SetBool("isDead", true);
            gameOver = true;
        }
    }

    
    IEnumerator Dash()
    {
        float startTime = Time.time;
        while(Time.time<startTime+dashTime&& !gameOver)
        {
          
            allowKill = true;
            transform.Translate(Vector3.forward *  dashSpeed * Time.deltaTime);
            animator.SetInteger("running", 1);
            yield return null;
          
        }
        yield return null;
         animator.SetInteger("running", 0);
        allowKill = false;
    }

    private void PlayerRotation()
    {
        if (!gameOver)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);  //PlayerRotation Code
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                transform.LookAt(hit.point);
                transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
            }
        }

    }




}
