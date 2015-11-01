using UnityEngine;
using System.Collections;

public class eSpawns : MonoBehaviour {

    public Rigidbody player;
    public GameObject[] enemies;
    public GameObject[] boosts;
    // Wait time
    int spawnTime = 3;
    //Hell spawn positions
    public Transform[] spawnPoints;
    public Transform[] powerPoints;

	// Use this for initialization
	void Start () {
        InvokeRepeating("MonsterSpawn", spawnTime, 10f);
        PowerSpawn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void MonsterSpawn()
    {
        Debug.Log("Monsters Spawning");
        // Makes array in spawn positions
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        // Makes an array for monsters spawning
        int monstersCreated = Random.Range(0, enemies.Length);
        // Instantiate the enemies and their position and rotation
        Instantiate(enemies[monstersCreated], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

    void PowerSpawn()
    {
        Debug.Log("Boost Active");
        for (int i = 0; i < 3; ++i)
        {
            int boostsCreated = Random.Range(0, boosts.Length);
            Instantiate(boosts[boostsCreated], powerPoints[i].position, powerPoints[i].rotation);
        }
    }
}
