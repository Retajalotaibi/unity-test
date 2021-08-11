using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{

    public GameObject playerBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        Vector2 toTarget = playerBody.transform.position - transform.position;
        float speed = 0.5f;

        transform.Translate(toTarget * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
