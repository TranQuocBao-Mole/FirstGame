using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovements : MonoBehaviour
{
    public Transform GroundCheckTransform; // Điểm kiểm tra có đang ở trên mặt đất không
    public float GroundCheckRadius; // Bán kính kiểm tra mặt đất
    public LayerMask GroundMask; // LayerMask để xác định mặt đất  
    void Start()
    {
        
    }

    void Update()
    {
        Move();
        if (OnGround())
        {
            transform.rotation = Quaternion.identity;
        }
     }

        public void Move()
        {
        float move = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(move, 0, 0);
        transform.position += movement * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (move < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (move > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (move != 0)
        {
            GetComponent<Animator>().SetBool("isRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isRunning", false);
        } 
        if (Input.GetKey(KeyCode.S)) 
        {
            GetComponent<Animator>().SetBool("isCrouching", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isCrouching", false);
        }
    }
    public void Jump()
    {
        if (OnGround())
        {
             GetComponent<Rigidbody2D>().AddForce(Vector3.up * 3.2f, ForceMode2D.Impulse);
        }
       
    }
      public bool OnGround()
    {
        return Physics2D.OverlapCircle(GroundCheckTransform.position, GroundCheckRadius, GroundMask);
    }

}