using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject Enemy;
    public float SpawnTime ;

    void OnEnable()
    {
        StartCoroutine(SpawnEnemy());
    }

    void OnDisable()
    {
        StopCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {       
                yield return new WaitForSeconds(SpawnTime);
                if (transform.childCount < 1)
                {
                    GameObject newEnemy = Instantiate(Enemy, transform.position, transform.rotation);
                    newEnemy.transform.parent = transform;
                }
                
        }
    }
}