using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
public class rightballscript : NetworkBehaviour
{

    public bool rightdestroyball;
    [SerializeField]
    public Text win_text;
    private void Start()
    {
        rightdestroyball = false;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            print("ball hit the side");
            rightdestroyball = true;
            win_text.text = "Player 2 Wins";
        }
    }
}
