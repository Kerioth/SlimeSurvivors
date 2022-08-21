using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject slime;

    [SerializeField]
    GameObject bigSlime;

    [SerializeField]
    GameObject giantSlime;

    public float spawnTime = 1f;
    float spawnTimer;

    float gameTimer;
    float difficultyTime = 15f;

    [SerializeField]
    bool canSpawn = true;

    void Start()
    {
        spawnTimer = 0;
        gameTimer = 0;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer >= spawnTime)
        {
            if(canSpawn)Spawn(slime);
            spawnTimer = 0;
        }

        gameTimer += Time.deltaTime;
        if (gameTimer >= difficultyTime)
        {
            if(spawnTime > 0.1f)spawnTime -= 0.05f;
            else
            {
                if (canSpawn) Spawn(bigSlime);
                difficultyTime = Mathf.Clamp(difficultyTime- 0.5f, 0.5f, 15f);

                if(difficultyTime < 5f) Spawn(giantSlime);
            }
            gameTimer = 0f;
        }

        if (!GameStates.Instance.isPlay) canSpawn = false;
    }

    void Spawn(GameObject spawnSlime)
    {
        Vector3 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        Instantiate(spawnSlime, transform.position + dir * 5, Quaternion.identity);
    }

}
