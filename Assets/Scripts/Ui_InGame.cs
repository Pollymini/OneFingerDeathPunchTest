using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_InGame : MonoBehaviour
{
    public Text waveNumber;
    public Text waveCountdownN;
    public Text enemyCount;

    public float highScore;

    public Enemy_Spawn enemySpawn;
    
    void Start()
    {
        highScore = 0;
    }

    
    void Update()
    {
        waveCountdownN.text = (enemySpawn.waveCountdown).ToString("0");


        waveNumber.text = (enemySpawn.currWave).ToString("0");

        enemyCount.text = (highScore).ToString("0");

    }
}
