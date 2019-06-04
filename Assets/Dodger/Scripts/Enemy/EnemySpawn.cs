using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    
    public GameObject enemy;
    public GameObject candy;
    public float spawnRate;
    public float difficultyLimit;

    private GameManager gameManager;
    private float timer = 0;
    private float rate;

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        // If Game Stops, Destroy children to prevent post score
        if (!gameManager.IsRunning())
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }

        if (gameManager.IsRunning())
        {
            if (timer <= 0)
            {
                SpawnEnemy();
                timer = rate;
            } else {
                timer -= Time.deltaTime;
            }
        }
    }

    public void IncreaseDifficulty()
    {
        if (rate >= difficultyLimit)
            rate -= 0.1f;
    }

    public void ResetDifficulty()
    {
        rate = spawnRate;
    }

    private void SpawnEnemy()
    {
        float index = Random.Range(0, 10);
        var clone = (index <= 0.5) ? candy : enemy;
        Vector3 position = new Vector3(
            Random.Range(-3f, 3f),
            transform.position.y, 
            transform.position.z);
        Instantiate(clone, position, clone.transform.rotation, transform);
    }

}
