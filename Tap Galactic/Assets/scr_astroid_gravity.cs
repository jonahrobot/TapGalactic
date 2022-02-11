using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_astroid_gravity : MonoBehaviour
{

    private Rigidbody2D rb;
    public GameObject planet;
    private Vector3 velocity;
    private float speed = 5f;
    private float speedMax = 8f;
    private float planetRange;
    private bool notSet = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = new Vector2(0f, -1f);
        planetRange = planet.GetComponent<CircleCollider2D>().radius * planet.transform.localScale.x; //radius of planet
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        Vector3 planetPos = planet.transform.position;

        Vector3 a = pos - planetPos;

        transform.rotation = Quaternion.Euler(0, 0, (Mathf.Atan2(a.y, a.x) * Mathf.Rad2Deg - 90f));

        if (Vector2.Distance(pos, planetPos) > planetRange)
        {
            transform.position += velocity * Time.fixedDeltaTime;
            velocity = Vector3.ClampMagnitude((planetPos - pos).normalized * speed, speedMax);
        }
        else
        {
            if(Vector2.Distance(pos, planetPos) != planetRange)
            {
                transform.position = a.normalized * planetRange;
            }
        }
    }
}
