using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour
{
    public float speed;
    public float distance;
    private Vector3 firstPoint; 

    // Start is called before the first frame update
    void Start()
    {
        firstPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        float dis = Vector2.Distance(firstPoint, transform.position);
        if (dis > distance)
        {
            Destroy(gameObject);
        }
    }
}