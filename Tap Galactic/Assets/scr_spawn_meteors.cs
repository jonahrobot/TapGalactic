using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_spawn_meteors : MonoBehaviour
{

    public GameObject planet;
    public Transform prefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnMeteor());
    }

    private IEnumerator spawnMeteor()
    {
        yield return new WaitForSeconds(1f);

        //create it
        int angleType = Random.Range(0, 2); // 0 1 
        float angle = Random.Range(45f, 135f);

        if (angleType == 0) { angle = Random.Range(225f, 315f); }

        angle *= Mathf.Deg2Rad;

        float distanceFromCenter = 5f;
        float x = distanceFromCenter * Mathf.Cos(angle) + planet.transform.position.x;
        float y = distanceFromCenter * Mathf.Sin(angle) + planet.transform.position.y;

        Instantiate( prefab, new Vector3(x,y,2) , new Quaternion(0f,0f,0f,1f));

        StartCoroutine(spawnMeteor());
    }
}
