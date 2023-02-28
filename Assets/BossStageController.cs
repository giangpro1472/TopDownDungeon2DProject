using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

[System.Serializable]
public class StageInfo
{
    public int enemyNum;
    public EnemyController[] enemies;
    public float spawnInterval;
}
public class BossStageController : MonoBehaviour
{
    [SerializeField] StageInfo[] stages;
    public Transform[] spawnPoint;

    private StageInfo stageInfos;
    private int currentWave;

    private bool canSpawn = true;
    private float nextSpawnTime;

    int enemyNum;
    bool isClearStage = false;

    private void Start()
    {
        enemyNum = stages[currentWave].enemyNum;
        stageInfos = stages[currentWave];
    }

    private void Awake()
    {
        Observer.Instance.AddObserver(TOPICNAME.ENEMYDIED, OnEnemyDie);
    }

    public void OnEnemyDie(object data)
    {
        enemyNum--;
        Debug.Log("Enemy Remains: " + enemyNum);
    }

    void Update()
    {
        Debug.Log("EnemyNum: " + enemyNum);
        if (enemyNum == 0)
        {
            if (!isClearStage)
            {
                currentWave++;
                Debug.Log("Next Wave: " + currentWave);
                if (currentWave >= stages.Length)
                {
                    Debug.Log("End Waves");
                    isClearStage = true;
                    GameManager.instance.Victory();
                    return;
                }
                else
                {
                    canSpawn = true;
                    enemyNum = stages[currentWave].enemyNum;
                }
            }
        }
        else
        {
            stageInfos = stages[currentWave];
            SpawnWave();
        }
    }

   

    void SpawnWave()
    {
        if (canSpawn && nextSpawnTime < Time.time)
        {
                Debug.Log("Current Wave: " + currentWave);
                EnemyController randomEnemy = stageInfos.enemies[Random.Range(0, stageInfos.enemies.Length)];
                Instantiate(randomEnemy, spawnPoint[Random.Range(0, spawnPoint.Length - 1)].position, Quaternion.identity);
                stageInfos.enemyNum--;
                nextSpawnTime = Time.time + stageInfos.spawnInterval;
                if (stageInfos.enemyNum == 0)
                {
                    canSpawn = false;
                }
        }
        
    }
}
