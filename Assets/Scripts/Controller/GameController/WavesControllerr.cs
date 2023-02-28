using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;

[System.Serializable]
public class WaveInfo
{
    public int SkeletonNum;
    public int FireDemonsNum;
    public int IceZombiesNum;
    public int MudSlimeNum;
    public int NecromancerNum;
    public int OrgeNum;
    public int Boss;
}

public class WavesControllerr : MonoBehaviour
{
    WaveInfo[] waveInfos;
    int currentWave = 0;
    int totalSkeleton = 0;
    int totalIceZombie = 0;
    int totalFireDemon = 0;
    int totalMudSlime = 0;
    int totalNecromancer = 0;
    int totalOrge = 0;
    int totalBoss = 0;

    int totalEnemy = 0;


    [SerializeField] Transform enemySpawnPoint;

    public WaveInfo[] WaveInfos
    {
        set
        {
            currentWave = 0;
            waveInfos = value;
        }
    }

    private void Awake()
    {
        Observer.Instance.AddObserver(TOPICNAME.ENEMYDIED, OnEnemyDie);
    }

    public void StartWave()
    {
        WaveInfo waveInfo = waveInfos[currentWave];

        totalSkeleton = waveInfo.SkeletonNum;
        totalOrge = waveInfo.OrgeNum;
        totalNecromancer = waveInfo.NecromancerNum;
        totalFireDemon = waveInfo.FireDemonsNum;
        totalIceZombie = waveInfo.IceZombiesNum;
        totalMudSlime = waveInfo.MudSlimeNum;
        totalBoss = waveInfo.Boss;

        if (totalSkeleton > 0)
        {
            for (int i = 0; i < totalSkeleton; i++)
            {
                Vector3 pos = new Vector3(Random.Range(enemySpawnPoint.position.x - 1f, enemySpawnPoint.position.x + 1f), 
                    Random.Range(enemySpawnPoint.position.y + 1f, enemySpawnPoint.position.y - 0.7f));
                SkeletonController skeleton = Create.Instance.CreateSkeleton(pos);
            }
        }

        if (totalIceZombie > 0)
        {
            for (int i = 0; i < totalIceZombie; i++)
            {
                Vector3 pos = new Vector3(Random.Range(enemySpawnPoint.position.x - 1f, enemySpawnPoint.position.x + 1f),
                   Random.Range(enemySpawnPoint.position.y + 1f, enemySpawnPoint.position.y - 0.7f));
                IceZombieController iceZombie = Create.Instance.CreateIceZombie(pos);
            }
        }

        if (totalNecromancer > 0)
        {
            for (int i = 0; i < totalNecromancer; i++)
            {
                Vector3 pos = new Vector3(Random.Range(enemySpawnPoint.position.x - 1f, enemySpawnPoint.position.x + 1f),
                   Random.Range(enemySpawnPoint.position.y + 1f, enemySpawnPoint.position.y - 0.7f));
                NecromancerController necromancer = Create.Instance.CreateNecromancer(pos);
            }
        }

        if (totalFireDemon > 0)
        {
            for (int i = 0; i < totalFireDemon; i++)
            {
                Vector3 pos = new Vector3(Random.Range(enemySpawnPoint.position.x - 1f, enemySpawnPoint.position.x + 1f),
                   Random.Range(enemySpawnPoint.position.y + 1f, enemySpawnPoint.position.y - 0.7f));
                FireDemon fireDemon = Create.Instance.CreateFireDemon(pos);
            }
        }

        if (totalOrge > 0)
        {
            for (int i = 0; i < totalOrge; i++)
            {
                Vector3 pos = new Vector3(Random.Range(enemySpawnPoint.position.x - 1f, enemySpawnPoint.position.x + 1f),
                   Random.Range(enemySpawnPoint.position.y + 1f, enemySpawnPoint.position.y - 0.7f));
                OrgeController orge = Create.Instance.CreateOrge(pos);
            }
        }

        if (totalMudSlime > 0)
        {
            for (int i = 0; i < totalMudSlime; i++)
            {
                Vector3 pos = new Vector3(Random.Range(enemySpawnPoint.position.x - 1f, enemySpawnPoint.position.x + 1f),
                   Random.Range(enemySpawnPoint.position.y + 1f, enemySpawnPoint.position.y - 0.7f));
                MudSlime mudSlime = Create.Instance.CreateMudSlime(pos);
            }
        }
       
        if (totalBoss > 0)
        {
            for (int i = 0; i < totalBoss; i++)
            {
                Vector3 pos = new Vector3(Random.Range(enemySpawnPoint.position.x - 1f, enemySpawnPoint.position.x + 1f),
                   Random.Range(enemySpawnPoint.position.y + 1f, enemySpawnPoint.position.y - 0.7f));
                BossController boss = Create.Instance.CreateBoss(pos);
            }
        }

        totalEnemy = (SkeletonController.skeletons.Count + IceZombieController.iceZombieControllers.Count + FireDemon.fireDemons.Count
            + OrgeController.orges.Count + NecromancerController.necromancers.Count + MudSlime.mudSlimes.Count + BossController.boss.Count);

        Debug.Log("Total Skeleton: " + SkeletonController.skeletons.Count);
        Debug.Log("Total Ice: " + IceZombieController.iceZombieControllers.Count);
        Debug.Log("Total Fire: " + FireDemon.fireDemons.Count);
        Debug.Log("Total Orge: " + OrgeController.orges.Count);
        Debug.Log("Total Necromancer: " + NecromancerController.necromancers.Count);
        Debug.Log("Total MudSime: " + MudSlime.mudSlimes.Count);
        Debug.Log("Total Boss: " + BossController.boss.Count);

        Debug.Log("Total enemy: " + totalEnemy);
    }

    public void OnEnemyDie(object data)
    {
        totalEnemy--;
        Debug.Log("Total Enemy Remain:" +totalEnemy);
        if (totalEnemy == 0)
        {
            Debug.Log("Next Wave");
            currentWave++;
            if (currentWave >= waveInfos.Length)
            {
                Debug.Log("End Waves");
                Observer.Instance.Notify(TOPICNAME.ENDWAVE);
                return;
            }
            StartWave();
        }
    }

    private void OnDestroy()
    {
        Observer.Instance.RemoveObserver(TOPICNAME.ENEMYDIED, OnEnemyDie);
    }
}

public class Wave : SingletonMonoBehaviour<WavesControllerr>
{

}
