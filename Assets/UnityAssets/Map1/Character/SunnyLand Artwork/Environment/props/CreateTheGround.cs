using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTheGround : MonoBehaviour
{
    private GameObject player;
    private GameObject checkPoint;
    private BoxCollider2D boxCollider;

    void Start()
    {
        checkPoint = transform.GetChild(0).gameObject;
        player = GameObject.Find("Player");
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (checkPoint.transform.position.y <= player.transform.position.y)
        {
            boxCollider.enabled = true;
        }
        else
        {
            boxCollider.enabled = false;
        }
    }
}