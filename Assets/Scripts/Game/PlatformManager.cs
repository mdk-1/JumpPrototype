using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to control playing jumping from platforms

public class PlatformManager : MonoBehaviour
{
    private float yForce = 10f;
    public static bool jumpCheck = false;
    public AudioSource jump;

    //if collision with platfrom, apply velocity on Y axis to rigidbody of player
    //play jump sound
    //apply jump check bool to true
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rB = collision.collider.GetComponent<Rigidbody2D>();
            if (rB != null)
            {
                //set velocity directly
                Vector2 velocity = rB.velocity;
                velocity.y = yForce;
                rB.velocity = velocity;
                jump.Play();
                jumpCheck = true;
            }
        }
    }

}
