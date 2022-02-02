using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_movement : MonoBehaviour
{

    private Rigidbody2D rb;
    private bool moveDir = false;
    public GameObject planet;
    private float speed = 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            moveDir = !moveDir;
        }
    }


    private void FixedUpdate()
    {

        float firstRot = (rb.rotation % 360f +100f) * Mathf.PI / 180f;
        Vector2 pos = transform.position;
        Vector2 planetPos = planet.transform.position;

        Vector2 a = pos - planetPos;

        Vector2 targetRot = Vector2.Perpendicular((new Vector2(Mathf.Cos(firstRot),  Mathf.Sin(firstRot))).normalized / 5f);

        rb.MovePosition(rb.position + targetRot * speed * Time.fixedDeltaTime);
    }
}