using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1f;

    private float xInput, zInput;

    private CharacterController controller;

    private RPCSpriteHandler sprite;

    private bool facingRight;


    private void Awake()
    {
        controller = GetComponentInChildren<CharacterController>();
        sprite = GetComponentInChildren<RPCSpriteHandler>();
    }

    void Update()
    {
        HandleInput();

        if(xInput < 0 && facingRight)
        {
            facingRight = false;
            sprite.flip(true);
        }
        else if(xInput > 0 && !facingRight)
        {
            facingRight = true;
            sprite.flip(false);
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void HandleInput()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
    }

   void Move()
    {
        float xForce = xInput * moveSpeed;
        float zForce = zInput * moveSpeed;

        controller.Move(new Vector3(xForce, 0, zForce));

        //transform.position = new Vector3(transform.position.x + deltaX, transform.position.y, transform.position.z + yForce);
    }
}
