using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_gravity : MonoBehaviour
{

    private Rigidbody2D rb;
    public GameObject planet;
    private Vector2 velocity;
    private float speed = 10f;
    private float planetRange = 1.33f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = new Vector2(0f,-1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 pos = transform.position;
        Vector2 planetPos = planet.transform.position;

        Vector2 targetRot = pos - planetPos;

        rb.MoveRotation(Mathf.Atan2(targetRot.y,targetRot.x) * Mathf.Rad2Deg - 90f);

        if (Vector2.Distance(pos, planetPos) > planetRange)
        {
            planetRange = 1.33f;
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

            velocity = Vector2.ClampMagnitude( (planetPos - pos).normalized * speed, 4f);
        }
        else
        {
            planetRange = 2f;
        }
    }
}
