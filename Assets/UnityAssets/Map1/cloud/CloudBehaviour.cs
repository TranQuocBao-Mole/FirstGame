using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour
{
    public float speed;
    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("CloudTarget");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (target.transform.position.x > transform.position.x)
        {
            Destroy(gameObject);
        }

    }
}