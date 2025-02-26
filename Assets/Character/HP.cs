using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public float health ; 
    public float dame;
    public float attackSpeed ;
    private float timer = 0f;
    void Update()
    {
        if (health <= 0)
        {
            if (this.CompareTag("Player"))
            {
                Debug.Log("Game Over");
                Time.timeScale = 0;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        HandleCollision(other.gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        HandleCollision(other.gameObject);
    }
    void OnCollisionStay2D(Collision2D other)
    { 
    
       timer += Time.deltaTime;
        if (timer >= attackSpeed)
        {
            DealsDamageOverTime(other.gameObject);
            timer = 0f; // Đặt lại bộ đếm thời gian
        }
   
    }
    void OnTriggerStay2D(Collider2D other)
    { 
    
       timer += Time.deltaTime;
        if (timer >= attackSpeed)
        {
            DealsDamageOverTime(other.gameObject);
            timer = 0f; // Đặt lại bộ đếm thời gian
        }
   
    }
    void OnCollisionExit2D(Collision2D other)
    {
        this.GetComponent<Animator>().SetBool("isHurt", false);   
    }
    void OnTriggerExit2D(Collider2D other)
    {
        this.GetComponent<Animator>().SetBool("isHurt", false);   
    }

    void HandleCollision(GameObject other)
    {
        float damage = 0;
        HP otherHP = other.GetComponent<HP>();
        if (otherHP != null)
        {
            damage = otherHP.dame;
        }

        if ((other.CompareTag("Attack") && !this.CompareTag("Player")) ||
            (other.CompareTag("Enemy") && this.CompareTag("Player")))
        {
            TakeDamage(damage);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Current Health: " + health);
        this.GetComponent<Animator>().SetBool("isHurt", true);   
        
    }
    private void DealsDamageOverTime(GameObject other)
    {
        HandleCollision(other);
    }

   


}