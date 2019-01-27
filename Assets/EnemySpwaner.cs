using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwaner : MonoBehaviour
{
    public float minTime = 1f;
    public float maxTime = 5f;


    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawn());
    }


    IEnumerator spawn()
    {
        while (true)
        {
            Instantiate(prefab, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        }
    }
}