using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_counter : MonoBehaviour
{

    public GameObject counterObj;
    private TMPro.TextMeshProUGUI counter;
    int count = 1;
    // Start is called before the first frame update
    void Start()
    {
        counter = counterObj.GetComponent<TMPro.TextMeshProUGUI>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        count += 1;
        counter.text = count.ToString();
    }
}
