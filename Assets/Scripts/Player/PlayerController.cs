using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float baseSpeed = 10f;
    public float sprintSpeed = 15f;
    private float speed = 10f;

    public Rigidbody2D rb;
    Vector2 movement;
    //public GameObject pauseMenu;
    void Start()
    {
       
    }

    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Tab))
        {
         //   pauseMenu.SetActive(!pauseMenu.activeSelf);
            if (pauseMenu.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
     
        //if timescale is = 0, then the game is paused
        if (Time.timeScale == 0f)
        {
            return;
        }
       */
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
    }
    void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        rb.velocity = movement.normalized * speed;
    }
}

