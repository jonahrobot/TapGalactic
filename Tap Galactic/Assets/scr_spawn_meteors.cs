using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_spawn_meteors : MonoBehaviour
{

    public GameObject planet;
    public Transform meteor;
    public Transform saw;
    private int spawnCount;

    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    private void spawn()
    {
        if (spawnCount % 10 == 0)
        {
            StartCoroutine(spawnSaw(saw));
        }
        else
        {
            StartCoroutine(spawnMeteor(meteor));
        }
    }

    private IEnumerator spawnMeteor(Transform prefab)
    {
        yield return new WaitForSeconds(1f);
        spawnCount += 1;
        //create it
        int angleType = Random.Range(0, 2); // 0 1 
        float angle = Random.Range(45f, 135f);

        if (angleType == 0) { angle = Random.Range(225f, 315f); }

        spawnObjAtAngle(angle, prefab);
    }

    private IEnumerator spawnSaw(Transform prefab)
    {
        yield return new WaitForSeconds(1f);
        spawnCount += 1;

        float[] angleRange = new float[] { 45f, 135f, 225f, 315f };
        float angle = angleRange[(int) Random.Range(0, 4)];

        spawnObjAtAngle(angle, prefab);
    }

    private void spawnObjAtAngle(float angle, Transform prefab)
    {
        angle *= Mathf.Deg2Rad;

        float distanceFromCenter = 5f;
        float x = distanceFromCenter * Mathf.Cos(angle) + planet.transform.position.x;
        float y = distanceFromCenter * Mathf.Sin(angle) + planet.transform.position.y;

        Instantiate(prefab, new Vector3(x, y, 2), new Quaternion(0f, 0f, 0f, 1f));

        spawn();
    }
}
