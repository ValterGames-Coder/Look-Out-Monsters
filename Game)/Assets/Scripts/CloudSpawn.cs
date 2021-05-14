using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour
{
    public GameObject clouds;
    void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(clouds, new Vector2(transform.position.x, Random.Range(10f, 13f)), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3f, 6.5f));
        }
    }
}
