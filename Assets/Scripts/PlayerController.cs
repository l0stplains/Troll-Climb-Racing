using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float torqueAmount = 2000f; // Works fine with 5 angular drag
    [SerializeField] float normalSpeed = 20f;
    [SerializeField] float boostSpeed = 25f;
    [SerializeField] float slowSpeed = 10f;
    Rigidbody2D rb2d;
    SurfaceEffector2D se2d;
    bool canMove = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        se2d = FindObjectOfType<SurfaceEffector2D>();
    }


    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            PlayerSpeedControl();
        }
    }

    public void DisableControl()
    {
        canMove = false;
    }

    public void AbleControl()
    {
        canMove = true;
    }

    void PlayerSpeedControl()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            se2d.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            se2d.speed = slowSpeed;
        }
        else
        {
            se2d.speed = normalSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-1 * torqueAmount * Time.deltaTime);
        }
    }
}
