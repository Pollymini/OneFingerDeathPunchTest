using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Spawn : MonoBehaviour
{
    public List<Enemy> enemies = new List<Enemy>();
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    public List<GameObject> spawned = new List<GameObject>();
    public List<Transform> spawnLocations = new List<Transform>();

    private Transform spawnLocation;
    
    public int currWave;
    public int waveValue;
    public float waveCountdown;




    private int waveDur;
    private float waveTimer;
    private float spawnInt;
    private float spawnTimer;
    private bool newWave;

  

    void Start()
    {
        newWave = true;
        
    }
    
    void Update()
    {
       
        wavesCounter();

        if (newWave == true)
        {
          GenerateWave();
          
          newWave = false;
        }
        SpawnEnemies();
    }



    void wavesCounter()
    {
        if (waveCountdown <= 0)
        {
            waveCountdown = waveDur;
        }


        waveCountdown -= Time.deltaTime;

        if (waveCountdown <= 0 && enemiesToSpawn.Count <= 0 && spawned.Count == 0)
        {
            newWave = true;
            currWave += 1;

            Debug.Log("New Wave");
        }
    }
                
                
          

    public void GenerateWave()
    {
        waveValue = currWave * 10;
        waveDur = currWave * 10;

        GenerateEnemies();
        
        
        spawnInt = waveDur / enemiesToSpawn.Count;
        waveTimer = waveDur;
        
    }
    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        while (waveValue >= 0)
        {
            int randEnemyId = Random.Range(0, enemies.Count);
            int randEnemyCost = enemies[randEnemyId].cost;

            if (waveValue - randEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);
                waveValue -= randEnemyCost;
            }
            else if (waveValue <= 0)
            {
                Debug.Log("break");
                break;
            }
        }
        
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;

    }
    void SpawnEnemies()
    {
        if (spawnTimer <= 0)
        {
            if (enemiesToSpawn.Count > 0)
            {
                spawnLocation = spawnLocations[Random.Range(0, spawnLocations.Count)];

                GameObject nextEnemy = (GameObject)Instantiate(enemiesToSpawn[0], spawnLocation.position, Quaternion.identity);
                enemiesToSpawn.RemoveAt(0);
                spawned.Add(nextEnemy);

                spawnTimer = spawnInt;
            }
        }
        else
        {
            spawnTimer -= Time.deltaTime;
            waveTimer -= Time.deltaTime;

        }
    }

    
}
[System.Serializable]

public class Enemy 
{
    public GameObject enemyPrefab;
    public int cost;
}


        

       

   




       
        
        
        






            
       


        
        


   
    

    

