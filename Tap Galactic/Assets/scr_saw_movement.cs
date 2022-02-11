using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_saw_movement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    private int moveDir = -1;
    public GameObject planet;
    private float speed = 2f;
    private Vector3 targetRot;

    private bool hit = false;
    private bool runRev = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "planet" && runRev == false)
        {
            runRev = true;
            StartCoroutine(bladeRev());
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hit == true)
        {
            Vector2 pos = transform.position;
            Vector2 planetPos = planet.transform.position;

            Vector2 a = pos - planetPos;

            transform.rotation = Quaternion.Euler(0, 0, (Mathf.Atan2(a.y, a.x) * Mathf.Rad2Deg - 90f));
            
            transform.position += moveDir * transform.right * speed * Time.fixedDeltaTime;
            transform.position -= transform.up * speed * 0.125f * Time.fixedDeltaTime;
            targetRot = transform.right;
        }
        transform.GetChild(0).rotation *= Quaternion.Euler(0, 0, 20);
    }
    private IEnumerator bladeRev()
    {
        yield return new WaitForSeconds(0.75f);
        hit = true;
        StartCoroutine(kill());
    }

    private IEnumerator kill()
    {
        yield return new WaitForSeconds(0.75f);
        if (hit)
        {
            hit = false;
            StartCoroutine(kill());
        }
        else
        {
            Destroy(gameObject);
        }
    }
}