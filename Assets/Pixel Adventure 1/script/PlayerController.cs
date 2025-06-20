using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rbody;
    Animator anim;

    bool walking = false, jumping = false, jumped = false, grounded = false;
    float speed = 10f, height = 20f, jumpTime = 0, walkTime = 0;
    int moveState;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Move(Vector3 dir)
    {
        walking = true;
        speed = Mathf.Clamp(speed, speed, 80f);
        walkTime += Time.deltaTime;

        transform.Translate(dir * speed * Time.deltaTime);

        if (walkTime < 3f && walking)
        {
            speed += 0.025f;
        }
        else if (walkTime > 3f)
        {
            speed = 10f;
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (grounded)
            {
                rbody.linearVelocity = new Vector2(rbody.linearVelocity.x, height);
            }
        }

        if (jumping && jumped)
        {
            rbody.gravityScale -= (0.1f * Time.fixedDeltaTime);
        }

        if (jumpTime > 1f)
        {
            jumping = false;
            jumpTime = 0;
        }

        if (!jumping && jumped)
        {
            rbody.gravityScale += 0.2f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            GameController.instance.GameOver();
            Time.timeScale = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            GameController.instance.GameOver();
            Time.timeScale = 0;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            jumped = false;
            jumping = false;

            anim.SetBool("Jump", false);
            jumpTime = 0;
            rbody.gravityScale = 5;
        }
    }

    void State()
    {
        switch (moveState)
        {
            case 1:
                anim.SetBool("Run", true);
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x),
                                                   transform.localScale.y,
                                                   transform.localScale.z);
                Move(Vector3.right);
                break;

            case 2:
                anim.SetBool("Run", true);
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x),
                                                   transform.localScale.y,
                                                   transform.localScale.z);
                Move(Vector3.left);
                break;

            default:
                walking = false;
                walkTime = 0;
                speed = 10f;
                anim.SetBool("Run", false);
                break;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            jumped = true;
            jumping = true;
            jumpTime += Time.fixedDeltaTime;
        }
        else
        {
            jumping = false;
        }
    }

    void Update()
    {
        State();
    }

    void FixedUpdate()
    {
        if (!Input.GetKey(KeyCode.RightArrow) &&
            !Input.GetKey(KeyCode.UpArrow) &&
            !Input.GetKey(KeyCode.LeftArrow))
        {
            moveState = 0;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveState = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveState = 2;
        }

        Jump();
    }
}
