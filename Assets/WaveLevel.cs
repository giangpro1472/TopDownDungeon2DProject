using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LTAUnityBase.Base.DesignPattern;
using System;

public class WaveLevel : MonoBehaviour
{
    int totalEnemy = 0;
    [SerializeField] DoorController door;
    //private void Awake()
    //{
    //    Observer.Instance.AddObserver(TOPICNAME.ENEMYDIED, OnEnemyDie);
    //}

    private void Start()
    {
        totalEnemy = (SkeletonController.skeletons.Count + IceZombieController.iceZombieControllers.Count + FireDemon.fireDemons.Count
           + OrgeController.orges.Count + NecromancerController.necromancers.Count + MudSlime.mudSlimes.Count);

        Debug.Log("Total Skeleton: " + SkeletonController.skeletons.Count);
        Debug.Log("Total Ice: " + IceZombieController.iceZombieControllers.Count);
        Debug.Log("Total Fire: " + FireDemon.fireDemons.Count);
        Debug.Log("Total Orge: " + OrgeController.orges.Count);
        Debug.Log("Total Necromancer: " + NecromancerController.necromancers.Count);
        Debug.Log("Total MudSime: " + MudSlime.mudSlimes.Count);

        Debug.Log("Total enemy: " + totalEnemy);
    }

    //private void OnEnemyDie(object data)
    //{
    //    totalEnemy--;
    //    if (totalEnemy == 0)
    //    {
    //        door.anim.Play("Open");
    //    }
    //}
}
