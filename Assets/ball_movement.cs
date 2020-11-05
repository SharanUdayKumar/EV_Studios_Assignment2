using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class ball_movement : NetworkBehaviour
{
    public Rigidbody2D rb;
   // [SerializeField]
    //public float jump_force;
   // public float raycastdist;
    public bool isgrounded;
    public LayerMask groundlayers;
    public bool ismoving;
    public Transform ball_downside;
    public float speed = 500f;
    [SyncVar]
    Vector3 targetpos;
    [SyncVar]
    public float ballsidedirection;
    public bool destroyleftball=false;
    public bool destroyrightball=false;
    leftballscript lbcs;
    rightballscript rbcs;
    

    //playermirrortrial PMT;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
         isgrounded = true;
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        lbcs = GameObject.FindObjectOfType<leftballscript>();
        rbcs = GameObject.FindObjectOfType<rightballscript>();
        print("ball is moving on this direction" + ballsidedirection);
       

        Debug.Log("is moving is" + ismoving + "targetpos.x is " + ballsidedirection);

        BallMove();

        if(gameObject.transform.position.x <-8  && lbcs.leftdestroyball== true)
        {
          // destroyleftball = true;
            Debug.Log("LeftPlayerScores");
         
            Destroy(gameObject);
            NetworkServer.DisconnectAll();
        }

        else if(gameObject.transform.position.x > 8 && rbcs.rightdestroyball == true)
        {
            Debug.Log("RightPlayerWins");
            Destroy(gameObject);
            NetworkServer.DisconnectAll();
        }
    }

     void BallMove()
    {
        Collider2D groundcheck = Physics2D.OverlapCircle(ball_downside.position, 0.005f, groundlayers);
        if (groundcheck != null)
        {
            isgrounded = true;
        }
        else
        {
            isgrounded = false;
        }

        if (ismoving == true)
        {
            targetpos = new Vector3(ballsidedirection, transform.position.y, transform.position.z);
           
            transform.position = Vector3.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
        }
    }
}
