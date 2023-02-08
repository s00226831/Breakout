using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    public float movespeed;
    public Rigidbody2D body;
    float horizontal;
    Vector2 velocity;
    
    void Update()
    {
        //Get vertical input from the player
        horizontal = Input.GetAxisRaw("Horizontal");
        //Calculate the velocity
        velocity.x = movespeed * horizontal;
        //update the rigid body velocity
        body.velocity = velocity;

    }
}
