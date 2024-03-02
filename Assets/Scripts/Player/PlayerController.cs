using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float baseSpeed = 10f;
    public float sprintSpeed = 15f;
    private float speed = 10f;
    public float deceleration=1f;
    public float acceleration=2f;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 frameVelocity;
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
        //ApplyMovement();
    }
    void Move()
    {
        //this method was too slow 
        if(movement.x==0){
           frameVelocity.x =Mathf.MoveTowards(frameVelocity.x,0,deceleration*Time.fixedDeltaTime);
        }else{
            frameVelocity.x= Mathf.MoveTowards(frameVelocity.x,movement.x*speed,acceleration*Time.fixedDeltaTime);
        }
        if(movement.y==0){
          
           frameVelocity.y =Mathf.MoveTowards(frameVelocity.y,0,deceleration*Time.fixedDeltaTime);
        }else{
          
           frameVelocity.y =Mathf.MoveTowards(frameVelocity.y,movement.y*speed,acceleration*Time.fixedDeltaTime);
        }
        rb.velocity = movement.normalized * speed;
    }
    private void ApplyMovement(){
        //uncomment in fixed update to run
        rb.velocity=frameVelocity;
    }
}

