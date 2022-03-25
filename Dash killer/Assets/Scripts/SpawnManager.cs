using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] enemySpawner;
    private PlayerController player;
    private float xRange=14.7f;
    private float zRange = 14.7f;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        StartCoroutine("Spawner");
    }
    IEnumerator Spawner()
    {

        while (!player.gameOver)
        {
            yield return new WaitForSeconds(1.5f);
            Vector3 position = new Vector3(Random.Range(-xRange, xRange), 0.96f, Random.Range(-zRange, zRange));
            int index = Random.Range(0, enemySpawner.Length);
            Instantiate(enemySpawner[index],position,enemySpawner[index].transform.rotation);
        }
       
    }

}
