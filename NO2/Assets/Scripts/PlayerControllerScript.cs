using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public Rigidbody2D RB;
    public SpriteRenderer SR;
    public Collider2D Coll;
    public PlayerControllerScript PS;
    private bool onGround;
    public float Speed = 10f;
    public bool Alive = true;
    public float slowDownLength = 3f;
    public float jumpForce;
    public SlowMoScript timeManager;
    public ParticleSystem ps;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        Coll = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Alive)
        {
            Vector2 velocity = RB.velocity;
            //Movement
            if (Input.GetKey(KeyCode.D))
            {
                velocity.x = Speed;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                velocity.x = 0f - Speed;
            }
            else
            {
                velocity.x = 0f;
            }
            if (Input.GetKeyDown(KeyCode.W) && onGround)
            {
                velocity.y = jumpForce;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                velocity.y = (0f - Speed) / 2f;
            }
            //Slow-Mo
            if (Input.GetKeyDown(KeyCode.Space))
            {
                timeManager.SlowMotion();
            }
            RB.velocity = velocity;
        }
    }

    private void Jump()
    {
        RB.velocity = Vector2.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }

    public void Die()
    {
        Object.FindObjectOfType<God>().Alive = false;
        SR.color = Color.grey;
        Alive = false;
        Debug.Log("You Loose");
        timeManager.SlowMotion();
    }
}
