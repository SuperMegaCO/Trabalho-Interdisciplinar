using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    int waveID = 0;
    public GameObject[] Waves;
    public static int numbOfEnemies;
    public static int aliveEnemies;
    public GameObject[] Enemies;
    public string[] SpawnTags = { "CauldronSpawnPoint", "AnvilSpawnPoint"};
    public bool waveSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        aliveEnemies = 0;
        SpawnWave();
        InvokeRepeating("SpawnSwords", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (aliveEnemies <= 0 && waveSpawned == true)
        {
            if (waveID != Waves.GetLength(0) -1)
            {
                numbOfEnemies = 0;
                waveSpawned = false;
                Waves[waveID].SetActive(false);
                waveID++;
                Invoke("SpawnWave", 5f);
            }
            else
            {
                GameManager.gameWon = true;
            }
            
        }
    }
    void SpawnWave()
    {
        PlayerMovement.timeLastHit = Time.time;
        Waves[waveID].gameObject.SetActive(true);
        waveSpawned = true;
        int i = 0;
        foreach (var tag in SpawnTags) 
        {
            GameObject[] SpawnPoints = GameObject.FindGameObjectsWithTag(tag);
            
            foreach (var point in SpawnPoints)
            {
                Instantiate(Enemies[i], new Vector3(point.transform.position.x, GameObject.Find("ActionPlane").transform.position.y, point.transform.position.z), Quaternion.identity);
                if (tag != "SwordSpawnPoint" && point.name!= "Particle System") { 
                aliveEnemies++;
                numbOfEnemies++;
                }

            }
            i++;
        }
        
    }
    void SpawnSwords()
    {
        foreach (var point in GameObject.FindGameObjectsWithTag("SwordSpawnPoint"))
        {
            Instantiate(Enemies[2], new Vector3(point.transform.position.x, GameObject.Find("ActionPlane").transform.position.y, point.transform.position.z), Quaternion.identity);
        }
    }
}
