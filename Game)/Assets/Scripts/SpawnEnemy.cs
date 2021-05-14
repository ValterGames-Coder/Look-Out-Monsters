using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject[] Enemy;
    public GameObject[] spawn;
    public int spawner;
    public int enemy;
    void Start()
    {
        if(PlayerPrefs.GetInt("LEVEL") == 0)
            InvokeRepeating("SpawnEnem", 3, Random.Range(7, 10));
        else if (PlayerPrefs.GetInt("LEVEL") == 1)
            InvokeRepeating("SpawnEnem", 3, Random.Range(5, 8));
        else if (PlayerPrefs.GetInt("LEVEL") == 2)
            InvokeRepeating("SpawnEnem", 3, Random.Range(3, 6));
    }


    void SpawnEnem()
    {
        spawner = Random.Range(0, spawn.Length);
        enemy = Random.Range(0, Enemy.Length);
        if (Random.Range(0, 3) == 1)
        {
            Instantiate(Enemy[enemy], spawn[spawner].transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(Enemy[enemy], spawn[spawner].transform.position, Quaternion.identity);
        }
    }
}
