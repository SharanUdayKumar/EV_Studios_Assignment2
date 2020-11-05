using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
public class leftballscript : NetworkBehaviour
{

    public bool leftdestroyball;
    public Text win_text;
    private void Start()
    {
       leftdestroyball = false;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            print("ball hit the side");
            leftdestroyball = true;
            win_text.text = "Player 1 Wins";
        }
    }
}
