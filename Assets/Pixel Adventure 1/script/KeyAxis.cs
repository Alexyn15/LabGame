using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAxis : MonoBehaviour
{
    float trucx = 5;
    float trucy = 5;
    float speed = 10;
    Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-trucx, trucy, 1);
            rigidbody2D.AddForce(new Vector2(-1 * speed, 0));
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(trucx, trucy, 1);
            rigidbody2D.AddForce(new Vector2(1 * speed, 0));
        }
    }
}