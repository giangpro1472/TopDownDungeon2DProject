using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayeData 
{
    public int level;
    public float health;
    public PlayeData (PlayerController player)
    {
        level = player.expController.level;
        health = player.hpController.GetCurrentHP();
    }
}
