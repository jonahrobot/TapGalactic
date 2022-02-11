using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_astroid_kill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(kill());
    }
    private IEnumerator kill()
    {
        yield return new WaitForSeconds(0.75f);
        Destroy(gameObject);
    }
}
