using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrabStuff;

public class MenuSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject slime;

    public float spawnTime = 1f;
    float spawnTimer;

    public float spawnRange = 10f;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnTime)
        {
            Spawn(slime);
            spawnTimer = 0;
        }
    }

    void Spawn(GameObject spawnSlime)
    {
        Vector3 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        Instantiate(spawnSlime, transform.position + dir * spawnRange, Quaternion.identity);
    }

    public void StartGame() => Loader.Load(1);
}
