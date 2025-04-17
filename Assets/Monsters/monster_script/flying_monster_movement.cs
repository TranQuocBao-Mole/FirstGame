using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flying_monster_movement : MonoBehaviour
{
    public float speed = 10f;
    public float attackRadius = 0.5f; // Bán kính tấn công
    private Vector2 startPosition;
    private GameObject player;
    public LayerMask playerLayer; // Layer của player

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {   
        // Nếu tìm thấy player trong vòng tròn
        if (isPlayerInRange())
        {
            Debug.Log("Player in range");
            Vector2 direction = ((Vector2)player.transform.position - (Vector2)transform.position).normalized;
            transform.position = (Vector2)transform.position + direction * speed * Time.deltaTime;
        }
    }
    public bool isPlayerInRange()
    {
        return Physics2D.OverlapCircle(transform.position, attackRadius, playerLayer);
    }
}
