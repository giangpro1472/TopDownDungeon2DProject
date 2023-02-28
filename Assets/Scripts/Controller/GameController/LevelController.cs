using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] string musicName;
    void Start()
    {
        AudioController.instance.PlayMusic(musicName);
    }
}
