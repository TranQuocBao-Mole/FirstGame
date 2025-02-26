using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed ;
    private Transform player;
    void Start()
    {
        speed = 2f;
        player = GameObject.Find("Player").transform;
        if (player.localScale.x < 0)
        {
            speed = -speed;
        }
    }
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        Destroy(gameObject, 2f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Enemy"))
        {
            Debug.Log("Hit");
            Destroy(gameObject);
        }
    }
}
