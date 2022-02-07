using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_movement : MonoBehaviour
{

    private Rigidbody2D rb;
    private int moveDir = -1;
    public GameObject planet;
    private float speed = 4f;
    private bool State_stopMoving = false;
    private bool State_spinOut = false;
    private Vector3 targetRot;

    private int c = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && State_stopMoving == false)
        {
            if (moveDir == -1) { moveDir = 1; }
            else { moveDir = -1; }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        c += 1;
    }

    private void FixedUpdate()
    {
        if (State_stopMoving == false)
        {
            Vector2 pos = transform.position;
            Vector2 planetPos = planet.transform.position;

            Vector2 a = pos - planetPos;
            

            transform.rotation = Quaternion.Euler(0,0,(Mathf.Atan2(a.y, a.x) * Mathf.Rad2Deg - 90f));
            transform.position += moveDir * transform.right * speed * Time.fixedDeltaTime;
            transform.position -= transform.up * speed * 0.125f * Time.fixedDeltaTime;
            targetRot = transform.right;
        }

        if (State_spinOut)
        {
            transform.rotation *= Quaternion.Euler(0,0,5f);
            transform.position += moveDir * targetRot * speed * 4f* Time.fixedDeltaTime;
        }
    }
    
    private void spinOut()
    {
        State_stopMoving = true;
        State_spinOut = true;
    }
}
