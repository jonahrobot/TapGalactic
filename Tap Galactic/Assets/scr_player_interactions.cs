using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_player_interactions : MonoBehaviour
{
    public int hp = 1;
    private Rigidbody2D rb;
    public GameObject planet;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Hurt();
        }   
    }

    private void Hurt()
    { 
        hp -= 1;
        if(hp <= 0)
        {
            gameObject.SendMessage("spinOut");
        }
    }

}
