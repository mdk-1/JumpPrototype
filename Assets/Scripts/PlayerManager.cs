using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to control player movement and animation

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerManager : MonoBehaviour
{
    [Header ("Player calibration")]
    [SerializeField]
    private float movementSpeed = 10f;
    private float movement = 0f;
    public Animator anim;
    Rigidbody2D rB;

    // declare player components
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Apply movement and animations based on horizontal player input
    // control jump frequency with control bool
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        if (PlatformManager.jumpCheck == true)
        {
            anim.SetBool("Jump", true);
            PlatformManager.jumpCheck = false;
        }
        else if (PlatformManager.jumpCheck == false)
        {
            anim.SetBool("Jump", false);
        }
    }
    // apply movement to player rigidbody component
    void FixedUpdate()
    {
        Vector2 velocity = rB.velocity;
        velocity.x = movement;
        rB.velocity = velocity;
    }
}
