using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject normalBulletPrefab;
    public float attackCooldown = 0.5f; // Thời gian giữa các lần tấn công
    private float nextAttackTime = 0f;

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                GameObject bullet = Instantiate(normalBulletPrefab, transform.position, transform.rotation);
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }
}