using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Physics Variables")]
    public float acceleration;
    public float maxSpeed;
    public float friction;
    public float jumpForce;
    public float fallMultiplier;

    //[HideInInspector]
    public bool onGround = false;
    public bool touchingLeft = false;
    public bool touchingRight = false;
    private Rigidbody2D rb;

    //double jump
    public int numJump;

    // Start is called before the first frame update
    void Start(){
        rb = gameObject.GetComponent<Rigidbody2D>(); // stores player's rigidbody (physics)
    }

    // Update is called once per frame
    void Update(){
        /*
        *   This handles left and right movement
        */
        if(Input.GetAxisRaw("Horizontal") != 0){
            if((Input.GetAxisRaw("Horizontal") > 0 && !touchingRight) || (Input.GetAxisRaw("Horizontal") < 0 && !touchingLeft)){
                rb.velocity += new Vector2(Input.GetAxisRaw("Horizontal") * acceleration, 0); // accelerate
            }
            rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxSpeed, maxSpeed), rb.velocity.y); // caps speed
        }else{
            rb.velocity = new Vector2(rb.velocity.x / friction, rb.velocity.y); // slows down faster
        }
    
        /*
        *   This handles jumping
        */
        if(Input.GetButtonDown("Jump")) { 
            if(onGround){
                 rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // jump
            }else{
                if(numJump != 0){
                    rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse); // jump
                    numJump--; 
                }
            }        
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            if(onGround){
                
                 rb.AddForce(new Vector2(30, 0), ForceMode2D.Impulse); // slide

            }
        }
        /*
        *   This handles gravity/fall speed
        */    
        if(rb.velocity.y < 0){
            rb.velocity = new Vector2(rb.velocity.x, (rb.velocity.y * fallMultiplier > -15 ? rb.velocity.y * fallMultiplier : -15)); // makes heavier falling
        }

        /*
        *   This handles on ground scenarios
        */
        if(onGround){
            numJump = 1;
            }
    }
}
