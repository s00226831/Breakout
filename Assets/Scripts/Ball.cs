using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //variables
    public float moveSpeed;
    public Rigidbody2D body;
    Vector2 direction;
    
    private void Start()
    {
        ResetPosition();
        SetDirection();
    }
    void ResetPosition()
    {
        //reset to 0,0
        transform.position = Vector2.zero;

        //Set velocity to zero
        body.velocity = Vector2.zero;
    }
    void SetDirection()
    {
        direction.x = Random.Range(20, 160);
        direction.y = Random.Range(20, 160);
        direction.Normalize();
        body.velocity = direction * moveSpeed;
    }
    public GameManager manager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Kill"))
        {
            ResetPosition();
            SetDirection();
            manager.OnLiveLost();
        }
        else if(collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
            manager.OnBlockDestroyed();

            if(manager.BlocksRemaining == 1)
            {
                //1. Find the last block
                GameObject lastBlock = GameObject.FindGameObjectWithTag("Block");
                //2. Calculate the direction to it
                Vector2 direction = lastBlock.transform.position - transform.position;
                direction.Normalize();
                //3. Set the velocity towards the block
                body.velocity = direction * moveSpeed;
            }
    
        }
    }


}

