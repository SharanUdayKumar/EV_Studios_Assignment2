using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class playermirrortrial : NetworkBehaviour
{
    [SyncVar]
    public float _finaltarget;

    ball_movement BM;

    public Vector3 targetpos;
    public bool move;
    
    // Start is called before the first frame update

    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        BM = GameObject.FindObjectOfType<ball_movement>().GetComponent<ball_movement>();
        if (isLocalPlayer && Input.GetMouseButton(0))
      
     
        {
            Debug.Log("sending ola::");
            CmdLefttoRightMousetrack(_finaltarget);
        }
        else if(isServer && Input.GetMouseButton(0))
             {

            RpcLefttoRightMouseTrack(_finaltarget);
            }
            //Debug.Log(_finaltarget);


            Debug.Log("playerisalive");
       

        
        BM.ballsidedirection = _finaltarget;

    }

    [Command]
    void CmdLefttoRightMousetrack(float finaltarget)
    {
        RpcLefttoRightMouseTrack(_finaltarget);
    }

    [ClientRpc]
    void RpcLefttoRightMouseTrack(float x)
    {
        Debug.Log("Sending client click");
        //if (isServer  &&   Input.GetMouseButton(0) || isClient )
         
            targetpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            _finaltarget = targetpos.x;
            // y = targetpos.y;
            // z = targetpos.z;
            //targetpos.y = transform.position.y;
            // targetpos.z = transform.position.z;
            //Debug.Log("client x value is " + x);

            if (move == false)
            {
                BM.ismoving = true;
            }
       
    }
}
